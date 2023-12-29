namespace TestDataGeneration;

public enum CharacterType : ulong
{
    // IncludedBy: CharacterType.AsciiChars, CharacterType.ControlChars
    AsciiControlChars =     0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0001UL,

    // IncludedBy: CharacterType.Separators, CharacterType.AsciiChars, CharacterType.WhiteSpaceChars
    Space =                 0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0010UL,

    // Includes: CharacterType.Space
    // IncludedBy: CharacterType.WhiteSpaceChars
    Separators =            0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0110UL,

    // IncludedBy: CharacterType.AsciiPunctuation, CharacterType.AsciiChars, CharacterType.PunctuationChars
    _AsciiPunctuation =     0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_1000UL,

    // IncludedBy: CharacterType.AsciiHexDigitsUpper, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.Digits, CharacterType.Numbers,
    //             CharacterType.LettersAndDigits
    AsciiDigits =           0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0001_0000UL,

    // IncludedBy: CharacterType.AsciiSymbols, CharacterType.AsciiChars, CharacterType.Symbols
    _AsciiSymbols =         0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0010_0000UL,

    // IncludedBy: CharacterType.AsciiSymbols, CharacterType.AsciiChars, CharacterType.Symbols
    Plus =                  0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0100_0000UL,

    // IncludedBy: CharacterType.AsciiPunctuation, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.PunctuationChars
    Dash =                  0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_1000_0000UL,

    // IncludedBy: CharacterType.AsciiPunctuation, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.PunctuationChars
    Period =                0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0001_0000_0000UL,

    // IncludedBy: CharacterType.AsciiHexDigitsUpper, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper, CharacterType.AsciiHexDigits, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars,
    //             CharacterType.AsciiChars, CharacterType.UpperChars, CharacterType.Letters, CharacterType.LettersAndDigits
    _HexDigitVowelsUpper =  0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0010_0000_0000UL,

    // IncludedBy: CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper, CharacterType.AsciiHexDigits, CharacterType.HardConsonants, CharacterType.Consonants, CharacterType.AsciiLetters,
    //             CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.UpperChars, CharacterType.Letters, CharacterType.LettersAndDigits
    _UpperB =               0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0100_0000_0000UL,

    // IncludedBy: CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper, CharacterType.AsciiHexDigits, CharacterType.HardConsonants, CharacterType.Consonants, CharacterType.AsciiLetters,
    //             CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.UpperChars, CharacterType.Letters, CharacterType.LettersAndDigits
    _UpperC =               0b0000_0000_0000_0000_0000_0000_0000_0000_0000_1000_0000_0000UL,

    // IncludedBy: CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper, CharacterType.AsciiHexDigits, CharacterType.HardConsonants, CharacterType.Consonants, CharacterType.AsciiLetters,
    //             CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.UpperChars, CharacterType.Letters, CharacterType.LettersAndDigits
    _UpperD =               0b0000_0000_0000_0000_0000_0000_0000_0000_0001_0000_0000_0000UL,

    // IncludedBy: CharacterType.AsciiHexDigitsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper, CharacterType.AsciiHexDigits, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.AsciiLetters,
    //             CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.UpperChars, CharacterType.Letters, CharacterType.LettersAndDigits
    _UpperF =               0b0000_0000_0000_0000_0000_0000_0000_0000_0010_0000_0000_0000UL,

    // Includes: CharacterType.AsciiDigits, CharacterType._HexDigitVowelsUpper, CharacterType._UpperB, CharacterType._UpperC, CharacterType._UpperD, CharacterType._UpperF
    // IncludedBy: CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.LettersAndDigits
    AsciiHexDigitsUpper =   0b0000_0000_0000_0000_0000_0000_0000_0000_0011_1110_0001_0000UL,

    // IncludedBy: CharacterType.HardConsonantsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper, CharacterType.HardConsonants, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.AsciiLetters,
    //             CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.UpperChars, CharacterType.Letters, CharacterType.LettersAndDigits
    _UpperG =               0b0000_0000_0000_0000_0000_0000_0000_0000_0100_0000_0000_0000UL,

