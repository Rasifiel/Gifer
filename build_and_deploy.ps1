$projectPath="C:\Users\Rasifiel\source\repos\Gifer"
$solutionPath="$projectPath\Gifer.sln"
$releaseDir="$projectPath\Gifer\bin\Release"
msbuild $solutionPath -p:Configuration=Release -t:Rebuild
if ($LastExitCode -ne 0) {
 throw "Failed to build release"
}
$version=%{cat $projectPath\Gifer\MainForm.cs | Select-String -Pattern 'AutoUpdater.InstalledVersion = new Version\(\"(.+)\"\)' | % {"$($_.matches.groups[1])"}}
$xml=@"
<?xml version="1.0" encoding="UTF-8"?>
<item>
    <version>$version</version>
    <url>https://katou.moe/gifer/gifer-$version.zip</url>
    <changelog>https://katou.moe/gifer/changelog.html</changelog>
    <mandatory>false</mandatory>
</item>
"@
$tempDir = [System.IO.Path]::GetTempPath()
$random = [System.IO.Path]::GetRandomFileName()
$path = (Join-Path $tempDir $random)
New-Item -ItemType Directory -Path $path
New-Item -ItemType Directory -Path "$path\gifer"
$manifestPath = "$path\manifest.xml"
echo $xml > $manifestPath
$copy = @{
  Path = "$releaseDir\*"
  Include = "*.dll", "*.exe", "*.xml", "Gifer.*"
  Destination = "$path\gifer"
}
Copy-Item @copy
$releasePath = "$path\gifer-$version.zip"
$compress = @{
  Path = "$path\gifer\*.*"
  CompressionLevel = "Fastest"
  DestinationPath = "$releasePath"
}
Compress-Archive @compress
scp $releasePath giferdeploy@katou.moe:/var/www/gifer
if ($LastExitCode -ne 0) {
 throw "Failed to copy release build"
}
scp $manifestPath giferdeploy@katou.moe:/var/www/gifer