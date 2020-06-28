# NuGet package - Selenium WebDriver IEDriver

[![NuGet Package](https://img.shields.io/nuget/v/Selenium.WebDriver.IEDriver.svg)](https://www.nuget.org/packages/Selenium.WebDriver.IEDriver/)

## What's this? / これは何?

This NuGet package install IE Driver(x86) for Selenium WebDriver into your Unit Test Project.

この NuGet パッケージは、Selenium WebDriver用 IE Driver(x86) を単体テストプロジェクトに追加します。

"IEDriverServer.exe" does not appear in Solution Explorer, but it is copied to bin folder from package folder when the build process.

"IEDriverServer.exe" はソリューションエクスプローラ上には現れませんが、ビルド時にパッケージフォルダから bin フォルダへコピーされます。

NuGet package restoring ready, and no need to commit "IEDriverServer.exe" binary into source code control repository.

NuGet パッケージの復元に対応済み、"IEDriver.exe" をソース管理リポジトリに登録する必要はありません。

## How to install? / インストール方法

For example, at the package manager console on Visual Studio, enter following command.  
一例として、Visual Studio 上のパッケージ管理コンソールにて、下記のコマンドを入力してください。

    PM> Install-Package Selenium.WebDriver.IEDriver -Version 3.150.1.1

## Detail / 詳細

### Where is IEDriverServer.exe saved to? / どこに保存?

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

 And package installer configure msbuild task such as .csproj to
 copy IEDriverServer.exe into output folder during build process.

 
### How to include the driver file into published files? / ドライバーを発行ファイルに含めるには?

"IEDriverServer.exe" isn't included in published files on default configuration. This behavior is by design.

"IEDriverServer.exe" は、既定の構成では、発行ファイルに含まれません。この挙動は仕様です。

If you want to include "IEDriverServer.exe" into published files, please define `_PUBLISH_IEDRIVER` compilation symbol.

"IEDriverServer.exe" を発行ファイルに含めるには、コンパイル定数 `_PUBLISH_IEDRIVER` を定義してください。

![define _PUBLISH_IEDRIVER compilation symbol](.asset/define_PUBLISH_IEDRIVER_compilation_symbol.png)

Another way, you can define `PublishIEDriver` property with value is "true" in MSBuild file (.csproj, .vbproj, etc...) to publish the driver file instead of define compilation symbol.

別の方法として、コンパイル定数を定義する代わりに、MSBuild ファイル (.csproj, .vbproj, etc...) 中で `PublishIEDriver` プロパティを値 true で定義することでドライバーを発行ファイルに含めることができます。 

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

#### Note / 補足 

`PublishIEDriver` MSBuild property always override the condition of define `_PUBLISH_IEDRIVER` compilation symbol or not. If you define `PublishIEDriver` MSBuild property with false, then the driver file isn't included in publish files whenever define `_PUBLISH_IEDRIVER` compilation symbol or not.

`PublishIEDriver` MSBuild プロパティは常に `_PUBLISH_IEDRIVER` コンパイル定数を定義しているか否かの条件を上書きします。もし `PublishIEDriver` MSBuild プロパティを false で定義したならば、`_PUBLISH_IEDRIVER` コンパイル定数を定義しているか否かによらず、ドライバは発行ファイルに含められません。