    // IncludedBy: CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.UpperChars,
    //             CharacterType.Letters, CharacterType.LettersAndDigits
    _VowelsUpper =          0b0000_0000_0000_0000_0000_0000_0000_0000_1000_0000_0000_0000UL,

    // IncludedBy: CharacterType.HardConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper, CharacterType.HardConsonants, CharacterType.Consonants, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars,
    //             CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.UpperChars, CharacterType.Letters, CharacterType.LettersAndDigits
    _HardConsonantsUpper =  0b0000_0000_0000_0000_0000_0000_0000_0001_0000_0000_0000_0000UL,

    // Includes: CharacterType._UpperB, CharacterType._UpperC, CharacterType._UpperD, CharacterType._UpperG, CharacterType._HardConsonantsUpper
    // IncludedBy: CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper, CharacterType.HardConsonants, CharacterType.Consonants, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars,
    //             CharacterType.UpperChars, CharacterType.Letters, CharacterType.LettersAndDigits
    HardConsonantsUpper =   0b0000_0000_0000_0000_0000_0000_0000_0001_0101_1100_0000_0000UL,

    // IncludedBy: CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars,
    //             CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.UpperChars, CharacterType.Letters, CharacterType.LettersAndDigits
    _SoftConsonantsUpper =  0b0000_0000_0000_0000_0000_0000_0000_0010_0000_0000_0000_0000UL,

    // IncludedBy: CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper, CharacterType.Vowels, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits,
    //             CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.UpperChars, CharacterType.Letters, CharacterType.LettersAndDigits
    _UpperY =               0b0000_0000_0000_0000_0000_0000_0000_0100_0000_0000_0000_0000UL,

    // Includes: CharacterType._HexDigitVowelsUpper, CharacterType._VowelsUpper, CharacterType._UpperY
    // IncludedBy: CharacterType.AsciiLettersUpper, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.UpperChars, CharacterType.Letters,
    //             CharacterType.LettersAndDigits
    VowelsUpper =           0b0000_0000_0000_0000_0000_0000_0000_0100_1000_0010_0000_0000UL,

    // Includes: CharacterType._UpperF, CharacterType._UpperG, CharacterType._SoftConsonantsUpper, CharacterType._UpperY
    // IncludedBy: CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars,
    //             CharacterType.UpperChars, CharacterType.Letters, CharacterType.LettersAndDigits
    SoftConsonantsUpper =   0b0000_0000_0000_0000_0000_0000_0000_0110_0110_0000_0000_0000UL,

    // Includes: CharacterType._UpperB, CharacterType._UpperC, CharacterType._UpperD, CharacterType._UpperF, CharacterType._UpperG, CharacterType._HardConsonantsUpper, CharacterType.HardConsonantsUpper, CharacterType._SoftConsonantsUpper, CharacterType._UpperY, CharacterType.SoftConsonantsUpper
    // IncludedBy: CharacterType.AsciiLettersUpper, CharacterType.Consonants, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.UpperChars, CharacterType.Letters,
    //             CharacterType.LettersAndDigits
    ConsonantsUpper =       0b0000_0000_0000_0000_0000_0000_0000_0111_0111_1100_0000_0000UL,

    // Includes: CharacterType._HexDigitVowelsUpper, CharacterType._UpperB, CharacterType._UpperC, CharacterType._UpperD, CharacterType._UpperF, CharacterType._UpperG, CharacterType._VowelsUpper, CharacterType._HardConsonantsUpper, CharacterType.HardConsonantsUpper,
    //             CharacterType._SoftConsonantsUpper, CharacterType._UpperY, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper
    // IncludedBy: CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.UpperChars, CharacterType.Letters, CharacterType.LettersAndDigits
    AsciiLettersUpper =     0b0000_0000_0000_0000_0000_0000_0000_0111_1111_1110_0000_0000UL,

    // IncludedBy: CharacterType.AsciiPunctuation, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.PunctuationChars
    Underscore =            0b0000_0000_0000_0000_0000_0000_0000_1000_0000_0000_0000_0000UL,

