param(
	[string]$buildnumber,
	[bool]$ispreview
)

$semanticversion = $buildnumber.Split("_")[1];

$assemblyversion = $semanticversion.Replace("-build",".")
$assemblyinfo = Get-Content src\Birdhouse\Birdhouse\Properties\AssemblyInfo.cs
$assemblyinfo.Replace("0.9.0.0", "$assemblyversion") | Set-Content src\Birdhouse\Birdhouse\Properties\AssemblyInfo.cs

if ($ispreview) {
	$nuspecversion = $semanticversion.Split("-")[0];
}
else {
	$nuspecversion = $semanticversion
}

$nuspec = Get-Content src\Birdhouse\Birdhouse\Birdhouse.nuspec
$nuspec.Replace("0.9.0-developer", "$nuspecversion") | Set-Content src\Birdhouse\Birdhouse\Birdhouse.nuspec