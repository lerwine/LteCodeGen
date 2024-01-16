using static TestDataGeneration.CharacterTypes;
using static TestDataGeneration.UnitTests.HelperMethods;

namespace TestDataGeneration.UnitTests;

public class CharacterTypesTests
{
#pragma warning disable NUnit2014
    [Test]
    public void FlagsTest()
    {
        ulong[] bitValues = new[] { Flag_AsciiNonWsControlChars, Flag_AsciiWhitespaceControlChars, Flag_Space, Flag_NonAsciiSeparator, Flag_AsciiPunctuation, Flag_AsciiDigits, Flag_AsciiSymbols, Flag_Plus, Flag_Dash,
            Flag_Period, Flag_HexDigitVowelsUpper, Flag_UpperB, Flag_UpperC, Flag_UpperD, Flag_UpperF, Flag_VowelsUpper, Flag_HardConsonantsUpper, Flag_SoftConsonantsUpper, Flag_UpperY, Flag_Underscore,
            Flag_HexDigitVowelsLower, Flag_LowerB, Flag_LowerC, Flag_LowerD, Flag_LowerF, Flag_VowelsLower, Flag_HardConsonantsLower, Flag_SoftConsonantsLower, Flag_LowerY, Flag_Tilde, Flag_NonAsciiNonWsControlChars,
            Flag_NonAsciiPunctuationChars, Flag_NonAsciiSymbols, Flag_NonSeparatorWhiteSpace, Flag_NonAsciiNumbers, Flag_NonAsciiDigits, Flag_UpperNonAsciiChars, Flag_LowerNonAsciiChars, Flag_NonAsciiNonCaseLetters,
            Flag_HighSurrogates, Flag_LowSurrogates };
        var expected = 1UL;
        int index = -1;
        foreach (ulong value in bitValues)
        {
            index++;
            Assert.That(value, Is.EqualTo(expected), $"Index: {index}");
            expected <<= 1;
        }
    }

    [Test]
    public void AsciiControlCharsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.AsciiControlChars;
        var expectedValues = new[] { CharacterType.AsciiChars, CharacterType.ControlChars };
        var notExpectedValues = new[] { CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash, CharacterType.Period,
            CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper,
            CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower, CharacterType.HardConsonants,
            CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower,
            CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.UriDataChars, CharacterType.PunctuationChars,
            CharacterType.Symbols, CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.Letters, CharacterType.LettersAndDigits,
            CharacterType.HighSurrogates, CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        // BUG: Where flag is AsciiControlChars: NotSpecified does not exist in neither the expectedValues nor the notExpectedValues array
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target: {target:F}");
    }

