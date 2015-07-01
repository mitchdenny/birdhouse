param(
	[string]$buildnumber
)

Write-Output "The build number is: $version"
$version = $buildnumber.Split("_")[1];
Write-Output "The version is: $version"

$assemblyinfo = Get-Content src\Nest\Nest\Properties\AssemblyInfo.cs
$assemblyinfo.Replace("0.9.0.0", "$version") | Set-Content src\Nest\Nest\Properties\AssemblyInfo.cs

$nuspec = Get-Content src\Nest\Nest\Nest.nuspec
$nuspec.Replace("0.9.0.0", "$version") | Set-Content src\Nest\Nest\Nest.nuspec
