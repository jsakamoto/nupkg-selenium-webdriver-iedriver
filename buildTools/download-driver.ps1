# constants
$version = "4.8.0"
$driverName = "IEDriverServer.exe"
$zipName = "IEDriverServer_Win32_$version.zip"
$downloadurl = "https://github.com/SeleniumHQ/selenium/releases/download/selenium-$version/$zipName"

# move current folder to where contains this .ps1 script file.
$scriptDir = Split-Path $MyInvocation.MyCommand.Path
Push-Location $scriptDir
Set-Location ..
$currentPath = Convert-Path "."
$downloadDir = Join-Path $currentPath "downloads"

$zipPath = Join-Path $downloadDir $zipName
$driverPath = Join-Path $downloadDir $driverName

# download driver .zip file if not exists.
if (-not (Test-Path $zipPath)) {
    Invoke-WebRequest -Uri $downloadurl -OutFile $zipPath
}

# Decompress .zip file to extract driver file.
if (Test-Path $driverPath) { Remove-Item  $driverPath }
Expand-Archive $zipPath $downloadDir