using NuGet.Frameworks;
using NUnit.Framework.Internal;

namespace TestDataGeneration.UnitTests;

public class RandomCharacterSourceTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GetIncludedByTest()
    {
        IEnumerable<CharacterType>? actual;
        foreach (var type in new CharacterType[] { CharacterType.Surrogates, CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars, CharacterType.Numbers,
            CharacterType.LettersAndDigits, CharacterType.AsciiChars, CharacterType.ControlChars })
        {
            actual = RandomCharacterSource.GetIncludedBy(type);
            Assert.That(actual, Is.Not.Null, $"Type: {type}");
            Assert.That(actual.Any(), Is.False, $"Type: {type}");
        }

        var expected = new[] { CharacterType.ControlChars, CharacterType.AsciiChars };
        actual = RandomCharacterSource.GetIncludedBy(CharacterType.AsciiControlChars);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.Digits, CharacterType.AsciiHexDigitsUpper, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.Numbers,
            CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.LettersAndDigits, CharacterType.AsciiChars };
        actual = RandomCharacterSource.GetIncludedBy(CharacterType.AsciiDigits);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.PunctuationChars, CharacterType.AsciiChars };
        actual = RandomCharacterSource.GetIncludedBy(CharacterType.AsciiPunctuation);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.Symbols, CharacterType.AsciiChars };
        actual = RandomCharacterSource.GetIncludedBy(CharacterType.AsciiSymbols);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.WhiteSpaceChars };
        actual = RandomCharacterSource.GetIncludedBy(CharacterType.Separators);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.Surrogates };
        actual = RandomCharacterSource.GetIncludedBy(CharacterType.HighSurrogates);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        actual = RandomCharacterSource.GetIncludedBy(CharacterType.LowSurrogates);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.HardConsonants, CharacterType.ConsonantsUpper, CharacterType.Consonants, CharacterType.AsciiLettersUpper, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits,
            CharacterType.UpperChars, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.Letters, CharacterType.LettersAndDigits, CharacterType.AsciiChars };
        actual = RandomCharacterSource.GetIncludedBy(CharacterType.HardConsonantsUpper);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.HardConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits,
            CharacterType.LowerChars, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.Letters, CharacterType.LettersAndDigits, CharacterType.AsciiChars };
        actual = RandomCharacterSource.GetIncludedBy(CharacterType.HardConsonantsLower);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.Consonants, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.Letters,
            CharacterType.LettersAndDigits, CharacterType.AsciiChars };
        actual = RandomCharacterSource.GetIncludedBy(CharacterType.HardConsonants);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        actual = RandomCharacterSource.GetIncludedBy(CharacterType.SoftConsonants);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.ConsonantsUpper, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.AsciiLettersUpper, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits,
            CharacterType.UpperChars, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.Letters, CharacterType.LettersAndDigits, CharacterType.AsciiChars };
        actual = RandomCharacterSource.GetIncludedBy(CharacterType.SoftConsonantsUpper);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.Consonants, CharacterType.AsciiLettersUpper, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.UpperChars, CharacterType.CsIdentifierChars,
            CharacterType.UriDataChars, CharacterType.Letters, CharacterType.LettersAndDigits, CharacterType.AsciiChars };
        actual = RandomCharacterSource.GetIncludedBy(CharacterType.ConsonantsUpper);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits,
            CharacterType.LowerChars, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.Letters, CharacterType.LettersAndDigits, CharacterType.AsciiChars };
        actual = RandomCharacterSource.GetIncludedBy(CharacterType.SoftConsonantsLower);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.LowerChars, CharacterType.CsIdentifierChars,
            CharacterType.UriDataChars, CharacterType.Letters, CharacterType.LettersAndDigits, CharacterType.AsciiChars };
        actual = RandomCharacterSource.GetIncludedBy(CharacterType.ConsonantsLower);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.Letters, CharacterType.LettersAndDigits,
            CharacterType.AsciiChars };
        actual = RandomCharacterSource.GetIncludedBy(CharacterType.Consonants);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.AsciiLettersUpper, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.UpperChars, CharacterType.CsIdentifierChars,
            CharacterType.UriDataChars, CharacterType.Letters, CharacterType.LettersAndDigits, CharacterType.AsciiChars };
        actual = RandomCharacterSource.GetIncludedBy(CharacterType.VowelsUpper);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.UpperChars, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.Letters,
        CharacterType.LettersAndDigits, CharacterType.AsciiChars };
        actual = RandomCharacterSource.GetIncludedBy(CharacterType.AsciiLettersUpper);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.LowerChars, CharacterType.CsIdentifierChars,
            CharacterType.UriDataChars, CharacterType.Letters, CharacterType.LettersAndDigits, CharacterType.AsciiChars };
        actual = RandomCharacterSource.GetIncludedBy(CharacterType.VowelsLower);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.LowerChars, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.Letters,
        CharacterType.LettersAndDigits, CharacterType.AsciiChars };
        actual = RandomCharacterSource.GetIncludedBy(CharacterType.AsciiLettersLower);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.Letters,
            CharacterType.LettersAndDigits, CharacterType.AsciiChars };
        actual = RandomCharacterSource.GetIncludedBy(CharacterType.Vowels);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.Letters, CharacterType.LettersAndDigits, CharacterType.AsciiChars };
        actual = RandomCharacterSource.GetIncludedBy(CharacterType.AsciiLetters);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        // expected = new[] { CharacterType.Surrogates, CharacterType.HardConsonants, CharacterType.ConsonantsUpper, CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants,
        //     CharacterType.AsciiLettersUpper, CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.ControlChars, CharacterType.Digits, CharacterType.AsciiHexDigitsUpper,
        //     CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars,
        //     CharacterType.Numbers, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.Letters, CharacterType.LettersAndDigits,
        //     CharacterType.AsciiChars };
        // actual = RandomCharacterSource.GetIncludedBy(CharacterType.ControlChars);
        // Assert.That(actual, Is.Not.Null);
        // Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.Numbers, CharacterType.LettersAndDigits };
        actual = RandomCharacterSource.GetIncludedBy(CharacterType.Digits);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.LettersAndDigits, CharacterType.AsciiChars };
        actual = RandomCharacterSource.GetIncludedBy(CharacterType.AsciiHexDigitsUpper);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        actual = RandomCharacterSource.GetIncludedBy(CharacterType.AsciiHexDigitsLower);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.LettersAndDigits, CharacterType.AsciiChars };
        actual = RandomCharacterSource.GetIncludedBy(CharacterType.AsciiHexDigits);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.LettersAndDigits, CharacterType.AsciiChars };
        actual = RandomCharacterSource.GetIncludedBy(CharacterType.AsciiLettersAndDigits);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.Letters, CharacterType.LettersAndDigits };
        actual = RandomCharacterSource.GetIncludedBy(CharacterType.UpperChars);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        actual = RandomCharacterSource.GetIncludedBy(CharacterType.LowerChars);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.UriDataChars, CharacterType.AsciiChars };
        actual = RandomCharacterSource.GetIncludedBy(CharacterType.CsIdentifierChars);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.AsciiChars };
        actual = RandomCharacterSource.GetIncludedBy(CharacterType.UriDataChars);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.LettersAndDigits };
        actual = RandomCharacterSource.GetIncludedBy(CharacterType.Letters);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));
    }

    [Test]
    public void GetIncludedTypesTest()
    {
        IEnumerable<CharacterType>? actual;
        foreach (var type in new CharacterType[] { CharacterType.AsciiControlChars, CharacterType.AsciiDigits, CharacterType.AsciiPunctuation, CharacterType.AsciiSymbols, CharacterType.Separators,
            CharacterType.HighSurrogates, CharacterType.LowSurrogates, CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.SoftConsonantsUpper, CharacterType.SoftConsonantsLower,
            CharacterType.VowelsUpper, CharacterType.VowelsLower })
        {
            actual = RandomCharacterSource.GetIncludedTypes(type);
            Assert.That(actual, Is.Not.Null, $"Type: {type}");
            Assert.That(actual.Any(), Is.False, $"Type: {type}");
        }

        var expected = new[] { CharacterType.HighSurrogates, CharacterType.LowSurrogates };
        actual = RandomCharacterSource.GetIncludedTypes(CharacterType.Surrogates);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower };
        actual = RandomCharacterSource.GetIncludedTypes(CharacterType.HardConsonants);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.HardConsonantsUpper, CharacterType.SoftConsonantsUpper };
        actual = RandomCharacterSource.GetIncludedTypes(CharacterType.ConsonantsUpper);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.HardConsonantsLower,CharacterType.SoftConsonantsLower };
        actual = RandomCharacterSource.GetIncludedTypes(CharacterType.ConsonantsLower);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.SoftConsonantsUpper, CharacterType.SoftConsonantsLower };
        actual = RandomCharacterSource.GetIncludedTypes(CharacterType.SoftConsonants);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants };
        actual = RandomCharacterSource.GetIncludedTypes(CharacterType.Consonants);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.HardConsonantsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.VowelsUpper };
        actual = RandomCharacterSource.GetIncludedTypes(CharacterType.AsciiLettersUpper);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.HardConsonantsLower, CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.VowelsLower };
        actual = RandomCharacterSource.GetIncludedTypes(CharacterType.AsciiLettersLower);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.VowelsUpper, CharacterType.VowelsLower };
        actual = RandomCharacterSource.GetIncludedTypes(CharacterType.Vowels);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper,
            CharacterType.VowelsLower, CharacterType.AsciiLettersLower, CharacterType.Vowels };
        actual = RandomCharacterSource.GetIncludedTypes(CharacterType.AsciiLetters);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.AsciiControlChars };
        actual = RandomCharacterSource.GetIncludedTypes(CharacterType.ControlChars);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.AsciiDigits };
        actual = RandomCharacterSource.GetIncludedTypes(CharacterType.Digits);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.AsciiDigits };
        actual = RandomCharacterSource.GetIncludedTypes(CharacterType.AsciiHexDigitsUpper);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        actual = RandomCharacterSource.GetIncludedTypes(CharacterType.AsciiHexDigitsLower);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.AsciiDigits, CharacterType.AsciiHexDigitsUpper, CharacterType.AsciiHexDigitsLower };
        actual = RandomCharacterSource.GetIncludedTypes(CharacterType.AsciiHexDigits);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.AsciiDigits, CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper,
            CharacterType.VowelsLower, CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.AsciiHexDigitsUpper,
            CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits };
        actual = RandomCharacterSource.GetIncludedTypes(CharacterType.AsciiLettersAndDigits);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.AsciiPunctuation };
        actual = RandomCharacterSource.GetIncludedTypes(CharacterType.PunctuationChars);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.AsciiSymbols };
        actual = RandomCharacterSource.GetIncludedTypes(CharacterType.Symbols);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.Separators };
        actual = RandomCharacterSource.GetIncludedTypes(CharacterType.WhiteSpaceChars);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.AsciiDigits, CharacterType.Digits };
        actual = RandomCharacterSource.GetIncludedTypes(CharacterType.Numbers);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.HardConsonantsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper };
        actual = RandomCharacterSource.GetIncludedTypes(CharacterType.UpperChars);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.HardConsonantsLower, CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.VowelsLower, CharacterType.AsciiLettersLower };
        actual = RandomCharacterSource.GetIncludedTypes(CharacterType.LowerChars);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.AsciiDigits, CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper,
            CharacterType.VowelsLower, CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.AsciiHexDigitsUpper, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits,
            CharacterType.AsciiLettersAndDigits };
        actual = RandomCharacterSource.GetIncludedTypes(CharacterType.CsIdentifierChars);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.AsciiDigits, CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper,
            CharacterType.VowelsLower, CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.AsciiHexDigitsUpper, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits,
            CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars };
        actual = RandomCharacterSource.GetIncludedTypes(CharacterType.UriDataChars);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper,
            CharacterType.VowelsLower, CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.UpperChars, CharacterType.LowerChars };
        actual = RandomCharacterSource.GetIncludedTypes(CharacterType.Letters);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.AsciiDigits, CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper,
            CharacterType.VowelsLower, CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.Digits, CharacterType.AsciiHexDigitsUpper,
            CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.Letters };
        actual = RandomCharacterSource.GetIncludedTypes(CharacterType.LettersAndDigits);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));

        expected = new[] { CharacterType.AsciiControlChars, CharacterType.AsciiDigits, CharacterType.AsciiPunctuation, CharacterType.AsciiSymbols, CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower,
            CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants,
            CharacterType.Consonants, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper, CharacterType.VowelsLower, CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters,
            CharacterType.AsciiHexDigitsUpper, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars };
        actual = RandomCharacterSource.GetIncludedTypes(CharacterType.AsciiChars);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.ToArray(), Is.EqualTo(expected));
    }

    [Test]
    public void GetAllCharsTest()
    {
        var actual = RandomCharacterSource.GetAllChars();
        Assert.That(actual, Is.Not.Null);
        var enumerator = actual.GetEnumerator();
        int index = 0;
        for (var c = char.MinValue; c < char.MaxValue; c++)
        {
            Assert.Multiple(() =>
            {
                Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)c:x4}");
                Assert.That(enumerator.Current, Is.EqualTo(c), $"Index: {index}; Char: {(int)c:x4}");
            });
            index++;
        }

        Assert.That(enumerator.MoveNext(), Is.True);
        Assert.Multiple(() =>
        {
            Assert.That(enumerator.Current, Is.EqualTo(char.MaxValue), $"Index: {index}; Char: {(int)char.MaxValue:x4}");
            Assert.That(enumerator.MoveNext(), Is.False, $"Index: {index}; Char: {(int)char.MaxValue:x4}");
        });
    }

    [Test]
    public void GetAsciiCharsTest()
    {
        var actual = RandomCharacterSource.GetAsciiChars();
        Assert.That(actual, Is.Not.Null);
        var enumerator = actual.GetEnumerator();
        int index = 0;
        for (var c = char.MinValue; c < char.MaxValue; c++)
        {
            if (char.IsAscii(c))
            {
                Assert.Multiple(() =>
                {
                    Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)c:x4}");
                    Assert.That(enumerator.Current, Is.EqualTo(c), $"Index: {index}; Char: {(int)c:x4}");
                });
                index++;
            }
        }
        if (char.IsAscii(char.MaxValue))
        {
            Assert.Multiple(() =>
            {
                Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)char.MaxValue:x4}");
                Assert.That(enumerator.Current, Is.EqualTo(char.MaxValue), $"Index: {index}; Char: {(int)char.MaxValue:x4}");
            });
            index++;
        }
        Assert.That(enumerator.MoveNext(), Is.False);
    }

    [Test]
    public void GetAsciiControlCharsTest()
    {
        var actual = RandomCharacterSource.GetAsciiControlChars();
        Assert.That(actual, Is.Not.Null);
        var enumerator = actual.GetEnumerator();
        int index = 0;
        for (var c = char.MinValue; c < char.MaxValue; c++)
        {
            if (char.IsAscii(c) && char.IsControl(c))
            {
                Assert.Multiple(() =>
                {
                    Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)c:x4}");
                    Assert.That(enumerator.Current, Is.EqualTo(c), $"Index: {index}; Char: {(int)c:x4}");
                });
                index++;
            }
        }
        if (char.IsAscii(char.MaxValue) && char.IsControl(char.MaxValue))
        {
            Assert.Multiple(() =>
            {
                Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)char.MaxValue:x4}");
                Assert.That(enumerator.Current, Is.EqualTo(char.MaxValue), $"Index: {index}; Char: {(int)char.MaxValue:x4}");
            });
            index++;
        }
        Assert.That(enumerator.MoveNext(), Is.False);
    }

    [Test]
    public void GetAsciiDigitsTest()
    {
        var actual = RandomCharacterSource.GetAsciiDigits();
        Assert.That(actual, Is.Not.Null);
        var enumerator = actual.GetEnumerator();
        int index = 0;
        for (var c = char.MinValue; c < char.MaxValue; c++)
        {
            if (char.IsAsciiDigit(c))
            {
                Assert.Multiple(() =>
                {
                    Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)c:x4}");
                    Assert.That(enumerator.Current, Is.EqualTo(c), $"Index: {index}; Char: {(int)c:x4}");
                });
                index++;
            }
        }
        if (char.IsAsciiDigit(char.MaxValue))
        {
            Assert.Multiple(() =>
            {
                Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)char.MaxValue:x4}");
                Assert.That(enumerator.Current, Is.EqualTo(char.MaxValue), $"Index: {index}; Char: {(int)char.MaxValue:x4}");
            });
            index++;
        }
        Assert.That(enumerator.MoveNext(), Is.False);
    }

    [Test]
    public void GetAsciiHexDigitsTest()
    {
        var actual = RandomCharacterSource.GetAsciiHexDigits();
        Assert.That(actual, Is.Not.Null);
        var enumerator = actual.GetEnumerator();
        int index = 0;
        for (var c = char.MinValue; c < char.MaxValue; c++)
        {
            if (char.IsAsciiHexDigit(c))
            {
                Assert.Multiple(() =>
                {
                    Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)c:x4}");
                    Assert.That(enumerator.Current, Is.EqualTo(c), $"Index: {index}; Char: {(int)c:x4}");
                });
                index++;
            }
        }
        if (char.IsAsciiHexDigit(char.MaxValue))
        {
            Assert.Multiple(() =>
            {
                Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)char.MaxValue:x4}");
                Assert.That(enumerator.Current, Is.EqualTo(char.MaxValue), $"Index: {index}; Char: {(int)char.MaxValue:x4}");
            });
            index++;
        }
        Assert.That(enumerator.MoveNext(), Is.False);
    }

    [Test]
    public void GetAsciiHexDigitsLowerTest()
    {
        var actual = RandomCharacterSource.GetAsciiHexDigitsLower();
        Assert.That(actual, Is.Not.Null);
        var enumerator = actual.GetEnumerator();
        int index = 0;
        for (var c = char.MinValue; c < char.MaxValue; c++)
        {
            if (char.IsAsciiHexDigitLower(c))
            {
                Assert.Multiple(() =>
                {
                    Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)c:x4}");
                    Assert.That(enumerator.Current, Is.EqualTo(c), $"Index: {index}; Char: {(int)c:x4}");
                });
                index++;
            }
        }
        if (char.IsAsciiHexDigitLower(char.MaxValue))
        {
            Assert.Multiple(() =>
            {
                Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)char.MaxValue:x4}");
                Assert.That(enumerator.Current, Is.EqualTo(char.MaxValue), $"Index: {index}; Char: {(int)char.MaxValue:x4}");
            });
            index++;
        }
        Assert.That(enumerator.MoveNext(), Is.False);
    }

    [Test]
    public void GetAsciiHexDigitsUpperTest()
    {
        var actual = RandomCharacterSource.GetAsciiHexDigitsUpper();
        Assert.That(actual, Is.Not.Null);
        var enumerator = actual.GetEnumerator();
        int index = 0;
        for (var c = char.MinValue; c < char.MaxValue; c++)
        {
            if (char.IsAsciiHexDigitUpper(c))
            {
                Assert.Multiple(() =>
                {
                    Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)c:x4}");
                    Assert.That(enumerator.Current, Is.EqualTo(c), $"Index: {index}; Char: {(int)c:x4}");
                });
                index++;
            }
        }
        if (char.IsAsciiHexDigitUpper(char.MaxValue))
        {
            Assert.Multiple(() =>
            {
                Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)char.MaxValue:x4}");
                Assert.That(enumerator.Current, Is.EqualTo(char.MaxValue), $"Index: {index}; Char: {(int)char.MaxValue:x4}");
            });
            index++;
        }
        Assert.That(enumerator.MoveNext(), Is.False);
    }

    [Test]
    public void GetAsciiLettersTest()
    {
        var actual = RandomCharacterSource.GetAsciiLetters();
        Assert.That(actual, Is.Not.Null);
        var enumerator = actual.GetEnumerator();
        int index = 0;
        for (var c = char.MinValue; c < char.MaxValue; c++)
        {
            if (char.IsAsciiLetter(c))
            {
                Assert.Multiple(() =>
                {
                    Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)c:x4}");
                    Assert.That(enumerator.Current, Is.EqualTo(c), $"Index: {index}; Char: {(int)c:x4}");
                });
                index++;
            }
        }
        if (char.IsAsciiLetter(char.MaxValue))
        {
            Assert.Multiple(() =>
            {
                Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)char.MaxValue:x4}");
                Assert.That(enumerator.Current, Is.EqualTo(char.MaxValue), $"Index: {index}; Char: {(int)char.MaxValue:x4}");
            });
            index++;
        }
        Assert.That(enumerator.MoveNext(), Is.False);
    }

    [Test]
    public void GetAsciiLettersAndDigitsTest()
    {
        var actual = RandomCharacterSource.GetAsciiLettersAndDigits();
        Assert.That(actual, Is.Not.Null);
        var enumerator = actual.GetEnumerator();
        int index = 0;
        for (var c = char.MinValue; c < char.MaxValue; c++)
        {
            if (char.IsAsciiLetterOrDigit(c))
            {
                Assert.Multiple(() =>
                {
                    Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)c:x4}");
                    Assert.That(enumerator.Current, Is.EqualTo(c), $"Index: {index}; Char: {(int)c:x4}");
                });
                index++;
            }
        }
        if (char.IsAsciiLetterOrDigit(char.MaxValue))
        {
            Assert.Multiple(() =>
            {
                Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)char.MaxValue:x4}");
                Assert.That(enumerator.Current, Is.EqualTo(char.MaxValue), $"Index: {index}; Char: {(int)char.MaxValue:x4}");
            });
            index++;
        }
        Assert.That(enumerator.MoveNext(), Is.False);
    }

    [Test]
    public void GetAsciiLettersLowerTest()
    {
        var actual = RandomCharacterSource.GetAsciiLettersLower();
        Assert.That(actual, Is.Not.Null);
        var enumerator = actual.GetEnumerator();
        int index = 0;
        for (var c = char.MinValue; c < char.MaxValue; c++)
        {
            if (char.IsAsciiLetterLower(c))
            {
                Assert.Multiple(() =>
                {
                    Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)c:x4}");
                    Assert.That(enumerator.Current, Is.EqualTo(c), $"Index: {index}; Char: {(int)c:x4}");
                });
                index++;
            }
        }
        if (char.IsAsciiLetterLower(char.MaxValue))
        {
            Assert.Multiple(() =>
            {
                Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)char.MaxValue:x4}");
                Assert.That(enumerator.Current, Is.EqualTo(char.MaxValue), $"Index: {index}; Char: {(int)char.MaxValue:x4}");
            });
            index++;
        }
        Assert.That(enumerator.MoveNext(), Is.False);
    }

    [Test]
    public void GetAsciiLettersUpperTest()
    {
        var actual = RandomCharacterSource.GetAsciiLettersUpper();
        Assert.That(actual, Is.Not.Null);
        var enumerator = actual.GetEnumerator();
        int index = 0;
        for (var c = char.MinValue; c < char.MaxValue; c++)
        {
            if (char.IsAsciiLetterUpper(c))
            {
                Assert.Multiple(() =>
                {
                    Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)c:x4}");
                    Assert.That(enumerator.Current, Is.EqualTo(c), $"Index: {index}; Char: {(int)c:x4}");
                });
                index++;
            }
        }
        if (char.IsAsciiLetterUpper(char.MaxValue))
        {
            Assert.Multiple(() =>
            {
                Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)char.MaxValue:x4}");
                Assert.That(enumerator.Current, Is.EqualTo(char.MaxValue), $"Index: {index}; Char: {(int)char.MaxValue:x4}");
            });
            index++;
        }
        Assert.That(enumerator.MoveNext(), Is.False);
    }

    [Test]
    public void GetAsciiPunctuationTest()
    {
        var actual = RandomCharacterSource.GetAsciiPunctuation();
        Assert.That(actual, Is.Not.Null);
        var enumerator = actual.GetEnumerator();
        int index = 0;
        for (var c = char.MinValue; c < char.MaxValue; c++)
        {
            if (char.IsAscii(c) && char.IsPunctuation(c))
            {
                Assert.Multiple(() =>
                {
                    Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)c:x4}");
                    Assert.That(enumerator.Current, Is.EqualTo(c), $"Index: {index}; Char: {(int)c:x4}");
                });
                index++;
            }
        }
        if (char.IsAsciiLetterUpper(char.MaxValue) && char.IsPunctuation(char.MaxValue))
        {
            Assert.Multiple(() =>
            {
                Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)char.MaxValue:x4}");
                Assert.That(enumerator.Current, Is.EqualTo(char.MaxValue), $"Index: {index}; Char: {(int)char.MaxValue:x4}");
            });
            index++;
        }
        Assert.That(enumerator.MoveNext(), Is.False);
    }

    [Test]
    public void GetAsciiSymbolsTest()
    {
        var actual = RandomCharacterSource.GetAsciiSymbols();
        Assert.That(actual, Is.Not.Null);
        var enumerator = actual.GetEnumerator();
        int index = 0;
        for (var c = char.MinValue; c < char.MaxValue; c++)
        {
            if (char.IsAscii(c) && char.IsSymbol(c))
            {
                Assert.Multiple(() =>
                {
                    Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)c:x4}");
                    Assert.That(enumerator.Current, Is.EqualTo(c), $"Index: {index}; Char: {(int)c:x4}");
                });
                index++;
            }
        }
        if (char.IsAsciiLetterUpper(char.MaxValue) && char.IsSymbol(char.MaxValue))
        {
            Assert.Multiple(() =>
            {
                Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)char.MaxValue:x4}");
                Assert.That(enumerator.Current, Is.EqualTo(char.MaxValue), $"Index: {index}; Char: {(int)char.MaxValue:x4}");
            });
            index++;
        }
        Assert.That(enumerator.MoveNext(), Is.False);
    }

    [Test]
    public void GetControlCharsTest()
    {
        var actual = RandomCharacterSource.GetControlChars();
        Assert.That(actual, Is.Not.Null);
        var enumerator = actual.GetEnumerator();
        int index = 0;
        for (var c = char.MinValue; c < char.MaxValue; c++)
        {
            if (char.IsControl(c))
            {
                Assert.Multiple(() =>
                {
                    Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)c:x4}");
                    Assert.That(enumerator.Current, Is.EqualTo(c), $"Index: {index}; Char: {(int)c:x4}");
                });
                index++;
            }
        }
        if (char.IsControl(char.MaxValue))
        {
            Assert.Multiple(() =>
            {
                Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)char.MaxValue:x4}");
                Assert.That(enumerator.Current, Is.EqualTo(char.MaxValue), $"Index: {index}; Char: {(int)char.MaxValue:x4}");
            });
            index++;
        }
        Assert.That(enumerator.MoveNext(), Is.False);
    }

    [Test]
    public void GetCsIdentifierCharsTest()
    {
        var actual = RandomCharacterSource.GetCsIdentifierChars();
        Assert.That(actual, Is.Not.Null);
        var enumerator = actual.GetEnumerator();
        int index = 0;
        for (var c = char.MinValue; c < char.MaxValue; c++)
        {
            if (c == '_' || char.IsAsciiLetterOrDigit(c))
            {
                Assert.Multiple(() =>
                {
                    Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)c:x4}");
                    Assert.That(enumerator.Current, Is.EqualTo(c), $"Index: {index}; Char: {(int)c:x4}");
                });
                index++;
            }
        }
        if (char.IsAsciiLetterOrDigit(char.MaxValue))
        {
            Assert.Multiple(() =>
            {
                Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)char.MaxValue:x4}");
                Assert.That(enumerator.Current, Is.EqualTo(char.MaxValue), $"Index: {index}; Char: {(int)char.MaxValue:x4}");
            });
            index++;
        }
        Assert.That(enumerator.MoveNext(), Is.False);
    }

    [Test]
    public void GetDigitsTest()
    {
        var actual = RandomCharacterSource.GetDigits();
        Assert.That(actual, Is.Not.Null);
        var enumerator = actual.GetEnumerator();
        int index = 0;
        for (var c = char.MinValue; c < char.MaxValue; c++)
        {
            if (char.IsDigit(c))
            {
                Assert.Multiple(() =>
                {
                    Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)c:x4}");
                    Assert.That(enumerator.Current, Is.EqualTo(c), $"Index: {index}; Char: {(int)c:x4}");
                });
                index++;
            }
        }
        if (char.IsDigit(char.MaxValue))
        {
            Assert.Multiple(() =>
            {
                Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)char.MaxValue:x4}");
                Assert.That(enumerator.Current, Is.EqualTo(char.MaxValue), $"Index: {index}; Char: {(int)char.MaxValue:x4}");
            });
            index++;
        }
        Assert.That(enumerator.MoveNext(), Is.False);
    }

    [Test]
    public void GetHighSurrogatesTest()
    {
        var actual = RandomCharacterSource.GetHighSurrogates();
        Assert.That(actual, Is.Not.Null);
        var enumerator = actual.GetEnumerator();
        int index = 0;
        for (var c = char.MinValue; c < char.MaxValue; c++)
        {
            if (char.IsHighSurrogate(c))
            {
                Assert.Multiple(() =>
                {
                    Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)c:x4}");
                    Assert.That(enumerator.Current, Is.EqualTo(c), $"Index: {index}; Char: {(int)c:x4}");
                });
                index++;
            }
        }
        if (char.IsHighSurrogate(char.MaxValue))
        {
            Assert.Multiple(() =>
            {
                Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)char.MaxValue:x4}");
                Assert.That(enumerator.Current, Is.EqualTo(char.MaxValue), $"Index: {index}; Char: {(int)char.MaxValue:x4}");
            });
            index++;
        }
        Assert.That(enumerator.MoveNext(), Is.False);
    }

    [Test]
    public void GetLettersTest()
    {
        var actual = RandomCharacterSource.GetLetters();
        Assert.That(actual, Is.Not.Null);
        var enumerator = actual.GetEnumerator();
        int index = 0;
        for (var c = char.MinValue; c < char.MaxValue; c++)
        {
            if (char.IsLetter(c))
            {
                Assert.Multiple(() =>
                {
                    Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)c:x4}");
                    Assert.That(enumerator.Current, Is.EqualTo(c), $"Index: {index}; Char: {(int)c:x4}");
                });
                index++;
            }
        }
        if (char.IsLetter(char.MaxValue))
        {
            Assert.Multiple(() =>
            {
                Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)char.MaxValue:x4}");
                Assert.That(enumerator.Current, Is.EqualTo(char.MaxValue), $"Index: {index}; Char: {(int)char.MaxValue:x4}");
            });
            index++;
        }
        Assert.That(enumerator.MoveNext(), Is.False);
    }

    [Test]
    public void GetLettersAndDigitsTest()
    {
        var actual = RandomCharacterSource.GetLettersAndDigits();
        Assert.That(actual, Is.Not.Null);
        var enumerator = actual.GetEnumerator();
        int index = 0;
        for (var c = char.MinValue; c < char.MaxValue; c++)
        {
            if (char.IsLetterOrDigit(c))
            {
                Assert.Multiple(() =>
                {
                    Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)c:x4}");
                    Assert.That(enumerator.Current, Is.EqualTo(c), $"Index: {index}; Char: {(int)c:x4}");
                });
                index++;
            }
        }
        if (char.IsLetterOrDigit(char.MaxValue))
        {
            Assert.Multiple(() =>
            {
                Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)char.MaxValue:x4}");
                Assert.That(enumerator.Current, Is.EqualTo(char.MaxValue), $"Index: {index}; Char: {(int)char.MaxValue:x4}");
            });
            index++;
        }
        Assert.That(enumerator.MoveNext(), Is.False);
    }

    [Test]
    public void GetLowerCharsTest()
    {
        var actual = RandomCharacterSource.GetLowerChars();
        Assert.That(actual, Is.Not.Null);
        var enumerator = actual.GetEnumerator();
        int index = 0;
        for (var c = char.MinValue; c < char.MaxValue; c++)
        {
            if (char.IsLower(c))
            {
                Assert.Multiple(() =>
                {
                    Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)c:x4}");
                    Assert.That(enumerator.Current, Is.EqualTo(c), $"Index: {index}; Char: {(int)c:x4}");
                });
                index++;
            }
        }
        if (char.IsLower(char.MaxValue))
        {
            Assert.Multiple(() =>
            {
                Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)char.MaxValue:x4}");
                Assert.That(enumerator.Current, Is.EqualTo(char.MaxValue), $"Index: {index}; Char: {(int)char.MaxValue:x4}");
            });
            index++;
        }
        Assert.That(enumerator.MoveNext(), Is.False);
    }

    [Test]
    public void GetLowSurrogatesTest()
    {
        var actual = RandomCharacterSource.GetLowSurrogates();
        Assert.That(actual, Is.Not.Null);
        var enumerator = actual.GetEnumerator();
        int index = 0;
        for (var c = char.MinValue; c < char.MaxValue; c++)
        {
            if (char.IsLowSurrogate(c))
            {
                Assert.Multiple(() =>
                {
                    Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)c:x4}");
                    Assert.That(enumerator.Current, Is.EqualTo(c), $"Index: {index}; Char: {(int)c:x4}");
                });
                index++;
            }
        }
        if (char.IsLowSurrogate(char.MaxValue))
        {
            Assert.Multiple(() =>
            {
                Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)char.MaxValue:x4}");
                Assert.That(enumerator.Current, Is.EqualTo(char.MaxValue), $"Index: {index}; Char: {(int)char.MaxValue:x4}");
            });
            index++;
        }
        Assert.That(enumerator.MoveNext(), Is.False);
    }

    [Test]
    public void GetNumbersTest()
    {
        var actual = RandomCharacterSource.GetNumbers();
        Assert.That(actual, Is.Not.Null);
        var enumerator = actual.GetEnumerator();
        int index = 0;
        for (var c = char.MinValue; c < char.MaxValue; c++)
        {
            if (char.IsNumber(c))
            {
                Assert.Multiple(() =>
                {
                    Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)c:x4}");
                    Assert.That(enumerator.Current, Is.EqualTo(c), $"Index: {index}; Char: {(int)c:x4}");
                });
                index++;
            }
        }
        if (char.IsNumber(char.MaxValue))
        {
            Assert.Multiple(() =>
            {
                Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)char.MaxValue:x4}");
                Assert.That(enumerator.Current, Is.EqualTo(char.MaxValue), $"Index: {index}; Char: {(int)char.MaxValue:x4}");
            });
            index++;
        }
        Assert.That(enumerator.MoveNext(), Is.False);
    }

    [Test]
    public void GetPunctuationCharsTest()
    {
        var actual = RandomCharacterSource.GetPunctuationChars();
        Assert.That(actual, Is.Not.Null);
        var enumerator = actual.GetEnumerator();
        int index = 0;
        for (var c = char.MinValue; c < char.MaxValue; c++)
        {
            if (char.IsPunctuation(c))
            {
                Assert.Multiple(() =>
                {
                    Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)c:x4}");
                    Assert.That(enumerator.Current, Is.EqualTo(c), $"Index: {index}; Char: {(int)c:x4}");
                });
                index++;
            }
        }
        if (char.IsPunctuation(char.MaxValue))
        {
            Assert.Multiple(() =>
            {
                Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)char.MaxValue:x4}");
                Assert.That(enumerator.Current, Is.EqualTo(char.MaxValue), $"Index: {index}; Char: {(int)char.MaxValue:x4}");
            });
            index++;
        }
        Assert.That(enumerator.MoveNext(), Is.False);
    }

    [Test]
    public void GetSeparatorsTest()
    {
        var actual = RandomCharacterSource.GetSeparators();
        Assert.That(actual, Is.Not.Null);
        var enumerator = actual.GetEnumerator();
        int index = 0;
        for (var c = char.MinValue; c < char.MaxValue; c++)
        {
            if (char.IsSeparator(c))
            {
                Assert.Multiple(() =>
                {
                    Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)c:x4}");
                    Assert.That(enumerator.Current, Is.EqualTo(c), $"Index: {index}; Char: {(int)c:x4}");
                });
                index++;
            }
        }
        if (char.IsSeparator(char.MaxValue))
        {
            Assert.Multiple(() =>
            {
                Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)char.MaxValue:x4}");
                Assert.That(enumerator.Current, Is.EqualTo(char.MaxValue), $"Index: {index}; Char: {(int)char.MaxValue:x4}");
            });
            index++;
        }
        Assert.That(enumerator.MoveNext(), Is.False);
    }

    [Test]
    public void GetSurrogatesTest()
    {
        var actual = RandomCharacterSource.GetSurrogates();
        Assert.That(actual, Is.Not.Null);
        var enumerator = actual.GetEnumerator();
        int index = 0;
        for (var c = char.MinValue; c < char.MaxValue; c++)
        {
            if (char.IsSurrogate(c))
            {
                Assert.Multiple(() =>
                {
                    Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)c:x4}");
                    Assert.That(enumerator.Current, Is.EqualTo(c), $"Index: {index}; Char: {(int)c:x4}");
                });
                index++;
            }
        }
        if (char.IsSurrogate(char.MaxValue))
        {
            Assert.Multiple(() =>
            {
                Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)char.MaxValue:x4}");
                Assert.That(enumerator.Current, Is.EqualTo(char.MaxValue), $"Index: {index}; Char: {(int)char.MaxValue:x4}");
            });
            index++;
        }
        Assert.That(enumerator.MoveNext(), Is.False);
    }

    [Test]
    public void GetSymbolsTest()
    {
        var actual = RandomCharacterSource.GetSymbols();
        Assert.That(actual, Is.Not.Null);
        var enumerator = actual.GetEnumerator();
        int index = 0;
        for (var c = char.MinValue; c < char.MaxValue; c++)
        {
            if (char.IsSymbol(c))
            {
                Assert.Multiple(() =>
                {
                    Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)c:x4}");
                    Assert.That(enumerator.Current, Is.EqualTo(c), $"Index: {index}; Char: {(int)c:x4}");
                });
                index++;
            }
        }
        if (char.IsSymbol(char.MaxValue))
        {
            Assert.Multiple(() =>
            {
                Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)char.MaxValue:x4}");
                Assert.That(enumerator.Current, Is.EqualTo(char.MaxValue), $"Index: {index}; Char: {(int)char.MaxValue:x4}");
            });
            index++;
        }
        Assert.That(enumerator.MoveNext(), Is.False);
    }

    [Test]
    public void GetUpperCharsTest()
    {
        var actual = RandomCharacterSource.GetUpperChars();
        Assert.That(actual, Is.Not.Null);
        var enumerator = actual.GetEnumerator();
        int index = 0;
        for (var c = char.MinValue; c < char.MaxValue; c++)
        {
            if (char.IsUpper(c))
            {
                Assert.Multiple(() =>
                {
                    Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)c:x4}");
                    Assert.That(enumerator.Current, Is.EqualTo(c), $"Index: {index}; Char: {(int)c:x4}");
                });
                index++;
            }
        }
        if (char.IsUpper(char.MaxValue))
        {
            Assert.Multiple(() =>
            {
                Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)char.MaxValue:x4}");
                Assert.That(enumerator.Current, Is.EqualTo(char.MaxValue), $"Index: {index}; Char: {(int)char.MaxValue:x4}");
            });
            index++;
        }
        Assert.That(enumerator.MoveNext(), Is.False);
    }

    [Test]
    public void GetWhiteSpaceCharsTest()
    {
        var actual = RandomCharacterSource.GetWhiteSpaceChars();
        Assert.That(actual, Is.Not.Null);
        var enumerator = actual.GetEnumerator();
        int index = 0;
        for (var c = char.MinValue; c < char.MaxValue; c++)
        {
            if (char.IsWhiteSpace(c))
            {
                Assert.Multiple(() =>
                {
                    Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)c:x4}");
                    Assert.That(enumerator.Current, Is.EqualTo(c), $"Index: {index}; Char: {(int)c:x4}");
                });
                index++;
            }
        }
        if (char.IsWhiteSpace(char.MaxValue))
        {
            Assert.Multiple(() =>
            {
                Assert.That(enumerator.MoveNext(), Is.True, $"Index: {index}; Char: {(int)char.MaxValue:x4}");
                Assert.That(enumerator.Current, Is.EqualTo(char.MaxValue), $"Index: {index}; Char: {(int)char.MaxValue:x4}");
            });
            index++;
        }
        Assert.That(enumerator.MoveNext(), Is.False);
    }

    [Test]
    public void IsAsciiControlCharTest()
    {
        bool actual;
        for (var c = char.MinValue; c < char.MaxValue; c++)
        {
            actual = RandomCharacterSource.IsAsciiControlChar(c);
            Assert.That(actual, Is.EqualTo(char.IsAscii(c) && char.IsControl(c)), $"Char: {(int)c:x4}");
        }
        actual = RandomCharacterSource.IsAsciiControlChar(char.MaxValue);
        Assert.That(actual, Is.EqualTo(char.IsAscii(char.MaxValue) && char.IsControl(char.MaxValue)), $"Char: {(int)char.MaxValue:x4}");
    }

    [Test]
    public void IsAsciiSymbolTest()
    {
        bool actual;
        for (var c = char.MinValue; c < char.MaxValue; c++)
        {
            actual = RandomCharacterSource.IsAsciiSymbol(c);
            Assert.That(actual, Is.EqualTo(char.IsAscii(c) && char.IsSymbol(c)), $"Char: {(int)c:x4}");
        }
        actual = RandomCharacterSource.IsAsciiSymbol(char.MaxValue);
        Assert.That(actual, Is.EqualTo(char.IsAscii(char.MaxValue) && char.IsSymbol(char.MaxValue)), $"Char: {(int)char.MaxValue:x4}");
    }

    [Test]
    public void IsCsIdentifierCharTest()
    {
        bool actual;
        for (var c = char.MinValue; c < char.MaxValue; c++)
        {
            actual = RandomCharacterSource.IsCsIdentifierChar(c);
            Assert.That(actual, Is.EqualTo(char.IsAsciiLetterOrDigit(c) || c == '_'), $"Char: {(int)c:x4}");
        }
        actual = RandomCharacterSource.IsCsIdentifierChar(char.MaxValue);
        Assert.That(actual, Is.EqualTo(char.IsAsciiLetterOrDigit(char.MaxValue)), $"Char: {(int)char.MaxValue:x4}");
    }

    [Test]
    public void IsUriDataCharTest()
    {
        bool actual;
        for (var c = char.MinValue; c < char.MaxValue; c++)
        {
            var expected = c switch
            {
                '-' or '.' or '_' or '~' => true,
                _ => char.IsAsciiLetterOrDigit(c),
            };
            string d = Uri.EscapeDataString(new string(c, 1));
            Assert.That(expected, Is.EqualTo(d.Length == 1));
            actual = RandomCharacterSource.IsUriDataChar(c);
            Assert.That(actual, Is.EqualTo(expected), $"Char: {(int)c:x4}");
        }
        actual = RandomCharacterSource.IsUriDataChar(char.MaxValue);
        Assert.That(actual, Is.EqualTo(char.IsAsciiLetterOrDigit(char.MaxValue)), $"Char: {(int)char.MaxValue:x4}");
    }
}