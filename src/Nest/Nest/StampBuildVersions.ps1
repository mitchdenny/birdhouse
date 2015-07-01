param(
	[string]$revision
)

Get-Content src\Nest\Nest\Properties\AssemblyInfo.cs | % { $_.Replace("0.9.0.0", "$revision"); } | Set-Content src\Nest\Nest\Properties\AssemblyInfo.cs
Get-Content src\Nest\Nest\Nest.nuspec | % { $_.Replace("0.9.0.0", "$revision"); } | Set-Content src\Nest\Nest\Nest.nuspec
