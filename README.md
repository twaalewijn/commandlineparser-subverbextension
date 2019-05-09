# Subverbs extension for [CommandLineParser](https://github.com/commandlineparser/commandline)
[![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/CommandLineParser.Extension.Subverbs.svg?label=CommandLineParser.Extensions.Subverbs)](https://www.nuget.org/packages/CommandLineParser.Extension.Subverbs)
[![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/CommandLineParser.Extension.Subverbs.FSharp.svg?label=CommandLineParser.Extensions.Subverbs.FSharp)](https://www.nuget.org/packages/CommandLineParser.Extension.Subverbs.FSharp)<br/>
[![Sonar Quality Gate](https://img.shields.io/sonar/https/sonarcloud.io/twaalewijn_commandlineparser-subverbextension/quality_gate.svg)](https://sonarcloud.io/dashboard?id=twaalewijn_commandlineparser-subverbextension)
[![Sonar Documented API Density](https://img.shields.io/sonar/https/sonarcloud.io/twaalewijn_commandlineparser-subverbextension/public_documented_api_density.svg)](https://sonarcloud.io/dashboard?id=twaalewijn_commandlineparser-subverbextension)
[![Azure DevOps coverage (branch)](https://img.shields.io/azure-devops/coverage/waalewijn/commandlineparser-subverbextension/1/develop.svg)](https://waalewijn.visualstudio.com/commandlineparser-subverbextension/_build/latest?definitionId=1&branchName=develop)

This project contains a library with extension methods to help with parsing subverbs using the .NET [CommandLineParser](https://github.com/commandlineparser/commandline) library.

Subverb structures are currently not officially supported in CommandLineParser and the feature is being tracked in [this issue here](https://github.com/commandlineparser/commandline/issues/353).

Until an official solution has been implemented you can use this library to nest and group verbs as deeply as you desire without breaking, for example, the auto help.

## Build Status

Branch | Status
---|---
master | [![Build status](https://waalewijn.visualstudio.com/commandlineparser-subverbextension/_apis/build/status/commandlineparser-subverbextension-CI?branchName=master)](https://waalewijn.visualstudio.com/commandlineparser-subverbextension/_build/latest?definitionId=1&branchName=master)
develop | [![Build status](https://waalewijn.visualstudio.com/commandlineparser-subverbextension/_apis/build/status/commandlineparser-subverbextension-CI?branchName=develop)](https://waalewijn.visualstudio.com/commandlineparser-subverbextension/_build/latest?definitionId=1&branchName=develop)

## How To Use

See the links below for an example in one of the supported languages.

* [C#](usage/CSharp.md)
* [F#](usage/FSharp.md)
* [VB.NET](usage/VBNET.md)

## Build Instructions

### Prerequisites

* [Visual Studio](https://visualstudio.microsoft.com/downloads/) 2017 or higher
* [.NET Core SDK](https://dotnet.microsoft.com/download) 2.0 or higher
* [.NET Framework](https://dotnet.microsoft.com/download) 4.6.1 or higher

> The .NET Core SDK and .NET Framework Dev Pack can also be installed via the Visual Studio installer.

### Visual Studio

Open the solution and build like normal.<br/>
NuGet packages will be located in the bin folders.

### Cake

Run one of the targets below by calling ```build.ps1``` from a ```powershell``` prompt:

```
>.\build.ps1 -Target <Target here>
```

Target | Does
--- | ---
Build | Builds the solution.
Test | Builds and tests the solution.
Publish | Versions the assemblies based on the current tag by modifying Directory.Build.props, builds/tests the solution and copies the artifacts to ```./publish```.<br/><br/> **WARNING:** Cleans the repository via ```git clean -xdf```. Make sure unadded files are committed first.

## Contributing

Contributions are welcome, thanks for wanting to help out!

To make your contribution as smooth as possible for both of us please follow the guidelines below.

* File an issue stating what currently isn't working for you (perferably with a pseudo code example of the verbs, parser settings and commandline calls that were used).
* If you decide to fix it yourself:
    * Thanks :)
    * Create a branch based on develop instead of master.
    * Add some tests to test your fix or feature (at least one that tests the code example from your issue).
    * Submit a pull request while targeting the develop branch.
    * I'll try to review it as soon as I have time (usually during the weekend).

> Note that, because this project is only an extension, issues might also be caused by [CommandLineParser](https://github.com/commandlineparser/commandline/issues) itself.
> Please confirm that your issue is not already a known issue there before filing an issue on this project.
