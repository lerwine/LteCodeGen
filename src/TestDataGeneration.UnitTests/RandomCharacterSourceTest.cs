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

        // expected = new[] { CharacterType.AsciiControlChars, CharacterType.AsciiDigits, CharacterType.AsciiPunctuation, CharacterType.AsciiSymbols, CharacterType.Separators, CharacterType.HighSurrogates,
        //     CharacterType.LowSurrogates, CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
        //     CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper,
        //     CharacterType.VowelsLower, CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.ControlChars, CharacterType.Digits, CharacterType.AsciiHexDigitsUpper,
        //     CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.CsIdentifierChars,
        //     CharacterType.UriDataChars, CharacterType.Letters };
        // actual = RandomCharacterSource.GetIncludedTypes(CharacterType.HardConsonants);
        // Assert.That(actual, Is.Not.Null);
        // Assert.That(actual.ToArray(), Is.EqualTo(expected));

        // expected = new[] { CharacterType.AsciiControlChars, CharacterType.AsciiDigits, CharacterType.AsciiPunctuation, CharacterType.AsciiSymbols, CharacterType.Separators, CharacterType.HighSurrogates,
        //     CharacterType.LowSurrogates, CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
        //     CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper,
        //     CharacterType.VowelsLower, CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.ControlChars, CharacterType.Digits, CharacterType.AsciiHexDigitsUpper,
        //     CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.CsIdentifierChars,
        //     CharacterType.UriDataChars, CharacterType.Letters };
        // actual = RandomCharacterSource.GetIncludedTypes(CharacterType.ConsonantsUpper);
        // Assert.That(actual, Is.Not.Null);
        // Assert.That(actual.ToArray(), Is.EqualTo(expected));

        // expected = new[] { CharacterType.AsciiControlChars, CharacterType.AsciiDigits, CharacterType.AsciiPunctuation, CharacterType.AsciiSymbols, CharacterType.Separators, CharacterType.HighSurrogates,
        //     CharacterType.LowSurrogates, CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
        //     CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper,
        //     CharacterType.VowelsLower, CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.ControlChars, CharacterType.Digits, CharacterType.AsciiHexDigitsUpper,
        //     CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.CsIdentifierChars,
        //     CharacterType.UriDataChars, CharacterType.Letters };
        // actual = RandomCharacterSource.GetIncludedTypes(CharacterType.ConsonantsLower);
        // Assert.That(actual, Is.Not.Null);
        // Assert.That(actual.ToArray(), Is.EqualTo(expected));

        // expected = new[] { CharacterType.AsciiControlChars, CharacterType.AsciiDigits, CharacterType.AsciiPunctuation, CharacterType.AsciiSymbols, CharacterType.Separators, CharacterType.HighSurrogates,
        //     CharacterType.LowSurrogates, CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
        //     CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper,
        //     CharacterType.VowelsLower, CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.ControlChars, CharacterType.Digits, CharacterType.AsciiHexDigitsUpper,
        //     CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.CsIdentifierChars,
        //     CharacterType.UriDataChars, CharacterType.Letters };
        // actual = RandomCharacterSource.GetIncludedTypes(CharacterType.SoftConsonants);
        // Assert.That(actual, Is.Not.Null);
        // Assert.That(actual.ToArray(), Is.EqualTo(expected));

        // expected = new[] { CharacterType.AsciiControlChars, CharacterType.AsciiDigits, CharacterType.AsciiPunctuation, CharacterType.AsciiSymbols, CharacterType.Separators, CharacterType.HighSurrogates,
        //     CharacterType.LowSurrogates, CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
        //     CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper,
        //     CharacterType.VowelsLower, CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.ControlChars, CharacterType.Digits, CharacterType.AsciiHexDigitsUpper,
        //     CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.CsIdentifierChars,
        //     CharacterType.UriDataChars, CharacterType.Letters };
        // actual = RandomCharacterSource.GetIncludedTypes(CharacterType.Consonants);
        // Assert.That(actual, Is.Not.Null);
        // Assert.That(actual.ToArray(), Is.EqualTo(expected));

        // expected = new[] { CharacterType.AsciiControlChars, CharacterType.AsciiDigits, CharacterType.AsciiPunctuation, CharacterType.AsciiSymbols, CharacterType.Separators, CharacterType.HighSurrogates,
        //     CharacterType.LowSurrogates, CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
        //     CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper,
        //     CharacterType.VowelsLower, CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.ControlChars, CharacterType.Digits, CharacterType.AsciiHexDigitsUpper,
        //     CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.CsIdentifierChars,
        //     CharacterType.UriDataChars, CharacterType.Letters };
        // actual = RandomCharacterSource.GetIncludedTypes(CharacterType.AsciiLettersUpper);
        // Assert.That(actual, Is.Not.Null);
        // Assert.That(actual.ToArray(), Is.EqualTo(expected));

        // expected = new[] { CharacterType.AsciiControlChars, CharacterType.AsciiDigits, CharacterType.AsciiPunctuation, CharacterType.AsciiSymbols, CharacterType.Separators, CharacterType.HighSurrogates,
        //     CharacterType.LowSurrogates, CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
        //     CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper,
        //     CharacterType.VowelsLower, CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.ControlChars, CharacterType.Digits, CharacterType.AsciiHexDigitsUpper,
        //     CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.CsIdentifierChars,
        //     CharacterType.UriDataChars, CharacterType.Letters };
        // actual = RandomCharacterSource.GetIncludedTypes(CharacterType.AsciiLettersLower);
        // Assert.That(actual, Is.Not.Null);
        // Assert.That(actual.ToArray(), Is.EqualTo(expected));

        // expected = new[] { CharacterType.AsciiControlChars, CharacterType.AsciiDigits, CharacterType.AsciiPunctuation, CharacterType.AsciiSymbols, CharacterType.Separators, CharacterType.HighSurrogates,
        //     CharacterType.LowSurrogates, CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
        //     CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper,
        //     CharacterType.VowelsLower, CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.ControlChars, CharacterType.Digits, CharacterType.AsciiHexDigitsUpper,
        //     CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.CsIdentifierChars,
        //     CharacterType.UriDataChars, CharacterType.Letters };
        // actual = RandomCharacterSource.GetIncludedTypes(CharacterType.Vowels);
        // Assert.That(actual, Is.Not.Null);
        // Assert.That(actual.ToArray(), Is.EqualTo(expected));

        // expected = new[] { CharacterType.AsciiControlChars, CharacterType.AsciiDigits, CharacterType.AsciiPunctuation, CharacterType.AsciiSymbols, CharacterType.Separators, CharacterType.HighSurrogates,
        //     CharacterType.LowSurrogates, CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
        //     CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper,
        //     CharacterType.VowelsLower, CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.ControlChars, CharacterType.Digits, CharacterType.AsciiHexDigitsUpper,
        //     CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.CsIdentifierChars,
        //     CharacterType.UriDataChars, CharacterType.Letters };
        // actual = RandomCharacterSource.GetIncludedTypes(CharacterType.AsciiLetters);
        // Assert.That(actual, Is.Not.Null);
        // Assert.That(actual.ToArray(), Is.EqualTo(expected));

        // expected = new[] { CharacterType.AsciiControlChars, CharacterType.AsciiDigits, CharacterType.AsciiPunctuation, CharacterType.AsciiSymbols, CharacterType.Separators, CharacterType.HighSurrogates,
        //     CharacterType.LowSurrogates, CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
        //     CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper,
        //     CharacterType.VowelsLower, CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.ControlChars, CharacterType.Digits, CharacterType.AsciiHexDigitsUpper,
        //     CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.CsIdentifierChars,
        //     CharacterType.UriDataChars, CharacterType.Letters };
        // actual = RandomCharacterSource.GetIncludedTypes(CharacterType.ControlChars);
        // Assert.That(actual, Is.Not.Null);
        // Assert.That(actual.ToArray(), Is.EqualTo(expected));

        // expected = new[] { CharacterType.AsciiControlChars, CharacterType.AsciiDigits, CharacterType.AsciiPunctuation, CharacterType.AsciiSymbols, CharacterType.Separators, CharacterType.HighSurrogates,
        //     CharacterType.LowSurrogates, CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
        //     CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper,
        //     CharacterType.VowelsLower, CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.ControlChars, CharacterType.Digits, CharacterType.AsciiHexDigitsUpper,
        //     CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.CsIdentifierChars,
        //     CharacterType.UriDataChars, CharacterType.Letters };
        // actual = RandomCharacterSource.GetIncludedTypes(CharacterType.Digits);
        // Assert.That(actual, Is.Not.Null);
        // Assert.That(actual.ToArray(), Is.EqualTo(expected));

        // expected = new[] { CharacterType.AsciiControlChars, CharacterType.AsciiDigits, CharacterType.AsciiPunctuation, CharacterType.AsciiSymbols, CharacterType.Separators, CharacterType.HighSurrogates,
        //     CharacterType.LowSurrogates, CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
        //     CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper,
        //     CharacterType.VowelsLower, CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.ControlChars, CharacterType.Digits, CharacterType.AsciiHexDigitsUpper,
        //     CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.CsIdentifierChars,
        //     CharacterType.UriDataChars, CharacterType.Letters };
        // actual = RandomCharacterSource.GetIncludedTypes(CharacterType.AsciiHexDigitsUpper);
        // Assert.That(actual, Is.Not.Null);
        // Assert.That(actual.ToArray(), Is.EqualTo(expected));

        // expected = new[] { CharacterType.AsciiControlChars, CharacterType.AsciiDigits, CharacterType.AsciiPunctuation, CharacterType.AsciiSymbols, CharacterType.Separators, CharacterType.HighSurrogates,
        //     CharacterType.LowSurrogates, CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
        //     CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper,
        //     CharacterType.VowelsLower, CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.ControlChars, CharacterType.Digits, CharacterType.AsciiHexDigitsUpper,
        //     CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.CsIdentifierChars,
        //     CharacterType.UriDataChars, CharacterType.Letters };
        // actual = RandomCharacterSource.GetIncludedTypes(CharacterType.AsciiHexDigitsLower);
        // Assert.That(actual, Is.Not.Null);
        // Assert.That(actual.ToArray(), Is.EqualTo(expected));

        // expected = new[] { CharacterType.AsciiControlChars, CharacterType.AsciiDigits, CharacterType.AsciiPunctuation, CharacterType.AsciiSymbols, CharacterType.Separators, CharacterType.HighSurrogates,
        //     CharacterType.LowSurrogates, CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
        //     CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper,
        //     CharacterType.VowelsLower, CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.ControlChars, CharacterType.Digits, CharacterType.AsciiHexDigitsUpper,
        //     CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.CsIdentifierChars,
        //     CharacterType.UriDataChars, CharacterType.Letters };
        // actual = RandomCharacterSource.GetIncludedTypes(CharacterType.AsciiHexDigits);
        // Assert.That(actual, Is.Not.Null);
        // Assert.That(actual.ToArray(), Is.EqualTo(expected));

        // expected = new[] { CharacterType.AsciiControlChars, CharacterType.AsciiDigits, CharacterType.AsciiPunctuation, CharacterType.AsciiSymbols, CharacterType.Separators, CharacterType.HighSurrogates,
        //     CharacterType.LowSurrogates, CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
        //     CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper,
        //     CharacterType.VowelsLower, CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.ControlChars, CharacterType.Digits, CharacterType.AsciiHexDigitsUpper,
        //     CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.CsIdentifierChars,
        //     CharacterType.UriDataChars, CharacterType.Letters };
        // actual = RandomCharacterSource.GetIncludedTypes(CharacterType.AsciiLettersAndDigits);
        // Assert.That(actual, Is.Not.Null);
        // Assert.That(actual.ToArray(), Is.EqualTo(expected));

        // expected = new[] { CharacterType.AsciiControlChars, CharacterType.AsciiDigits, CharacterType.AsciiPunctuation, CharacterType.AsciiSymbols, CharacterType.Separators, CharacterType.HighSurrogates,
        //     CharacterType.LowSurrogates, CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
        //     CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper,
        //     CharacterType.VowelsLower, CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.ControlChars, CharacterType.Digits, CharacterType.AsciiHexDigitsUpper,
        //     CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.CsIdentifierChars,
        //     CharacterType.UriDataChars, CharacterType.Letters };
        // actual = RandomCharacterSource.GetIncludedTypes(CharacterType.PunctuationChars);
        // Assert.That(actual, Is.Not.Null);
        // Assert.That(actual.ToArray(), Is.EqualTo(expected));

        // expected = new[] { CharacterType.AsciiControlChars, CharacterType.AsciiDigits, CharacterType.AsciiPunctuation, CharacterType.AsciiSymbols, CharacterType.Separators, CharacterType.HighSurrogates,
        //     CharacterType.LowSurrogates, CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
        //     CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper,
        //     CharacterType.VowelsLower, CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.ControlChars, CharacterType.Digits, CharacterType.AsciiHexDigitsUpper,
        //     CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.CsIdentifierChars,
        //     CharacterType.UriDataChars, CharacterType.Letters };
        // actual = RandomCharacterSource.GetIncludedTypes(CharacterType.Symbols);
        // Assert.That(actual, Is.Not.Null);
        // Assert.That(actual.ToArray(), Is.EqualTo(expected));

        // expected = new[] { CharacterType.AsciiControlChars, CharacterType.AsciiDigits, CharacterType.AsciiPunctuation, CharacterType.AsciiSymbols, CharacterType.Separators, CharacterType.HighSurrogates,
        //     CharacterType.LowSurrogates, CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
        //     CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper,
        //     CharacterType.VowelsLower, CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.ControlChars, CharacterType.Digits, CharacterType.AsciiHexDigitsUpper,
        //     CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.CsIdentifierChars,
        //     CharacterType.UriDataChars, CharacterType.Letters };
        // actual = RandomCharacterSource.GetIncludedTypes(CharacterType.WhiteSpaceChars);
        // Assert.That(actual, Is.Not.Null);
        // Assert.That(actual.ToArray(), Is.EqualTo(expected));

        // expected = new[] { CharacterType.AsciiControlChars, CharacterType.AsciiDigits, CharacterType.AsciiPunctuation, CharacterType.AsciiSymbols, CharacterType.Separators, CharacterType.HighSurrogates,
        //     CharacterType.LowSurrogates, CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
        //     CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper,
        //     CharacterType.VowelsLower, CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.ControlChars, CharacterType.Digits, CharacterType.AsciiHexDigitsUpper,
        //     CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.CsIdentifierChars,
        //     CharacterType.UriDataChars, CharacterType.Letters };
        // actual = RandomCharacterSource.GetIncludedTypes(CharacterType.Numbers);
        // Assert.That(actual, Is.Not.Null);
        // Assert.That(actual.ToArray(), Is.EqualTo(expected));

        // expected = new[] { CharacterType.AsciiControlChars, CharacterType.AsciiDigits, CharacterType.AsciiPunctuation, CharacterType.AsciiSymbols, CharacterType.Separators, CharacterType.HighSurrogates,
        //     CharacterType.LowSurrogates, CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
        //     CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper,
        //     CharacterType.VowelsLower, CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.ControlChars, CharacterType.Digits, CharacterType.AsciiHexDigitsUpper,
        //     CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.CsIdentifierChars,
        //     CharacterType.UriDataChars, CharacterType.Letters };
        // actual = RandomCharacterSource.GetIncludedTypes(CharacterType.UpperChars);
        // Assert.That(actual, Is.Not.Null);
        // Assert.That(actual.ToArray(), Is.EqualTo(expected));

        // expected = new[] { CharacterType.AsciiControlChars, CharacterType.AsciiDigits, CharacterType.AsciiPunctuation, CharacterType.AsciiSymbols, CharacterType.Separators, CharacterType.HighSurrogates,
        //     CharacterType.LowSurrogates, CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
        //     CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper,
        //     CharacterType.VowelsLower, CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.ControlChars, CharacterType.Digits, CharacterType.AsciiHexDigitsUpper,
        //     CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.CsIdentifierChars,
        //     CharacterType.UriDataChars, CharacterType.Letters };
        // actual = RandomCharacterSource.GetIncludedTypes(CharacterType.LowerChars);
        // Assert.That(actual, Is.Not.Null);
        // Assert.That(actual.ToArray(), Is.EqualTo(expected));

        // expected = new[] { CharacterType.AsciiControlChars, CharacterType.AsciiDigits, CharacterType.AsciiPunctuation, CharacterType.AsciiSymbols, CharacterType.Separators, CharacterType.HighSurrogates,
        //     CharacterType.LowSurrogates, CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
        //     CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper,
        //     CharacterType.VowelsLower, CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.ControlChars, CharacterType.Digits, CharacterType.AsciiHexDigitsUpper,
        //     CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.CsIdentifierChars,
        //     CharacterType.UriDataChars, CharacterType.Letters };
        // actual = RandomCharacterSource.GetIncludedTypes(CharacterType.CsIdentifierChars);
        // Assert.That(actual, Is.Not.Null);
        // Assert.That(actual.ToArray(), Is.EqualTo(expected));

        // expected = new[] { CharacterType.AsciiControlChars, CharacterType.AsciiDigits, CharacterType.AsciiPunctuation, CharacterType.AsciiSymbols, CharacterType.Separators, CharacterType.HighSurrogates,
        //     CharacterType.LowSurrogates, CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
        //     CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper,
        //     CharacterType.VowelsLower, CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.ControlChars, CharacterType.Digits, CharacterType.AsciiHexDigitsUpper,
        //     CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.CsIdentifierChars,
        //     CharacterType.UriDataChars, CharacterType.Letters };
        // actual = RandomCharacterSource.GetIncludedTypes(CharacterType.UriDataChars);
        // Assert.That(actual, Is.Not.Null);
        // Assert.That(actual.ToArray(), Is.EqualTo(expected));

        // expected = new[] { CharacterType.AsciiControlChars, CharacterType.AsciiDigits, CharacterType.AsciiPunctuation, CharacterType.AsciiSymbols, CharacterType.Separators, CharacterType.HighSurrogates,
        //     CharacterType.LowSurrogates, CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
        //     CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper,
        //     CharacterType.VowelsLower, CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.ControlChars, CharacterType.Digits, CharacterType.AsciiHexDigitsUpper,
        //     CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.CsIdentifierChars,
        //     CharacterType.UriDataChars, CharacterType.Letters };
        // actual = RandomCharacterSource.GetIncludedTypes(CharacterType.Letters);
        // Assert.That(actual, Is.Not.Null);
        // Assert.That(actual.ToArray(), Is.EqualTo(expected));

        // expected = new[] { CharacterType.AsciiControlChars, CharacterType.AsciiDigits, CharacterType.AsciiPunctuation, CharacterType.AsciiSymbols, CharacterType.Separators, CharacterType.HighSurrogates,
        //     CharacterType.LowSurrogates, CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
        //     CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper,
        //     CharacterType.VowelsLower, CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.ControlChars, CharacterType.Digits, CharacterType.AsciiHexDigitsUpper,
        //     CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.CsIdentifierChars,
        //     CharacterType.UriDataChars, CharacterType.Letters };
        // actual = RandomCharacterSource.GetIncludedTypes(CharacterType.LettersAndDigits);
        // Assert.That(actual, Is.Not.Null);
        // Assert.That(actual.ToArray(), Is.EqualTo(expected));

        // expected = new[] { CharacterType.AsciiControlChars, CharacterType.AsciiDigits, CharacterType.AsciiPunctuation, CharacterType.AsciiSymbols, CharacterType.Separators, CharacterType.HighSurrogates,
        //     CharacterType.LowSurrogates, CharacterType.HardConsonantsUpper, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
        //     CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.VowelsUpper, CharacterType.AsciiLettersUpper,
        //     CharacterType.VowelsLower, CharacterType.AsciiLettersLower, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.ControlChars, CharacterType.Digits, CharacterType.AsciiHexDigitsUpper,
        //     CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.CsIdentifierChars,
        //     CharacterType.UriDataChars, CharacterType.Letters };
        // actual = RandomCharacterSource.GetIncludedTypes(CharacterType.AsciiChars);
        // Assert.That(actual, Is.Not.Null);
        // Assert.That(actual.ToArray(), Is.EqualTo(expected));
    }
}