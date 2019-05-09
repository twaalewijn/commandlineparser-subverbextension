#tool "nuget:?package=Microsoft.TestPlatform&version=16.0.1"

#addin "nuget:?package=Cake.Git&version=0.19.0"
#addin "nuget:?package=Cake.Coverlet&version=2.2.1"

using System.Text.RegularExpressions;

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

string target = Argument("target", "Default");
string configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

public static string AssemblyVersion = "0.0.0.0";

public static string AssemblyInfoVersion = "0.0.0.0";

public static string PublishPathRoot = "./publish";

public static string SolutionFile = "./CommandLine.Extension.Subverbs.sln";

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("PrepareAssemblyInfo")
    .Does(() =>
    {
        // Always render long format (e.g. 1.0.0-0-abcdefg) even if currently on a tagged commit.
        Information("Determining version based on tag.");
        string gitTagVersion = GitDescribe(".", true, GitDescribeStrategy.Tags);
        string[] versionParts = gitTagVersion.Split('-');
        FilePath buildPropsFile = MakeAbsolute(File("./Directory.Build.props"));

        if (versionParts.Length != 3)
        {
            throw new CakeException("Version string '" + gitTagVersion + "' is not in a valid format to determine the assembly version. Expected something like '1.0.0-0-abcdefg'.");
        }

        AssemblyVersion = versionParts[0] + "." + versionParts[1];

        bool injectPackageVersionProp = versionParts[1] != "0";

        StringBuilder infoVersion = new StringBuilder();
        infoVersion.Append(AssemblyVersion + "-" + versionParts[2]);

        string tempSuffix = "";

        if (TFBuild.IsRunningOnVSTS)
        {
            if (EnvironmentVariable("BUILD_SOURCEBRANCH").StartsWith("refs/tags"))
            {
                tempSuffix = "tag";
            }
            else
            {
                tempSuffix = EnvironmentVariable("BUILD_SOURCEBRANCHNAME");
            }
        }
        else
        {
            try
            {
                GitBranch versionBranch = GitBranchCurrent(".");

                if (versionBranch.FriendlyName != "(no branch)")
                {
                    tempSuffix = versionBranch.FriendlyName;
                }
                else if (versionParts[1] == "0")
                {
                    tempSuffix = "tag";
                }
                else
                {
                    tempSuffix = "headless";
                }
            }
            catch
            {
            }
        }

        infoVersion.Append($"-{tempSuffix}");

        AssemblyInfoVersion = infoVersion.ToString();

        Information("Modifying Directory.Build.props.");

        string[] oldPropsFile = System.IO.File.ReadAllLines(buildPropsFile.FullPath, Encoding.UTF8);

        StringBuilder newPropsFile = new StringBuilder();

        Regex versionRegex = new Regex(">.*<");

        foreach(string oldLine in oldPropsFile)
        {
            if (oldLine.Contains("<Version>"))
            {
                Information($"Setting <Version> to {AssemblyVersion}.");
                newPropsFile.AppendLine(versionRegex.Replace(oldLine, $">{AssemblyVersion}<"));
            }
            else if (oldLine.Contains("<InformationalVersion>"))
            {
                Information($"Setting <InformationalVersion> to {AssemblyInfoVersion}.");
                newPropsFile.AppendLine(versionRegex.Replace(oldLine, $">{AssemblyInfoVersion}<"));
            }
            else if (injectPackageVersionProp && oldLine.Contains("<PackageVersion>"))
            {
                string packageVersion = versionParts[0] + "." + versionParts[1] + "-beta";
                Information($"Setting <PackageVersion> to {packageVersion} for pre-release package.");
                newPropsFile.AppendLine(versionRegex.Replace(oldLine, $">{packageVersion}<"));
            }
            else
            {
                newPropsFile.AppendLine(oldLine);
            }
        }

        System.IO.File.WriteAllText(buildPropsFile.FullPath, newPropsFile.ToString(), Encoding.UTF8);
    });

Task("Purge")
    .Does(() =>
    {
        StartProcess("git", "clean -xdf -e \"tools\"");
    });

Task("Build")
    .Does(() =>
    {
        DotNetCoreBuild(SolutionFile, new DotNetCoreBuildSettings
        {
            Configuration = configuration
        });
    });

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
    {
        DotNetCoreTestSettings testSettings = new DotNetCoreTestSettings
        {
            Configuration = configuration,
            NoBuild = true,
            Logger = "trx",
            ResultsDirectory = "./TestResults"
        };

        CoverletSettings coverletSettings = new CoverletSettings
        {
            CollectCoverage = true,
            CoverletOutputFormat = CoverletOutputFormat.cobertura
        };

        DotNetCoreTest(SolutionFile, testSettings, coverletSettings);
    });

Task("Publish-NuGet")
    .IsDependentOn("Test")
    .Does(() =>
    {
        string outputRoot = PublishPathRoot;

        EnsureDirectoryExists(outputRoot);
        CleanDirectory(outputRoot);
        EnsureDirectoryExists(outputRoot);

        var libPackagefiles = GetFiles($"./src/**/bin/{configuration}/**/*.nupkg");

        CopyFiles(libPackagefiles, outputRoot);

        var symbolPackagefiles = GetFiles($"./src/**/bin/{configuration}/**/*.snupkg");
        
        CopyFiles(symbolPackagefiles, outputRoot);
    });

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Test");

Task("Publish")
    .IsDependentOn("Purge")
    .IsDependentOn("PrepareAssemblyInfo")
    .IsDependentOn("Publish-NuGet");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
