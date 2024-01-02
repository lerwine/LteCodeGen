Function ConvertFrom-BinaryNotation {
    [CmdletBinding(DefaultParameterSetName = "Dynamic")]
    Param(
        [Parameter(Mandatory = $true, ValueFromPipeline = $true, ParameterSetName = "Dynamic")]
        [ValidatePattern('^(?i)(0b)?_*((?=[01_]+U$)([01]_*){1,32}|([01]_*){1,64}(U?L)?)$')]
        [string[]]$Pattern,
        
        [Parameter(Mandatory = $true, ValueFromPipeline = $true, ParameterSetName = "64-Bit")]
        [ValidatePattern('^(?i)(0b)?_*([01]_*){1,64}(U?L)?$')]
        [string[]]$Pattern64,
        
        [Parameter(Mandatory = $true, ValueFromPipeline = $true, ParameterSetName = "32-Bit")]
        [ValidatePattern('^(?i)(0b)?_*([01]_*){1,32}U?$')]
        [string[]]$Pattern32,
        
        [Parameter(Mandatory = $true, ValueFromPipeline = $true, ParameterSetName = "16-Bit")]
        [ValidatePattern('^(?i)(0b)?_*([01]_*){1,16}$')]
        [string[]]$Pattern16,
        
        [Parameter(Mandatory = $true, ValueFromPipeline = $true, ParameterSetName = "8-Bit")]
        [ValidatePattern('^(?i)(0b)?_*([01]_*){1,8}$')]
        [string[]]$Pattern8,
        
        [Parameter(ParameterSetName = "Explicit")]
        [switch]$Signed
    )

    Process {
        $p = $Pattern.Replace('_', '');
        if ($p.StartsWith('0b')) { $p = $p.Substring(2) }
        $i = $p.IndexOf('1');
        if ($i -lt 0) {
            switch ($PSCmdlet.ParameterSetName) {
                "64-Bit" {
                    if ($Signed.IsPresent) { ([long]0) | Write-Output } else { ([ulong]0) | Write-Output }
                    break;
                }
                "32-Bit" {
                    if ($Signed.IsPresent) { ([int]0) | Write-Output } else { ([uint]0) | Write-Output }
                    break;
                }
                "16-Bit" {
                    if ($Signed.IsPresent) { ([short]0) | Write-Output } else { ([ushort]0) | Write-Output }
                    break;
                }
                "8-Bit" {
                    if ($Signed.IsPresent) { ([sbyte]0) | Write-Output } else { ([byte]0) | Write-Output }
                    break;
                }
                default {
                    switch ($p) {
                        "UL" {
                            ([ulong]0) | Write-Output;
                            break;
                        }
                        "L" {
                            ([long]0) | Write-Output;
                            break;
                        }
                        "U" {
                            ([uit]0) | Write-Output;
                            break;
                        }
                        default {
                            0 | Write-Output;
                            break;
                        }
                    }
                    break;
                }
            }
        } else {
            $p = $p.Substring($i);
            switch ($PSCmdlet.ParameterSetName) {
                "64-Bit" {
                    $Bytes = New-Object -TypeName 'System.Byte[]' -ArgumentList 64;
                    break;
                }
                "32-Bit" {
                    $Bytes = New-Object -TypeName 'System.Byte[]' -ArgumentList 32;
                    break;
                }
                "16-Bit" {
                    if ($p.Length -eq 1) {
                        if ($Signed.IsPresent) { ([short]1) | Write-Output } else { ([ushort]1) | Write-Output }
                    } else {
                        
                    }
                    $Bytes = New-Object -TypeName 'System.Byte[]' -ArgumentList 16;
                    break;
                }
                "8-Bit" {
                    if ($p.Length -eq 1) {
                        if ($Signed.IsPresent) { ([sbyte]1) | Write-Output } else { ([byte]1) | Write-Output }
                    } else {
                        $Value = 1;
                        for ($i = 1; $i -lt $p.Length; $i++) {
                            $Value = $Value -shl 1;
                            if ($p[$i] -eq '1') { $Value = $Value -bor 1 }
                        }
                        if ($Signed.IsPresent) {
                            $Bytes = New-Object -TypeName 'System.Byte[]' -ArgumentList 8;
                            [System.BitConverter]::GetBytes(([byte]$Value));
                            $s = 7 - $p.Length;
                            $Bytes[$s] = 1;
                        } else {
                            ([byte]$Value) | Write-Output;
                        }
                        # 1100_0000: -64
                        # 1010_0000: -96
                        # 0000_0101: -96
                        # 10000000: 128
                        # 00000010: ([sbyte]2) -shl 6
                        # 00000011: ([sbyte]3) -shl 6
                        # 00000100: ([sbyte]4) -shl 5
                        # 00000101: ([sbyte]5) -shl 5
                        # 00000110: ([sbyte]6) -shl 5
                        # 00000111: ([sbyte]7) -shl 5
                        # 00001000: ([sbyte]6) -shl 4
                    }
                    break;
                }
                default {
                    $Bytes = New-Object -TypeName 'System.Byte[]' -ArgumentList 64;
                    break;
                }
            }
        }
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

        [ValidateRange(1, 64)]
        [int]$MinBits = 1,

        [switch]$NoPrefix,

        [Parameter(Mandatory = $true, ParameterSetName = 'Nibble')]
        [switch]$SeparateByNibble,

        [Parameter(Mandatory = $true, ParameterSetName = 'Byte')]
        [switch]$SeparateByByte,

        [Parameter(Mandatory = $true, ParameterSetName = 'Word')]
        [switch]$SeparateByWord,

        [Parameter(Mandatory = $true, ParameterSetName = 'DWord')]
        [switch]$SeparateByDWord
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

Add-Type -TypeDefinition @'
public static class CharacterTypes
{
    public const ulong Flag_AsciiNonWsControlChars = 0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0001UL;
    public const ulong Flag_AsciiWhitespaceControlChars = 0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0010UL;
    public const ulong Flag_Space = 0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0100UL;
    public const ulong Flag_NonAsciiSeparator = 0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_1000UL;
    public const ulong Flag_AsciiPunctuation = 0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0001_0000UL;
    public const ulong Flag_AsciiDigits = 0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0010_0000UL;
    public const ulong Flag_AsciiSymbols = 0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0100_0000UL;
    public const ulong Flag_Plus = 0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_1000_0000UL;
    public const ulong Flag_Dash = 0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0001_0000_0000UL;
    public const ulong Flag_Period = 0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0010_0000_0000UL;
    public const ulong Flag_HexDigitVowelsUpper = 0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0100_0000_0000UL;
    public const ulong Flag_UpperB = 0b0000_0000_0000_0000_0000_0000_0000_0000_0000_1000_0000_0000UL;
    public const ulong Flag_UpperC = 0b0000_0000_0000_0000_0000_0000_0000_0000_0001_0000_0000_0000UL;
    public const ulong Flag_UpperD = 0b0000_0000_0000_0000_0000_0000_0000_0000_0010_0000_0000_0000UL;
    public const ulong Flag_UpperF = 0b0000_0000_0000_0000_0000_0000_0000_0000_0100_0000_0000_0000UL;
    public const ulong Flag_VowelsUpper = 0b0000_0000_0000_0000_0000_0000_0000_0000_1000_0000_0000_0000UL;
    public const ulong Flag_HardConsonantsUpper = 0b0000_0000_0000_0000_0000_0000_0000_0001_0000_0000_0000_0000UL;
    public const ulong Flag_SoftConsonantsUpper = 0b0000_0000_0000_0000_0000_0000_0000_0010_0000_0000_0000_0000UL;
    public const ulong Flag_UpperY = 0b0000_0000_0000_0000_0000_0000_0000_0100_0000_0000_0000_0000UL;
    public const ulong Flag_Underscore = 0b0000_0000_0000_0000_0000_0000_0000_1000_0000_0000_0000_0000UL;
    public const ulong Flag_HexDigitVowelsLower = 0b0000_0000_0000_0000_0000_0000_0001_0000_0000_0000_0000_0000UL;
    public const ulong Flag_LowerB = 0b0000_0000_0000_0000_0000_0000_0010_0000_0000_0000_0000_0000UL;
    public const ulong Flag_LowerC = 0b0000_0000_0000_0000_0000_0000_0100_0000_0000_0000_0000_0000UL;
    public const ulong Flag_LowerD = 0b0000_0000_0000_0000_0000_0000_1000_0000_0000_0000_0000_0000UL;
    public const ulong Flag_LowerF = 0b0000_0000_0000_0000_0000_0001_0000_0000_0000_0000_0000_0000UL;
    public const ulong Flag_VowelsLower = 0b0000_0000_0000_0000_0000_0010_0000_0000_0000_0000_0000_0000UL;
    public const ulong Flag_HardConsonantsLower = 0b0000_0000_0000_0000_0000_0100_0000_0000_0000_0000_0000_0000UL;
    public const ulong Flag_SoftConsonantsLower = 0b0000_0000_0000_0000_0000_1000_0000_0000_0000_0000_0000_0000UL;
    public const ulong Flag_LowerY = 0b0000_0000_0000_0000_0001_0000_0000_0000_0000_0000_0000_0000UL;
    public const ulong Flag_Tilde = 0b0000_0000_0000_0000_0010_0000_0000_0000_0000_0000_0000_0000UL;
    public const ulong Flag_NonAsciiNonWsControlChars = 0b0000_0000_0000_0000_0100_0000_0000_0000_0000_0000_0000_0000UL;
    public const ulong Flag_NonAsciiPunctuationChars = 0b0000_0000_0000_0000_1000_0000_0000_0000_0000_0000_0000_0000UL;
    public const ulong Flag_NonAsciiSymbols = 0b0000_0000_0000_0001_0000_0000_0000_0000_0000_0000_0000_0000UL;
    public const ulong Flag_NonSeparatorWhiteSpace = 0b0000_0000_0000_0010_0000_0000_0000_0000_0000_0000_0000_0000UL;
    public const ulong Flag_NonAsciiNumbers = 0b0000_0000_0000_0100_0000_0000_0000_0000_0000_0000_0000_0000UL;
    public const ulong Flag_NonAsciiDigits = 0b0000_0000_0000_1000_0000_0000_0000_0000_0000_0000_0000_0000UL;
    public const ulong Flag_UpperNonAsciiChars = 0b0000_0000_0001_0000_0000_0000_0000_0000_0000_0000_0000_0000UL;
    public const ulong Flag_LowerNonAsciiChars = 0b0000_0000_0010_0000_0000_0000_0000_0000_0000_0000_0000_0000UL;
    public const ulong Flag_NonAsciiNonCaseLetters = 0b0000_0000_0100_0000_0000_0000_0000_0000_0000_0000_0000_0000UL;
    public const ulong Flag_HighSurrogates = 0b0000_0000_1000_0000_0000_0000_0000_0000_0000_0000_0000_0000UL;
    public const ulong Flag_LowSurrogates = 0b0000_0001_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000UL;
}
public enum CharacterType : ulong
{
    AsciiControlChars = CharacterTypes.Flag_AsciiNonWsControlChars | CharacterTypes.Flag_AsciiWhitespaceControlChars,
    Space = CharacterTypes.Flag_Space,
    AsciiWhiteSpace = CharacterTypes.Flag_Space | CharacterTypes.Flag_AsciiWhitespaceControlChars,
    Separators = CharacterTypes.Flag_Space | CharacterTypes.Flag_NonAsciiSeparator,
    AsciiDigits = CharacterTypes.Flag_AsciiDigits,
    Plus = CharacterTypes.Flag_Plus,
    Dash = CharacterTypes.Flag_Dash,
    Period = CharacterTypes.Flag_Period,
    AsciiHexDigitsUpper = CharacterTypes.Flag_AsciiDigits | CharacterTypes.Flag_HexDigitVowelsUpper | CharacterTypes.Flag_UpperB | CharacterTypes.Flag_UpperC | CharacterTypes.Flag_UpperD | CharacterTypes.Flag_UpperF,
    HardConsonantsUpper = CharacterTypes.Flag_UpperB | CharacterTypes.Flag_UpperC | CharacterTypes.Flag_UpperD | CharacterTypes.Flag_HardConsonantsUpper,
    VowelsUpper = CharacterTypes.Flag_HexDigitVowelsUpper | CharacterTypes.Flag_VowelsUpper | CharacterTypes.Flag_UpperY,
    SoftConsonantsUpper = CharacterTypes.Flag_UpperC | CharacterTypes.Flag_UpperF | CharacterTypes.Flag_SoftConsonantsUpper | CharacterTypes.Flag_UpperY,
    ConsonantsUpper = CharacterTypes.Flag_UpperB | CharacterTypes.Flag_UpperC | CharacterTypes.Flag_UpperD | CharacterTypes.Flag_UpperF | CharacterTypes.Flag_HardConsonantsUpper | CharacterTypes.Flag_SoftConsonantsUpper | CharacterTypes.Flag_UpperY,
    AsciiLettersUpper = CharacterTypes.Flag_HexDigitVowelsUpper | CharacterTypes.Flag_UpperB | CharacterTypes.Flag_UpperC | CharacterTypes.Flag_UpperD | CharacterTypes.Flag_UpperF | CharacterTypes.Flag_VowelsUpper | CharacterTypes.Flag_HardConsonantsUpper | CharacterTypes.Flag_SoftConsonantsUpper | CharacterTypes.Flag_UpperY,
    Underscore = CharacterTypes.Flag_Underscore,
    AsciiPunctuation = CharacterTypes.Flag_AsciiPunctuation | CharacterTypes.Flag_Dash | CharacterTypes.Flag_Period | CharacterTypes.Flag_Underscore,
    AsciiHexDigitsLower = CharacterTypes.Flag_AsciiDigits | CharacterTypes.Flag_HexDigitVowelsLower | CharacterTypes.Flag_LowerB | CharacterTypes.Flag_LowerC | CharacterTypes.Flag_LowerD | CharacterTypes.Flag_LowerF,
    AsciiHexDigits = CharacterTypes.Flag_AsciiDigits | CharacterTypes.Flag_HexDigitVowelsUpper | CharacterTypes.Flag_UpperB | CharacterTypes.Flag_UpperC | CharacterTypes.Flag_UpperD | CharacterTypes.Flag_UpperF | CharacterTypes.Flag_HexDigitVowelsLower | CharacterTypes.Flag_LowerB | CharacterTypes.Flag_LowerC | CharacterTypes.Flag_LowerD | CharacterTypes.Flag_LowerF,
    HardConsonantsLower = CharacterTypes.Flag_LowerB | CharacterTypes.Flag_LowerC | CharacterTypes.Flag_LowerD | CharacterTypes.Flag_HardConsonantsLower,
    HardConsonants = CharacterTypes.Flag_UpperB | CharacterTypes.Flag_UpperC | CharacterTypes.Flag_UpperD | CharacterTypes.Flag_HardConsonantsUpper | CharacterTypes.Flag_LowerB | CharacterTypes.Flag_LowerC | CharacterTypes.Flag_LowerD | CharacterTypes.Flag_HardConsonantsLower,
    VowelsLower = CharacterTypes.Flag_HexDigitVowelsLower | CharacterTypes.Flag_VowelsLower | CharacterTypes.Flag_LowerY,
    Vowels = CharacterTypes.Flag_HexDigitVowelsUpper | CharacterTypes.Flag_VowelsUpper | CharacterTypes.Flag_UpperY | CharacterTypes.Flag_HexDigitVowelsLower | CharacterTypes.Flag_VowelsLower | CharacterTypes.Flag_LowerY,
    SoftConsonantsLower = CharacterTypes.Flag_LowerC | CharacterTypes.Flag_LowerF | CharacterTypes.Flag_SoftConsonantsLower | CharacterTypes.Flag_LowerY,
    SoftConsonants = CharacterTypes.Flag_UpperC | CharacterTypes.Flag_UpperF | CharacterTypes.Flag_SoftConsonantsUpper | CharacterTypes.Flag_UpperY | CharacterTypes.Flag_LowerC | CharacterTypes.Flag_LowerF | CharacterTypes.Flag_SoftConsonantsLower | CharacterTypes.Flag_LowerY,
    ConsonantsLower = CharacterTypes.Flag_LowerB | CharacterTypes.Flag_LowerC | CharacterTypes.Flag_LowerD | CharacterTypes.Flag_LowerF | CharacterTypes.Flag_HardConsonantsLower | CharacterTypes.Flag_SoftConsonantsLower | CharacterTypes.Flag_LowerY,
    Consonants = CharacterTypes.Flag_UpperB | CharacterTypes.Flag_UpperC | CharacterTypes.Flag_UpperD | CharacterTypes.Flag_UpperF | CharacterTypes.Flag_HardConsonantsUpper | CharacterTypes.Flag_SoftConsonantsUpper | CharacterTypes.Flag_UpperY | CharacterTypes.Flag_LowerB | CharacterTypes.Flag_LowerC | CharacterTypes.Flag_LowerD | CharacterTypes.Flag_LowerF |
        CharacterTypes.Flag_HardConsonantsLower | CharacterTypes.Flag_SoftConsonantsLower | CharacterTypes.Flag_LowerY,
    AsciiLettersLower = CharacterTypes.Flag_HexDigitVowelsLower | CharacterTypes.Flag_LowerB | CharacterTypes.Flag_LowerC | CharacterTypes.Flag_LowerD | CharacterTypes.Flag_LowerF | CharacterTypes.Flag_VowelsLower | CharacterTypes.Flag_HardConsonantsLower | CharacterTypes.Flag_SoftConsonantsLower | CharacterTypes.Flag_LowerY,
    AsciiLetters = CharacterTypes.Flag_HexDigitVowelsUpper | CharacterTypes.Flag_UpperB | CharacterTypes.Flag_UpperC | CharacterTypes.Flag_UpperD | CharacterTypes.Flag_UpperF | CharacterTypes.Flag_VowelsUpper | CharacterTypes.Flag_HardConsonantsUpper | CharacterTypes.Flag_SoftConsonantsUpper | CharacterTypes.Flag_UpperY |
        CharacterTypes.Flag_HexDigitVowelsLower | CharacterTypes.Flag_LowerB | CharacterTypes.Flag_LowerC | CharacterTypes.Flag_LowerD | CharacterTypes.Flag_LowerF | CharacterTypes.Flag_VowelsLower | CharacterTypes.Flag_HardConsonantsLower | CharacterTypes.Flag_SoftConsonantsLower | CharacterTypes.Flag_LowerY,
    AsciiLettersAndDigits = CharacterTypes.Flag_AsciiDigits | CharacterTypes.Flag_HexDigitVowelsUpper | CharacterTypes.Flag_UpperB | CharacterTypes.Flag_UpperC | CharacterTypes.Flag_UpperD | CharacterTypes.Flag_UpperF | CharacterTypes.Flag_VowelsUpper | CharacterTypes.Flag_HardConsonantsUpper | CharacterTypes.Flag_SoftConsonantsUpper |
        CharacterTypes.Flag_UpperY | CharacterTypes.Flag_HexDigitVowelsLower | CharacterTypes.Flag_LowerB | CharacterTypes.Flag_LowerC | CharacterTypes.Flag_LowerD | CharacterTypes.Flag_LowerF | CharacterTypes.Flag_VowelsLower | CharacterTypes.Flag_HardConsonantsLower | CharacterTypes.Flag_SoftConsonantsLower | CharacterTypes.Flag_LowerY,
    CsIdentifierChars = CharacterTypes.Flag_AsciiDigits | CharacterTypes.Flag_HexDigitVowelsUpper | CharacterTypes.Flag_UpperB | CharacterTypes.Flag_UpperC | CharacterTypes.Flag_UpperD | CharacterTypes.Flag_UpperF | CharacterTypes.Flag_VowelsUpper | CharacterTypes.Flag_HardConsonantsUpper | CharacterTypes.Flag_SoftConsonantsUpper |
        CharacterTypes.Flag_UpperY | CharacterTypes.Flag_Underscore | CharacterTypes.Flag_HexDigitVowelsLower | CharacterTypes.Flag_LowerB | CharacterTypes.Flag_LowerC | CharacterTypes.Flag_LowerD | CharacterTypes.Flag_LowerF | CharacterTypes.Flag_VowelsLower | CharacterTypes.Flag_HardConsonantsLower | CharacterTypes.Flag_SoftConsonantsLower | CharacterTypes.Flag_LowerY,
    Tilde = CharacterTypes.Flag_Tilde,
    AsciiSymbols = CharacterTypes.Flag_AsciiSymbols | CharacterTypes.Flag_Plus | CharacterTypes.Flag_Tilde,
    UriDataChars = CharacterTypes.Flag_AsciiDigits | CharacterTypes.Flag_Dash | CharacterTypes.Flag_Period | CharacterTypes.Flag_HexDigitVowelsUpper | CharacterTypes.Flag_UpperB | CharacterTypes.Flag_UpperC | CharacterTypes.Flag_UpperD | CharacterTypes.Flag_UpperF | CharacterTypes.Flag_VowelsUpper | CharacterTypes.Flag_HardConsonantsUpper |
        CharacterTypes.Flag_SoftConsonantsUpper | CharacterTypes.Flag_UpperY | CharacterTypes.Flag_Underscore | CharacterTypes.Flag_HexDigitVowelsLower | CharacterTypes.Flag_LowerB | CharacterTypes.Flag_LowerC | CharacterTypes.Flag_LowerD | CharacterTypes.Flag_LowerF | CharacterTypes.Flag_VowelsLower | CharacterTypes.Flag_HardConsonantsLower |
        CharacterTypes.Flag_SoftConsonantsLower | CharacterTypes.Flag_LowerY | CharacterTypes.Flag_Tilde,
    AsciiChars = CharacterTypes.Flag_AsciiNonWsControlChars | CharacterTypes.Flag_AsciiWhitespaceControlChars | CharacterTypes.Flag_Space | CharacterTypes.Flag_AsciiPunctuation | CharacterTypes.Flag_AsciiDigits | CharacterTypes.Flag_AsciiSymbols | CharacterTypes.Flag_Plus | CharacterTypes.Flag_Dash | CharacterTypes.Flag_Period |
        CharacterTypes.Flag_HexDigitVowelsUpper | CharacterTypes.Flag_UpperB | CharacterTypes.Flag_UpperC | CharacterTypes.Flag_UpperD | CharacterTypes.Flag_UpperF | CharacterTypes.Flag_VowelsUpper | CharacterTypes.Flag_HardConsonantsUpper | CharacterTypes.Flag_SoftConsonantsUpper | CharacterTypes.Flag_UpperY | CharacterTypes.Flag_Underscore |
        CharacterTypes.Flag_HexDigitVowelsLower | CharacterTypes.Flag_LowerB | CharacterTypes.Flag_LowerC | CharacterTypes.Flag_LowerD | CharacterTypes.Flag_LowerF | CharacterTypes.Flag_VowelsLower | CharacterTypes.Flag_HardConsonantsLower | CharacterTypes.Flag_SoftConsonantsLower | CharacterTypes.Flag_LowerY | CharacterTypes.Flag_Tilde,
    PunctuationChars = CharacterTypes.Flag_AsciiPunctuation | CharacterTypes.Flag_Dash | CharacterTypes.Flag_Period | CharacterTypes.Flag_Underscore | CharacterTypes.Flag_NonAsciiPunctuationChars,
    Symbols = CharacterTypes.Flag_AsciiSymbols | CharacterTypes.Flag_Plus | CharacterTypes.Flag_Tilde | CharacterTypes.Flag_NonAsciiSymbols,
    WhiteSpaceChars = CharacterTypes.Flag_Space | CharacterTypes.Flag_NonAsciiSeparator | CharacterTypes.Flag_AsciiWhitespaceControlChars | CharacterTypes.Flag_NonSeparatorWhiteSpace,
    Numbers = CharacterTypes.Flag_AsciiDigits | CharacterTypes.Flag_NonAsciiNumbers,
    Digits = CharacterTypes.Flag_AsciiDigits | CharacterTypes.Flag_NonAsciiNumbers | CharacterTypes.Flag_NonAsciiDigits,
    UpperChars = CharacterTypes.Flag_HexDigitVowelsUpper | CharacterTypes.Flag_UpperB | CharacterTypes.Flag_UpperC | CharacterTypes.Flag_UpperD | CharacterTypes.Flag_UpperF | CharacterTypes.Flag_VowelsUpper | CharacterTypes.Flag_HardConsonantsUpper | CharacterTypes.Flag_SoftConsonantsUpper | CharacterTypes.Flag_UpperY | CharacterTypes.Flag_UpperNonAsciiChars,
    LowerChars = CharacterTypes.Flag_HexDigitVowelsLower | CharacterTypes.Flag_LowerB | CharacterTypes.Flag_LowerC | CharacterTypes.Flag_LowerD | CharacterTypes.Flag_LowerF | CharacterTypes.Flag_VowelsLower | CharacterTypes.Flag_HardConsonantsLower | CharacterTypes.Flag_SoftConsonantsLower | CharacterTypes.Flag_LowerY | CharacterTypes.Flag_LowerNonAsciiChars,
    Letters = CharacterTypes.Flag_HexDigitVowelsUpper | CharacterTypes.Flag_UpperB | CharacterTypes.Flag_UpperC | CharacterTypes.Flag_UpperD | CharacterTypes.Flag_UpperF | CharacterTypes.Flag_VowelsUpper | CharacterTypes.Flag_HardConsonantsUpper | CharacterTypes.Flag_SoftConsonantsUpper | CharacterTypes.Flag_UpperY |
        CharacterTypes.Flag_HexDigitVowelsLower | CharacterTypes.Flag_LowerB | CharacterTypes.Flag_LowerC | CharacterTypes.Flag_LowerD | CharacterTypes.Flag_LowerF | CharacterTypes.Flag_VowelsLower | CharacterTypes.Flag_HardConsonantsLower | CharacterTypes.Flag_SoftConsonantsLower | CharacterTypes.Flag_LowerY | CharacterTypes.Flag_UpperNonAsciiChars |
        CharacterTypes.Flag_LowerNonAsciiChars | CharacterTypes.Flag_NonAsciiNonCaseLetters,
    LettersAndDigits = CharacterTypes.Flag_AsciiDigits | CharacterTypes.Flag_HexDigitVowelsUpper | CharacterTypes.Flag_UpperB | CharacterTypes.Flag_UpperC | CharacterTypes.Flag_UpperD | CharacterTypes.Flag_UpperF | CharacterTypes.Flag_VowelsUpper | CharacterTypes.Flag_HardConsonantsUpper | CharacterTypes.Flag_SoftConsonantsUpper |
        CharacterTypes.Flag_UpperY | CharacterTypes.Flag_HexDigitVowelsLower | CharacterTypes.Flag_LowerB | CharacterTypes.Flag_LowerC | CharacterTypes.Flag_LowerD | CharacterTypes.Flag_LowerF | CharacterTypes.Flag_VowelsLower | CharacterTypes.Flag_HardConsonantsLower | CharacterTypes.Flag_SoftConsonantsLower | CharacterTypes.Flag_LowerY | CharacterTypes.Flag_NonAsciiNumbers |
        CharacterTypes.Flag_UpperNonAsciiChars | CharacterTypes.Flag_LowerNonAsciiChars | CharacterTypes.Flag_NonAsciiNonCaseLetters,
    HighSurrogates = CharacterTypes.Flag_HighSurrogates,
    ControlChars = CharacterTypes.Flag_AsciiWhitespaceControlChars | CharacterTypes.Flag_NonAsciiNonWsControlChars | CharacterTypes.Flag_AsciiNonWsControlChars,
    LowSurrogates = CharacterTypes.Flag_LowSurrogates,
    Surrogates = CharacterTypes.Flag_HighSurrogates | CharacterTypes.Flag_LowSurrogates
}
'@ -ErrorAction Stop;

Function Get-WrappedStringTokens {
    [CmdletBinding()]
    Param(
        [string]$OpenWith,

        [Parameter(Mandatory = $true, ValueFromPipeline = $true)]
        [string[]]$StringTokens,

        [ValidateRange([System.Management.Automation.ValidateRangeKind]::Positive)]
        [int]$MaxWidth,

        [ValidateLength(1, [int]::MaxValue)]
        [string]$IndentString = '    ',

        [ValidateRange([System.Management.Automation.ValidateRangeKind]::NonNegative)]
        [int]$IndentLevel = 2,

        [AllowEmptyString()]
        [string]$PadBefore = ' ',

        [string]$JoinWith = ',',

        [string]$CloseWith
    )

    Begin {
        $AllStringTokens = [System.Collections.ObjectModel.Collection[string]]::new();
        if (-not $PSBoundParameters.ContainsKey('MaxWidth')) { $MaxWidth = $Host.UI.RawUI.BufferSize.Width }
        $BaseIndent = '';
        for ($i = 0; $i -lt $IndentLevel; $i++) { $BaseIndent += $IndentString }
        $ElementIndent = $BaseIndent + $IndentString;
    }

    Process {
        $StringTokens | ForEach-Object { $AllStringTokens.Add($_) }
    }

    End {
        $CurrentLine = $BaseIndent;
        if ($PSBoundParameters.ContainsKey('OpenWith')) { $CurrentLine += $OpenWith }
        foreach ($Token in (@(($AllStringTokens | Select-Object -Skip 1 -SkipLast 1) | ForEach-Object { $_ + $JoinWith }) + @($AllStringTokens[-1]) )) {
            if ($CurrentLine.Length + $Token.Length + $PadBefore.Length -gt $MaxWidth) {
                $CurrentLine | Write-Output;
                $CurrentLine = $ElementIndent + $Token;
            } else {
                $CurrentLine = $CurrentLine + $PadBefore + $Token;
            }
        }
        if ($PSBoundParameters.ContainsKey('CloseWith')) { ($CurrentLine + $CloseWith) | Write-Output } else { $CloseWith | Write-Output }
    }
}

Function Get-WrappedCsCollectionInitLines {
    [CmdletBinding()]
    Param(
        [Parameter(Mandatory = $true, ValueFromPipeline = $true)]
        [string]$Code,

        [ValidateRange([System.Management.Automation.ValidateRangeKind]::Positive)]
        [int]$MaxWidth,

        [ValidateLength(1, [int]::MaxValue)]
        [string]$IndentString,

        [ValidateRange([System.Management.Automation.ValidateRangeKind]::NonNegative)]
        [int]$IndentLevel = 2
    )

    Begin { $AllCodeLines = [System.Collections.ObjectModel.Collection[string]]::new() }

    Process { $AllCodeLines.Add($Code) }

    End {
        $Code = ($AllCodeLines | Out-String).TrimEnd() -replace '^[ \t]*[\r\n]+', '';
        if ($Code -match '^[\r\n\s]*(?<var>[^=\s]+(\s+[^=\s]+)*)\s*=\s*(?<constr>new(\s+[^\[\]{\s]+(\s+[^\[\]{\s]+)*|\s*)(\[\]|\(\))?)\s*\{\s*(?<el>[^}]+)\};?$') {
            $AllElements = @($Matches['el'].Split(',') | ForEach-Object { $_.Trim() });
            $OpenWith = "$BaseIndent$($Matches['var'] -replace '[\r\n\s]+', ' ') = $( $Matches['constr'] -replace '[\r\n\s]+', ' ') {";
            if ($PSBoundParameters.ContainsKey('MaxWidth')) {
                if ($PSBoundParameters.ContainsKey('IndentString')) {
                    if ($PSBoundParameters.ContainsKey('IndentLevel')) {
                        $AllElements | Get-WrappedStringTokens -OpenWith $OpenWith -CloseWith ' };' -MaxWidth $MaxWidth -IndentString $IndentString -IndentLevel $IndentLevel;
                    } else {
                        $AllElements | Get-WrappedStringTokens -OpenWith $OpenWith -CloseWith ' };' -MaxWidth $MaxWidth -IndentString $IndentString;
                    }
                } else {
                    if ($PSBoundParameters.ContainsKey('IndentLevel')) {
                        $AllElements | Get-WrappedStringTokens -OpenWith $OpenWith -CloseWith ' };' -MaxWidth $MaxWidth -IndentLevel $IndentLevel;
                    } else {
                        $AllElements | Get-WrappedStringTokens -OpenWith $OpenWith -CloseWith ' };' -MaxWidth $MaxWidth;
                    }
                }
            } else {
                if ($PSBoundParameters.ContainsKey('IndentString')) {
                    if ($PSBoundParameters.ContainsKey('IndentLevel')) {
                        $AllElements | Get-WrappedStringTokens -OpenWith $OpenWith -CloseWith ' };' -IndentString $IndentString -IndentLevel $IndentLevel;
                    } else {
                        $AllElements | Get-WrappedStringTokens -OpenWith $OpenWith -CloseWith ' };' -IndentString $IndentString;
                    }
                } else {
                    if ($PSBoundParameters.ContainsKey('IndentLevel')) {
                        $AllElements | Get-WrappedStringTokens -OpenWith $OpenWith -CloseWith ' };' -IndentLevel $IndentLevel;
                    } else {
                        $AllElements | Get-WrappedStringTokens -OpenWith $OpenWith -CloseWith ' };';
                    }
                }
            }
        } else {
            Write-Warning -Message 'Could not match pattern of assignment';
            $AllCodeLines | Write-Output;
        }
    }
}

Function Get-TrimmedEnumList {
    [CmdletBinding()]
    Param(
        [string]$VariableType,

        [Parameter(Mandatory = $true)]
        [string]$VariableName,

        [Parameter(Mandatory = $true, ValueFromPipeline = $true)]
        [string]$ToExclude,

        [ValidateRange([System.Management.Automation.ValidateRangeKind]::Positive)]
        [int]$MaxWidth,

        [ValidateLength(1, [int]::MaxValue)]
        [string]$IndentString,

        [ValidateRange([System.Management.Automation.ValidateRangeKind]::NonNegative)]
        [int]$IndentLevel = 2
    )

    Begin { $AllCodeLines = [System.Collections.ObjectModel.Collection[string]]::new() }

    Process { $AllCodeLines.Add($Code) }

    End {
        $Code = ($AllCodeLines | Out-String).TrimEnd() -replace '^[ \t]*[\r\n]+', '';
        $ToExcludeElements = @($ToExclude.Split(',') | ForEach-Object { $_.Trim() });
        $AllElements = @([Enum]::GetNames([CharacterType]) | ForEach-Object { "CharacterType.$_" } | Where-Object { $ToExcludeElements -notcontains $_ });
        if ($AllElements.Count -eq 0) {
            if ($PSBoundParameters.ContainsKey('VariableType')) {
                "$VariableType $VariableName = Array.Empty<CharacterType>();"
            } else {
                "$VariableName = Array.Empty<CharacterType>();"
            }
        } else {
            $OpenWith = '';
            if ($PSBoundParameters.ContainsKey('VariableType')) {
                $OpenWith = "$VariableType $VariableName = new[] {";
            } else {
                $OpenWith = "$VariableName = new[] {";
            }
            if ($PSBoundParameters.ContainsKey('MaxWidth')) {
                if ($PSBoundParameters.ContainsKey('IndentString')) {
                    if ($PSBoundParameters.ContainsKey('IndentLevel')) {
                        $AllElements | Get-WrappedStringTokens -OpenWith $OpenWith -CloseWith ' };' -MaxWidth $MaxWidth -IndentString $IndentString -IndentLevel $IndentLevel;
                    } else {
                        $AllElements | Get-WrappedStringTokens -OpenWith $OpenWith -CloseWith ' };' -MaxWidth $MaxWidth -IndentString $IndentString;
                    }
                } else {
                    if ($PSBoundParameters.ContainsKey('IndentLevel')) {
                        $AllElements | Get-WrappedStringTokens -OpenWith $OpenWith -CloseWith ' };' -MaxWidth $MaxWidth -IndentLevel $IndentLevel;
                    } else {
                        $AllElements | Get-WrappedStringTokens -OpenWith $OpenWith -CloseWith ' };' -MaxWidth $MaxWidth;
                    }
                }
            } else {
                if ($PSBoundParameters.ContainsKey('IndentString')) {
                    if ($PSBoundParameters.ContainsKey('IndentLevel')) {
                        $AllElements | Get-WrappedStringTokens -OpenWith $OpenWith -CloseWith ' };' -IndentString $IndentString -IndentLevel $IndentLevel;
                    } else {
                        $AllElements | Get-WrappedStringTokens -OpenWith $OpenWith -CloseWith ' };' -IndentString $IndentString;
                    }
                } else {
                    if ($PSBoundParameters.ContainsKey('IndentLevel')) {
                        $AllElements | Get-WrappedStringTokens -OpenWith $OpenWith -CloseWith ' };' -IndentLevel $IndentLevel;
                    } else {
                        $AllElements | Get-WrappedStringTokens -OpenWith $OpenWith -CloseWith ' };';
                    }
                }
            }
        }
    }
}
Add-Type -AssemblyName 'System.Windows.Forms';
Add-Type -AssemblyName 'Microsoft.CodeAnalysis.CSharp';

Function Get-TypeNameAndBaseTypes {
    Param(
        [Parameter(Mandatory = $true, Position = 0, ValueFromPipeline = $true)]
        [Type[]]$Type
    )

    Process {
        $BaseType = $Type.BaseType;
        $b = '';
        if ($null -ne $BaseType -and $BaseType -ne [object]) {
            $b = $BaseType.ToString();
            while ($null -ne ($BaseType = $BaseType.BaseType) -and $BaseType -ne [object]) {
                $b = "$b, $($BaseType)";
            }
        }
        $Interfaces = $Type.GetInterfaces();
        if ($Interfaces.Length -gt 0) {
            if ($b.Length -eq 0) {
                $b = $Interfaces[0];
                ($Interfaces | Select-Object -Skip 1) | ForEach-Object { $b = "$b, $_" }
            } else {
                $Interfaces | ForEach-Object { $b = "$b, $_" }
            }
        }
        if ($b.Length -gt 0) { "$Type : $b" | Write-Output } else { $Type.ToString() | Write-Output }
    }
}

Function Get-EnumNames {
    [CmdletBinding(DefaultParameterSetName = 'FieldName')]
    Param(
        [Parameter(Mandatory = $true, Position = 0, ValueFromPipelineByPropertyName = $true, HelpMessage="Literal path to enum source code.")]
        [Alias("PSPath")]
        [ValidateNotNullOrEmpty()]
        [string[]]$Path,

        [Parameter(Mandatory = $true, ParameterSetName = 'FullName')]
        [switch]$FullName,

        [Parameter(ParameterSetName = 'FieldName')]
        [switch]$FieldName
    )
    $Code = [System.IO.File]::ReadAllText($Path);
    $SyntaxTree = [Microsoft.CodeAnalysis.CSharp.CSharpSyntaxTree]::ParseText($Code, $null, $Path);
    [Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode]$Root = $null;
    if ($SyntaxTree.TryGetRoot([ref]$Root)) {
        if ($FullName.IsPresent) {
            $Root.ChildNodes() | ForEach-Object {
                if ($_ -is [Microsoft.CodeAnalysis.CSharp.Syntax.BaseNamespaceDeclarationSyntax]) {
                    $ns = $_.Name;
                    $_.ChildNodes() | Where-Object { $_ -is [Microsoft.CodeAnalysis.CSharp.Syntax.EnumDeclarationSyntax] } | ForEach-Object {
                        $TypeName = $_.Identifier.Text;
                        $_.ChildNodes() | Where-Object { $_ -is [Microsoft.CodeAnalysis.CSharp.Syntax.EnumMemberDeclarationSyntax] } | ForEach-Object { "$ns.$TypeName.$($_.Identifier.Text)" }
                    }
                } else {
                    if ($_ -is [Microsoft.CodeAnalysis.CSharp.Syntax.EnumDeclarationSyntax]) {
                        $TypeName = $_.Identifier.Text;
                        $_.ChildNodes() | Where-Object { $_ -is [Microsoft.CodeAnalysis.CSharp.Syntax.EnumMemberDeclarationSyntax] } | ForEach-Object { "$TypeName.$($_.Identifier.Text)" }
                    }
                }
            }
        } else {
            if ($FieldName.IsPresent) {
                $Root.ChildNodes() | ForEach-Object {
                    if ($_ -is [Microsoft.CodeAnalysis.CSharp.Syntax.BaseNamespaceDeclarationSyntax]) {
                        $_.ChildNodes() | Where-Object { $_ -is [Microsoft.CodeAnalysis.CSharp.Syntax.EnumDeclarationSyntax] } | ForEach-Object {
                            $_.ChildNodes() | Where-Object { $_ -is [Microsoft.CodeAnalysis.CSharp.Syntax.EnumMemberDeclarationSyntax] } | ForEach-Object { $_.Identifier.Text }
                        }
                    } else {
                        if ($_ -is [Microsoft.CodeAnalysis.CSharp.Syntax.EnumDeclarationSyntax]) {
                            $_.ChildNodes() | Where-Object { $_ -is [Microsoft.CodeAnalysis.CSharp.Syntax.EnumMemberDeclarationSyntax] } | ForEach-Object { $_.Identifier.Text }
                        }
                    }
                }
            } else {
                $Root.ChildNodes() | ForEach-Object {
                    if ($_ -is [Microsoft.CodeAnalysis.CSharp.Syntax.BaseNamespaceDeclarationSyntax]) {
                        $_.ChildNodes() | Where-Object { $_ -is [Microsoft.CodeAnalysis.CSharp.Syntax.EnumDeclarationSyntax] } | ForEach-Object {
                            $TypeName = $_.Identifier.Text;
                            $_.ChildNodes() | Where-Object { $_ -is [Microsoft.CodeAnalysis.CSharp.Syntax.EnumMemberDeclarationSyntax] } | ForEach-Object { "$TypeName.$($_.Identifier.Text)" }
                        }
                    } else {
                        if ($_ -is [Microsoft.CodeAnalysis.CSharp.Syntax.EnumDeclarationSyntax]) {
                            $TypeName = $_.Identifier.Text;
                            $_.ChildNodes() | Where-Object { $_ -is [Microsoft.CodeAnalysis.CSharp.Syntax.EnumMemberDeclarationSyntax] } | ForEach-Object { "$TypeName.$($_.Identifier.Text)" }
                        }
                    }
                }
            }
        }
    } else {
        Write-Warning -Message 'Could not parse code';
    }
}

Add-Type -TypeDefinition @'
public class CodeOutputContext : System.IDisposable
{
    private System.Text.StringBuilder _currentLine;
    private readonly bool _disposeWriter;
    private System.IO.TextWriter _writer;
    private readonly int _maxWidth;
    private readonly string _indentString;
    private readonly int _indentLevel;
    private readonly string _currentIndent;
    private int _lineCount = 0;

    private string _previousLine = string.Empty;

    public string PreviousLine { get { return _previousLine; } }

    public int CurrentLineLength { get { return _currentLine.Length; } }
    
    public int LineCount { get { return _lineCount; } }

    public int IndentLevel { get { return _indentLevel; } }

    public int MaxWidth { get { return _maxWidth; } }

    public string IndentString { get { return _indentString; } }

    public bool CurrentLineEndsWith(string text)
    {
        if (string.IsNullOrEmpty(text)) return _currentLine.Length == 0;
        int start = _currentLine.Length - text.Length;
        if (start < 0) return false;
        for (int i = 0; i < text.Length; i++) if (_currentLine[start + i] != text[i]) return false;
        return true;
    }
    
    public CodeOutputContext(int maxWidth, string indentString, int indentLevel, System.IO.TextWriter writer = null)
    {
        _disposeWriter = writer is null;
        _writer = _disposeWriter ? new System.IO.StringWriter() : writer;
        _maxWidth = maxWidth;
        _indentString = indentString;
        _indentLevel = indentLevel;
        _currentLine = new System.Text.StringBuilder();
        if (indentLevel < 1)
            _currentIndent = string.Empty;
        else
        {
            _currentIndent = indentString;
            for (int i = 1; i < indentLevel; i++)
                _currentIndent += indentString;
        }
    }

    public CodeOutputContext Indent() { return new CodeOutputContext(this); }

    private CodeOutputContext(CodeOutputContext parent)
    {
        _disposeWriter = false;
        _currentLine = parent._currentLine;
        _writer = parent._writer;
        _maxWidth = parent._maxWidth;
        _indentString = parent._indentString;
        _indentLevel = parent._indentLevel + 1;
        _currentIndent = parent._currentIndent + _indentString;
    }
    
    private static readonly System.Text.RegularExpressions.Regex _lineBreakRegex = new System.Text.RegularExpressions.Regex(@"\r\n|\n", System.Text.RegularExpressions.RegexOptions.Compiled);
    public void AppendRaw(string text)
    {
        if (_writer == null) throw new System.ObjectDisposedException(nameof(CodeOutputContext));
        if (_lineBreakRegex.IsMatch(text))
        {
            string[] lines = _lineBreakRegex.Split(text);
            int end = lines.Length - 1;
            for (int i = 0; i < end; i++) AppendLineRaw(text);
            text = lines[end];
        }
        if (string.IsNullOrEmpty(text)) return;
        if (_currentLine.Length == 0) _lineCount++;
        _currentLine.Append(text);
    }
    
    public void AppendLine()
    {
        if (_writer == null) throw new System.ObjectDisposedException(nameof(CodeOutputContext));
        _previousLine = _currentLine.ToString();
        _currentLine.Clear();
        if (_previousLine.Length == 0) _lineCount++;
        _writer.WriteLine(_previousLine);
    }
    
    public void AppendLineRaw(string text)
    {
        if (_writer == null) throw new System.ObjectDisposedException(nameof(CodeOutputContext));
        if (_lineBreakRegex.IsMatch(text))
        {
            foreach (string line in _lineBreakRegex.Split(text)) AppendLineRaw(text);
            return;
        }
        if (string.IsNullOrWhiteSpace(text))
            _previousLine = _currentLine.ToString();
        else
            _previousLine = _currentLine.Append(text).ToString();
        _currentLine.Clear();
        if (_currentLine.Length == 0) _lineCount++;
        _writer.WriteLine(_previousLine);
    }
    
    public void AppendLine(string text)
    {
        if (_writer == null) throw new System.ObjectDisposedException(nameof(CodeOutputContext));
        if (_lineBreakRegex.IsMatch(text))
        {
            foreach (string line in _lineBreakRegex.Split(text)) AppendLine(text);
            return;
        }
        if (string.IsNullOrWhiteSpace(text))
            _previousLine = _currentLine.ToString();
        else
            _previousLine = _currentLine.Append(_currentIndent).Append(text).ToString();
        _currentLine.Clear();
        if (_currentLine.Length == 0) _lineCount++;
        _writer.WriteLine(_previousLine);
    }
    
    public void Append(string text, int additionalSpace = 0)
    {
        if (_writer == null) throw new System.ObjectDisposedException(nameof(CodeOutputContext));
        if (string.IsNullOrWhiteSpace(text)) return;
        
        if (_lineBreakRegex.IsMatch(text))
        {
            string[] lines = _lineBreakRegex.Split(text);
            int end = lines.Length - 1;
            for (int i = 0; i < end; i++) AppendLineRaw(text);
            text = lines[end];
        }
        if (_currentLine.Length == 0)
        {
            _lineCount++;
            _currentLine.Append(_currentIndent).Append(text);
        }
        else if (text.Length + _currentLine.Length + additionalSpace > _maxWidth)
        {
            _lineCount++;
            _previousLine = _currentLine.ToString();
            _currentLine.Clear().Append(_currentIndent).Append(text);
            _writer.WriteLine(_previousLine);
        }
        else
            _currentLine.Append(text);
    }

    public void AppendWithSeparator(string separator, string text, int additionalSpace = 0)
    {
        if (_writer == null) throw new System.ObjectDisposedException(nameof(CodeOutputContext));
        if (string.IsNullOrWhiteSpace(text)) return;
        
        if (_currentLine.Length == 0)
        {
            _lineCount++;
            _currentLine.Append(_currentIndent).Append(separator).Append(text);
        }
        else if (separator.Length + text.Length + _currentLine.Length + additionalSpace > _maxWidth)
        {
            _lineCount++;
            _previousLine = _currentLine.ToString();
            _currentLine.Clear().Append(_currentIndent).Append(separator).Append(text);
            _writer.WriteLine(_previousLine);
        }
        else
            _currentLine.Append(separator).Append(text);
    }

    public void AppendWithPadding(string padding, string text, int additionalSpace = 0)
    {
        if (_writer == null) throw new System.ObjectDisposedException(nameof(CodeOutputContext));
        if (string.IsNullOrWhiteSpace(text)) return;
        
        if (_currentLine.Length == 0)
        {
            _lineCount++;
            _currentLine.Append(_currentIndent).Append(text);
        }
        else if (padding.Length + text.Length + _currentLine.Length + additionalSpace > _maxWidth)
        {
            _lineCount++;
            _previousLine = _currentLine.ToString();
            _currentLine.Clear().Append(_currentIndent).Append(text);
            _writer.WriteLine(_previousLine);
        }
        else
            _currentLine.Append(padding).Append(text);
    }
    
    public void AppendWithSeparatorAndPadding(string separator, string padding, string text, int additionalSpace = 0)
    {
        if (_writer == null) throw new System.ObjectDisposedException(nameof(CodeOutputContext));
        if (string.IsNullOrWhiteSpace(text)) return;
        
        if (_currentLine.Length == 0)
        {
            _lineCount++;
            _currentLine.Append(_currentIndent).Append(separator).Append(padding).Append(text);
        }
        else if (separator.Length + padding.Length + text.Length + _currentLine.Length + additionalSpace > _maxWidth)
        {
            _lineCount++;
            _previousLine = _currentLine.Append(separator).ToString();
            _currentLine.Clear().Append(_currentIndent).Append(text);
            _writer.WriteLine(_previousLine);
        }
        else
            _currentLine.Append(separator).Append(padding).Append(text);
    }

    public override string ToString()
    {
        if (_writer == null) throw new System.ObjectDisposedException(nameof(CodeOutputContext));
        if (_currentLine.Length > 0)
        {
            string s = _writer.ToString();
            return string.IsNullOrEmpty(s) ? _currentLine.ToString() : s + _currentLine.ToString();
        }
        return _writer.ToString() ?? string.Empty;
    }

    protected virtual void Dispose(bool disposing)
    {
        System.IO.TextWriter writer = _writer;
        _writer = null;
        if (disposing && _disposeWriter && writer != null)
            writer.Dispose();
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        System.GC.SuppressFinalize(this);
    }
}
'@ -ErrorAction Stop;
Function Repair-CsCodeLineWrapping {
    [CmdletBinding()]
    Param (
        [Parameter(Mandatory = $true, ValueFromPipeline = $true, ParameterSetName = "SyntaxNode")]
        [Parameter(Mandatory = $true, ValueFromPipeline = $true, ParameterSetName = "Context")]
        [Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode]$SyntaxNode,

        [Parameter(Mandatory = $true, ParameterSetName = "Code")]
        [string]$Code,

        [Parameter(ParameterSetName = "Code")]
        [Parameter(ParameterSetName = "SyntaxNode")]
        [ValidateRange([System.Management.Automation.ValidateRangeKind]::Positive)]
        [int]$MaxWidth,

        [Parameter(ParameterSetName = "Code")]
        [Parameter(ParameterSetName = "SyntaxNode")]
        [ValidateLength(1, [int]::MaxValue)]
        [string]$IndentString = '    ',

        [Parameter(ParameterSetName = "Code")]
        [Parameter(ParameterSetName = "SyntaxNode")]
        [ValidateRange([System.Management.Automation.ValidateRangeKind]::NonNegative)]
        [int]$IndentLevel = 0,

        [string]$AppendSeparator,

        [Parameter(ValueFromPipeline = $true, ParameterSetName = "Context")]
        [CodeOutputContext]$Context
    )

    Begin {
        if (-not $PSBoundParameters.ContainsKey('MaxWidth')) { $MaxWidth = $Host.UI.RawUI.BufferSize.Width }
        $CurrentIndent = '';
        for ($i = 0; $i -lt $IndentLevel; $i++) { $CurrentIndent += $IndentString }
        if ($PSCmdlet.ParameterSetName -eq 'SyntaxNode') {
            $Context = [CodeOutputContext]::new($MaxWidth, $IndentString, $IndentLevel);
        }
    }

    Process {
        if ($PSCmdlet.ParameterSetName -eq 'Code') {
            $SyntaxTree = [Microsoft.CodeAnalysis.CSharp.CSharpSyntaxTree]::ParseText($Code, $null, $Path);
            [Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode]$Root = $null;
            if ($SyntaxTree.TryGetRoot([ref]$Root)) {
                $Context = [CodeOutputContext]::new($MaxWidth, $IndentString, $IndentLevel);
                $Root.ChildNodes() | Repair-CsCodeLineWrapping -Context $Context;
                $Context.ToString() | Write-Output;
            } else {
                Write-Warning -Message 'Unable to parse code';
            }
        } else {
            $SyntaxNode.GetType().FullName | Write-Host -ForegroundColor Gray;
            switch ($SyntaxNode) {
                { $_ -is [Microsoft.CodeAnalysis.CSharp.Syntax.UsingDirectiveSyntax] } {
                    if ($PSBoundParameters.ContainsKey('AppendSeparator')) { $Context.AppendLine($AppendSeparator) }
                    if ($Context.CurrentLineLength -gt 0) { $Context.AppendLine() }
                    $Context.AppendLine(($SyntaxNode.ToString().Trim() -replace '[\r\n\s]+', ' '));
                    break;
                }
                { $_ -is [Microsoft.CodeAnalysis.CSharp.Syntax.FileScopedNamespaceDeclarationSyntax] } {
                    if ($PSBoundParameters.ContainsKey('AppendSeparator')) { $Context.AppendLine($AppendSeparator) }
                    if ($Context.CurrentLineLength -gt 0) { $Context.AppendLine() }
                    if ($Context.PreviousLine.Length -gt 0) { $Context.AppendLine() }
                    $Context.AppendLine("namespace $($SyntaxNode.Name);");
                    $SyntaxNode.ChildNodes() | Repair-CsCodeLineWrapping -Context $Context;
                    break;
                }
                { $_ -is [Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax] } {
                    if ($PSBoundParameters.ContainsKey('AppendSeparator')) { $Context.AppendLine($AppendSeparator) }
                    if ($Context.CurrentLineLength -gt 0) { $Context.AppendLine() }
                    if ($Context.PreviousLine.Length -gt 0) { $Context.AppendLine() }
                    $Context.AppendLine("namespace $($SyntaxNode.Name)");
                    $Context.AppendLine("{");
                    $SyntaxNode.ChildNodes() | Repair-CsCodeLineWrapping -Context $Context.Indent();
                    if ($Context.CurrentLineLength -gt 0) { $Context.AppendLine() }
                    $Context.Append("}");
                    break;
                }
                { $_ -is [Microsoft.CodeAnalysis.CSharp.Syntax.GlobalStatementSyntax] -or $_ -is [Microsoft.CodeAnalysis.CSharp.Syntax.LocalDeclarationStatementSyntax] -or $_ -is [Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionStatementSyntax] } {
                    if ($PSBoundParameters.ContainsKey('AppendSeparator')) {
                        $SyntaxNode.ChildNodes() | Repair-CsCodeLineWrapping -Context $Context -AppendSeparator $AppendSeparator;
                    } else {
                        $SyntaxNode.ChildNodes() | Repair-CsCodeLineWrapping -Context $Context;
                    }
                    break;
                }
                { $_ -is [Microsoft.CodeAnalysis.CSharp.Syntax.VariableDeclarationSyntax] } {
                    if ($Context.CurrentLineLength -gt 0) { $Context.AppendLine() }
                    if ($PSBoundParameters.ContainsKey('AppendSeparator')) {
                        $SyntaxNode.Type | Repair-CsCodeLineWrapping -Context $Context -AppendSeparator $AppendSeparator;
                    } else {
                        $SyntaxNode.Type | Repair-CsCodeLineWrapping -Context $Context;
                    }
                    $SyntaxNode.Variables[0] | Repair-CsCodeLineWrapping -Context $Context.Indent();
                    ($SyntaxNode.Variables | Select-Object -Skip 1) | Repair-CsCodeLineWrapping -Context $Context.Indent() -AppendSeparator ',';
                    $Context.AppendRaw(';');
                    break;
                }
                { $_ -is [Microsoft.CodeAnalysis.CSharp.Syntax.VariableDeclaratorSyntax] } {
                    if ($PSBoundParameters.ContainsKey('AppendSeparator')) {
                        $Context.AppendWithSeparatorAndPadding($AppendSeparator, ' ', $SyntaxNode.Identifier.ToString(), 1);
                    } else {
                        $Context.AppendWithPadding(' ', $SyntaxNode.Identifier.ToString(), 1);
                    }
                    $SyntaxNode.Initializer | Repair-CsCodeLineWrapping -Context $Context;
                    break;
                }
                { $_ -is [Microsoft.CodeAnalysis.CSharp.Syntax.ArrayTypeSyntax] } {
                    if ($PSBoundParameters.ContainsKey('AppendSeparator')) {
                        $SyntaxNode.ElementType | Repair-CsCodeLineWrapping -Context $Context -AppendSeparator $AppendSeparator;
                    } else {
                        $SyntaxNode.ElementType | Repair-CsCodeLineWrapping -Context $Context;
                    }
                    $Context.Append($SyntaxNode.RankSpecifiers.ToString());
                    break;
                }
                { $_ -is [Microsoft.CodeAnalysis.CSharp.Syntax.PredefinedTypeSyntax] } {
                    if ($PSBoundParameters.ContainsKey('AppendSeparator')) {
                        $Context.AppendWithSeparatorAndPadding($AppendSeparator, ' ', $SyntaxNode.ToString(), 1);
                    } else {
                        $Context.AppendWithPadding(' ', $SyntaxNode.ToString(), 1);
                    }
                    break;
                }
                { $_ -is [Microsoft.CodeAnalysis.CSharp.Syntax.ArrayCreationExpressionSyntax] } {
                    if ($PSBoundParameters.ContainsKey('AppendSeparator')) {
                        $Context.AppendWithSeparatorAndPadding($AppendSeparator, ' ', "new", 1);
                    } else {
                        $Context.AppendWithPadding(' ', "new", 1);
                    }
                    $SyntaxNode.Type | Repair-CsCodeLineWrapping -Context $Context.Indent();
                    $SyntaxNode.Initializer | Repair-CsCodeLineWrapping -Context $Context.Indent();
                    break;
                }
                { $_ -is [Microsoft.CodeAnalysis.CSharp.Syntax.EqualsValueClauseSyntax] } {
                    if ($PSBoundParameters.ContainsKey('AppendSeparator')) {
                        $Context.AppendWithSeparatorAndPadding($AppendSeparator, ' ', $SyntaxNode.EqualsToken.ToString(), 1);
                    } else {
                        $Context.AppendWithPadding(' ', $SyntaxNode.EqualsToken.ToString(), 1);
                    }
                    $SyntaxNode.Value | Repair-CsCodeLineWrapping -Context $Context;
                    break;
                }
                { $_ -is [Microsoft.CodeAnalysis.CSharp.Syntax.AssignmentExpressionSyntax] } {
                    if ($Context.CurrentLineLength -gt 0) { $Context.AppendLine() }
                    $SyntaxNode.Left | Repair-CsCodeLineWrapping -Context $Context;
                    if ($PSBoundParameters.ContainsKey('AppendSeparator')) {
                        $Context.AppendWithSeparatorAndPadding($AppendSeparator, ' ', $SyntaxNode.OperatorToken.ToString(), 1);
                    } else {
                        $Context.AppendWithPadding(' ', $SyntaxNode.OperatorToken.ToString(), 1);
                    }
                    $SyntaxNode.Right | Repair-CsCodeLineWrapping -Context $Context.Indent();
                    $Context.AppendRaw(';');
                    break;
                }
                { $_ -is [Microsoft.CodeAnalysis.CSharp.Syntax.IdentifierNameSyntax] } {
                    if ($PSBoundParameters.ContainsKey('AppendSeparator')) {
                        $Context.AppendWithSeparatorAndPadding($AppendSeparator, ' ', $SyntaxNode.Identifier.ToString(), 1);
                    } else {
                        $Context.AppendWithPadding(' ', $SyntaxNode.Identifier.ToString(), 1);
                    }
                    break;
                }
                { $_ -is [Microsoft.CodeAnalysis.CSharp.Syntax.ImplicitArrayCreationExpressionSyntax] } {
                    if ($PSBoundParameters.ContainsKey('AppendSeparator')) {
                        $Context.AppendWithSeparatorAndPadding($AppendSeparator, ' ', "new[$($SyntaxNode.Commas)]", 1);
                    } else {
                        $Context.AppendWithPadding(' ', "new[$($SyntaxNode.Commas)]", 1);
                    }
                    $SyntaxNode.Initializer | Repair-CsCodeLineWrapping -Context $Context;
                    break;
                }
                { $_ -is [Microsoft.CodeAnalysis.CSharp.Syntax.InitializerExpressionSyntax] } {
                    if ($PSBoundParameters.ContainsKey('AppendSeparator')) {
                        $Context.AppendWithSeparatorAndPadding($AppendSeparator, ' ', '{', 1);
                    } else {
                        $Context.AppendWithPadding(' ', '{', 1);
                    }
                    if ($SyntaxNode.Expressions.Count -gt 0) {
                        $SyntaxNode.Expressions[0] | Repair-CsCodeLineWrapping -Context $Context;
                        ($SyntaxNode.Expressions | Select-Object -Skip 1) | Repair-CsCodeLineWrapping -Context $Context -AppendSeparator ',';
                    }
                    $Context.AppendWithPadding(' ', '}');
                    break;
                }
                { $_ -is [Microsoft.CodeAnalysis.CSharp.Syntax.MemberAccessExpressionSyntax] } {
                    $m = $Context.MaxWidth - $Context.IndentLevel * $Content.IndentString;
                    if ($m -lt 1) { $m = 1 }
                    $Expression = $SyntaxNode.Expression | Repair-CsCodeLineWrapping -IndentString $Context.IndentString -MaxWidth $m;
                    if ($PSBoundParameters.ContainsKey('AppendSeparator')) {
                        $Context.AppendWithSeparatorAndPadding($AppendSeparator, ' ', "$Expression$($SyntaxNode.OperatorToken)$($SyntaxNode.Name)", 1);
                    } else {
                        $Context.AppendWithPadding(' ', "$Expression$($SyntaxNode.OperatorToken)$($SyntaxNode.Name)", 1);
                    }
                    break;
                }
                default {
                    Write-Warning -Message "Unknown type";
                    $SyntaxNode.GetType() | Get-TypeNameAndBaseTypes | Write-Host -ForegroundColor Cyan;
                    break;
                }
            }
        }
    }

    End {
        if ($PSCmdlet.ParameterSetName -eq 'SyntaxNode') {
            $Context.ToString() | Write-Output;
        }
    }
}

# $EnumDeclarationSyntax = Get-EnumNames -Path 'C:\Users\Lenny\Source\Repositories\LteCodeGen\src\TestDataGeneration\CharacterType.cs';
# $EnumDeclarationSyntax | Get-Member
# $Code = [System.Windows.Forms.Clipboard]::GetText();


# $Code = @'

# notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash, CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper,
#     CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower,
#     CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants,
#     CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.Tilde,
#     CharacterType.AsciiSymbols, CharacterType.UriDataChars, CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars, CharacterType.LowerChars,
#     CharacterType.Letters, CharacterType.LettersAndDigits, CharacterType.HighSurrogates, CharacterType.ControlChars, CharacterType.LowSurrogates, CharacterType.Surrogates };
# '@
# $Code = [System.Windows.Forms.Clipboard]::GetText();
# $Results = @(Repair-CsCodeLineWrapping -Code $Code -IndentLevel 2 -MaxWidth 221);
# $Text = $Results | Where-Object { $_ -is [string] } | Select-Object -First 1;
# if ($null -ne $Text) { [System.Windows.Forms.Clipboard]::SetText("`n$Text") }
# $SyntaxNode = ($Results | Where-Object { $_ -is [Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode] }) | Select-Object -First 1;
# if ($null -ne $SyntaxNode) { $SyntaxNode | Get-Member }

#Get-EnumNames -Path 'C:\Users\Lenny\Source\Repositories\LteCodeGen\src\TestDataGeneration\CharacterType.cs';
<#
if ($Code -match '^(?s)(?<l>([^\S\r\n]*[\r\n]+)+)?\s*(?<c>\S.*)$') {
    $LeadingLines = $Matches['l'];
    $Code = (Get-WrappedCsCollectionInitLines -Code $Matches['c'] -MaxWidth 221) -join "`n";
    if ([string]::IsNullOrEmpty($LeadingLines)) { [System.Windows.Forms.Clipboard]::SetText($Code) } else { [System.Windows.Forms.Clipboard]::SetText($LeadingLines + $Code) }
} else {
    Write-Warning -Message 'Not able to find non-whitespace in clipboard';
}
#>
<#
$Code = (Get-TrimmedEnumList -VariableName 'notExpectedValues' -ToExclude $Code -MaxWidth 221) -join "`n";
[System.Windows.Forms.Clipboard]::SetText(@"

$Code
"@);
#>

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
        if ($_.Includes.Length -gt 0) { $Writer.WriteLine("
        if ($_.IncludedBy.Length -gt 0) { $Writer.WriteLine("
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
<#
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