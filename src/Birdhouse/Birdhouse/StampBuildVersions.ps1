param(
	[string]$buildnumber
)

$version = $buildnumber.Split("_")[1];

$assemblyinfo = Get-Content src\Birdhouse\Birdhouse\Properties\AssemblyInfo.cs
$assemblyinfo.Replace("0.9.0.0", "$version") | Set-Content src\Birdhouse\Birdhouse\Properties\AssemblyInfo.cs

$nuspec = Get-Content src\Birdhouse\Birdhouse\Birdhouse.nuspec
$nuspec.Replace("0.9.0.0", "$version") | Set-Content src\Birdhouse\Birdhouse\Birdhouse.nuspec