$projectPath="C:\Users\Rasifiel\source\repos\Gifer"
$solutionPath="$projectPath\Gifer.sln"
$ffmpegPath="$projectPath\ffmpeg"
$releaseDir="$projectPath\Gifer\bin\Release"
msbuild $solutionPath -p:Configuration=Release -t:Rebuild
if ($LastExitCode -ne 0) {
 throw "Failed to build release"
}
if (!(Test-Path $ffmpegPath)) {
	New-Item -ItemType Directory -Path $ffmpegPath
}
if (!(Test-Path $ffmpegPath\ffmpeg.exe)) {
	Invoke-WebRequest -Uri "https://www.gyan.dev/ffmpeg/builds/ffmpeg-release-essentials.zip" -OutFile $ffmpegPath\ffmpeg.zip
	Expand-Archive -LiteralPath "$ffmpegPath\ffmpeg.zip" -DestinationPath $ffmpegPath
	Copy-Item -Path "$ffmpeg\ffmpeg*\bin\ffmpeg.exe" -Destination $ffmpeg\
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
  Exclude = "ffmpeg.exe"
  Destination = "$path\gifer"
}
Copy-Item @copy
Copy-Item -Path $ffmpegPath\ffmpeg.exe -Destination "$path\gifer"
$releasePath = "$path\gifer-$version.zip"
$compress = @{
  Path = "$path\gifer\*.*"
  CompressionLevel = "Fastest"
  DestinationPath = "$releasePath"
}
cat .\docs\changelog.md | pandoc  -t html -o changelog.html
$index_md = Get-Content .\docs\index.md -Raw
$index_md.Replace("@ver@","$version").Replace("@filename@","gifer-$version.zip") | pandoc -s -t html -o index.html --metadata title="Gifer"
$index_ru_md = Get-Content .\docs\index_ru.md -Raw
$index_ru_md.Replace("@ver@","$version").Replace("@filename@","gifer-$version.zip") | pandoc -s -t html -o index_ru.html --metadata title="Gifer"
Compress-Archive @compress
scp $releasePath giferdeploy@katou.moe:/var/www/gifer
if ($LastExitCode -ne 0) {
 throw "Failed to copy release build"
}
scp $manifestPath giferdeploy@katou.moe:/var/www/gifer
scp *.html giferdeploy@katou.moe:/var/www/gifer