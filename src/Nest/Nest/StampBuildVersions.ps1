param(
	[string]$revision
)

Get-Content Properties\AssemblyInfo.cs | % { $_.Replace("0.9.0.0", "$revision"); } | Set-Content Properties\AssemblyInfo.cs
Get-Content Nest.nuspec | % { $_.Replace("0.9.0.0", "$revision"); } | Set-Content Nest.nuspec