    // Includes: CharacterType._AsciiPunctuation, CharacterType.Dash, CharacterType.Period, CharacterType.Underscore
    // IncludedBy: CharacterType.AsciiChars, CharacterType.PunctuationChars
    AsciiPunctuation =      0b0000_0000_0000_0000_0000_0000_0000_1000_0000_0001_1000_1000UL,

    // IncludedBy: CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars,
    //             CharacterType.AsciiChars, CharacterType.LowerChars, CharacterType.Letters, CharacterType.LettersAndDigits
    _HexDigitVowelsLower =  0b0000_0000_0000_0000_0000_0000_0001_0000_0000_0000_0000_0000UL,

    // IncludedBy: CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters,
    //             CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.LowerChars, CharacterType.Letters, CharacterType.LettersAndDigits
    _LowerB =               0b0000_0000_0000_0000_0000_0000_0010_0000_0000_0000_0000_0000UL,

    // IncludedBy: CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters,
    //             CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.LowerChars, CharacterType.Letters, CharacterType.LettersAndDigits
    _LowerC =               0b0000_0000_0000_0000_0000_0000_0100_0000_0000_0000_0000_0000UL,

    // IncludedBy: CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters,
    //             CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.LowerChars, CharacterType.Letters, CharacterType.LettersAndDigits
    _LowerD =               0b0000_0000_0000_0000_0000_0000_1000_0000_0000_0000_0000_0000UL,

    // IncludedBy: CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters,
    //             CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.LowerChars, CharacterType.Letters, CharacterType.LettersAndDigits
    _LowerF =               0b0000_0000_0000_0000_0000_0001_0000_0000_0000_0000_0000_0000UL,

    // Includes: CharacterType.AsciiDigits, CharacterType._HexDigitVowelsLower, CharacterType._LowerB, CharacterType._LowerC, CharacterType._LowerD, CharacterType._LowerF
    // IncludedBy: CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.LettersAndDigits
    AsciiHexDigitsLower =   0b0000_0000_0000_0000_0000_0001_1111_0000_0000_0000_0001_0000UL,

    // Includes: CharacterType.AsciiDigits, CharacterType._HexDigitVowelsUpper, CharacterType._UpperB, CharacterType._UpperC, CharacterType._UpperD, CharacterType._UpperF, CharacterType.AsciiHexDigitsUpper, CharacterType._HexDigitVowelsLower, CharacterType._LowerB, CharacterType._LowerC,
    //             CharacterType._LowerD, CharacterType._LowerF, CharacterType.AsciiHexDigitsLower
    // IncludedBy: CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.LettersAndDigits
    AsciiHexDigits =        0b0000_0000_0000_0000_0000_0001_1111_0000_0011_1110_0001_0000UL,

    // IncludedBy: CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters,
    //             CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.LowerChars, CharacterType.Letters, CharacterType.LettersAndDigits
    _LowerG =               0b0000_0000_0000_0000_0000_0010_0000_0000_0000_0000_0000_0000UL,

    // IncludedBy: CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.LowerChars,
    //             CharacterType.Letters, CharacterType.LettersAndDigits
    _VowelsLower =          0b0000_0000_0000_0000_0000_0100_0000_0000_0000_0000_0000_0000UL,

    // IncludedBy: CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars,
    //             CharacterType.AsciiChars, CharacterType.LowerChars, CharacterType.Letters, CharacterType.LettersAndDigits
    _HardConsonantsLower =  0b0000_0000_0000_0000_0000_1000_0000_0000_0000_0000_0000_0000UL,

    // Includes: CharacterType._LowerB, CharacterType._LowerC, CharacterType._LowerD, CharacterType._LowerG, CharacterType._HardConsonantsLower
    // IncludedBy: CharacterType.HardConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars,
    //             CharacterType.LowerChars, CharacterType.Letters, CharacterType.LettersAndDigits
    HardConsonantsLower =   0b0000_0000_0000_0000_0000_1010_1110_0000_0000_0000_0000_0000UL,

