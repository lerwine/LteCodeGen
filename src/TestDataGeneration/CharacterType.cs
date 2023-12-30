using static TestDataGeneration.CharacterTypes;

namespace TestDataGeneration;

[Flags]
public enum CharacterType : ulong
{
    // IncludedBy: CharacterType.AsciiChars
    /// <summary>
    /// 
    /// </summary>
    AsciiControlChars = Flag_AsciiNonWsControlChars,

    // IncludedBy: CharacterType.Separators, CharacterType.AsciiChars, CharacterType.WhiteSpaceChars
    Space = Flag_Space,

    // Includes: CharacterType.Space
    // IncludedBy: CharacterType.WhiteSpaceChars
    Separators = Flag_Space | Flag_NonAsciiSeparator,

    // IncludedBy: CharacterType.AsciiHexDigitsUpper, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars,
    //             CharacterType.AsciiChars, CharacterType.Digits, CharacterType.Digits, CharacterType.LettersAndDigits
    AsciiDigits = Flag_AsciiDigits,

    // IncludedBy: CharacterType.AsciiSymbols, CharacterType.AsciiChars, CharacterType.Symbols
    Plus = Flag_Plus,

    // IncludedBy: CharacterType.AsciiPunctuation, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.PunctuationChars
    Dash = Flag_Dash,

    // IncludedBy: CharacterType.AsciiPunctuation, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.PunctuationChars
    Period = Flag_Period,

    // Includes: CharacterType.AsciiDigits
    // IncludedBy: CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.LettersAndDigits
    AsciiHexDigitsUpper = Flag_AsciiDigits | Flag_HexDigitVowelsUpper | Flag_UpperB | Flag_UpperC | Flag_UpperD | Flag_UpperF,

    // IncludedBy: CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper, CharacterType.HardConsonants, CharacterType.Consonants, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits,
    //             CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.UpperChars, CharacterType.Letters, CharacterType.LettersAndDigits
    HardConsonantsUpper = Flag_UpperB | Flag_UpperC | Flag_UpperD | Flag_HardConsonantsUpper,

    // IncludedBy: CharacterType.AsciiLettersUpper, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars,
    //             CharacterType.AsciiChars, CharacterType.UpperChars, CharacterType.Letters, CharacterType.LettersAndDigits
    VowelsUpper = Flag_HexDigitVowelsUpper | Flag_VowelsUpper | Flag_UpperY,

    // IncludedBy: CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits,
    //             CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.UpperChars, CharacterType.Letters, CharacterType.LettersAndDigits
    SoftConsonantsUpper = Flag_UpperC | Flag_UpperF | Flag_SoftConsonantsUpper | Flag_UpperY,

    // Includes: CharacterType.HardConsonantsUpper, CharacterType.SoftConsonantsUpper
    // IncludedBy: CharacterType.AsciiLettersUpper, CharacterType.Consonants, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars,
    //             CharacterType.AsciiChars, CharacterType.UpperChars, CharacterType.Letters, CharacterType.LettersAndDigits
    ConsonantsUpper = Flag_UpperB | Flag_UpperC | Flag_UpperD | Flag_UpperF | Flag_HardConsonantsUpper | Flag_SoftConsonantsUpper | Flag_UpperY,

    // Includes: CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper
    // IncludedBy: CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.UpperChars, CharacterType.Letters,
    //             CharacterType.LettersAndDigits
    AsciiLettersUpper = Flag_HexDigitVowelsUpper | Flag_UpperB | Flag_UpperC | Flag_UpperD | Flag_UpperF | Flag_VowelsUpper | Flag_HardConsonantsUpper | Flag_SoftConsonantsUpper | Flag_UpperY,

    // IncludedBy: CharacterType.AsciiPunctuation, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.PunctuationChars
    Underscore = Flag_Underscore,

    // Includes: CharacterType.Dash, CharacterType.Period, CharacterType.Underscore
    // IncludedBy: CharacterType.AsciiChars, CharacterType.PunctuationChars
    AsciiPunctuation = Flag_AsciiPunctuation | Flag_Dash | Flag_Period | Flag_Underscore,

    // Includes: CharacterType.AsciiDigits
    // IncludedBy: CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.LettersAndDigits
    AsciiHexDigitsLower = Flag_AsciiDigits | Flag_HexDigitVowelsLower | Flag_LowerB | Flag_LowerC | Flag_LowerD | Flag_LowerF,

