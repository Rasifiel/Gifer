$projectPath="C:\Users\Rasifiel\source\repos\Gifer"
$version=%{cat $projectPath\Gifer\MainForm.cs | Select-String -Pattern 'AutoUpdater.InstalledVersion = new Version\(\"(.+)\"\)' | % {"$($_.matches.groups[1])"}}
gh release create "v$version" -F docs\changelog.md "release\gifer-$version.zip"