    // Includes: CharacterType._UpperB, CharacterType._UpperC, CharacterType._UpperD, CharacterType._UpperG, CharacterType._HardConsonantsUpper, CharacterType.HardConsonantsUpper, CharacterType._LowerB, CharacterType._LowerC, CharacterType._LowerD, CharacterType._LowerG,
    //             CharacterType._HardConsonantsLower, CharacterType.HardConsonantsLower
    // IncludedBy: CharacterType.Consonants, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.Letters, CharacterType.LettersAndDigits
    HardConsonants =        0b0000_0000_0000_0000_0000_1010_1110_0001_0101_1100_0000_0000UL,

    // IncludedBy: CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars,
    //             CharacterType.AsciiChars, CharacterType.LowerChars, CharacterType.Letters, CharacterType.LettersAndDigits
    _SoftConsonantsLower =  0b0000_0000_0000_0000_0001_0000_0000_0000_0000_0000_0000_0000UL,

    // IncludedBy: CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits,
    //             CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.LowerChars, CharacterType.Letters, CharacterType.LettersAndDigits
    _LowerY =               0b0000_0000_0000_0000_0010_0000_0000_0000_0000_0000_0000_0000UL,

    // Includes: CharacterType._HexDigitVowelsLower, CharacterType._VowelsLower, CharacterType._LowerY
    // IncludedBy: CharacterType.Vowels, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.LowerChars, CharacterType.Letters,
    //             CharacterType.LettersAndDigits
    VowelsLower =           0b0000_0000_0000_0000_0010_0100_0001_0000_0000_0000_0000_0000UL,

    // Includes: CharacterType._HexDigitVowelsUpper, CharacterType._VowelsUpper, CharacterType._UpperY, CharacterType.VowelsUpper, CharacterType._HexDigitVowelsLower, CharacterType._VowelsLower, CharacterType._LowerY, CharacterType.VowelsLower
    // IncludedBy: CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.Letters, CharacterType.LettersAndDigits
    Vowels =                0b0000_0000_0000_0000_0010_0100_0001_0100_1000_0010_0000_0000UL,

    // Includes: CharacterType._LowerF, CharacterType._LowerG, CharacterType._SoftConsonantsLower, CharacterType._LowerY
    // IncludedBy: CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars,
    //             CharacterType.LowerChars, CharacterType.Letters, CharacterType.LettersAndDigits
    SoftConsonantsLower =   0b0000_0000_0000_0000_0011_0011_0000_0000_0000_0000_0000_0000UL,

    // Includes: CharacterType._UpperF, CharacterType._UpperG, CharacterType._SoftConsonantsUpper, CharacterType._UpperY, CharacterType.SoftConsonantsUpper, CharacterType._LowerF, CharacterType._LowerG, CharacterType._SoftConsonantsLower, CharacterType._LowerY, CharacterType.SoftConsonantsLower
    // IncludedBy: CharacterType.Consonants, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.Letters, CharacterType.LettersAndDigits
    SoftConsonants =        0b0000_0000_0000_0000_0011_0011_0000_0110_0110_0000_0000_0000UL,

    // Includes: CharacterType._LowerB, CharacterType._LowerC, CharacterType._LowerD, CharacterType._LowerF, CharacterType._LowerG, CharacterType._HardConsonantsLower, CharacterType.HardConsonantsLower, CharacterType._SoftConsonantsLower, CharacterType._LowerY, CharacterType.SoftConsonantsLower
    // IncludedBy: CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.LowerChars, CharacterType.Letters,
    //             CharacterType.LettersAndDigits
    ConsonantsLower =       0b0000_0000_0000_0000_0011_1011_1110_0000_0000_0000_0000_0000UL,

    // Includes: CharacterType._UpperB, CharacterType._UpperC, CharacterType._UpperD, CharacterType._UpperF, CharacterType._UpperG, CharacterType._HardConsonantsUpper, CharacterType.HardConsonantsUpper, CharacterType._SoftConsonantsUpper, CharacterType._UpperY, CharacterType.SoftConsonantsUpper,
    //             CharacterType.ConsonantsUpper, CharacterType._LowerB, CharacterType._LowerC, CharacterType._LowerD, CharacterType._LowerF, CharacterType._LowerG, CharacterType._HardConsonantsLower, CharacterType.HardConsonantsLower, CharacterType.HardConsonants,
    //             CharacterType._SoftConsonantsLower, CharacterType._LowerY, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower
    // IncludedBy: CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.Letters, CharacterType.LettersAndDigits
    Consonants =            0b0000_0000_0000_0000_0011_1011_1110_0111_0111_1100_0000_0000UL,

