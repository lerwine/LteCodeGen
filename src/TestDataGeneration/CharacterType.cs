using static TestDataGeneration.CharacterTypes;

namespace TestDataGeneration;

[Flags]
public enum CharacterType : ulong
{
    /// <summary>
    /// Non-whitespace ASCII control characters.
    /// </summary>
    AsciiControlChars = Flag_AsciiNonWsControlChars | Flag_AsciiWhitespaceControlChars,

    /// <summary>
    /// Space character.
    /// </summary>
    Space = Flag_Space,

    /// <summary>
    /// Whitespace ASCII control characters.
    /// </summary>
    AsciiWhiteSpace = Flag_Space | Flag_AsciiWhitespaceControlChars,

    /// <summary>
    /// Separator characters.
    /// </summary>
    Separators = Flag_Space | Flag_NonAsciiSeparator,

    /// <summary>
    /// ASCII digits.
    /// </summary>
    AsciiDigits = Flag_AsciiDigits,

    /// <summary>
    /// The <c>+</c> symbol.
    /// </summary>
    Plus = Flag_Plus,

    /// <summary>
    /// The <c>-</c> punctuation character.
    /// </summary>
    Dash = Flag_Dash,

    /// <summary>
    /// The <c>.</c> punctuation character.
    /// </summary>
    Period = Flag_Period,

    /// <summary>
    /// ASCII digits, including upper-case hexidecimal letters.
    /// </summary>
    AsciiHexDigitsUpper = Flag_AsciiDigits | Flag_HexDigitVowelsUpper | Flag_UpperB | Flag_UpperC | Flag_UpperD | Flag_UpperF,

    /// <summary>
    /// Upper-case consonants.
    /// </summary>
    HardConsonantsUpper = Flag_UpperB | Flag_UpperC | Flag_UpperD | Flag_HardConsonantsUpper,

    /// <summary>
    /// Upper-case vowels
    /// </summary>
    VowelsUpper = Flag_HexDigitVowelsUpper | Flag_VowelsUpper | Flag_UpperY,

    /// <summary>
    /// Upper-case soft consonants.
    /// </summary>
    SoftConsonantsUpper = Flag_UpperC | Flag_UpperF | Flag_SoftConsonantsUpper | Flag_UpperY,

    /// <summary>
    /// All upper-case consonants.
    /// </summary>
    ConsonantsUpper = Flag_UpperB | Flag_UpperC | Flag_UpperD | Flag_UpperF | Flag_HardConsonantsUpper | Flag_SoftConsonantsUpper | Flag_UpperY,

    /// <summary>
    /// All ASCII upper-case letters.
    /// </summary>
    AsciiLettersUpper = Flag_HexDigitVowelsUpper | Flag_UpperB | Flag_UpperC | Flag_UpperD | Flag_UpperF | Flag_VowelsUpper | Flag_HardConsonantsUpper | Flag_SoftConsonantsUpper | Flag_UpperY,

    /// <summary>
    /// The <c>_</c> character.
    /// </summary>
    Underscore = Flag_Underscore,

    /// <summary>
    /// ASCII punctuation characters.
    /// </summary>
    AsciiPunctuation = Flag_AsciiPunctuation | Flag_Dash | Flag_Period | Flag_Underscore,

    /// <summary>
    /// ASCII digits, including lower-case hexidecimal letters.
    /// </summary>
    AsciiHexDigitsLower = Flag_AsciiDigits | Flag_HexDigitVowelsLower | Flag_LowerB | Flag_LowerC | Flag_LowerD | Flag_LowerF,

    /// <summary>
    /// ASCII digits, including hexidecimal letters.
    /// </summary>
    AsciiHexDigits = Flag_AsciiDigits | Flag_HexDigitVowelsUpper | Flag_UpperB | Flag_UpperC | Flag_UpperD | Flag_UpperF | Flag_HexDigitVowelsLower | Flag_LowerB | Flag_LowerC | Flag_LowerD | Flag_LowerF,

    /// <summary>
    /// Lower-case hard consonants.
    /// </summary>
    HardConsonantsLower = Flag_LowerB | Flag_LowerC | Flag_LowerD | Flag_HardConsonantsLower,

    /// <summary>
    /// All hard consonants.
    /// </summary>
    HardConsonants = Flag_UpperB | Flag_UpperC | Flag_UpperD | Flag_HardConsonantsUpper | Flag_LowerB | Flag_LowerC | Flag_LowerD | Flag_HardConsonantsLower,

    /// <summary>
    /// Lower-case vowels.
    /// </summary>
    VowelsLower = Flag_HexDigitVowelsLower | Flag_VowelsLower | Flag_LowerY,

    /// <summary>
    /// All Vowels.
    /// </summary>
    Vowels = Flag_HexDigitVowelsUpper | Flag_VowelsUpper | Flag_UpperY | Flag_HexDigitVowelsLower | Flag_VowelsLower | Flag_LowerY,

