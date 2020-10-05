# Development and contribution

## Prerequisites

1. clone repository
1. install .NET Core >= 2.x
1. [optional] install [Nerdbank.GitVersioning .NET Core CLI tool](https://github.com/dotnet/Nerdbank.GitVersioning).  
    - only necessary if you want to create *release candidate* or *release* branches
    - for more information on versioning read [Versioning and deployment](#versioning-and-deployment)
1. download the National Instruments TDM C DLL library [here](https://www.ni.com/content/dam/web/product-documentation/c_dll_tdm.zip) and place the zip in `src>libs>NILIBDDC-64bit.zip` 
    - zip the contents of `TDM C DLL\dev\bin\64-bit` 
    - replace the target file

    ![Install NILIBDDC](img/InstallNIDDCLIB.gif)

## Building the project
Is as easy as:
- run `build solution` in visual studio 
- or run `BUILD.cmd`



## Versioning and deployment
This project utilizes the [Nerdbank.GitVersioning](https://github.com/dotnet/Nerdbank.GitVersioning) package for stamping assemblies and version assignment and follows the [semantic versioning guideline](https://semver.org/#spec-item-9). 

```
1.0.0-prerelease < 1.0.1-prerelease < 1.0.1-rc < 1.0.1
```

The intended development git lineage should look like this:

![](img/GitLineage.png)

The master and feature branches are used for feature development and track versions with the `prerelease` suffix. These branches are considered by the CI pipeline which regularly builds publicly available packages and pushes them to the [public feed](). 