    // Includes: CharacterType.AsciiDigits, CharacterType.AsciiHexDigitsUpper, CharacterType.AsciiHexDigitsLower
    // IncludedBy: CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.LettersAndDigits
    AsciiHexDigits = Flag_AsciiDigits | Flag_HexDigitVowelsUpper | Flag_UpperB | Flag_UpperC | Flag_UpperD | Flag_UpperF | Flag_HexDigitVowelsLower | Flag_LowerB | Flag_LowerC | Flag_LowerD | Flag_LowerF,

    // IncludedBy: CharacterType.HardConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits,
    //             CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.LowerChars, CharacterType.Letters, CharacterType.LettersAndDigits
    HardConsonantsLower = Flag_LowerB | Flag_LowerC | Flag_LowerD | Flag_HardConsonantsLower,

    // Includes: CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower
    // IncludedBy: CharacterType.Consonants, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.Letters,
    //             CharacterType.LettersAndDigits
    HardConsonants = Flag_UpperB | Flag_UpperC | Flag_UpperD | Flag_HardConsonantsUpper | Flag_LowerB | Flag_LowerC | Flag_LowerD | Flag_HardConsonantsLower,

    // IncludedBy: CharacterType.Vowels, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars,
    //             CharacterType.AsciiChars, CharacterType.LowerChars, CharacterType.Letters, CharacterType.LettersAndDigits
    VowelsLower = Flag_HexDigitVowelsLower | Flag_VowelsLower | Flag_LowerY,

    // Includes: CharacterType.VowelsUpper, CharacterType.VowelsLower
    // IncludedBy: CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.Letters,
    //             CharacterType.LettersAndDigits
    Vowels = Flag_HexDigitVowelsUpper | Flag_VowelsUpper | Flag_UpperY | Flag_HexDigitVowelsLower | Flag_VowelsLower | Flag_LowerY,

    // IncludedBy: CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits,
    //             CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.LowerChars, CharacterType.Letters, CharacterType.LettersAndDigits
    SoftConsonantsLower = Flag_LowerC | Flag_LowerF | Flag_SoftConsonantsLower | Flag_LowerY,

    // Includes: CharacterType.SoftConsonantsUpper, CharacterType.SoftConsonantsLower
    // IncludedBy: CharacterType.Consonants, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.Letters,
    //             CharacterType.LettersAndDigits
    SoftConsonants = Flag_UpperC | Flag_UpperF | Flag_SoftConsonantsUpper | Flag_UpperY | Flag_LowerC | Flag_LowerF | Flag_SoftConsonantsLower | Flag_LowerY,

    // Includes: CharacterType.HardConsonantsLower, CharacterType.SoftConsonantsLower
    // IncludedBy: CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars,
    //             CharacterType.AsciiChars, CharacterType.LowerChars, CharacterType.Letters, CharacterType.LettersAndDigits
    ConsonantsLower = Flag_LowerB | Flag_LowerC | Flag_LowerD | Flag_LowerF | Flag_HardConsonantsLower | Flag_SoftConsonantsLower | Flag_LowerY,

    // Includes: CharacterType.HardConsonantsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsLower,
    //           CharacterType.SoftConsonants, CharacterType.ConsonantsLower
    // IncludedBy: CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.Letters,
    //             CharacterType.LettersAndDigits
    Consonants = Flag_UpperB | Flag_UpperC | Flag_UpperD | Flag_UpperF | Flag_HardConsonantsUpper | Flag_SoftConsonantsUpper | Flag_UpperY | Flag_LowerB | Flag_LowerC | Flag_LowerD | Flag_LowerF |
        Flag_HardConsonantsLower | Flag_SoftConsonantsLower | Flag_LowerY,

    // Includes: CharacterType.HardConsonantsLower, CharacterType.VowelsLower, CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower
    // IncludedBy: CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.LowerChars, CharacterType.Letters,
    //             CharacterType.LettersAndDigits
    AsciiLettersLower = Flag_HexDigitVowelsLower | Flag_LowerB | Flag_LowerC | Flag_LowerD | Flag_LowerF | Flag_VowelsLower | Flag_HardConsonantsLower | Flag_SoftConsonantsLower | Flag_LowerY,

