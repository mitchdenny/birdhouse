param(
	[string]$buildnumber,
	[string]$buildmetadata
)

Write-Output "BuildNumber was: $buildnumber"
Write-Output "BuildMetadata was: $buildmetadata"

$semanticversion = $buildnumber.Split("_")[1];

Write-Output "Semantic Version was: $semanticversion"

$assemblyversion = $semanticversion.Replace("-build",".")

Write-Output "Assembly Version was: $assemblyversion"

$assemblyinfo = Get-Content src\Birdhouse\Birdhouse\Properties\AssemblyInfo.cs
$assemblyinfo.Replace("0.9.0.0", "$assemblyversion") | Set-Content src\Birdhouse\Birdhouse\Properties\AssemblyInfo.cs

if ($buildmetadata -eq "") {
	Write-Output "No BuildMetadata Detected!"
	$nuspecversion = $semanticversion.Split("-")[0];
}
else {
	Write-Output "BuildMetadata Detected!"
    $nuspecversion = $semanticversion.Replace("build", $buildmetadata)
}

Write-Output "Nuspec Version was: $nuspecversion"

$nuspec = Get-Content src\Birdhouse\Birdhouse\Birdhouse.nuspec
$nuspec.Replace("0.9.0-developer", "$nuspecversion") | Set-Content src\Birdhouse\Birdhouse\Birdhouse.nuspec