    /// <summary>
    /// Lower-case soft consonants.
    /// </summary>
    SoftConsonantsLower = Flag_LowerC | Flag_LowerF | Flag_SoftConsonantsLower | Flag_LowerY,

    /// <summary>
    /// All soft consonants.
    /// </summary>
    SoftConsonants = Flag_UpperC | Flag_UpperF | Flag_SoftConsonantsUpper | Flag_UpperY | Flag_LowerC | Flag_LowerF | Flag_SoftConsonantsLower | Flag_LowerY,

    /// <summary>
    /// All lower-case consonants.
    /// </summary>
    ConsonantsLower = Flag_LowerB | Flag_LowerC | Flag_LowerD | Flag_LowerF | Flag_HardConsonantsLower | Flag_SoftConsonantsLower | Flag_LowerY,

    /// <summary>
    /// All consonants.
    /// </summary>
    Consonants = Flag_UpperB | Flag_UpperC | Flag_UpperD | Flag_UpperF | Flag_HardConsonantsUpper | Flag_SoftConsonantsUpper | Flag_UpperY | Flag_LowerB | Flag_LowerC | Flag_LowerD | Flag_LowerF |
        Flag_HardConsonantsLower | Flag_SoftConsonantsLower | Flag_LowerY,

    /// <summary>
    /// All lower-case ASCII letters.
    /// </summary>
    AsciiLettersLower = Flag_HexDigitVowelsLower | Flag_LowerB | Flag_LowerC | Flag_LowerD | Flag_LowerF | Flag_VowelsLower | Flag_HardConsonantsLower | Flag_SoftConsonantsLower | Flag_LowerY,

    /// <summary>
    /// All ASCII letters.
    /// </summary>
    AsciiLetters = Flag_HexDigitVowelsUpper | Flag_UpperB | Flag_UpperC | Flag_UpperD | Flag_UpperF | Flag_VowelsUpper | Flag_HardConsonantsUpper | Flag_SoftConsonantsUpper | Flag_UpperY |
        Flag_HexDigitVowelsLower | Flag_LowerB | Flag_LowerC | Flag_LowerD | Flag_LowerF | Flag_VowelsLower | Flag_HardConsonantsLower | Flag_SoftConsonantsLower | Flag_LowerY,

    /// <summary>
    /// All ASCII letters and digits.
    /// </summary>
    AsciiLettersAndDigits = Flag_AsciiDigits | Flag_HexDigitVowelsUpper | Flag_UpperB | Flag_UpperC | Flag_UpperD | Flag_UpperF | Flag_VowelsUpper | Flag_HardConsonantsUpper | Flag_SoftConsonantsUpper |
        Flag_UpperY | Flag_HexDigitVowelsLower | Flag_LowerB | Flag_LowerC | Flag_LowerD | Flag_LowerF | Flag_VowelsLower | Flag_HardConsonantsLower | Flag_SoftConsonantsLower | Flag_LowerY,

    /// <summary>
    /// Basic characters for csharp identifier names.
    /// </summary>
    CsIdentifierChars = Flag_AsciiDigits | Flag_HexDigitVowelsUpper | Flag_UpperB | Flag_UpperC | Flag_UpperD | Flag_UpperF | Flag_VowelsUpper | Flag_HardConsonantsUpper | Flag_SoftConsonantsUpper |
        Flag_UpperY | Flag_Underscore | Flag_HexDigitVowelsLower | Flag_LowerB | Flag_LowerC | Flag_LowerD | Flag_LowerF | Flag_VowelsLower | Flag_HardConsonantsLower | Flag_SoftConsonantsLower | Flag_LowerY,

    /// <summary>
    /// The <c>~</c> character.
    /// </summary>
    Tilde = Flag_Tilde,

    /// <summary>
    /// ASCII symbol characters.
    /// </summary>
    AsciiSymbols = Flag_AsciiSymbols | Flag_Plus | Flag_Tilde,

    /// <summary>
    /// Characters which do not need to be encoded in a URL data string.
    /// </summary>
    UriDataChars = Flag_AsciiDigits | Flag_Dash | Flag_Period | Flag_HexDigitVowelsUpper | Flag_UpperB | Flag_UpperC | Flag_UpperD | Flag_UpperF | Flag_VowelsUpper | Flag_HardConsonantsUpper |
        Flag_SoftConsonantsUpper | Flag_UpperY | Flag_Underscore | Flag_HexDigitVowelsLower | Flag_LowerB | Flag_LowerC | Flag_LowerD | Flag_LowerF | Flag_VowelsLower | Flag_HardConsonantsLower |
        Flag_SoftConsonantsLower | Flag_LowerY | Flag_Tilde,

