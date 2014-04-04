# NuGet package - Selenium WebDriver IEDriver

## What's this? / これは何?

This NuGet package download and install IE Driver(x86) for Selenium WebDriver into your Unit Test Project on the fly.  
(This package dose not contain IEDriverServer.exe, but add the avility of automatically downloading IEDriverServer.exe form official site to your project.)

この NuGet パッケージは、Selenium WebDriver用 IE Driver(x86) をその場でダウンロードし単体テストプロジェクトに追加します。  
(この NuGet パッケージには IEDriverSerevr.exe は含まれません、公式サイトから IEDriverServer.exe を自動でダウンロードする能力をプロジェクトに追加します)

"IEDriverServer.exe" added as a linked project item, and copied to bin folder at the build.

"IEDriverServer.exe" はリンクされたアイテムとしてプロジェクトに追加され、ビルド時に bin フォルダにコピーされます。

NuGet package restoring ready, and no need to commit "IEDriverServer.exe" binary into source code control repository.

NuGet パッケージの復元に対応済み、"IEDriver.exe" をソース管理リポジトリに登録する必要はありません。

## How to install? / インストール方法

For example, at the package manager console on Visual Studio, enter following command.  
一例として、Visual Studio 上のパッケージ管理コンソールにて、下記のコマンドを入力してください。

    PM> Install-Package Selenium.WebDriver.IEDriver
 
 ## Detail / 詳細

### How to configure HTTP proxy? / プロクシの設定

This package downloading "IEDriverServer.exe" on the fly with using
HTTP proxy settings from following order.

1. At first, try to get from HTTP_PROXY system environment variable specified the format like a ```http://username:password@myproxy:8080```.
2. Second, try to get from NuGet.config file in ```%APPDATA%\NuGet``` folder. You can setup proxy settings for NuGet by follow command line:  
```> nuget.exe config -set http_proxy=http://myproxy:8080 http_proxy.user=user http_proxy.password=passwrd```
3. At last, try to get from system default proxy settings that Control Panle - Internet Options.

このパッケージは、下記の順序で HTTP プロクシ設定を使用して "IEDriverServer.exe" をその場でダウンロードします。

1. はじめに、HTTP_PROXY システム環境変数に設定された、```http://username:password@myproxy:8080``` 形式の指定の取得を試みます。
2. 次に、```%APPDATA%\NuGet``` フォルダにある NuGet.config ファイルからの取得を試みます。NuGet のプロクシ設定は、次のコマンドラインで設定できます:  
```> nuget.exe config -set http_proxy=http://myproxy:8080 http_proxy.user=user http_proxy.password=passwrd```
3. 最後に、コントロールパネル - インターネット設定の、システム既定のプロクシ設定の取得を試みます。

### Where is IEDriverServer.exe saved to? / どこに保存?

IEDriverServer.exe is downloaded from official web site, and saved to  
" _{solution folder}_ /packages/Selenium.WebDriver.IEDriver. _{ver}_ /content"  
folder at installing this package or building a project.

     {Solution folder}/
      +-- packages/
      |   +-- Selenium.WebDriver.IEDriver.{version}/
      |       +-- content/
      |       |   +-- IEDriverServer.exe (download by package installer or build process)
      |       +-- tools/
      +-- {project folder}/
          +-- bin/
              +-- Debug/
              |   +-- IEDriverServer.exe (copy from above by build process)
              +-- Release/
                  +-- IEDriverServer.exe (copy from above by build process)
 
 And package installer configure msbuild task such as .csproj to
 copy IEDriverServer.exe into output folder during build process.
 