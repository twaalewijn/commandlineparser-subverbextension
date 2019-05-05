#tool "nuget:?package=Microsoft.TestPlatform&version=16.0.1"

#addin "nuget:?package=Cake.Git&version=0.19.0"

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

public static bool RunFSharpBuild = false;

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
        StringBuilder infoVersion = new StringBuilder();
        infoVersion.Append(AssemblyVersion + "-" + versionParts[2]);

        try
        {
            GitBranch versionBranch = GitBranchCurrent(".");

            if (versionBranch.FriendlyName != "(no branch)")
            {
                infoVersion.Append($"-{versionBranch.FriendlyName}");
            }
            else if (versionParts[1] == "0")
            {
                infoVersion.Append($"-tag");
            }
            else
            {
                infoVersion.Append($"-headless");
            }
        }
        catch
        {
        }

        Information("Resetting Directory.Build.props.");
        GitCheckout(".", buildPropsFile);
        
        AssemblyInfoVersion = infoVersion.ToString();

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
            else
            {
                newPropsFile.AppendLine(oldLine);
            }
        }

        System.IO.File.WriteAllText(buildPropsFile.FullPath, newPropsFile.ToString(), Encoding.UTF8);
    });

Task("PrepareFsharpBuild")
    .Does(() =>
    {
        RunFSharpBuild = true;
    });

Task("Purge")
    .Does(() =>
    {
        StartProcess("git", "clean -xdf -e \"tools\"");
    });

Task("Build")
    .Does(() =>
    {
        DotNetCoreBuildSettings settings = new DotNetCoreBuildSettings
        {
            Configuration = configuration
        };

        if (RunFSharpBuild)
        {
            settings.MSBuildSettings = new DotNetCoreMSBuildSettings()
                .WithProperty("BuildTarget", "fsharp");
        }

        DotNetCoreBuild(SolutionFile, settings);
    });

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
    {
        DotNetCoreTest(SolutionFile, new DotNetCoreTestSettings
        {
            Configuration = configuration,
            NoBuild = true,
            Logger = "trx",
            ResultsDirectory = "./TestResults"
        });
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

Task("FSharp-Build")
    .IsDependentOn("PrepareFSharpBuild")
    .IsDependentOn("Build");

Task("FSharp-Test")
    .IsDependentOn("PrepareFSharpBuild")
    .IsDependentOn("Test");

Task("FSharp-Publish")
    .IsDependentOn("PrepareFSharpBuild")
    .IsDependentOn("Publish");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