    // Includes: CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper, CharacterType.HardConsonantsLower,
    //           CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants,
    //           CharacterType.AsciiLettersLower
    // IncludedBy: CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.Letters, CharacterType.LettersAndDigits
    AsciiLetters = Flag_HexDigitVowelsUpper | Flag_UpperB | Flag_UpperC | Flag_UpperD | Flag_UpperF | Flag_VowelsUpper | Flag_HardConsonantsUpper | Flag_SoftConsonantsUpper | Flag_UpperY |
        Flag_HexDigitVowelsLower | Flag_LowerB | Flag_LowerC | Flag_LowerD | Flag_LowerF | Flag_VowelsLower | Flag_HardConsonantsLower | Flag_SoftConsonantsLower | Flag_LowerY,

    // Includes: CharacterType.AsciiDigits, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
    //           CharacterType.AsciiLettersUpper, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.VowelsLower,
    //           CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters
    // IncludedBy: CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.LettersAndDigits
    AsciiLettersAndDigits = Flag_AsciiDigits | Flag_HexDigitVowelsUpper | Flag_UpperB | Flag_UpperC | Flag_UpperD | Flag_UpperF | Flag_VowelsUpper | Flag_HardConsonantsUpper | Flag_SoftConsonantsUpper |
        Flag_UpperY | Flag_HexDigitVowelsLower | Flag_LowerB | Flag_LowerC | Flag_LowerD | Flag_LowerF | Flag_VowelsLower | Flag_HardConsonantsLower | Flag_SoftConsonantsLower | Flag_LowerY,

    // Includes: CharacterType.AsciiDigits, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
    //           CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower, CharacterType.HardConsonants,
    //           CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower,
    //           CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits
    // IncludedBy: CharacterType.UriDataChars, CharacterType.AsciiChars
    CsIdentifierChars = Flag_AsciiDigits | Flag_HexDigitVowelsUpper | Flag_UpperB | Flag_UpperC | Flag_UpperD | Flag_UpperF | Flag_VowelsUpper | Flag_HardConsonantsUpper | Flag_SoftConsonantsUpper |
        Flag_UpperY | Flag_Underscore | Flag_HexDigitVowelsLower | Flag_LowerB | Flag_LowerC | Flag_LowerD | Flag_LowerF | Flag_VowelsLower | Flag_HardConsonantsLower | Flag_SoftConsonantsLower | Flag_LowerY,

    // IncludedBy: CharacterType.AsciiSymbols, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.Symbols
    Tilde = Flag_Tilde,

    // Includes: CharacterType.Plus, CharacterType.Tilde
    // IncludedBy: CharacterType.AsciiChars, CharacterType.Symbols
    AsciiSymbols = Flag_AsciiSymbols | Flag_Plus | Flag_Tilde,

    // Includes: CharacterType.AsciiDigits, CharacterType.Dash, CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper,
    //           CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower,
    //           CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants,
    //           CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.Tilde
    // IncludedBy: CharacterType.AsciiChars
    UriDataChars = Flag_AsciiDigits | Flag_Dash | Flag_Period | Flag_HexDigitVowelsUpper | Flag_UpperB | Flag_UpperC | Flag_UpperD | Flag_UpperF | Flag_VowelsUpper | Flag_HardConsonantsUpper |
        Flag_SoftConsonantsUpper | Flag_UpperY | Flag_Underscore | Flag_HexDigitVowelsLower | Flag_LowerB | Flag_LowerC | Flag_LowerD | Flag_LowerF | Flag_VowelsLower | Flag_HardConsonantsLower |
        Flag_SoftConsonantsLower | Flag_LowerY | Flag_Tilde,

    // Includes: CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash, CharacterType.Period, CharacterType.AsciiHexDigitsUpper,
    //           CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper, CharacterType.Underscore,
    //           CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.VowelsLower,
    //           CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters,
    //           CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.UriDataChars
    AsciiChars = Flag_AsciiNonWsControlChars | Flag_Space | Flag_AsciiPunctuation | Flag_AsciiDigits | Flag_AsciiSymbols | Flag_Plus | Flag_Dash | Flag_Period | Flag_HexDigitVowelsUpper | Flag_UpperB | Flag_UpperC |
        Flag_UpperD | Flag_UpperF | Flag_VowelsUpper | Flag_HardConsonantsUpper | Flag_SoftConsonantsUpper | Flag_UpperY | Flag_Underscore | Flag_HexDigitVowelsLower | Flag_LowerB | Flag_LowerC |
        Flag_LowerD | Flag_LowerF | Flag_VowelsLower | Flag_HardConsonantsLower | Flag_SoftConsonantsLower | Flag_LowerY | Flag_Tilde,

