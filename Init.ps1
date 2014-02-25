param($installPath, $toolsPath, $package, $project)

$driverFile = "IEDriverServer.exe"
$downloadUrl = "https://selenium-release.storage.googleapis.com/2.40/IEDriverServer_Win32_2.40.0.zip"

$contentPath = Join-Path $installPath "content"
$driverPath = Join-Path $contentPath $driverFile

if ((Test-Path $driverPath) -eq $false) {

    # Download selenium driver zip file.
    $tmpFilePath = [IO.Path]::GetTempFileName() + ".zip"
    (new-object Net.WebClient).DownloadFile($downloadUrl, $tmpFilePath)

    $shell = new-object -com Shell.Application
    $zipFile = $shell.NameSpace($tmpFilePath)

    $zipFile.Items() | `
    where {(Split-Path $_.Path -Leaf) -eq $driverFile} | `
    foreach {
        $contentFolder = $shell.NameSpace($contentPath)
        $contentFolder.copyhere($_.Path)
    }

    rm $tmpFilePath
}
