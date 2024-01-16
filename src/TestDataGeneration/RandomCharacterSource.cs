using static TestDataGeneration.CharacterTypes;

namespace TestDataGeneration;

public class RandomCharacterSource
{
    private readonly IEnumerable<char> _getValues;
    private readonly Func<char, bool> _test;

    public CharacterClass Type { get; }

    public bool Test(char c) => _test(c);

    public IEnumerable<char> GetValues() => _getValues;

    public RandomCharacterSource(IEnumerable<CharacterClass> types)
    {
        Type = types?.Aggregate(CharacterClass.NotSpecified, (a, b) => a | b) ?? CharacterClass.NotSpecified;
        switch (Type)
        {
            case CharacterClass.NotSpecified:
                _getValues = GetAllCharacters();
                _test = c => true;
                return;
            case CharacterClass.AsciiControlChars:
                _test = c => char.IsAscii(c) && char.IsControl(c);
                break;
            case CharacterClass.Space:
                _test = c => c == ' ';
                _getValues = new char[] { ' ' };
                return;
            case CharacterClass.AsciiWhiteSpace:
                _test = c => char.IsAscii(c) && char.IsWhiteSpace(c);
                break;
            case CharacterClass.Separators:
                _test = char.IsSeparator;
                break;
            case CharacterClass.AsciiDigits:
                _test = char.IsAsciiDigit;
                break;
            case CharacterClass.Plus:
                _test = c => c == '+';
                _getValues = new char[] { '+' };
                return;
            case CharacterClass.Dash:
                _test = c => c == '-';
                _getValues = new char[] { '-' };
                return;
            case CharacterClass.Period:
                _test = c => c == '.';
                _getValues = new char[] { '.' };
                return;
            case CharacterClass.AsciiHexDigitsUpper:
                _test = char.IsAsciiHexDigitUpper;
                break;
            case CharacterClass.HardConsonantsUpper:
                _test = IsHardConsonantUpper;
                _getValues = GetAllHardConsonantsUpper();
                return;
            case CharacterClass.VowelsUpper:
                _test = IsVowelUpper;
                _getValues = GetAllVowelsUpper();
                return;
            case CharacterClass.SoftConsonantsUpper:
                _test = IsSoftConsonantUpper;
                _getValues = GetAllSoftConsonantsUpper();
                return;
            case CharacterClass.ConsonantsUpper:
                _test = IsConsonantUpper;
                _getValues = GetAllConsonantsUpper();
                return;
            case CharacterClass.AsciiLettersUpper:
                _test = char.IsAsciiLetterUpper;
                break;
            case CharacterClass.Underscore:
                _test = c => c == '_';
                _getValues = new char[] { '_' };
                return;
            case CharacterClass.AsciiPunctuation:
                _test = c => char.IsAscii(c) && char.IsPunctuation(c);
                break;
            case CharacterClass.AsciiHexDigitsLower:
                _test = char.IsAsciiHexDigitLower;
                break;
            case CharacterClass.AsciiHexDigits:
                _test = char.IsAsciiHexDigit;
                break;
            case CharacterClass.HardConsonantsLower:
                _test = IsHardConsonantLower;
                _getValues = GetAllHardConsonantsLower();
                return;
            case CharacterClass.HardConsonants:
                _test = IsHardConsonant;
                _getValues = GetAllHardConsonants();
                return;
            case CharacterClass.VowelsLower:
                _test = IsVowelLower;
                _getValues = GetAllVowelsLower();
                return;
            case CharacterClass.Vowels:
                _test = IsVowel;
                _getValues = GetAllVowels();
                return;
            case CharacterClass.SoftConsonantsLower:
                _test = IsSoftConsonantLower;
                _getValues = GetAllSoftConsonantsLower();
                return;
            case CharacterClass.SoftConsonants:
                _test = IsSoftConsonant;
                _getValues = GetAllSoftConsonants();
                return;
            case CharacterClass.ConsonantsLower:
                _test = IsConsonantLower;
                _getValues = GetAllConsonantsLower();
                return;
            case CharacterClass.Consonants:
                _test = IsConsonant;
                _getValues = GetAllConsonants();
                return;
            case CharacterClass.AsciiLettersLower:
                _test = char.IsAsciiLetterLower;
                break;
            case CharacterClass.AsciiLetters:
                _test = char.IsAsciiLetter;
                break;
            case CharacterClass.AsciiLettersAndDigits:
                _test = char.IsAsciiLetterOrDigit;
                break;
            case CharacterClass.CsIdentifierChars:
                // TODO: Implement for CsIdentifierChars
                throw new NotImplementedException();
            case CharacterClass.Tilde:
                _test = c => c == '~';
                _getValues = new char[] { '~' };
                return;
            case CharacterClass.AsciiSymbols:
                _test = c => char.IsAscii(c) && char.IsSymbol(c);
                break;
            case CharacterClass.UriDataChars:
                // TODO: Implement for UriDataChars
                throw new NotImplementedException();
            case CharacterClass.AsciiChars:
                _test = char.IsAscii;
                break;
            case CharacterClass.PunctuationChars:
                _test = char.IsPunctuation;
                break;
            case CharacterClass.Symbols:
                _test = char.IsSymbol;
                break;
            case CharacterClass.WhiteSpaceChars:
                _test = char.IsWhiteSpace;
                break;
            case CharacterClass.Numbers:
                _test = char.IsNumber;
                break;
            case CharacterClass.Digits:
                _test = char.IsDigit;
                break;
            case CharacterClass.UpperChars:
                _test = char.IsUpper;
                break;
            case CharacterClass.LowerChars:
                _test = char.IsLower;
                break;
            case CharacterClass.Letters:
                _test = char.IsLetter;
                break;
            case CharacterClass.LettersAndDigits:
                _test = char.IsLetterOrDigit;
                break;
            case CharacterClass.HighSurrogates:
                _test = char.IsHighSurrogate;
                break;
            case CharacterClass.ControlChars:
                _test = char.IsControl;
                break;
            case CharacterClass.LowSurrogates:
                _test = char.IsLowSurrogate;
                break;
            case CharacterClass.Surrogates:
                _test = char.IsSurrogate;
                break;
            default:
                // TODO: Implement for combined flags
                throw new NotImplementedException();
        }
        _getValues = GetAllCharacters().Where(_test);
    }
}