    // Includes: CharacterType._HexDigitVowelsLower, CharacterType._LowerB, CharacterType._LowerC, CharacterType._LowerD, CharacterType._LowerF, CharacterType._LowerG, CharacterType._VowelsLower, CharacterType._HardConsonantsLower, CharacterType.HardConsonantsLower,
    //             CharacterType._SoftConsonantsLower, CharacterType._LowerY, CharacterType.VowelsLower, CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower
    // IncludedBy: CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.LowerChars, CharacterType.Letters, CharacterType.LettersAndDigits
    AsciiLettersLower =     0b0000_0000_0000_0000_0011_1111_1111_0000_0000_0000_0000_0000UL,

    // Includes: CharacterType._HexDigitVowelsUpper, CharacterType._UpperB, CharacterType._UpperC, CharacterType._UpperD, CharacterType._UpperF, CharacterType._UpperG, CharacterType._VowelsUpper, CharacterType._HardConsonantsUpper, CharacterType.HardConsonantsUpper,
    //             CharacterType._SoftConsonantsUpper, CharacterType._UpperY, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper, CharacterType._HexDigitVowelsLower, CharacterType._LowerB, CharacterType._LowerC,
    //             CharacterType._LowerD, CharacterType._LowerF, CharacterType._LowerG, CharacterType._VowelsLower, CharacterType._HardConsonantsLower, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType._SoftConsonantsLower, CharacterType._LowerY,
    //             CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower
    // IncludedBy: CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.Letters, CharacterType.LettersAndDigits
    AsciiLetters =          0b0000_0000_0000_0000_0011_1111_1111_0111_1111_1110_0000_0000UL,

    // Includes: CharacterType.AsciiDigits, CharacterType._HexDigitVowelsUpper, CharacterType._UpperB, CharacterType._UpperC, CharacterType._UpperD, CharacterType._UpperF, CharacterType.AsciiHexDigitsUpper, CharacterType._UpperG, CharacterType._VowelsUpper, CharacterType._HardConsonantsUpper,
    //             CharacterType.HardConsonantsUpper, CharacterType._SoftConsonantsUpper, CharacterType._UpperY, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper, CharacterType._HexDigitVowelsLower, CharacterType._LowerB,
    //             CharacterType._LowerC, CharacterType._LowerD, CharacterType._LowerF, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType._LowerG, CharacterType._VowelsLower, CharacterType._HardConsonantsLower, CharacterType.HardConsonantsLower,
    //             CharacterType.HardConsonants, CharacterType._SoftConsonantsLower, CharacterType._LowerY, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants,
    //             CharacterType.AsciiLettersLower, CharacterType.AsciiLetters
    // IncludedBy: CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.LettersAndDigits
    AsciiLettersAndDigits = 0b0000_0000_0000_0000_0011_1111_1111_0111_1111_1110_0001_0000UL,

    // Includes: CharacterType.AsciiDigits, CharacterType._HexDigitVowelsUpper, CharacterType._UpperB, CharacterType._UpperC, CharacterType._UpperD, CharacterType._UpperF, CharacterType.AsciiHexDigitsUpper, CharacterType._UpperG, CharacterType._VowelsUpper, CharacterType._HardConsonantsUpper,
    //             CharacterType.HardConsonantsUpper, CharacterType._SoftConsonantsUpper, CharacterType._UpperY, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper, CharacterType.Underscore,
    //             CharacterType._HexDigitVowelsLower, CharacterType._LowerB, CharacterType._LowerC, CharacterType._LowerD, CharacterType._LowerF, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType._LowerG, CharacterType._VowelsLower, CharacterType._HardConsonantsLower,
    //             CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType._SoftConsonantsLower, CharacterType._LowerY, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower,
    //             CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits
    // IncludedBy: CharacterType.UriDataChars, CharacterType.AsciiChars
    CsIdentifierChars =     0b0000_0000_0000_0000_0011_1111_1111_1111_1111_1110_0001_0000UL,