    [Test]
    public void SpaceCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.Space;
        var expectedValues = new[] { CharacterType.Separators, CharacterType.AsciiChars, CharacterType.WhiteSpaceChars, CharacterType.AsciiWhiteSpace };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash, CharacterType.Period, CharacterType.AsciiHexDigitsUpper,
            CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper, CharacterType.Underscore,
            CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.VowelsLower,
            CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters,
            CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.UriDataChars, CharacterType.PunctuationChars, CharacterType.Symbols,
            CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.Letters, CharacterType.LettersAndDigits, CharacterType.HighSurrogates, CharacterType.ControlChars,
            CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target: {target:F}");
    }

    [Test]
    public void AsciiWhiteSpaceCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.AsciiWhiteSpace;
        var expectedValues = new[] { CharacterType.AsciiChars, CharacterType.WhiteSpaceChars };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash, CharacterType.Period,
            CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper,
            CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower, CharacterType.HardConsonants,
            CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower,
            CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.UriDataChars, CharacterType.PunctuationChars,
            CharacterType.Symbols, CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.Letters, CharacterType.LettersAndDigits, CharacterType.HighSurrogates,
            CharacterType.ControlChars, CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void SeparatorsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.Separators;
        var expectedValue = CharacterType.WhiteSpaceChars;
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash, CharacterType.Period,
            CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper,
            CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower, CharacterType.HardConsonants,
            CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower,
            CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.UriDataChars, CharacterType.AsciiChars,
            CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.Letters, CharacterType.LettersAndDigits,
            CharacterType.HighSurrogates, CharacterType.ControlChars, CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValue, notExpectedValues);
        Assert.That(expectedValue.HasFlag(flag), Is.True);
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void AsciiDigitsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.AsciiDigits;
        var expectedValues = new[] { CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigitsUpper, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars,
            CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.Numbers, CharacterType.Digits, CharacterType.LettersAndDigits };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.Plus, CharacterType.Dash, CharacterType.Period,
            CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper, CharacterType.Underscore,
            CharacterType.AsciiPunctuation, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower,
            CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.Tilde, CharacterType.AsciiSymbols,
            CharacterType.ControlChars, CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.Letters,
            CharacterType.HighSurrogates, CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void PlusCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.Plus;
        var expectedValues = new[] { CharacterType.AsciiSymbols, CharacterType.AsciiChars, CharacterType.Symbols };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Dash, CharacterType.Period,
            CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper,
            CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower, CharacterType.HardConsonants,
            CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower,
            CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.Tilde, CharacterType.UriDataChars, CharacterType.ControlChars, CharacterType.PunctuationChars,
            CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.Letters, CharacterType.LettersAndDigits,
            CharacterType.HighSurrogates, CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void DashCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.Dash;
        var expectedValues = new[] { CharacterType.AsciiPunctuation, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.PunctuationChars };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Period,
            CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper,
            CharacterType.Underscore, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels,
            CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters,
            CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.ControlChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars,
            CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.Letters, CharacterType.LettersAndDigits, CharacterType.HighSurrogates,
            CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void PeriodCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.Period;
        var expectedValues = new[] { CharacterType.AsciiPunctuation, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.PunctuationChars };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper,
            CharacterType.Underscore, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels,
            CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters,
            CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.ControlChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars,
            CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.Letters, CharacterType.LettersAndDigits, CharacterType.HighSurrogates,
            CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void AsciiHexDigitsUpperCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.AsciiHexDigitsUpper;
        var expectedValues = new[] { CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.LettersAndDigits };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper, CharacterType.Underscore,
            CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels,
            CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.Tilde,
            CharacterType.AsciiSymbols, CharacterType.ControlChars, CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.Digits,
            CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.Letters, CharacterType.HighSurrogates, CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void HardConsonantsUpperCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.HardConsonantsUpper;
        var expectedValues = new[] { CharacterType.AsciiLettersUpper, CharacterType.ConsonantsUpper, CharacterType.HardConsonants, CharacterType.Consonants, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits,
            CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.UpperChars, CharacterType.Letters, CharacterType.LettersAndDigits };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation,
            CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower,
            CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.AsciiLettersLower, CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.ControlChars, CharacterType.PunctuationChars,
            CharacterType.Symbols, CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.Digits, CharacterType.LowerChars, CharacterType.HighSurrogates, CharacterType.LowSurrogates, CharacterType.Surrogates,
            CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void VowelsUpperCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.VowelsUpper;
        var expectedValues = new[] { CharacterType.Vowels, CharacterType.AsciiLettersUpper, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars,
            CharacterType.AsciiChars, CharacterType.UpperChars, CharacterType.Letters, CharacterType.LettersAndDigits };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper, CharacterType.Underscore,
            CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.VowelsLower,
            CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.Tilde, CharacterType.AsciiSymbols,
            CharacterType.ControlChars, CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.Digits, CharacterType.LowerChars,
            CharacterType.HighSurrogates, CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void SoftConsonantsUpperCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.SoftConsonantsUpper;
        var expectedValues = new[] { CharacterType.AsciiLettersUpper, CharacterType.ConsonantsUpper, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits,
            CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.UpperChars, CharacterType.Letters, CharacterType.LettersAndDigits };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation,
            CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels,
            CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.AsciiLettersLower, CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.ControlChars, CharacterType.PunctuationChars,
            CharacterType.Symbols, CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.Digits, CharacterType.LowerChars, CharacterType.HighSurrogates, CharacterType.LowSurrogates, CharacterType.Surrogates,
            CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void ConsonantsUpperCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.ConsonantsUpper;
        var expectedValues = new[] { CharacterType.AsciiLettersUpper, CharacterType.Consonants, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars,
            CharacterType.AsciiChars, CharacterType.UpperChars, CharacterType.Letters, CharacterType.LettersAndDigits };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.Underscore,
            CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.VowelsLower,
            CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.AsciiLettersLower, CharacterType.Tilde, CharacterType.AsciiSymbols,
            CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.Digits, CharacterType.LowerChars, CharacterType.HighSurrogates,
            CharacterType.ControlChars, CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void AsciiLettersUpperCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.AsciiLettersUpper;
        var expectedValues = new[] { CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.UpperChars,
            CharacterType.Letters, CharacterType.LettersAndDigits };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower, CharacterType.HardConsonants,
            CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower,
            CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.Digits, CharacterType.LowerChars,
            CharacterType.HighSurrogates, CharacterType.ControlChars, CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void UnderscoreCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.Underscore;
        var expectedValues = new[] { CharacterType.AsciiPunctuation, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.PunctuationChars };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.AsciiLettersUpper, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.VowelsLower,
            CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters,
            CharacterType.AsciiLettersAndDigits, CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.Symbols, CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.Digits,
            CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.Letters, CharacterType.LettersAndDigits, CharacterType.HighSurrogates, CharacterType.ControlChars, CharacterType.LowSurrogates,
            CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void AsciiPunctuationCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.AsciiPunctuation;
        var expectedValues = new[] { CharacterType.AsciiChars, CharacterType.PunctuationChars };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower, CharacterType.HardConsonants,
            CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower,
            CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.UriDataChars, CharacterType.Symbols,
            CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.Letters, CharacterType.LettersAndDigits,
            CharacterType.HighSurrogates, CharacterType.ControlChars, CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void AsciiHexDigitsLowerCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.AsciiHexDigitsLower;
        var expectedValues = new[] { CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.LettersAndDigits };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.AsciiLettersUpper,
            CharacterType.ConsonantsUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.HardConsonantsLower, CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels,
            CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.Tilde,
            CharacterType.AsciiSymbols, CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars,
            CharacterType.LowerChars, CharacterType.Letters, CharacterType.HighSurrogates, CharacterType.ControlChars, CharacterType.LowSurrogates, CharacterType.Surrogates };
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void AsciiHexDigitsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.AsciiHexDigits;
        var expectedValues = new[] { CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.LettersAndDigits };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.HardConsonantsLower, CharacterType.HardConsonants,
            CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower,
            CharacterType.AsciiLetters, CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.Digits,
            CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.Letters, CharacterType.HighSurrogates, CharacterType.ControlChars, CharacterType.LowSurrogates, CharacterType.Surrogates,
            CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void HardConsonantsLowerCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.HardConsonantsLower;
        var expectedValues = new[] { CharacterType.HardConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits,
            CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.LowerChars, CharacterType.Letters, CharacterType.LettersAndDigits };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.VowelsLower, CharacterType.Vowels,
            CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars,
            CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars, CharacterType.HighSurrogates, CharacterType.ControlChars, CharacterType.LowSurrogates, CharacterType.Surrogates,
            CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void HardConsonantsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.HardConsonants;
        var expectedValues = new[] { CharacterType.Consonants, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars,
            CharacterType.Letters, CharacterType.LettersAndDigits };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower,
            CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.AsciiLettersLower, CharacterType.Tilde,
            CharacterType.AsciiSymbols, CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars,
            CharacterType.LowerChars, CharacterType.HighSurrogates, CharacterType.ControlChars, CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void VowelsLowerCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.VowelsLower;
        var expectedValues = new[] { CharacterType.Vowels, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars,
            CharacterType.AsciiChars, CharacterType.LowerChars, CharacterType.Letters, CharacterType.LettersAndDigits };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower,
            CharacterType.HardConsonants, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.Tilde, CharacterType.AsciiSymbols,
            CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars, CharacterType.HighSurrogates,
            CharacterType.ControlChars, CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void VowelsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.Vowels;
        var expectedValues = new[] { CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.Letters,
            CharacterType.LettersAndDigits };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower,
            CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants,
            CharacterType.AsciiLettersLower, CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars, CharacterType.Numbers,
            CharacterType.Digits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.HighSurrogates, CharacterType.ControlChars, CharacterType.LowSurrogates, CharacterType.Surrogates,
            CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void SoftConsonantsLowerCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.SoftConsonantsLower;
        var expectedValues = new[] { CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits,
            CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.LowerChars, CharacterType.Letters, CharacterType.LettersAndDigits };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower,
            CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.PunctuationChars, CharacterType.Symbols,
            CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars, CharacterType.HighSurrogates, CharacterType.ControlChars, CharacterType.LowSurrogates,
            CharacterType.Surrogates };
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void SoftConsonantsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.SoftConsonants;
        var expectedValues = new[] { CharacterType.Consonants, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars,
            CharacterType.Letters, CharacterType.LettersAndDigits };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower,
            CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.ConsonantsLower, CharacterType.AsciiLettersLower, CharacterType.Tilde,
            CharacterType.AsciiSymbols, CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars,
            CharacterType.LowerChars, CharacterType.HighSurrogates, CharacterType.ControlChars, CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void ConsonantsLowerCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.ConsonantsLower;
        var expectedValues = new[] { CharacterType.Consonants, CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars,
            CharacterType.AsciiChars, CharacterType.LowerChars, CharacterType.Letters, CharacterType.LettersAndDigits };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower,
            CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.Tilde, CharacterType.AsciiSymbols,
            CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars, CharacterType.HighSurrogates,
            CharacterType.ControlChars, CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void ConsonantsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.Consonants;
        var expectedValues = new[] { CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.Letters,
            CharacterType.LettersAndDigits };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower,
            CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.AsciiLettersLower,
            CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars,
            CharacterType.LowerChars, CharacterType.HighSurrogates, CharacterType.ControlChars, CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void AsciiLettersLowerCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.AsciiLettersLower;
        var expectedValues = new[] { CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.LowerChars,
            CharacterType.Letters, CharacterType.LettersAndDigits };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower,
            CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants,
            CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars,
            CharacterType.HighSurrogates, CharacterType.ControlChars, CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void AsciiLettersCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.AsciiLetters;
        var expectedValues = new[] { CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.Letters, CharacterType.LettersAndDigits };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower,
            CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants,
            CharacterType.AsciiLettersLower, CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars, CharacterType.Numbers,
            CharacterType.Digits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.HighSurrogates, CharacterType.ControlChars, CharacterType.LowSurrogates, CharacterType.Surrogates,
            CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void AsciiLettersAndDigitsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.AsciiLettersAndDigits;
        var expectedValues = new[] { CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.LettersAndDigits };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower,
            CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants,
            CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars,
            CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.Letters, CharacterType.HighSurrogates, CharacterType.ControlChars, CharacterType.LowSurrogates,
            CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void CsIdentifierCharsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.CsIdentifierChars;
        var expectedValues = new[] { CharacterType.UriDataChars, CharacterType.AsciiChars };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower,
            CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants,
            CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.PunctuationChars, CharacterType.Symbols,
            CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.Letters, CharacterType.LettersAndDigits,
            CharacterType.HighSurrogates, CharacterType.ControlChars, CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void TildeCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.Tilde;
        var expectedValues = new[] { CharacterType.AsciiSymbols, CharacterType.AsciiChars, CharacterType.UriDataChars, CharacterType.Symbols };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower,
            CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants,
            CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.PunctuationChars, CharacterType.WhiteSpaceChars,
            CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.Letters, CharacterType.LettersAndDigits, CharacterType.HighSurrogates, CharacterType.ControlChars,
            CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void AsciiSymbolsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.AsciiSymbols;
        var expectedValues = new[] { CharacterType.AsciiChars, CharacterType.Symbols };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower,
            CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants,
            CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.Tilde, CharacterType.UriDataChars,
            CharacterType.PunctuationChars, CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.Letters,
            CharacterType.LettersAndDigits, CharacterType.HighSurrogates, CharacterType.ControlChars, CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void UriDataCharsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.UriDataChars;
        var expectedValues = new[] { CharacterType.AsciiChars };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower,
            CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants,
            CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.Tilde, CharacterType.AsciiSymbols,
            CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.Letters,
            CharacterType.LettersAndDigits, CharacterType.HighSurrogates, CharacterType.ControlChars, CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void AsciiCharsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.AsciiChars;
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower,
            CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants,
            CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.UriDataChars,
            CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.Letters,
            CharacterType.LettersAndDigits, CharacterType.HighSurrogates, CharacterType.ControlChars, CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, null, notExpectedValues);
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void PunctuationCharsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.PunctuationChars;
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower,
            CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants,
            CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.UriDataChars,
            CharacterType.AsciiChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.Letters,
            CharacterType.LettersAndDigits, CharacterType.HighSurrogates, CharacterType.ControlChars, CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, null, notExpectedValues);
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void SymbolsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.Symbols;
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower,
            CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants,
            CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.UriDataChars,
            CharacterType.AsciiChars, CharacterType.PunctuationChars, CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.Letters,
            CharacterType.LettersAndDigits, CharacterType.HighSurrogates, CharacterType.ControlChars, CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, null, notExpectedValues);
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void WhiteSpaceCharsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.WhiteSpaceChars;
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower,
            CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants,
            CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.UriDataChars,
            CharacterType.AsciiChars, CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.Letters,
            CharacterType.LettersAndDigits, CharacterType.HighSurrogates, CharacterType.ControlChars, CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, null, notExpectedValues);
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void NumbersCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.Numbers;
        var expectedValues = new[] { CharacterType.Digits, CharacterType.LettersAndDigits };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower,
            CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants,
            CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.UriDataChars,
            CharacterType.AsciiChars, CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.Letters,
            CharacterType.HighSurrogates, CharacterType.ControlChars, CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void DigitsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.Digits;
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower,
            CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants,
            CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.UriDataChars,
            CharacterType.AsciiChars, CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.UpperChars, CharacterType.LowerChars, CharacterType.Letters,
            CharacterType.LettersAndDigits, CharacterType.HighSurrogates, CharacterType.ControlChars, CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, null, notExpectedValues);
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void UpperCharsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.UpperChars;
        var expectedValues = new[] { CharacterType.Letters, CharacterType.LettersAndDigits };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower,
            CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants,
            CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.UriDataChars,
            CharacterType.AsciiChars, CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.Digits, CharacterType.LowerChars,
            CharacterType.HighSurrogates, CharacterType.ControlChars, CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void LowerCharsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.LowerChars;
        var expectedValues = new[] { CharacterType.Letters, CharacterType.LettersAndDigits };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower,
            CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants,
            CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.UriDataChars,
            CharacterType.AsciiChars, CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars,
            CharacterType.HighSurrogates, CharacterType.ControlChars, CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void LettersCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.Letters;
        var expectedValues = new[] { CharacterType.LettersAndDigits };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower,
            CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants,
            CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.UriDataChars,
            CharacterType.AsciiChars, CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars, CharacterType.LowerChars,
            CharacterType.HighSurrogates, CharacterType.ControlChars, CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void LettersAndDigitsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.LettersAndDigits;
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower,
            CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants,
            CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.UriDataChars,
            CharacterType.AsciiChars, CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars, CharacterType.LowerChars,
            CharacterType.Letters, CharacterType.HighSurrogates, CharacterType.ControlChars, CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, null, notExpectedValues);
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void HighSurrogatesCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.HighSurrogates;
        var expectedValues = new[] { CharacterType.Surrogates };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower,
            CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants,
            CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.UriDataChars,
            CharacterType.AsciiChars, CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars, CharacterType.LowerChars,
            CharacterType.Letters, CharacterType.LettersAndDigits, CharacterType.ControlChars, CharacterType.LowSurrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void ControlCharsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.ControlChars;
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower,
            CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants,
            CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.UriDataChars,
            CharacterType.AsciiChars, CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars, CharacterType.LowerChars,
            CharacterType.Letters, CharacterType.LettersAndDigits, CharacterType.HighSurrogates, CharacterType.LowSurrogates, CharacterType.Surrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, null, notExpectedValues);
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void LowSurrogatesCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.LowSurrogates;
        var expectedValues = new[] { CharacterType.Surrogates };
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower,
            CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants,
            CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.UriDataChars,
            CharacterType.AsciiChars, CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars, CharacterType.LowerChars,
            CharacterType.Letters, CharacterType.LettersAndDigits, CharacterType.HighSurrogates, CharacterType.ControlChars, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void SurrogatesCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterType.Surrogates;
        var notExpectedValues = new[] { CharacterType.AsciiControlChars, CharacterType.Space, CharacterType.AsciiWhiteSpace, CharacterType.Separators, CharacterType.AsciiDigits, CharacterType.Plus, CharacterType.Dash,
            CharacterType.Period, CharacterType.AsciiHexDigitsUpper, CharacterType.HardConsonantsUpper, CharacterType.VowelsUpper, CharacterType.SoftConsonantsUpper, CharacterType.ConsonantsUpper,
            CharacterType.AsciiLettersUpper, CharacterType.Underscore, CharacterType.AsciiPunctuation, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.HardConsonantsLower,
            CharacterType.HardConsonants, CharacterType.VowelsLower, CharacterType.Vowels, CharacterType.SoftConsonantsLower, CharacterType.SoftConsonants, CharacterType.ConsonantsLower, CharacterType.Consonants,
            CharacterType.AsciiLettersLower, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.Tilde, CharacterType.AsciiSymbols, CharacterType.UriDataChars,
            CharacterType.AsciiChars, CharacterType.PunctuationChars, CharacterType.Symbols, CharacterType.WhiteSpaceChars, CharacterType.Numbers, CharacterType.Digits, CharacterType.UpperChars, CharacterType.LowerChars,
            CharacterType.Letters, CharacterType.LettersAndDigits, CharacterType.HighSurrogates, CharacterType.ControlChars, CharacterType.LowSurrogates, CharacterType.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, null, notExpectedValues);
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void AsciiNonWsControlCharsTest()
    {
        var expected = GetAllTestCharacters().Where(c => char.IsControl(c) && char.IsAscii(c) && !char.IsWhiteSpace(c)).ToArray();
        var actual = GetAsciiNonWsControlChars().ToArray();
        Assert.That(actual, Has.Length.EqualTo(expected.Length));
        foreach (char target in expected)
            Assert.That(actual.Contains(target), Is.True);
    }

    [Test]
    public void AsciiWhitespaceControlCharsTest()
    {
        var expected = GetAllTestCharacters().Where(c => char.IsControl(c) && char.IsWhiteSpace(c) && char.IsAscii(c)).ToArray();
        var actual = GetAsciiWhitespaceControlChars().ToArray();
        Assert.That(actual, Has.Length.EqualTo(expected.Length));
        foreach (char target in expected)
            Assert.That(actual.Contains(target), Is.True);
    }

    [Test]
    public void NonAsciiSeparatorCharsTest()
    {
        var expected = GetAllTestCharacters().Where(c => char.IsSeparator(c) && !char.IsAscii(c)).ToArray();
        var actual = GetNonAsciiSeparatorChars().ToArray();
        Assert.That(actual, Has.Length.EqualTo(expected.Length));
        foreach (char target in expected)
            Assert.That(actual.Contains(target), Is.True);
    }

    [Test]
    public void AsciiPunctuationTest()
    {
        var expected = GetAllTestCharacters().Where(c => char.IsAscii(c) && c switch
        {
            '-' or '.' or '_' => false,
            _ => char.IsPunctuation(c),
        }).ToArray();
        var actual = GetAsciiPunctuation().ToArray();
        Assert.That(actual, Has.Length.EqualTo(expected.Length));
        foreach (char target in expected)
            Assert.That(actual.Contains(target), Is.True);
    }

    [Test]
    public void AsciiDigitsTest()
    {
        var expected = GetAllTestCharacters().Where(char.IsAsciiDigit).ToArray();
        var actual = GetAsciiDigits().ToArray();
        Assert.That(actual, Has.Length.EqualTo(expected.Length));
        foreach (char target in expected)
            Assert.That(actual.Contains(target), Is.True);
    }

    [Test]
    public void AsciiSymbolsTest()
    {
        var expected = GetAllTestCharacters().Where(c => char.IsAscii(c) && c switch
        {
            '+' or '~' => false,
            _ => char.IsSymbol(c),
        }).ToArray();
        var actual = GetAsciiSymbols().ToArray();
        Assert.That(actual, Has.Length.EqualTo(expected.Length));
        foreach (char target in expected)
            Assert.That(actual.Contains(target), Is.True);
    }

    [Test]
    public void HexDigitVowelsUpperTest()
    {
        var expected = new[] { 'A', 'E' };
        var actual = GetHexDigitVowelsUpper().ToArray();
        Assert.That(actual, Has.Length.EqualTo(expected.Length));
        foreach (char target in expected)
            Assert.That(actual.Contains(target), Is.True);
    }

    [Test]
    public void VowelsUpperTest()
    {
        var expected = new[] { 'I', 'O', 'U' };
        var actual = GetVowelsUpper().ToArray();
        Assert.That(actual, Has.Length.EqualTo(expected.Length));
        foreach (char target in expected)
            Assert.That(actual.Contains(target), Is.True);
    }

    [Test]
    public void HardConsonantsUpperTest()
    {
        var expected = new[] { 'G', 'J', 'K', 'P', 'Q', 'T', 'X' };
        var actual = GetHardConsonantsUpper().ToArray();
        Assert.That(actual, Has.Length.EqualTo(expected.Length));
        foreach (char target in expected)
            Assert.That(actual.Contains(target), Is.True);
    }

    [Test]
    public void SoftConsonantsUpperTest()
    {
        var expected = new[] { 'H', 'L', 'M', 'N', 'R', 'S', 'V', 'W', 'Z' };
        var actual = GetSoftConsonantsUpper().ToArray();
        Assert.That(actual, Has.Length.EqualTo(expected.Length));
        foreach (char target in expected)
            Assert.That(actual.Contains(target), Is.True);
    }

    [Test]
    public void VowelsLowerTest()
    {
        var expected = new[] { 'i', 'o', 'u' };
        var actual = GetVowelsLower().ToArray();
        Assert.That(actual, Has.Length.EqualTo(expected.Length));
        foreach (char target in expected)
            Assert.That(actual.Contains(target), Is.True);
    }

    [Test]
    public void HardConsonantsLowerTest()
    {
        var expected = new[] { 'g', 'j', 'k', 'p', 'q', 't', 'x' };
        var actual = GetHardConsonantsLower().ToArray();
        Assert.That(actual, Has.Length.EqualTo(expected.Length));
        foreach (char target in expected)
            Assert.That(actual.Contains(target), Is.True);
    }

    [Test]
    public void SoftConsonantsLowerTest()
    {
        var expected = new[] { 'h', 'l', 'm', 'n', 'r', 's', 'v', 'w', 'z' };
        var actual = GetSoftConsonantsLower().ToArray();
        Assert.That(actual, Has.Length.EqualTo(expected.Length));
        foreach (char target in expected)
            Assert.That(actual.Contains(target), Is.True);
    }

    [Test]
    public void NonAsciiNonWsControlCharsTest()
    {
        var expected = GetAllTestCharacters().Where(c => char.IsControl(c) && !(char.IsWhiteSpace(c) || char.IsAscii(c))).ToArray();
        var actual = GetNonAsciiNonWsControlChars().ToArray();
        Assert.That(actual, Has.Length.EqualTo(expected.Length));
        foreach (char target in expected)
            Assert.That(actual.Contains(target), Is.True);
    }

    [Test]
    public void NonAsciiPunctuationCharsTest()
    {
        var expected = GetAllTestCharacters().Where(c => char.IsPunctuation(c) && !char.IsAscii(c)).ToArray();
        var actual = GetNonAsciiPunctuationChars().ToArray();
        Assert.That(actual, Has.Length.EqualTo(expected.Length));
        foreach (char target in expected)
            Assert.That(actual.Contains(target), Is.True);
    }

    [Test]
    public void NonAsciiSymbolsTest()
    {
        var expected = GetAllTestCharacters().Where(c => char.IsSymbol(c) && !char.IsAscii(c)).ToArray();
        var actual = GetNonAsciiSymbols().ToArray();
        Assert.That(actual, Has.Length.EqualTo(expected.Length));
        foreach (char target in expected)
            Assert.That(actual.Contains(target), Is.True);
    }

    [Test]
    public void NonAsciiNumbersTest()
    {
        var expected = GetAllTestCharacters().Where(c => char.IsNumber(c) && !(char.IsDigit(c) || char.IsAscii(c))).ToArray();
        var actual = GetNonAsciiNumbers().ToArray();
        Assert.That(actual, Has.Length.EqualTo(expected.Length));
        foreach (char target in expected)
            Assert.That(actual.Contains(target), Is.True);
    }

    [Test]
    public void NonAsciiDigitsTest()
    {
        var expected = GetAllTestCharacters().Where(c => char.IsDigit(c) && !char.IsAscii(c)).ToArray();
        var actual = GetNonAsciiDigits().ToArray();
        Assert.That(actual, Has.Length.EqualTo(expected.Length));
        foreach (char target in expected)
            Assert.That(actual.Contains(target), Is.True);
    }

    [Test]
    public void UpperNonAsciiCharsTest()
    {
        var expected = GetAllTestCharacters().Where(c => char.IsUpper(c) && !char.IsAscii(c)).ToArray();
        var actual = GetUpperNonAsciiChars().ToArray();
        Assert.That(actual, Has.Length.EqualTo(expected.Length));
        foreach (char target in expected)
            Assert.That(actual.Contains(target), Is.True);
    }

    [Test]
    public void LowerNonAsciiCharsTest()
    {
        var expected = GetAllTestCharacters().Where(c => char.IsLower(c) && !char.IsAscii(c)).ToArray();
        var actual = GetLowerNonAsciiChars().ToArray();
        Assert.That(actual, Has.Length.EqualTo(expected.Length));
        foreach (char target in expected)
            Assert.That(actual.Contains(target), Is.True);
    }

    [Test]
    public void NonAsciiNonCaseLettersTest()
    {
        var expected = GetAllTestCharacters().Where(c => char.IsLetter(c) && !(char.IsUpper(c) || char.IsLower(c) || char.IsAscii(c))).ToArray();
        var actual = GetNonAsciiNonCaseLetters().ToArray();
        Assert.That(actual, Has.Length.EqualTo(expected.Length));
        foreach (char target in expected)
            Assert.That(actual.Contains(target), Is.True);
    }

    [Test]
    public void AllNonAsciiLettersTest()
    {
        var expected = GetAllTestCharacters().Where(c => char.IsLetter(c) && !char.IsAscii(c)).ToArray();
        var actual = GetAllNonAsciiLetters().ToArray();
        Assert.That(actual, Has.Length.EqualTo(expected.Length));
        foreach (char target in expected)
            Assert.That(actual.Contains(target), Is.True);
    }

    [Test]
    public void HighSurrogatesTest()
    {
        var expected = GetAllTestCharacters().Where(c => char.IsHighSurrogate(c) && !char.IsAscii(c)).ToArray();
        var actual = GetHighSurrogates().ToArray();
        Assert.That(actual, Has.Length.EqualTo(expected.Length));
        foreach (char target in expected)
            Assert.That(actual.Contains(target), Is.True);
    }

    [Test]
    public void LowSurrogatesTest()
    {
        var expected = GetAllTestCharacters().Where(c => char.IsLowSurrogate(c) && !char.IsAscii(c)).ToArray();
        var actual = GetLowSurrogates().ToArray();
        Assert.That(actual, Has.Length.EqualTo(expected.Length));
        foreach (char target in expected)
            Assert.That(actual.Contains(target), Is.True);
    }

    [Test]
    public void AllSurrogatesTest()
    {
        var expected = GetAllTestCharacters().Where(c => char.IsSurrogate(c) && !char.IsAscii(c)).ToArray();
        var actual = GetAllSurrogates().ToArray();
        Assert.That(actual, Has.Length.EqualTo(expected.Length));
        foreach (char target in expected)
            Assert.That(actual.Contains(target), Is.True);
    }

#pragma warning restore NUnit2014
}