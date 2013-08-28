# NuGet package - Selenium WebDriver IEDriver

## What's this? / これは何?

This NuGet package download and install IE Driver(x86) for Selenium WebDriver into your Unit Test Project on the fly. 

この NuGet パッケージは、Selenium WebDriver用 IE Driver(x86) をその場でダウンロードし単体テストプロジェクトに追加します。

"IEDriverServer.exe" added as a linked project item, and copied to bin folder at the build.

"IEDriverServer.exe" はリンクされたアイテムとしてプロジェクトに追加され、ビルド時に bin フォルダにコピーされます。

NuGet package restoring ready, and no need to commit "IEDriverServer.exe" binary into source code control repository.

NuGet パッケージの復元に対応済み、"IEDriver.exe" をソース管理リポジトリに登録する必要はありません。

## How to install? / インストール方法

For example, at the package manager console on Visual Studio, enter following command.  
一例として、Visual Studio 上のパッケージ管理コンソールにて、下記のコマンドを入力してください。

    PM> Install-Package Selenium.WebDriver.IEDriver