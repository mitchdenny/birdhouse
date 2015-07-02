param(
	[string]$apikey
)

src\Birdhouse\packages\NuGet.CommandLine.2.8.5\tools\NuGet.exe push src\Birdhouse\Birdhouse\bin\Release\*.nupkg $apikey