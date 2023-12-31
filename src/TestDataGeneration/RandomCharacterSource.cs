using static TestDataGeneration.CharacterTypes;

namespace TestDataGeneration;

public class RandomCharacterSource
{
    private readonly IEnumerable<char> _getValues;
    private readonly Func<char, bool> _test;

    public CharacterType Type { get; }

    public bool Test(char c) => _test(c);

    public IEnumerable<char> GetValues() => _getValues;

    public RandomCharacterSource(IEnumerable<CharacterType> types)
    {
        Type = types?.Aggregate(CharacterType.NotSpecified, (a, b) => a | b) ?? CharacterType.NotSpecified;
        switch (Type)
        {
            case CharacterType.NotSpecified:
                _getValues = GetAllCharacters();
                _test = c => true;
                return;
            case CharacterType.AsciiControlChars:
                _test = c => char.IsAscii(c) && char.IsControl(c);
                break;
            case CharacterType.Space:
                _test = c => c == ' ';
                _getValues = new char[] { ' ' };
                return;
            case CharacterType.AsciiWhiteSpace:
                _test = c => char.IsAscii(c) && char.IsWhiteSpace(c);
                break;
            case CharacterType.Separators:
                _test = char.IsSeparator;
                break;
            case CharacterType.AsciiDigits:
                _test = char.IsAsciiDigit;
                break;
            case CharacterType.Plus:
                _test = c => c == '+';
                _getValues = new char[] { '+' };
                return;
            case CharacterType.Dash:
                _test = c => c == '-';
                _getValues = new char[] { '-' };
                return;
            case CharacterType.Period:
                _test = c => c == '.';
                _getValues = new char[] { '.' };
                return;
            case CharacterType.AsciiHexDigitsUpper:
                _test = char.IsAsciiHexDigitUpper;
                break;
            case CharacterType.HardConsonantsUpper:
                _test = IsHardConsonantUpper;
                _getValues = GetAllHardConsonantsUpper();
                return;
            case CharacterType.VowelsUpper:
                _test = IsVowelUpper;
                _getValues = GetAllVowelsUpper();
                return;
            case CharacterType.SoftConsonantsUpper:
                _test = IsSoftConsonantUpper;
                _getValues = GetAllSoftConsonantsUpper();
                return;
            case CharacterType.ConsonantsUpper:
                _test = IsConsonantUpper;
                _getValues = GetAllConsonantsUpper();
                return;
            case CharacterType.AsciiLettersUpper:
                _test = char.IsAsciiLetterUpper;
                break;
            case CharacterType.Underscore:
                _test = c => c == '_';
                _getValues = new char[] { '_' };
                return;
            case CharacterType.AsciiPunctuation:
                _test = c => char.IsAscii(c) && char.IsPunctuation(c);
                break;
            case CharacterType.AsciiHexDigitsLower:
                _test = char.IsAsciiHexDigitLower;
                break;
            case CharacterType.AsciiHexDigits:
                _test = char.IsAsciiHexDigit;
                break;
            case CharacterType.HardConsonantsLower:
                _test = IsHardConsonantLower;
                _getValues = GetAllHardConsonantsLower();
                return;
            case CharacterType.HardConsonants:
                _test = IsHardConsonant;
                _getValues = GetAllHardConsonants();
                return;
            case CharacterType.VowelsLower:
                _test = IsVowelLower;
                _getValues = GetAllVowelsLower();
                return;
            case CharacterType.Vowels:
                _test = IsVowel;
                _getValues = GetAllVowels();
                return;
            case CharacterType.SoftConsonantsLower:
                _test = IsSoftConsonantLower;
                _getValues = GetAllSoftConsonantsLower();
                return;
            case CharacterType.SoftConsonants:
                _test = IsSoftConsonant;
                _getValues = GetAllSoftConsonants();
                return;
            case CharacterType.ConsonantsLower:
                _test = IsConsonantLower;
                _getValues = GetAllConsonantsLower();
                return;
            case CharacterType.Consonants:
                _test = IsConsonant;
                _getValues = GetAllConsonants();
                return;
            case CharacterType.AsciiLettersLower:
                _test = char.IsAsciiLetterLower;
                break;
            case CharacterType.AsciiLetters:
                _test = char.IsAsciiLetter;
                break;
            case CharacterType.AsciiLettersAndDigits:
                _test = char.IsAsciiLetterOrDigit;
                break;
            case CharacterType.CsIdentifierChars:
                // TODO: Implement for CsIdentifierChars
                throw new NotImplementedException();
            case CharacterType.Tilde:
                _test = c => c == '~';
                _getValues = new char[] { '~' };
                return;
            case CharacterType.AsciiSymbols:
                _test = c => char.IsAscii(c) && char.IsSymbol(c);
                break;
            case CharacterType.UriDataChars:
                // TODO: Implement for UriDataChars
                throw new NotImplementedException();
            case CharacterType.AsciiChars:
                _test = char.IsAscii;
                break;
            case CharacterType.PunctuationChars:
                _test = char.IsPunctuation;
                break;
            case CharacterType.Symbols:
                _test = char.IsSymbol;
                break;
            case CharacterType.WhiteSpaceChars:
                _test = char.IsWhiteSpace;
                break;
            case CharacterType.Numbers:
                _test = char.IsNumber;
                break;
            case CharacterType.Digits:
                _test = char.IsDigit;
                break;
            case CharacterType.UpperChars:
                _test = char.IsUpper;
                break;
            case CharacterType.LowerChars:
                _test = char.IsLower;
                break;
            case CharacterType.Letters:
                _test = char.IsLetter;
                break;
            case CharacterType.LettersAndDigits:
                _test = char.IsLetterOrDigit;
                break;
            case CharacterType.HighSurrogates:
                _test = char.IsHighSurrogate;
                break;
            case CharacterType.ControlChars:
                _test = char.IsControl;
                break;
            case CharacterType.LowSurrogates:
                _test = char.IsLowSurrogate;
                break;
            case CharacterType.Surrogates:
                _test = char.IsSurrogate;
                break;
            default:
                // TODO: Implement for combined flags
                throw new NotImplementedException();
        }
        _getValues = GetAllCharacters().Where(_test);
    }
}