    // IncludedBy: CharacterType.AsciiSymbols, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.Symbols
    Tilde =                 0b0000_0000_0000_0000_0100_0000_0000_0000_0000_0000_0000_0000UL,

    // Includes: CharacterType._AsciiSymbols, CharacterType.Plus, CharacterType.Tilde
    // IncludedBy: CharacterType.AsciiChars, CharacterType.Symbols
    AsciiSymbols =          0b0000_0000_0000_0000_0100_0000_0000_0000_0000_0000_0110_0000UL,

    // Includes: CharacterType.AsciiDigits, CharacterType.Dash, CharacterType.Period, CharacterType._HexDigitVowelsUpper, CharacterType._UpperB, CharacterType._UpperC, CharacterType._UpperD, CharacterType._UpperF, CharacterType.AsciiHexDigitsUpper, CharacterType._UpperG,
    //             CharacterType._VowelsUpper, CharacterType._HardConsonantsUpper,CharacterType.HardConsonantsUpper, CharacterType._SoftConsonantsUpper, CharacterType._UpperY, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
    //             CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType._HexDigitVowelsLower, CharacterType._LowerB, CharacterType._LowerC, CharacterType._LowerD, CharacterType._LowerF, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType._LowerG,
    //             CharacterType._VowelsLower, CharacterType._HardConsonantsLower, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType._SoftConsonantsLower, CharacterType._LowerY, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower,
    //             CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.Tilde
    // IncludedBy: CharacterType.AsciiChars
    UriDataChars =          0b0000_0000_0000_0000_0111_1111_1111_1111_1111_1111_1001_0000UL,

    // Includes: CharacterType.AsciiControlChars, CharacterType.Space, CharacterType._AsciiPunctuation, CharacterType.AsciiDigits, CharacterType._AsciiSymbols, CharacterType.Plus, CharacterType.Dash, CharacterType.Period, CharacterType._HexDigitVowelsUpper, CharacterType._UpperB,
    //             CharacterType._UpperC, CharacterType._UpperD, CharacterType._UpperF, CharacterType.AsciiHexDigitsUpper, CharacterType._UpperG, CharacterType._VowelsUpper, CharacterType._HardConsonantsUpper, CharacterType.HardConsonantsUpper, CharacterType._SoftConsonantsUpper,
    //             CharacterType._UpperY, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType._HexDigitVowelsLower, CharacterType._LowerB,
    //             CharacterType._LowerC, CharacterType._LowerD, CharacterType._LowerF, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType._LowerG, CharacterType._VowelsLower, CharacterType._HardConsonantsLower, CharacterType.HardConsonantsLower,
    //             CharacterType.HardConsonants, CharacterType._SoftConsonantsLower, CharacterType._LowerY, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants,
    //             CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.UriDataChars
    AsciiChars =            0b0000_0000_0000_0000_0111_1111_1111_1111_1111_1111_1111_1011UL,

    // Includes: CharacterType.AsciiControlChars
    ControlChars =          0b0000_0000_0000_0000_1000_0000_0000_0000_0000_0000_0000_0001UL,

    // Includes: CharacterType._AsciiPunctuation, CharacterType.Dash, CharacterType.Period, CharacterType.Underscore, CharacterType.AsciiPunctuation
    PunctuationChars =      0b0000_0000_0000_0001_0000_0000_0000_1000_0000_0001_1000_1000UL,

    // Includes: CharacterType._AsciiSymbols, CharacterType.Plus, CharacterType.Tilde, CharacterType.AsciiSymbols
    Symbols =               0b0000_0000_0000_0010_0100_0000_0000_0000_0000_0000_0110_0000UL,

    // Includes: CharacterType.Space, CharacterType.Separators
    WhiteSpaceChars =       0b0000_0000_0000_0100_0000_0000_0000_0000_0000_0000_0000_0110UL,