    /// <summary>
    /// All ASCII characters.
    /// </summary>
    AsciiChars = Flag_AsciiNonWsControlChars | Flag_AsciiWhitespaceControlChars | Flag_Space | Flag_AsciiPunctuation | Flag_AsciiDigits | Flag_AsciiSymbols | Flag_Plus | Flag_Dash | Flag_Period |
        Flag_HexDigitVowelsUpper | Flag_UpperB | Flag_UpperC | Flag_UpperD | Flag_UpperF | Flag_VowelsUpper | Flag_HardConsonantsUpper | Flag_SoftConsonantsUpper | Flag_UpperY | Flag_Underscore |
        Flag_HexDigitVowelsLower | Flag_LowerB | Flag_LowerC | Flag_LowerD | Flag_LowerF | Flag_VowelsLower | Flag_HardConsonantsLower | Flag_SoftConsonantsLower | Flag_LowerY | Flag_Tilde,

    /// <summary>
    /// All punctuation characters.
    /// </summary>
    PunctuationChars = Flag_AsciiPunctuation | Flag_Dash | Flag_Period | Flag_Underscore | Flag_NonAsciiPunctuationChars,

    /// <summary>
    /// All symbol characters.
    /// </summary>
    Symbols = Flag_AsciiSymbols | Flag_Plus | Flag_Tilde | Flag_NonAsciiSymbols,

    /// <summary>
    /// All whitespace characters.
    /// </summary>
    WhiteSpaceChars = Flag_Space | Flag_NonAsciiSeparator | Flag_AsciiWhitespaceControlChars | Flag_NonSeparatorWhiteSpace,

    /// <summary>
    /// All number characters.
    /// </summary>
    Numbers = Flag_AsciiDigits | Flag_NonAsciiNumbers,

    /// <summary>
    /// All digits.
    /// </summary>
    Digits = Flag_AsciiDigits | Flag_NonAsciiNumbers | Flag_NonAsciiDigits,

    /// <summary>
    /// All upper-case letters.
    /// </summary>
    UpperChars = Flag_HexDigitVowelsUpper | Flag_UpperB | Flag_UpperC | Flag_UpperD | Flag_UpperF | Flag_VowelsUpper | Flag_HardConsonantsUpper | Flag_SoftConsonantsUpper | Flag_UpperY | Flag_UpperNonAsciiChars,

    /// <summary>
    /// All lower-case letters.
    /// </summary>
    LowerChars = Flag_HexDigitVowelsLower | Flag_LowerB | Flag_LowerC | Flag_LowerD | Flag_LowerF | Flag_VowelsLower | Flag_HardConsonantsLower | Flag_SoftConsonantsLower | Flag_LowerY | Flag_LowerNonAsciiChars,

    /// <summary>
    /// All letters.
    /// </summary>
    Letters = Flag_HexDigitVowelsUpper | Flag_UpperB | Flag_UpperC | Flag_UpperD | Flag_UpperF | Flag_VowelsUpper | Flag_HardConsonantsUpper | Flag_SoftConsonantsUpper | Flag_UpperY |
        Flag_HexDigitVowelsLower | Flag_LowerB | Flag_LowerC | Flag_LowerD | Flag_LowerF | Flag_VowelsLower | Flag_HardConsonantsLower | Flag_SoftConsonantsLower | Flag_LowerY | Flag_UpperNonAsciiChars |
        Flag_LowerNonAsciiChars | Flag_NonAsciiNonCaseLetters,

    /// <summary>
    /// All letters and digits.
    /// </summary>
    LettersAndDigits = Flag_AsciiDigits | Flag_HexDigitVowelsUpper | Flag_UpperB | Flag_UpperC | Flag_UpperD | Flag_UpperF | Flag_VowelsUpper | Flag_HardConsonantsUpper | Flag_SoftConsonantsUpper |
        Flag_UpperY | Flag_HexDigitVowelsLower | Flag_LowerB | Flag_LowerC | Flag_LowerD | Flag_LowerF | Flag_VowelsLower | Flag_HardConsonantsLower | Flag_SoftConsonantsLower | Flag_LowerY | Flag_NonAsciiNumbers |
        Flag_UpperNonAsciiChars | Flag_LowerNonAsciiChars | Flag_NonAsciiNonCaseLetters,

    /// <summary>
    /// High surrogate characters.
    /// </summary>
    HighSurrogates = Flag_HighSurrogates,

    /// <summary>
    /// All control characters.
    /// </summary>
    ControlChars = Flag_AsciiWhitespaceControlChars | Flag_NonAsciiNonWsControlChars | Flag_AsciiNonWsControlChars,

    /// <summary>
    /// Low surrogate characters.
    /// </summary>
    LowSurrogates = Flag_LowSurrogates,

    /// <summary>
    /// All surrogate characters.
    /// </summary>
    Surrogates = Flag_HighSurrogates | Flag_LowSurrogates
}