    // Includes: CharacterType.Dash, CharacterType.Period, CharacterType.Underscore, CharacterType.AsciiPunctuation
    PunctuationChars = Flag_AsciiPunctuation | Flag_Dash | Flag_Period | Flag_Underscore | Flag_NonAsciiPunctuationChars,

    // Includes: CharacterType.Plus, CharacterType.Tilde, CharacterType.AsciiSymbols
    Symbols = Flag_AsciiSymbols | Flag_Plus | Flag_Tilde | Flag_NonAsciiSymbols,

    // Includes: CharacterType.Space, CharacterType.Separators
    WhiteSpaceChars = Flag_Space | Flag_NonAsciiSeparator | Flag_NonSeparatorWhiteSpace,

    // Includes: CharacterType.AsciiDigits
    // IncludedBy: CharacterType.Digits, CharacterType.LettersAndDigits
    Numbers = Flag_AsciiDigits | Flag_NonAsciiNumbers,

    // Includes: CharacterType.AsciiDigits, CharacterType.Digits
    Digits = Flag_AsciiDigits | Flag_NonAsciiNumbers | Flag_NonAsciiDigits,

    // Includes: CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper
    // IncludedBy: CharacterType.Letters, CharacterType.LettersAndDigits
    UpperChars = Flag_HexDigitVowelsUpper | Flag_UpperB | Flag_UpperC | Flag_UpperD | Flag_UpperF | Flag_VowelsUpper | Flag_HardConsonantsUpper | Flag_SoftConsonantsUpper | Flag_UpperY | Flag_UpperNonAsciiChars,

    // Includes: CharacterType.HardConsonantsLower, CharacterType.VowelsLower, CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.AsciiLettersLower
    // IncludedBy: CharacterType.Letters, CharacterType.LettersAndDigits
    LowerChars = Flag_HexDigitVowelsLower | Flag_LowerB | Flag_LowerC | Flag_LowerD | Flag_LowerF | Flag_VowelsLower | Flag_HardConsonantsLower | Flag_SoftConsonantsLower | Flag_LowerY | Flag_LowerNonAsciiChars,

    // Includes: CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper, CharacterType.HardConsonantsLower,
    //           CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants,
    //           CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.UpperChars, CharacterType.LowerChars
    // IncludedBy: CharacterType.LettersAndDigits
    Letters = Flag_HexDigitVowelsUpper | Flag_UpperB | Flag_UpperC | Flag_UpperD | Flag_UpperF | Flag_VowelsUpper | Flag_HardConsonantsUpper | Flag_SoftConsonantsUpper | Flag_UpperY |
        Flag_HexDigitVowelsLower | Flag_LowerB | Flag_LowerC | Flag_LowerD | Flag_LowerF | Flag_VowelsLower | Flag_HardConsonantsLower | Flag_SoftConsonantsLower | Flag_LowerY | Flag_UpperNonAsciiChars |
        Flag_LowerNonAsciiChars | Flag_NonAsciiNonCaseLetters,

    // Includes: CharacterType.AsciiDigits, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
    //           CharacterType.AsciiLettersUpper, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.VowelsLower,
    //           CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters,
    //           CharacterType.AsciiLettersAndDigits, CharacterType.Digits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.Letters
    LettersAndDigits = Flag_AsciiDigits | Flag_HexDigitVowelsUpper | Flag_UpperB | Flag_UpperC | Flag_UpperD | Flag_UpperF | Flag_VowelsUpper | Flag_HardConsonantsUpper | Flag_SoftConsonantsUpper |
        Flag_UpperY | Flag_HexDigitVowelsLower | Flag_LowerB | Flag_LowerC | Flag_LowerD | Flag_LowerF | Flag_VowelsLower | Flag_HardConsonantsLower | Flag_SoftConsonantsLower | Flag_LowerY | Flag_NonAsciiNumbers |
        Flag_UpperNonAsciiChars | Flag_LowerNonAsciiChars | Flag_NonAsciiNonCaseLetters,

    // IncludedBy: CharacterType.Surrogates
    HighSurrogates = Flag_HighSurrogates,

    // IncludedBy: CharacterType.AsciiControlChars, CharacterType.AsciiChars
    ControlChars = Flag_NonAsciiNonWsControlChars | Flag_AsciiNonWsControlChars,

    // IncludedBy: CharacterType.Surrogates
    LowSurrogates = Flag_LowSurrogates,

    // Includes: CharacterType.HighSurrogates, CharacterType.LowSurrogates
    Surrogates = Flag_HighSurrogates | Flag_LowSurrogates
}