    // Includes: CharacterType.AsciiDigits
    // IncludedBy: CharacterType.Numbers, CharacterType.LettersAndDigits
    Digits =                0b0000_0000_0000_1000_0000_0000_0000_0000_0000_0000_0001_0000UL,

    // Includes: CharacterType.AsciiDigits, CharacterType.Digits
    Numbers =               0b0000_0000_0001_1000_0000_0000_0000_0000_0000_0000_0001_0000UL,

    // Includes: CharacterType._HexDigitVowelsUpper, CharacterType._UpperB, CharacterType._UpperC, CharacterType._UpperD, CharacterType._UpperF, CharacterType._UpperG, CharacterType._VowelsUpper, CharacterType._HardConsonantsUpper, CharacterType.HardConsonantsUpper,
    //             CharacterType._SoftConsonantsUpper, CharacterType._UpperY, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper
    // IncludedBy: CharacterType.Letters, CharacterType.LettersAndDigits
    UpperChars =            0b0000_0000_0010_0000_0000_0000_0000_0111_1111_1110_0000_0000UL,

    // Includes: CharacterType._HexDigitVowelsLower, CharacterType._LowerB, CharacterType._LowerC, CharacterType._LowerD, CharacterType._LowerF, CharacterType._LowerG, CharacterType._VowelsLower, CharacterType._HardConsonantsLower, CharacterType.HardConsonantsLower,
    //             CharacterType._SoftConsonantsLower, CharacterType._LowerY, CharacterType.VowelsLower, CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.AsciiLettersLower
    // IncludedBy: CharacterType.Letters, CharacterType.LettersAndDigits
    LowerChars =            0b0000_0000_0100_0000_0011_1111_1111_0000_0000_0000_0000_0000UL,

    // Includes: CharacterType._HexDigitVowelsUpper, CharacterType._UpperB, CharacterType._UpperC, CharacterType._UpperD, CharacterType._UpperF, CharacterType._UpperG, CharacterType._VowelsUpper, CharacterType._HardConsonantsUpper, CharacterType.HardConsonantsUpper,
    //             CharacterType._SoftConsonantsUpper, CharacterType._UpperY, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper, CharacterType._HexDigitVowelsLower, CharacterType._LowerB, CharacterType._LowerC,
    //             CharacterType._LowerD, CharacterType._LowerF, CharacterType._LowerG, CharacterType._VowelsLower, CharacterType._HardConsonantsLower, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType._SoftConsonantsLower, CharacterType._LowerY,
    //             CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.UpperChars,
    //             CharacterType.LowerChars
    // IncludedBy: CharacterType.LettersAndDigits
    Letters =               0b0000_0000_1110_0000_0011_1111_1111_0111_1111_1110_0000_0000UL,

    // Includes: CharacterType.AsciiDigits, CharacterType._HexDigitVowelsUpper, CharacterType._UpperB, CharacterType._UpperC, CharacterType._UpperD, CharacterType._UpperF, CharacterType.AsciiHexDigitsUpper, CharacterType._UpperG, CharacterType._VowelsUpper, CharacterType._HardConsonantsUpper,
    //             CharacterType.HardConsonantsUpper, CharacterType._SoftConsonantsUpper, CharacterType._UpperY, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper, CharacterType._HexDigitVowelsLower, CharacterType._LowerB,
    //             CharacterType._LowerC, CharacterType._LowerD, CharacterType._LowerF, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType._LowerG, CharacterType._VowelsLower, CharacterType._HardConsonantsLower, CharacterType.HardConsonantsLower,
    //             CharacterType.HardConsonants, CharacterType._SoftConsonantsLower, CharacterType._LowerY, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants,
    //             CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.Digits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.Letters
    LettersAndDigits =      0b0000_0000_1110_1000_0011_1111_1111_0111_1111_1110_0001_0000UL,

    // IncludedBy: CharacterType.Surrogates
    HighSurrogates =        0b0000_0001_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000UL,

    // IncludedBy: CharacterType.Surrogates
    LowSurrogates =         0b0000_0010_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000UL,

    // Includes: CharacterType.HighSurrogates, CharacterType.LowSurrogates
    Surrogates =            0b0000_0011_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000UL
}