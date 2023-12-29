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

$EnumFields = @(
    [PSCustomObject]@{
        Name = "AsciiControlChars";
        Value = "0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0001" | ConvertFrom-BinaryNotation;
        Includes = New-Object -TypeName 'System.String[]' -ArgumentList 0;
    },
    [PSCustomObject]@{
        Name = "Space";
        Value = "0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0010" | ConvertFrom-BinaryNotation;
        Includes = New-Object -TypeName 'System.String[]' -ArgumentList 0;
    },
    [PSCustomObject]@{
        Name = "Separators";
        Value = "0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0100" | ConvertFrom-BinaryNotation;
        Includes = ([string[]]@("Space"));
    },
    [PSCustomObject]@{
        Name = "_AsciiPunctuation";
        Value = "0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_1000" | ConvertFrom-BinaryNotation;
        Includes = New-Object -TypeName 'System.String[]' -ArgumentList 0;
    }, # !"#%&'()*,/:;?@[\]{}
    [PSCustomObject]@{
        Name = "AsciiDigits";
        Value = "0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0001_0000" | ConvertFrom-BinaryNotation;
        Includes = New-Object -TypeName 'System.String[]' -ArgumentList 0;
    }, # 01234567890
    [PSCustomObject]@{
        Name = "_AsciiSymbols";
        Value = "0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0010_0000" | ConvertFrom-BinaryNotation;
        Includes = New-Object -TypeName 'System.String[]' -ArgumentList 0;
    }, # $<=>^`|
    [PSCustomObject]@{
        Name = "Plus";
        Value = "0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0100_0000" | ConvertFrom-BinaryNotation;
        Includes = New-Object -TypeName 'System.String[]' -ArgumentList 0;
    }, # +
    [PSCustomObject]@{
        Name = "Dash";
        Value = "0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_1000_0000" | ConvertFrom-BinaryNotation;
        Includes = New-Object -TypeName 'System.String[]' -ArgumentList 0;
    }, # -
    [PSCustomObject]@{
        Name = "Period";
        Value = "0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0001_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = New-Object -TypeName 'System.String[]' -ArgumentList 0;
    }, # .
    [PSCustomObject]@{
        Name = "_HexDigitVowelsUpper";
        Value = "0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0010_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = New-Object -TypeName 'System.String[]' -ArgumentList 0;
    }, # AE
    [PSCustomObject]@{
        Name = "_UpperB";
        Value = "0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0100_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = New-Object -TypeName 'System.String[]' -ArgumentList 0;
    }, # B
    [PSCustomObject]@{
        Name = "_UpperC";
        Value = "0b0000_0000_0000_0000_0000_0000_0000_0000_0000_1000_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = New-Object -TypeName 'System.String[]' -ArgumentList 0;
    }, # C
    [PSCustomObject]@{
        Name = "_UpperD";
        Value = "0b0000_0000_0000_0000_0000_0000_0000_0000_0001_0000_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = New-Object -TypeName 'System.String[]' -ArgumentList 0;
    }, # D
    [PSCustomObject]@{
        Name = "_UpperF";
        Value = "0b0000_0000_0000_0000_0000_0000_0000_0000_0010_0000_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = New-Object -TypeName 'System.String[]' -ArgumentList 0;
    }, # F
    [PSCustomObject]@{
        Name = "_UpperG";
        Value = "0b0000_0000_0000_0000_0000_0000_0000_0000_0100_0000_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = New-Object -TypeName 'System.String[]' -ArgumentList 0;
    }, # G
    [PSCustomObject]@{
        Name = "_VowelsUpper";
        Value = "0b0000_0000_0000_0000_0000_0000_0000_0000_1000_0000_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = New-Object -TypeName 'System.String[]' -ArgumentList 0;
    }, # IOU
    [PSCustomObject]@{
        Name = "_HardConsonantsUpper";
        Value = "0b0000_0000_0000_0000_0000_0000_0000_0001_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = New-Object -TypeName 'System.String[]' -ArgumentList 0;
    }, # JKPQTX
    [PSCustomObject]@{
        Name = "_SoftConsonantsUpper";
        Value = "0b0000_0000_0000_0000_0000_0000_0000_0010_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = New-Object -TypeName 'System.String[]' -ArgumentList 0;
    }, # HLMNRSVWZ
    [PSCustomObject]@{
        Name = "_UpperY";
        Value = "0b0000_0000_0000_0000_0000_0000_0000_0100_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = New-Object -TypeName 'System.String[]' -ArgumentList 0;
    }, # Y
    [PSCustomObject]@{
        Name = "Underscore";
        Value = "0b0000_0000_0000_0000_0000_0000_0000_1000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = New-Object -TypeName 'System.String[]' -ArgumentList 0;
    }, # _
    [PSCustomObject]@{
        Name = "_HexDigitVowelsLower";
        Value = "0b0000_0000_0000_0000_0000_0000_0001_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = New-Object -TypeName 'System.String[]' -ArgumentList 0;
    }, # AE
    [PSCustomObject]@{
        Name = "_LowerB";
        Value = "0b0000_0000_0000_0000_0000_0000_0010_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = New-Object -TypeName 'System.String[]' -ArgumentList 0;
    }, # B
    [PSCustomObject]@{
        Name = "_LowerC";
        Value = "0b0000_0000_0000_0000_0000_0000_0100_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = New-Object -TypeName 'System.String[]' -ArgumentList 0;
    }, # C
    [PSCustomObject]@{
        Name = "_LowerD";
        Value = "0b0000_0000_0000_0000_0000_0000_1000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = New-Object -TypeName 'System.String[]' -ArgumentList 0;
    }, # D
    [PSCustomObject]@{
        Name = "_LowerF";
        Value = "0b0000_0000_0000_0000_0000_0001_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = New-Object -TypeName 'System.String[]' -ArgumentList 0;
    }, # F
    [PSCustomObject]@{
        Name = "_LowerG";
        Value = "0b0000_0000_0000_0000_0000_0010_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = New-Object -TypeName 'System.String[]' -ArgumentList 0;
    }, # G
    [PSCustomObject]@{
        Name = "_VowelsLower";
        Value = "0b0000_0000_0000_0000_0000_0100_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = New-Object -TypeName 'System.String[]' -ArgumentList 0;
    }, # IOU
    [PSCustomObject]@{
        Name = "_HardConsonantsLower";
        Value = "0b0000_0000_0000_0000_0000_1000_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = New-Object -TypeName 'System.String[]' -ArgumentList 0;
    }, # JKPQTX
    [PSCustomObject]@{
        Name = "_SoftConsonantsLower";
        Value = "0b0000_0000_0000_0000_0001_0000_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = New-Object -TypeName 'System.String[]' -ArgumentList 0;
    }, # HLMNRSVWZ
    [PSCustomObject]@{
        Name = "_LowerY";
        Value = "0b0000_0000_0000_0000_0010_0000_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = New-Object -TypeName 'System.String[]' -ArgumentList 0;
    }, # Y
    [PSCustomObject]@{
        Name = "Tilde";
        Value = "0b0000_0000_0000_0000_0100_0000_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = New-Object -TypeName 'System.String[]' -ArgumentList 0;
    }, # ~

    [PSCustomObject]@{
        Name = "ControlChars";
        Value = "0b0000_0000_0000_0000_1000_0000_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = ([string[]]@("AsciiControlChars"));
    },
    [PSCustomObject]@{
        Name = "AsciiPunctuation";
        Value = ([ulong]0);
        Includes = ([string[]]@("_AsciiPunctuation", "Underscore", "Dash", "Period"));
    },
    [PSCustomObject]@{
        Name = "AsciiSymbols";
        Value = ([ulong]0);
        Includes = ([string[]]@("_AsciiSymbols", "Tilde", "Plus"));
    }, # $+<=>^`|~
    [PSCustomObject]@{
        Name = "PunctuationChars";
        Value = "0b0000_0000_0000_0001_0000_0000_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = ([string[]]@("AsciiPunctuation"));
    },
    [PSCustomObject]@{
        Name = "Symbols";
        Value = "0b0000_0000_0000_0010_0000_0000_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = ([string[]]@("AsciiSymbols"));
    },
    [PSCustomObject]@{
        Name = "WhiteSpaceChars";
        Value = "0b0000_0000_0000_0100_0000_0000_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = ([string[]]@("Separators"));
    },
    [PSCustomObject]@{
        Name = "Digits";
        Value = "0b0000_0000_0000_1000_0000_0000_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = ([string[]]@("AsciiDigits"));
    },
    [PSCustomObject]@{
        Name = "Numbers";
        Value = "0b0000_0000_0001_0000_0000_0000_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = ([string[]]@("Digits"));
    },
    [PSCustomObject]@{
        Name = "HardConsonantsUpper";
        Value = ([ulong]0);
        Includes = ([string[]]@("_HardConsonantsUpper", "_UpperB", "_UpperC", "_UpperD", "_UpperG"));
    },
    [PSCustomObject]@{
        Name = "SoftConsonantsUpper";
        Value = ([ulong]0);
        Includes = ([string[]]@("_SoftConsonantsUpper", "_UpperF", "_UpperG", "_UpperY"));
    },
    [PSCustomObject]@{
        Name = "VowelsUpper";
        Value = ([ulong]0);
        Includes = ([string[]]@("_VowelsUpper", "_HexDigitVowelsUpper", "_UpperY"));
    },
    [PSCustomObject]@{
        Name = "HardConsonantsLower";
        Value = ([ulong]0);
        Includes = ([string[]]@("_HardConsonantsLower", "_LowerB", "_LowerC", "_LowerD", "_LowerG"));
    },
    [PSCustomObject]@{
        Name = "SoftConsonantsLower";
        Value = ([ulong]0);
        Includes = ([string[]]@("_SoftConsonantsLower", "_LowerF", "_LowerG", "_LowerY"));
    },
    [PSCustomObject]@{
        Name = "VowelsLower";
        Value = ([ulong]0);
        Includes = ([string[]]@("_VowelsLower", "_HexDigitVowelsLower", "_LowerY"));
    },
    [PSCustomObject]@{
        Name = "HardConsonants";
        Value = ([ulong]0);
        Includes = ([string[]]@("HardConsonantsUpper", "HardConsonantsLower"));
    },
    [PSCustomObject]@{
        Name = "ConsonantsUpper";
        Value = ([ulong]0);
        Includes = ([string[]]@("HardConsonantsUpper", "SoftConsonantsUpper"));
    },
    [PSCustomObject]@{
        Name = "ConsonantsLower";
        Value = ([ulong]0);
        Includes = ([string[]]@("HardConsonantsLower", "SoftConsonantsLower"));
    },
    [PSCustomObject]@{
        Name = "SoftConsonants";
        Value = ([ulong]0);
        Includes = ([string[]]@("SoftConsonantsUpper", "SoftConsonantsLower"));
    },
    [PSCustomObject]@{
        Name = "Consonants";
        Value = ([ulong]0);
        Includes = ([string[]]@("ConsonantsUpper", "ConsonantsLower"));
    },
    [PSCustomObject]@{
        Name = "Vowels";
        Value = ([ulong]0);
        Includes = ([string[]]@("VowelsUpper", "VowelsLower"));
    },
    [PSCustomObject]@{
        Name = "AsciiLettersUpper";
        Value = ([ulong]0);
        Includes = ([string[]]@("ConsonantsUpper", "VowelsUpper"));
    },
    [PSCustomObject]@{
        Name = "UpperChars";
        Value = "0b0000_0000_0010_0000_0000_0000_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = ([string[]]@("AsciiLettersUpper"));
    },
    [PSCustomObject]@{
        Name = "AsciiLettersLower";
        Value = ([ulong]0);
        Includes = ([string[]]@("ConsonantsLower", "VowelsLower"));
    },
    [PSCustomObject]@{
        Name = "LowerChars";
        Value = "0b0000_0000_0100_0000_0000_0000_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = ([string[]]@("AsciiLettersLower"));
    },
    [PSCustomObject]@{
        Name = "AsciiLetters";
        Value = ([ulong]0);
        Includes = ([string[]]@("Consonants", "Vowels"));
    },
    [PSCustomObject]@{
        Name = "Letters";
        Value = "0b0000_0000_1000_0000_0000_0000_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = ([string[]]@("AsciiLetters", "UpperChars", "LowerChars"));
    },
    [PSCustomObject]@{
        Name = "HighSurrogates";
        Value = "0b0000_0001_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = New-Object -TypeName 'System.String[]' -ArgumentList 0;
    },
    [PSCustomObject]@{
        Name = "LowSurrogates";
        Value = "0b0000_0010_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
        Includes = New-Object -TypeName 'System.String[]' -ArgumentList 0;
    },
    [PSCustomObject]@{
        Name = "Surrogates";
        Value = ([ulong]0);
        Includes = ([string[]]@("HighSurrogates", "LowSurrogates"));
    },
    [PSCustomObject]@{
        Name = "AsciiHexDigitsUpper";
        Value = ([ulong]0);
        Includes = ([string[]]@("AsciiDigits", "_HexDigitVowelsUpper", "_UpperB", "_UpperC", "_UpperD", "_UpperF", "_HexDigitVowelsUpper"));
    },
    [PSCustomObject]@{
        Name = "AsciiHexDigitsLower";
        Value = ([ulong]0);
        Includes = ([string[]]@("AsciiDigits", "_HexDigitVowelsLower", "_LowerB", "_LowerC", "_LowerD", "_LowerF", "_HexDigitVowelsLower"));
    },
    [PSCustomObject]@{
        Name = "AsciiHexDigits";
        Value = ([ulong]0);
        Includes = ([string[]]@("AsciiHexDigitsUpper", "AsciiHexDigitsLower"));
    },
    [PSCustomObject]@{
        Name = "AsciiLettersAndDigits";
        Value = ([ulong]0);
        Includes = ([string[]]@("AsciiLetters", "AsciiDigits"));
    },
    [PSCustomObject]@{
        Name = "CsIdentifierChars";
        Value = ([ulong]0);
        Includes = ([string[]]@("AsciiLettersAndDigits", "Underscore"));
    },
    [PSCustomObject]@{
        Name = "UriDataChars";
        Value = ([ulong]0);
        Includes = ([string[]]@("CsIdentifierChars", "Dash", "Period", "Underscore", "Tilde"));
    },
    [PSCustomObject]@{
        Name = "LettersAndDigits";
        Value = ([ulong]0);
        Includes = ([string[]]@("Letters", "Digits"));
    },
    [PSCustomObject]@{
        Name = "AsciiChars";
        Value = ([ulong]0);
        Includes = ([string[]]@("AsciiControlChars", "Space", "AsciiPunctuation", "AsciiSymbols", "AsciiLettersAndDigits"));
    }
);
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
    $_ | Add-Member -Name 'Includes' -MemberType NoteProperty -Value ([string[]]($EnumFields | Where-Object { $_.Name -ne $n -and ($_.Value -bor $v) -eq $v } | ForEach-Object { $_.Name })) -Force;
    $_ | Add-Member -Name 'IncludedBy' -MemberType NoteProperty -Value ([string[]]($EnumFields | Where-Object { $_.Name -ne $n -and ($_.Value -band $v) -eq $v } | ForEach-Object { $_.Name }));
}
$Writer = [System.IO.StreamWriter]::new(($PSScriptRoot | Join-Path -ChildPath 'temp.txt'), $false, [System.Text.UTF8Encoding]::new($false, $false));
try {
    $EnumFields | ForEach-Object {
        $n = $_.Name;
        $Writer.WriteLine();
        if ($_.Includes.Length -gt 0) { $Writer.WriteLine("    // Includes: CharacterType.$($_.Includes -join ', CharacterType.')") }
        if ($_.IncludedBy.Length -gt 0) { $Writer.WriteLine("    // IncludedBy: CharacterType.$($_.IncludedBy -join ', CharacterType.')") }
        $Spacing = [string]::new(([char]' '), ($MaxNameLength - $n.Length) + 1);
        $bn = $_.Value | ConvertTo-BinaryNotation;
        $Writer.WriteLine("    $n =$Spacing$($bn)UL,");
    }

} finally { $Writer.Close() }
# "0b1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111" | ConvertFrom-BinaryNotation;
# "0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000" | ConvertFrom-BinaryNotation;
# "0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0001" | ConvertFrom-BinaryNotation;
# "0b0000_0000_0000_0000_0000_0101_1000_0001_1001_1111_1000_1111" | ConvertFrom-BinaryNotation;
# 0 | ConvertTo-BinaryNotation
# 1 | ConvertTo-BinaryNotation
# 92381071 | ConvertTo-BinaryNotation;
# 281474976710655 | ConvertTo-BinaryNotation;