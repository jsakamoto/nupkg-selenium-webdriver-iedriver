# NuGet package - Selenium WebDriver IEDriver

[![NuGet Package](https://img.shields.io/nuget/v/Selenium.WebDriver.IEDriver.svg)](https://www.nuget.org/packages/Selenium.WebDriver.IEDriver/)

## What's this?

This NuGet package installs IE Driver(x86) for Selenium WebDriver into your Unit Test Project.

"IEDriverServer.exe" does not appear in Solution Explorer, but it is copied to the bin folder from the package folder during the build process.

This package is ready for NuGet package restoring, and no need to commit the "IEDriverServer.exe" binary into the source code control repository.

> **Warning**  
> Since Selenium WebDriver version 4.6 was released in November 2022 or later, it has contained ["Selenium Manager"](https://www.selenium.dev/blog/2022/introducing-selenium-manager/), which will automatically download the most suitable version and platform WebDriver executable file. So now, **you can run applications that use Selenium and manipulates web browsers without this package.** However, due to compatibility and some offline scenarios, we intend to keep this package for the time being.

## How to install? 

For example, enter the following command at the package manager console on Visual Studio.

```powershell
PM> Install-Package Selenium.WebDriver.IEDriver
```

## Required Configuration

Before automation Internet Explorer (or IE mode in Microsoft Edge), you must set up some configurations as below:

- You must set the "Protected Mode" settings for each zone to be the same value. 
- You also need to set "Change the size of text, apps, and other items" to 100% in display settings.

Please see also: 🌎[_"Required Configuration - IE Driver Server | Selenium"_](https://www.selenium.dev/documentation/ie_driver_server/#required-configuration)

### Notice

The "Enable Protected Mode" check box no longer exists in the "Internet Properties" dialog of the control panel on Windows 11 or later because Internet Explorer as a standalone application is no longer supported on Windows 11.

To configure the "Protected Mode" settings for each zone on Windows 11, I recommend using "Local Group Policy Editor" with the following steps instead of using the "Internet Properties" dialog.

1. Open the "Edit group policy" menu item from the Start menu.
2. Then, the "Local Group Policy Editor" window will be opened.
3. Expand the left tree from the root node "Local Computer Policy" to "Computer Configuration" > "Administrative Templates" > "Windows Components" > "Internet Explorer" > "Internet Control Panel" > "Security Page".
4. You will see some sub-nodes that node name ends with "...Zone", and you should be able to see the "Turn on Protected Mode" setting item In each sub-node.
5. Double click the "Turn on Protected Mode" setting item and select "Enable" or "Disable," which you want, and click the "OK" button to apply and close it.
6. Do that for all of the "...Zone" sub-nodes.

![Local Group Policy Editor](https://raw.githubusercontent.com/jsakamoto/nupkg-selenium-webdriver-iedriver/master/.asset/fig.001.png)

## How to automate IE mode in Microsoft Edge?

To automate IE mode in Microsoft Edge (not Internet Explorer as a standalone application), you should have to configure the options for IE Driver like below:

```csharp
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

var ieOptions = new InternetExplorerOptions
{
    // These 3 lines are needed to use Microsoft Edge IE mode.
    AttachToEdgeChrome = true,
    EdgeExecutablePath = "C:/Program Files (x86)/Microsoft/Edge/Application/msedge.exe",
    IgnoreZoomLevel = true,
};

using var driver = new InternetExplorerDriver(ieOptions);
...
```

Please see also: 🌎[_"Use Internet Explorer Driver to automate IE mode in Microsoft Edge | Microsoft Docs"_](https://docs.microsoft.com/microsoft-edge/webdriver-chromium/ie-mode)

## How to include the driver file into published files?

"IEDriverServer.exe" isn't included in published files on the default configuration. This behavior is by design.

If you want to include "IEDriverServer.exe" into published files, please define the `_PUBLISH_IEDRIVER` compilation symbol.

![define _PUBLISH_IEDRIVER compilation symbol](https://raw.githubusercontent.com/jsakamoto/nupkg-selenium-webdriver-iedriver/master/.asset/define_PUBLISH_IEDRIVER_compilation_symbol.png)

Another way, you can define `PublishIEDriver` property with value is "true" in the MSBuild file (.csproj, .vbproj, etc...) to publish the driver file instead of defining compilation symbol.

```xml
  <Project ...>
    ...
    <PropertyGroup>
      ...
      <PublishIEDriver>true</PublishIEDriver>
      ...
    </PropertyGroup>
...
</Project>
```

You can also define the `PublishIEDriver` property from the command line `-p` option for the `dotnet publish` command.

```shell
> dotnet publish -p:PublishChromeDriver=true
```

### Note

`PublishIEDriver` MSBuild property always overrides the condition of defining the`_PUBLISH_IEDRIVER` compilation symbol or not. If you define `PublishIEDriver` MSBuild property with false, then the driver file isn't included in publish files whenever define `_PUBLISH_IEDRIVER` compilation symbol or not.

## Appendix

### Where is IEDriverServer.exe saved to?

IEDriverServer.exe exists at  
" _{solution folder}_ /packages/Selenium.WebDriver.IEDriver. _{ver}_ /**driver**"  
folder.

     {Solution folder}/
      +-- packages/
      |   +-- Selenium.WebDriver.IEDriver.{version}/
      |       +-- driver/
      |       |   +-- IEDriverServer.exe
      |       +-- build/
      +-- {project folder}/
          +-- bin/
              +-- Debug/
              |   +-- IEDriverServer.exe (copy from above by build process)
              +-- Release/
                  +-- IEDriverServer.exe (copy from above by build process)

 And package installer configures msbuild tasks such as .csproj to copy IEDriverServer.exe into the output folder during the build process.

## License

The build script (.targets file) in this NuGet package is licensed under [The Unlicense](https://github.com/jsakamoto/nupkg-selenium-webdriver-iedriver/blob/master/LICENSE).

The binary file of the IE Driver is licensed under the [Apache License, Version 2.0](https://github.com/SeleniumHQ/selenium/blob/trunk/LICENSE).