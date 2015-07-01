param(
	[string]$apikey
)

src\Nest\packages\NuGet.CommandLine.2.8.5\tools\NuGet.exe push src\Nest\Nest\bin\Release\*.nupkg $apikey