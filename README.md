# Subverbs extension for [CommandLineParser](https://github.com/commandlineparser/commandline)

This project contains a library with extension methods to help with parsing subverbs using the .NET [CommandLineParser](https://github.com/commandlineparser/commandline) library.

## Build Status

Branch | Status
---|---
master | [![Build status](https://waalewijn.visualstudio.com/commandlineparser-subverbextension/_apis/build/status/commandlineparser-subverbextension-CI?branchName=master)](https://waalewijn.visualstudio.com/commandlineparser-subverbextension/_build/latest?definitionId=1)

## How To Use

See the usage guide for the language you are using.

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
>build.ps1 -Target <Target here>
```

Target | Does
--- | ---
Build | Builds the solution.
Test | Builds and tests the solution.
Publish | Versions the assemblies based on the current tag by modifying Directory.Build.props, builds/tests the solution and copies the artifacts to ```./publish```.<br/><br/> **WARNING:** Cleans the repository via ```git clean -xdf```. Make sure unadded files are committed first.