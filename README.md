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

    PM> Install-Package Selenium.WebDriver.IEDriver

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
