Import-Module -Name ($PSScriptRoot | Join-Path -ChildPath 'bin\Debug\net7.0\TestDataGeneration.psd1') -ErrorAction Stop;
Add-Type -AssemblyName 'System.Windows.Forms' -ErrorAction Stop;
$Text = [System.Windows.Forms.Clipboard]::GetText();
$Text = $Text | Remove-NonPrintableChars;
[System.Windows.Forms.Clipboard]::SetText($Text);





