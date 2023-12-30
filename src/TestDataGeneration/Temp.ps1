Function ConvertFrom-BinaryNotation {
    Param(
        [Parameter(Mandatory = $true, ValueFromPipeline = $true)]
        [ValidatePattern("^(0b)?[01]{4}(_?[01]{4}){11}$")]
        [string]$Pattern
    )

    Process {
        $p = $Pattern.Replace('_', '');
        if ($p.StartsWith('0b')) { $p = $p.Substring(2) }
        $Bytes = New-Object -TypeName 'System.Byte[]' -ArgumentList 8;
        for ($i = 0; $i -lt 6; $i++) {
            $Value = 0;
            if ($p.Substring($i * 8, 1) -eq '1') { $Value = 1 }
            for ($n = 1; $n -lt 8; $n++) {
                $Value = $Value -shl 1;
                if ($p.Substring(($i * 8) + $n, 1) -eq '1') { $Value = $Value -bor 1 }
            }
            $Bytes[5 - $i] = ([byte]$Value);
        }
        (($Bytes | % { $_.ToString('x2') }) -join ':') | Write-Host -ForegroundColor Cyan;
        [System.BitConverter]::ToUInt64($Bytes, 0) | Write-Output;
    }
}

Function ConvertTo-BinaryNotation {
    Param(
        [Parameter(Mandatory = $true, ValueFromPipeline = $true)]
        [ValidateRange(0, 281474976710655)]
        [ulong]$Value,

        [switch]$NoPrefix,

        [switch]$NoUnderscore
    )

    Begin {
        $BitMaps = @(128, 64, 32, 16, 8, 4, 2, 1);
        $Indexes = @(5, 4, 3, 2, 1, 0);
    }
    Process {
        $Result = $null;
        $Bytes = [System.BitConverter]::GetBytes($Value);
        if ($NoUnderscore.IsPresent) {
            $Result = -join ($Indexes | ForEach-Object {
                $b = $Bytes[$_];
                $BitMaps | ForEach-Object { if (($_ -band $b) -eq $_) { '1' | Write-Output } else { '0' | Write-Output } };
            });
        } else {
            $Result = ($Indexes | ForEach-Object {
                $b = $Bytes[$_];
                (-join (
                    (($BitMaps | Select-Object -First 4) | ForEach-Object {
                        if (($_ -band $b) -eq $_) { '1' | Write-Output } else { '0' | Write-Output }
                    }) + '_' + (($BitMaps | Select-Object -Skip 4) | ForEach-Object {
                        if (($_ -band $b) -eq $_) { '1' | Write-Output } else { '0' | Write-Output }
                    })
                )) | Write-Output;
            }) -join '_';
        }
        if ($NoPrefix.IsPresent) {
            $Result | Write-Output;
        } else {
            "0b$Result" | Write-Output;
        }
    }
}
<#
$FlagValues = @{
    AsciiControlChars =     "0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0001" | ConvertFrom-BinaryNotation;
    Space =                 "0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0010" | ConvertFrom-BinaryNotation;
    Separators =            "0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0100" | ConvertFrom-BinaryNotation;
    AsciiPunctuation =      "0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_1000" | ConvertFrom-BinaryNotation;
    AsciiDigits =           "0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0001_0000" | ConvertFrom-BinaryNotation;
    AsciiSymbols =          "0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0010_0000" | ConvertFrom-BinaryNotation;
    Plus =                  "0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0100_0000" | ConvertFrom-BinaryNotation;
    Dash =                  "0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_1000_0000" | ConvertFrom-BinaryNotation;
    Period =                "0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0001_0000_0000" | ConvertFrom-BinaryNotation;
    HexDigitVowelsUpper =   "0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0010_0000_0000" | ConvertFrom-BinaryNotation; # AE
    UpperB =                "0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0100_0000_0000" | ConvertFrom-BinaryNotation; # B
    UpperC =                "0b0000_0000_0000_0000_0000_0000_0000_0000_0000_1000_0000_0000" | ConvertFrom-BinaryNotation; # C
    UpperD =                "0b0000_0000_0000_0000_0000_0000_0000_0000_0001_0000_0000_0000" | ConvertFrom-BinaryNotation; # D
    UpperF =                "0b0000_0000_0000_0000_0000_0000_0000_0000_0010_0000_0000_0000" | ConvertFrom-BinaryNotation; # F
    UpperG =                "0b0000_0000_0000_0000_0000_0000_0000_0000_0100_0000_0000_0000" | ConvertFrom-BinaryNotation; # G
    VowelsUpper =           "0b0000_0000_0000_0000_0000_0000_0000_0000_1000_0000_0000_0000" | ConvertFrom-BinaryNotation; # IOU
    HardConsonantsUpper =   "0b0000_0000_0000_0000_0000_0000_0000_0001_0000_0000_0000_0000" | ConvertFrom-BinaryNotation; # JKPQTX
    SoftConsonantsUpper =   "0b0000_0000_0000_0000_0000_0000_0000_0010_0000_0000_0000_0000" | ConvertFrom-BinaryNotation; # HLMNRSVWZ
    UpperY =                "0b0000_0000_0000_0000_0000_0000_0000_0100_0000_0000_0000_0000" | ConvertFrom-BinaryNotation; # Y
    Underscore =            "0b0000_0000_0000_0000_0000_0000_0000_1000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation; # _
    HexDigitVowelsLower =   "0b0000_0000_0000_0000_0000_0000_0001_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation; # AE
    LowerB =                "0b0000_0000_0000_0000_0000_0000_0010_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation; # B
    LowerC =                "0b0000_0000_0000_0000_0000_0000_0100_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation; # C
    LowerD =                "0b0000_0000_0000_0000_0000_0000_1000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation; # D
    LowerF =                "0b0000_0000_0000_0000_0000_0001_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation; # F
    LowerG =                "0b0000_0000_0000_0000_0000_0010_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation; # G
    VowelsLower =           "0b0000_0000_0000_0000_0000_0100_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation; # IOU
    HardConsonantsLower =   "0b0000_0000_0000_0000_0000_1000_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation; # JKPQTX
    SoftConsonantsLower =   "0b0000_0000_0000_0000_0001_0000_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation; # HLMNRSVWZ
    LowerY =                "0b0000_0000_0000_0000_0010_0000_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation; # Y
    Tilde =                 "0b0000_0000_0000_0000_0100_0000_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation; # ~
    ControlChars =          "0b0000_0000_0000_0000_1000_0000_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
    PunctuationChars =      "0b0000_0000_0000_0001_0000_0000_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
    Symbols =               "0b0000_0000_0000_0010_0000_0000_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
    WhiteSpaceChars =       "0b0000_0000_0000_0100_0000_0000_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
    Numbers =                "0b0000_0000_0000_1000_0000_0000_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
    Digits =               "0b0000_0000_0001_0000_0000_0000_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
    UpperChars =            "0b0000_0000_0010_0000_0000_0000_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
    LowerChars =            "0b0000_0000_0100_0000_0000_0000_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
    Letters =               "0b0000_0000_1000_0000_0000_0000_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
    HighSurrogates =        "0b0000_0001_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
    LowSurrogates =         "0b0000_0010_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
}
$EnumFields = @(
    [PSCustomObject]@{
        Name = "AsciiControlChars";
        Flags = ([string[]]@("AsciiControlChars"));
        Includes = ([string[]]@());
    },
    [PSCustomObject]@{
        Name = "Space";
        Flags = ([string[]]@("Space"));
        Includes = ([string[]]@());
    },
    [PSCustomObject]@{
        Name = "Separators";
        Flags = ([string[]]@("Separators", "Space"));
        Includes = ([string[]]@());
    },
    [PSCustomObject]@{
        Name = "AsciiPunctuation";
        Flags = ([string[]]@("AsciiPunctuation", "Underscore", "Dash", "Period"));
        Includes = ([string[]]@());
    },
    [PSCustomObject]@{
        Name = "AsciiDigits";
        Flags = ([string[]]@("AsciiDigits"));
        Includes = ([string[]]@());
    },
    [PSCustomObject]@{
        Name = "AsciiSymbols";
        Flags = ([string[]]@("AsciiSymbols", "Tilde", "Plus"));
        Includes = ([string[]]@());
    },
    [PSCustomObject]@{
        Name = "Plus";
        Flags = ([string[]]@("Plus"));
        Includes = ([string[]]@());
    },
    [PSCustomObject]@{
        Name = "Dash";
        Flags = ([string[]]@("Dash"));
        Includes = ([string[]]@());
    },
    [PSCustomObject]@{
        Name = "Period";
        Flags = ([string[]]@("Period"));
        Includes = ([string[]]@());
    },
    [PSCustomObject]@{
        Name = "PunctuationChars";
        Flags = ([string[]]@("PunctuationChars", "AsciiPunctuation", "Underscore", "Dash", "Period"));
        Includes = ([string[]]@("AsciiPunctuation"));
    },
    [PSCustomObject]@{
        Name = "Symbols";
        Flags = ([string[]]@("Symbols", "AsciiSymbols", "Tilde", "Plus"));
        Includes = ([string[]]@("AsciiSymbols"));
    },
    [PSCustomObject]@{
        Name = "WhiteSpaceChars";
        Flags = ([string[]]@("WhiteSpaceChars"));
        Includes = ([string[]]@("Separators"));
    },
    [PSCustomObject]@{
        Name = "Numbers";
        Flags = ([string[]]@("Numbers"));
        Includes = ([string[]]@("AsciiDigits"));
    },
    [PSCustomObject]@{
        Name = "Digits";
        Flags = ([string[]]@("Digits"));
        Includes = ([string[]]@("Numbers"));
    },
    [PSCustomObject]@{
        Name = "HardConsonantsUpper";
        Flags = ([string[]]@("HardConsonantsUpper", "UpperB", "UpperC", "UpperD", "UpperG"));
        Includes = ([string[]]@());
    },
    [PSCustomObject]@{
        Name = "SoftConsonantsUpper";
        Flags = ([string[]]@("SoftConsonantsUpper", "UpperC", "UpperF", "UpperG", "UpperY"));
        Includes = ([string[]]@());
    },
    [PSCustomObject]@{
        Name = "Underscore";
        Flags = ([string[]]@("Underscore"));
        Includes = ([string[]]@());
    },
    [PSCustomObject]@{
        Name = "VowelsUpper";
        Flags = ([string[]]@("VowelsUpper", "HexDigitVowelsUpper", "UpperY"));
        Includes = ([string[]]@());
    },
    [PSCustomObject]@{
        Name = "HardConsonantsLower";
        Flags = ([string[]]@("HardConsonantsLower", "LowerB", "LowerC", "LowerD", "LowerG"));
        Includes = ([string[]]@());
    },
    [PSCustomObject]@{
        Name = "SoftConsonantsLower";
        Flags = ([string[]]@("SoftConsonantsLower", "LowerC", "LowerF", "LowerG", "LowerY"));
        Includes = ([string[]]@());
    },
    [PSCustomObject]@{
        Name = "VowelsLower";
        Flags = ([string[]]@("VowelsLower", "HexDigitVowelsLower", "LowerY"));
        Includes = ([string[]]@());
    },
    [PSCustomObject]@{
        Name = "HardConsonants";
        Flags = ([string[]]@());
        Includes = ([string[]]@("HardConsonantsUpper", "HardConsonantsLower"));
    },
    [PSCustomObject]@{
        Name = "ConsonantsUpper";
        Flags = ([string[]]@());
        Includes = ([string[]]@("HardConsonantsUpper", "SoftConsonantsUpper"));
    },
    [PSCustomObject]@{
        Name = "ConsonantsLower";
        Flags = ([string[]]@());
        Includes = ([string[]]@("HardConsonantsLower", "SoftConsonantsLower"));
    },
    [PSCustomObject]@{
        Name = "SoftConsonants";
        Flags = ([string[]]@());
        Includes = ([string[]]@("SoftConsonantsUpper", "SoftConsonantsLower"));
    },
    [PSCustomObject]@{
        Name = "Consonants";
        Flags = ([string[]]@());
        Includes = ([string[]]@("ConsonantsUpper", "ConsonantsLower"));
    },
    [PSCustomObject]@{
        Name = "Vowels";
        Flags = ([string[]]@());
        Includes = ([string[]]@("VowelsUpper", "VowelsLower"));
    },
    [PSCustomObject]@{
        Name = "AsciiLettersUpper";
        Flags = ([string[]]@());
        Includes = ([string[]]@("ConsonantsUpper", "VowelsUpper"));
    },
    [PSCustomObject]@{
        Name = "UpperChars";
        Flags = ([string[]]@("UpperChars"));
        Includes = ([string[]]@("AsciiLettersUpper"));
    },
    [PSCustomObject]@{
        Name = "AsciiLettersLower";
        Flags = ([string[]]@());
        Includes = ([string[]]@("ConsonantsLower", "VowelsLower"));
    },
    [PSCustomObject]@{
        Name = "LowerChars";
        Flags = ([string[]]@("LowerChars"));
        Includes = ([string[]]@("AsciiLettersLower"));
    },
    [PSCustomObject]@{
        Name = "AsciiLetters";
        Flags = ([string[]]@());
        Includes = ([string[]]@("Consonants", "Vowels"));
    },
    [PSCustomObject]@{
        Name = "Letters";
        Flags = ([string[]]@("Letters"));
        Includes = ([string[]]@("AsciiLetters", "UpperChars", "LowerChars"));
    },
    [PSCustomObject]@{
        Name = "Tilde";
        Flags = ([string[]]@("Tilde"));
        Includes = ([string[]]@());
    },
    [PSCustomObject]@{
        Name = "HighSurrogates";
        Flags = ([string[]]@("HighSurrogates"));
        Includes = ([string[]]@());
    },
    [PSCustomObject]@{
        Name = "LowSurrogates";
        Flags = ([string[]]@("LowSurrogates"));
        Includes = ([string[]]@());
    },
    [PSCustomObject]@{
        Name = "Surrogates";
        Flags = ([string[]]@());
        Includes = ([string[]]@("HighSurrogates", "LowSurrogates"));
    },
    [PSCustomObject]@{
        Name = "AsciiHexDigitsUpper";
        Flags = ([string[]]@("HexDigitVowelsUpper", "UpperB", "UpperC", "UpperD", "UpperF", "HexDigitVowelsUpper"));
        Includes = ([string[]]@("AsciiDigits"));
    },
    [PSCustomObject]@{
        Name = "AsciiHexDigitsLower";
        Flags = ([string[]]@("HexDigitVowelsLower", "LowerB", "LowerC", "LowerD", "LowerF", "HexDigitVowelsLower"));
        Includes = ([string[]]@("AsciiDigits"));
    },
    [PSCustomObject]@{
        Name = "AsciiHexDigits";
        Flags = ([string[]]@());
        Includes = ([string[]]@("AsciiHexDigitsUpper", "AsciiHexDigitsLower"));
    },
    [PSCustomObject]@{
        Name = "AsciiLettersAndDigits";
        Flags = ([string[]]@());
        Includes = ([string[]]@("AsciiLetters", "AsciiDigits"));
    },
    [PSCustomObject]@{
        Name = "CsIdentifierChars";
        Flags = ([string[]]@());
        Includes = ([string[]]@("AsciiLettersAndDigits", "Underscore"));
    },
    [PSCustomObject]@{
        Name = "UriDataChars";
        Flags = ([string[]]@());
        Includes = ([string[]]@("CsIdentifierChars", "Dash", "Period", "Underscore", "Tilde"));
    },
    [PSCustomObject]@{
        Name = "LettersAndDigits";
        Flags = ([string[]]@());
        Includes = ([string[]]@("Letters", "Digits"));
    },
    [PSCustomObject]@{
        Name = "AsciiChars";
        Flags = ([string[]]@());
        Includes = ([string[]]@("AsciiControlChars", "Space", "AsciiPunctuation", "AsciiSymbols", "AsciiLettersAndDigits"));
    }
);
$EnumFields | ForEach-Object {
    [ulong]$Value = 0;
    if ($_.Flags.Length -gt 0) {
        if ($FlagValues.ContainsKey($_.Flags[0])) {
            $Value = $FlagValues[$_.Flags[0]];
        } else {
            Write-Warning -Message "Flag $($_.Flags[0]) not found.";
        }
        ($_.Flags | Select-Object -Skip 1) | ForEach-Object {
            if ($FlagValues.ContainsKey($_)) {
                $Value = $Value -bor $FlagValues[$_];
            } else {
                Write-Warning -Message "Flag $_ not found.";
            }
        }
    }
    $_ | Add-Member -MemberType NoteProperty -Name 'Value' -Value $Value;
}
$Changed = @();
do {
    $Changed = @($EnumFields | Where-Object {
        [ulong]$Value = $_.Value;
        if ($_.Includes.Length -eq 0) { return $false }
        $_.Includes | ForEach-Object {
            $n = $_;
            $Item = $EnumFields | Where-Object { $_.Name -eq $n } | Select-Object -First 1;
            if ($null -eq $Item) {
                Write-Warning -Message "$n not found.";
            } else {
                $Value = $Value -bor $Item.Value;
            }
        }
        if ($Value -eq $_.Value) { return $false }
        $_ | Add-Member -MemberType NoteProperty -Name 'Value' -Value $Value -Force;
        return $true;
    });
} while ($Changed.Count -gt 0);
$EnumFields = ($EnumFields | Sort-Object -Property 'Value');
$MaxNameLength = 0;
$EnumFields | ForEach-Object {
    $n = $_.Name;
    if ($n.Length -gt $MaxNameLength) { $MaxNameLength = $n.Length }
    $v = $_.Value;
    $_ | Add-Member -Name 'Flags' -MemberType NoteProperty -Value ([string[]]($FlagValues.Keys | Where-Object { ($FlagValues[$_] -band $v) -ne 0 })) -Force;
    $_ | Add-Member -Name 'Includes' -MemberType NoteProperty -Value ([string[]]($EnumFields | Where-Object { $_.Name -ne $n -and ($_.Value -bor $v) -eq $v } | ForEach-Object { $_.Name })) -Force;
    $_ | Add-Member -Name 'IncludedBy' -MemberType NoteProperty -Value ([string[]]($EnumFields | Where-Object { $_.Name -ne $n -and ($_.Value -band $v) -eq $v } | ForEach-Object { $_.Name }));
}
$SortedFlags = @($FlagValues.Keys | Sort-Object -Property @{ Expression = { $FlagValues[$_] } });
$Writer = [System.IO.StreamWriter]::new(($PSScriptRoot | Join-Path -ChildPath 'temp.txt'), $false, [System.Text.UTF8Encoding]::new($false, $false));
try {
    $Writer.WriteLine("public static class CharacterTypes");
    $Writer.Write("{");
    $SortedFlags | ForEach-Object {
        $Writer.WriteLine();
        $Spacing = [string]::new(([char]' '), ($MaxNameLength - $_.Length) + 1);
        $bn = $FlagValues[$_] | ConvertTo-BinaryNotation;
        $Writer.WriteLine("    public const ulong Flag_$($_) =$Spacing $($bn)UL;");
    }
    $Writer.WriteLine("}");
    $Writer.WriteLine();
    $Writer.WriteLine("public enum CharacterType : ulong");
    $Writer.Write("{");
    $EnumFields | ForEach-Object {
        $Writer.WriteLine();
        if ($_.Includes.Length -gt 0) { $Writer.WriteLine("    // Includes: CharacterType.$($_.Includes -join ', CharacterType.')") }
        if ($_.IncludedBy.Length -gt 0) { $Writer.WriteLine("    // IncludedBy: CharacterType.$($_.IncludedBy -join ', CharacterType.')") }
        $Value = $_.Value;
        $Writer.WriteLine("    $($_.Name) = Flag_$(($SortedFlags | Where-Object { ($Value -band $FlagValues[$_]) -ne 0 }) -join ' | Flag_'),");
    }

} finally { $Writer.Close() }
#>
# "0b1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111" | ConvertFrom-BinaryNotation;
# "0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
# "0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0001" | ConvertFrom-BinaryNotation;
# "0b0000_0000_0000_0000_0000_0101_1000_0001_1001_1111_1000_1111" | ConvertFrom-BinaryNotation;
# 0 | ConvertTo-BinaryNotation
# 1 | ConvertTo-BinaryNotation
# 92381071 | ConvertTo-BinaryNotation;
# 281474976710655 | ConvertTo-BinaryNotation;
<#
$Values = @();
for ($i = 0; $i -lt 65536; $i++) {
    [char]$c = $i;
    # if ([char]::IsAscii($c) -and [char]::IsControl($c) -and -not [char]::IsWhiteSpace($c)) { $Values += $i.ToString('x4'); }
    # if ([char]::IsNumber($c) -and -not ([char]::IsAscii($c) -or [char]::IsDigit($c))) { $Values += $i.ToString('x4'); }
    if ([char]::IsControl($c) -and [char]::IsAscii($c)) { $Values += $i.ToString('x4'); }
    # if ([char]::IsPunctuation($c) -and -not [char]::IsAscii($c)) { $Values += $c; }
    # if ([char]::IsHighSurrogate($c)) { $Values += $c; }
    # if ([char]::IsHighSurrogate($c)) { $Values += $i.ToString('x4'); }
}
"'\u" + ($Values -join "', '\u") + "'"
# "'" + ($Values -join "', '") + "'"
#>
#<#
[char]$c = 0;
$EndIndex = -1;
$StartIndex = -1;
if ([char]::IsLetter($c) -and -not ([char]::IsUpper($c) -or [char]::IsLower($c) -or [char]::IsAscii($c))) {
# if ([char]::IsSymbol($c) -and [char]::IsAscii($c) -and $c -ne '+' -and $c -ne '~') {
# if ([char]::IsAsciiDigit($c)) {
    $StartIndex = 0;
    $EndIndex = 1;
}
$Writer = [System.IO.StreamWriter]::new(($PSScriptRoot | Join-Path -ChildPath 'temp.txt'), $false, [System.Text.UTF8Encoding]::new($false, $false));
try {
    $Writer.WriteLine();
    for ($i = 1; $i -lt 65536; $i++) {
        [char]$c = $i;
        if ([char]::IsLetter($c) -and -not ([char]::IsUpper($c) -or [char]::IsLower($c) -or [char]::IsAscii($c))) {
            if ($EndIndex -eq $i) {
                $EndIndex++;
            } else {
                $StartIndex = $i;
                $EndIndex = $i + 1;
            }
        } else {
            if ($EndIndex -eq $i) {
                if ($StartIndex -eq $EndIndex - 2) {
                    $Writer.WriteLine("        yield return '\u$($StartIndex.ToString('x4'))';");
                    $Writer.WriteLine("        yield return '\u$(($i - 1).ToString('x4'))';");
                    # $Writer.WriteLine("        yield return '$(([char]$StartIndex))';");
                    # $Writer.WriteLine("        yield return '$(([char]($i - 1)))';");
                } else {
                    if ($StartIndex -lt $EndIndex - 2) {
                        $Writer.WriteLine("        for (char c = '\u$($StartIndex.ToString('x4'))'; c <= '\u$(($i - 1).ToString('x4'))'; c++) yield return c;");
                        # $Writer.WriteLine("        for (char c = '$(([char]$StartIndex))'; c <= '$(([char]($i - 1)))'; c++) yield return c;");
                    } else {
                        $Writer.WriteLine("        yield return '\u$($StartIndex.ToString('x4'))';");
                        # $Writer.WriteLine("        yield return '$(([char]$StartIndex))';");
                    }
                }
            }
            $StartIndex = -2;
        }
    }
    if ($StartIndex -gt -1) {
        if ($StartIndex -eq $EndIndex - 2) {
            $Writer.WriteLine("        yield return '\u$($StartIndex.ToString('x4'))';");
            $Writer.WriteLine("        yield return '\u$(($i - 1).ToString('x4'))';");
            # $Writer.WriteLine("        yield return '$(([char]$StartIndex))';");
            # $Writer.WriteLine("        yield return '$(([char]($i - 1)))';");
        } else {
            if ($StartIndex -lt $EndIndex - 2) {
                $Writer.WriteLine("        for (char c = '\u$($StartIndex.ToString('x4'))'; c <= '\u$(($i - 1).ToString('x4'))'; c++) yield return c;");
                # $Writer.WriteLine("        for (char c = '$(([char]$StartIndex))'; c <= '$(([char]($i - 1)))'; c++) yield return c;");
            } else {
                $Writer.WriteLine("        yield return '\u$($StartIndex.ToString('x4'))';");
                # $Writer.WriteLine("        yield return '$(([char]$StartIndex))';");
            }
        }
    }
    $Writer.Flush();
} finally { $Writer.Close() }
#>