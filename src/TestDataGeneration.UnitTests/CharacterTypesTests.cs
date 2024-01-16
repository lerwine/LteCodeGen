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
        var flag = CharacterClass.AsciiControlChars;
        var expectedValues = new[] { CharacterClass.AsciiChars, CharacterClass.ControlChars };
        var notExpectedValues = new[] { CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash, CharacterClass.Period,
            CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper, CharacterClass.AsciiLettersUpper,
            CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower, CharacterClass.HardConsonants,
            CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants, CharacterClass.AsciiLettersLower,
            CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.UriDataChars, CharacterClass.PunctuationChars,
            CharacterClass.Symbols, CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.UpperChars, CharacterClass.LowerChars, CharacterClass.Letters, CharacterClass.LettersAndDigits,
            CharacterClass.HighSurrogates, CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        // BUG: Where flag is AsciiControlChars: NotSpecified does not exist in neither the expectedValues nor the notExpectedValues array
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target: {target:F}");
    }

    [Test]
    public void SpaceCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.Space;
        var expectedValues = new[] { CharacterClass.Separators, CharacterClass.AsciiChars, CharacterClass.WhiteSpaceChars, CharacterClass.AsciiWhiteSpace };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash, CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper,
            CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper, CharacterClass.AsciiLettersUpper, CharacterClass.Underscore,
            CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower, CharacterClass.HardConsonants, CharacterClass.VowelsLower,
            CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants, CharacterClass.AsciiLettersLower, CharacterClass.AsciiLetters,
            CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.UriDataChars, CharacterClass.PunctuationChars, CharacterClass.Symbols,
            CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.UpperChars, CharacterClass.LowerChars, CharacterClass.Letters, CharacterClass.LettersAndDigits, CharacterClass.HighSurrogates, CharacterClass.ControlChars,
            CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target: {target:F}");
    }

    [Test]
    public void AsciiWhiteSpaceCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.AsciiWhiteSpace;
        var expectedValues = new[] { CharacterClass.AsciiChars, CharacterClass.WhiteSpaceChars };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash, CharacterClass.Period,
            CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper, CharacterClass.AsciiLettersUpper,
            CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower, CharacterClass.HardConsonants,
            CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants, CharacterClass.AsciiLettersLower,
            CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.UriDataChars, CharacterClass.PunctuationChars,
            CharacterClass.Symbols, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.UpperChars, CharacterClass.LowerChars, CharacterClass.Letters, CharacterClass.LettersAndDigits, CharacterClass.HighSurrogates,
            CharacterClass.ControlChars, CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void SeparatorsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.Separators;
        var expectedValue = CharacterClass.WhiteSpaceChars;
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash, CharacterClass.Period,
            CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper, CharacterClass.AsciiLettersUpper,
            CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower, CharacterClass.HardConsonants,
            CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants, CharacterClass.AsciiLettersLower,
            CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.UriDataChars, CharacterClass.AsciiChars,
            CharacterClass.PunctuationChars, CharacterClass.Symbols, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.UpperChars, CharacterClass.LowerChars, CharacterClass.Letters, CharacterClass.LettersAndDigits,
            CharacterClass.HighSurrogates, CharacterClass.ControlChars, CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValue, notExpectedValues);
        Assert.That(expectedValue.HasFlag(flag), Is.True);
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void AsciiDigitsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.AsciiDigits;
        var expectedValues = new[] { CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigitsUpper, CharacterClass.AsciiHexDigits, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars,
            CharacterClass.UriDataChars, CharacterClass.AsciiChars, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.LettersAndDigits };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.Plus, CharacterClass.Dash, CharacterClass.Period,
            CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper, CharacterClass.AsciiLettersUpper, CharacterClass.Underscore,
            CharacterClass.AsciiPunctuation, CharacterClass.HardConsonantsLower, CharacterClass.HardConsonants, CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower,
            CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants, CharacterClass.AsciiLettersLower, CharacterClass.AsciiLetters, CharacterClass.Tilde, CharacterClass.AsciiSymbols,
            CharacterClass.ControlChars, CharacterClass.PunctuationChars, CharacterClass.Symbols, CharacterClass.WhiteSpaceChars, CharacterClass.UpperChars, CharacterClass.LowerChars, CharacterClass.Letters,
            CharacterClass.HighSurrogates, CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void PlusCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.Plus;
        var expectedValues = new[] { CharacterClass.AsciiSymbols, CharacterClass.AsciiChars, CharacterClass.Symbols };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Dash, CharacterClass.Period,
            CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper, CharacterClass.AsciiLettersUpper,
            CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower, CharacterClass.HardConsonants,
            CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants, CharacterClass.AsciiLettersLower,
            CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.Tilde, CharacterClass.UriDataChars, CharacterClass.ControlChars, CharacterClass.PunctuationChars,
            CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.UpperChars, CharacterClass.LowerChars, CharacterClass.Letters, CharacterClass.LettersAndDigits,
            CharacterClass.HighSurrogates, CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void DashCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.Dash;
        var expectedValues = new[] { CharacterClass.AsciiPunctuation, CharacterClass.UriDataChars, CharacterClass.AsciiChars, CharacterClass.PunctuationChars };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Period,
            CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper, CharacterClass.AsciiLettersUpper,
            CharacterClass.Underscore, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower, CharacterClass.HardConsonants, CharacterClass.VowelsLower, CharacterClass.Vowels,
            CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants, CharacterClass.AsciiLettersLower, CharacterClass.AsciiLetters,
            CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.ControlChars, CharacterClass.Symbols, CharacterClass.WhiteSpaceChars,
            CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.UpperChars, CharacterClass.LowerChars, CharacterClass.Letters, CharacterClass.LettersAndDigits, CharacterClass.HighSurrogates,
            CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void PeriodCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.Period;
        var expectedValues = new[] { CharacterClass.AsciiPunctuation, CharacterClass.UriDataChars, CharacterClass.AsciiChars, CharacterClass.PunctuationChars };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper, CharacterClass.AsciiLettersUpper,
            CharacterClass.Underscore, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower, CharacterClass.HardConsonants, CharacterClass.VowelsLower, CharacterClass.Vowels,
            CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants, CharacterClass.AsciiLettersLower, CharacterClass.AsciiLetters,
            CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.ControlChars, CharacterClass.Symbols, CharacterClass.WhiteSpaceChars,
            CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.UpperChars, CharacterClass.LowerChars, CharacterClass.Letters, CharacterClass.LettersAndDigits, CharacterClass.HighSurrogates,
            CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void AsciiHexDigitsUpperCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.AsciiHexDigitsUpper;
        var expectedValues = new[] { CharacterClass.AsciiHexDigits, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.UriDataChars, CharacterClass.AsciiChars, CharacterClass.LettersAndDigits };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper, CharacterClass.AsciiLettersUpper, CharacterClass.Underscore,
            CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.HardConsonantsLower, CharacterClass.HardConsonants, CharacterClass.VowelsLower, CharacterClass.Vowels,
            CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants, CharacterClass.AsciiLettersLower, CharacterClass.AsciiLetters, CharacterClass.Tilde,
            CharacterClass.AsciiSymbols, CharacterClass.ControlChars, CharacterClass.PunctuationChars, CharacterClass.Symbols, CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.Digits,
            CharacterClass.UpperChars, CharacterClass.LowerChars, CharacterClass.Letters, CharacterClass.HighSurrogates, CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void HardConsonantsUpperCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.HardConsonantsUpper;
        var expectedValues = new[] { CharacterClass.AsciiLettersUpper, CharacterClass.ConsonantsUpper, CharacterClass.HardConsonants, CharacterClass.Consonants, CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits,
            CharacterClass.CsIdentifierChars, CharacterClass.UriDataChars, CharacterClass.AsciiChars, CharacterClass.UpperChars, CharacterClass.Letters, CharacterClass.LettersAndDigits };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.Underscore, CharacterClass.AsciiPunctuation,
            CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower, CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower,
            CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.AsciiLettersLower, CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.ControlChars, CharacterClass.PunctuationChars,
            CharacterClass.Symbols, CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.LowerChars, CharacterClass.HighSurrogates, CharacterClass.LowSurrogates, CharacterClass.Surrogates,
            CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void VowelsUpperCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.VowelsUpper;
        var expectedValues = new[] { CharacterClass.Vowels, CharacterClass.AsciiLettersUpper, CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.UriDataChars,
            CharacterClass.AsciiChars, CharacterClass.UpperChars, CharacterClass.Letters, CharacterClass.LettersAndDigits };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper, CharacterClass.Underscore,
            CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower, CharacterClass.HardConsonants, CharacterClass.VowelsLower,
            CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants, CharacterClass.AsciiLettersLower, CharacterClass.Tilde, CharacterClass.AsciiSymbols,
            CharacterClass.ControlChars, CharacterClass.PunctuationChars, CharacterClass.Symbols, CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.LowerChars,
            CharacterClass.HighSurrogates, CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void SoftConsonantsUpperCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.SoftConsonantsUpper;
        var expectedValues = new[] { CharacterClass.AsciiLettersUpper, CharacterClass.ConsonantsUpper, CharacterClass.SoftConsonants, CharacterClass.Consonants, CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits,
            CharacterClass.CsIdentifierChars, CharacterClass.UriDataChars, CharacterClass.AsciiChars, CharacterClass.UpperChars, CharacterClass.Letters, CharacterClass.LettersAndDigits };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.Underscore, CharacterClass.AsciiPunctuation,
            CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower, CharacterClass.HardConsonants, CharacterClass.VowelsLower, CharacterClass.Vowels,
            CharacterClass.SoftConsonantsLower, CharacterClass.ConsonantsLower, CharacterClass.AsciiLettersLower, CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.ControlChars, CharacterClass.PunctuationChars,
            CharacterClass.Symbols, CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.LowerChars, CharacterClass.HighSurrogates, CharacterClass.LowSurrogates, CharacterClass.Surrogates,
            CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void ConsonantsUpperCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.ConsonantsUpper;
        var expectedValues = new[] { CharacterClass.AsciiLettersUpper, CharacterClass.Consonants, CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.UriDataChars,
            CharacterClass.AsciiChars, CharacterClass.UpperChars, CharacterClass.Letters, CharacterClass.LettersAndDigits };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.Underscore,
            CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower, CharacterClass.HardConsonants, CharacterClass.VowelsLower,
            CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.AsciiLettersLower, CharacterClass.Tilde, CharacterClass.AsciiSymbols,
            CharacterClass.PunctuationChars, CharacterClass.Symbols, CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.LowerChars, CharacterClass.HighSurrogates,
            CharacterClass.ControlChars, CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void AsciiLettersUpperCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.AsciiLettersUpper;
        var expectedValues = new[] { CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.UriDataChars, CharacterClass.AsciiChars, CharacterClass.UpperChars,
            CharacterClass.Letters, CharacterClass.LettersAndDigits };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper,
            CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower, CharacterClass.HardConsonants,
            CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants, CharacterClass.AsciiLettersLower,
            CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.PunctuationChars, CharacterClass.Symbols, CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.LowerChars,
            CharacterClass.HighSurrogates, CharacterClass.ControlChars, CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void UnderscoreCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.Underscore;
        var expectedValues = new[] { CharacterClass.AsciiPunctuation, CharacterClass.CsIdentifierChars, CharacterClass.UriDataChars, CharacterClass.AsciiChars, CharacterClass.PunctuationChars };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper,
            CharacterClass.AsciiLettersUpper, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower, CharacterClass.HardConsonants, CharacterClass.VowelsLower,
            CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants, CharacterClass.AsciiLettersLower, CharacterClass.AsciiLetters,
            CharacterClass.AsciiLettersAndDigits, CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.Symbols, CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.Digits,
            CharacterClass.UpperChars, CharacterClass.LowerChars, CharacterClass.Letters, CharacterClass.LettersAndDigits, CharacterClass.HighSurrogates, CharacterClass.ControlChars, CharacterClass.LowSurrogates,
            CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void AsciiPunctuationCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.AsciiPunctuation;
        var expectedValues = new[] { CharacterClass.AsciiChars, CharacterClass.PunctuationChars };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper,
            CharacterClass.AsciiLettersUpper, CharacterClass.Underscore, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower, CharacterClass.HardConsonants,
            CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants, CharacterClass.AsciiLettersLower,
            CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.UriDataChars, CharacterClass.Symbols,
            CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.UpperChars, CharacterClass.LowerChars, CharacterClass.Letters, CharacterClass.LettersAndDigits,
            CharacterClass.HighSurrogates, CharacterClass.ControlChars, CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void AsciiHexDigitsLowerCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.AsciiHexDigitsLower;
        var expectedValues = new[] { CharacterClass.AsciiHexDigits, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.UriDataChars, CharacterClass.AsciiChars, CharacterClass.LettersAndDigits };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.AsciiLettersUpper,
            CharacterClass.ConsonantsUpper, CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.HardConsonantsLower, CharacterClass.HardConsonants, CharacterClass.VowelsLower, CharacterClass.Vowels,
            CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants, CharacterClass.AsciiLettersLower, CharacterClass.AsciiLetters, CharacterClass.Tilde,
            CharacterClass.AsciiSymbols, CharacterClass.PunctuationChars, CharacterClass.Symbols, CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.UpperChars,
            CharacterClass.LowerChars, CharacterClass.Letters, CharacterClass.HighSurrogates, CharacterClass.ControlChars, CharacterClass.LowSurrogates, CharacterClass.Surrogates };
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void AsciiHexDigitsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.AsciiHexDigits;
        var expectedValues = new[] { CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.UriDataChars, CharacterClass.AsciiChars, CharacterClass.LettersAndDigits };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper,
            CharacterClass.AsciiLettersUpper, CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.HardConsonantsLower, CharacterClass.HardConsonants,
            CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants, CharacterClass.AsciiLettersLower,
            CharacterClass.AsciiLetters, CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.PunctuationChars, CharacterClass.Symbols, CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.Digits,
            CharacterClass.UpperChars, CharacterClass.LowerChars, CharacterClass.Letters, CharacterClass.HighSurrogates, CharacterClass.ControlChars, CharacterClass.LowSurrogates, CharacterClass.Surrogates,
            CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void HardConsonantsLowerCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.HardConsonantsLower;
        var expectedValues = new[] { CharacterClass.HardConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants, CharacterClass.AsciiLettersLower, CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits,
            CharacterClass.CsIdentifierChars, CharacterClass.UriDataChars, CharacterClass.AsciiChars, CharacterClass.LowerChars, CharacterClass.Letters, CharacterClass.LettersAndDigits };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper,
            CharacterClass.AsciiLettersUpper, CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.VowelsLower, CharacterClass.Vowels,
            CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.PunctuationChars, CharacterClass.Symbols, CharacterClass.WhiteSpaceChars,
            CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.UpperChars, CharacterClass.HighSurrogates, CharacterClass.ControlChars, CharacterClass.LowSurrogates, CharacterClass.Surrogates,
            CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void HardConsonantsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.HardConsonants;
        var expectedValues = new[] { CharacterClass.Consonants, CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.UriDataChars, CharacterClass.AsciiChars,
            CharacterClass.Letters, CharacterClass.LettersAndDigits };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper,
            CharacterClass.AsciiLettersUpper, CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower,
            CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.AsciiLettersLower, CharacterClass.Tilde,
            CharacterClass.AsciiSymbols, CharacterClass.PunctuationChars, CharacterClass.Symbols, CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.UpperChars,
            CharacterClass.LowerChars, CharacterClass.HighSurrogates, CharacterClass.ControlChars, CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void VowelsLowerCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.VowelsLower;
        var expectedValues = new[] { CharacterClass.Vowels, CharacterClass.AsciiLettersLower, CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.UriDataChars,
            CharacterClass.AsciiChars, CharacterClass.LowerChars, CharacterClass.Letters, CharacterClass.LettersAndDigits };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper,
            CharacterClass.AsciiLettersUpper, CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower,
            CharacterClass.HardConsonants, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants, CharacterClass.Tilde, CharacterClass.AsciiSymbols,
            CharacterClass.PunctuationChars, CharacterClass.Symbols, CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.UpperChars, CharacterClass.HighSurrogates,
            CharacterClass.ControlChars, CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void VowelsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.Vowels;
        var expectedValues = new[] { CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.UriDataChars, CharacterClass.AsciiChars, CharacterClass.Letters,
            CharacterClass.LettersAndDigits };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper,
            CharacterClass.AsciiLettersUpper, CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower,
            CharacterClass.HardConsonants, CharacterClass.VowelsLower, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants,
            CharacterClass.AsciiLettersLower, CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.PunctuationChars, CharacterClass.Symbols, CharacterClass.WhiteSpaceChars, CharacterClass.Numbers,
            CharacterClass.Digits, CharacterClass.UpperChars, CharacterClass.LowerChars, CharacterClass.HighSurrogates, CharacterClass.ControlChars, CharacterClass.LowSurrogates, CharacterClass.Surrogates,
            CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void SoftConsonantsLowerCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.SoftConsonantsLower;
        var expectedValues = new[] { CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants, CharacterClass.AsciiLettersLower, CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits,
            CharacterClass.CsIdentifierChars, CharacterClass.UriDataChars, CharacterClass.AsciiChars, CharacterClass.LowerChars, CharacterClass.Letters, CharacterClass.LettersAndDigits };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper,
            CharacterClass.AsciiLettersUpper, CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower,
            CharacterClass.HardConsonants, CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.PunctuationChars, CharacterClass.Symbols,
            CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.UpperChars, CharacterClass.HighSurrogates, CharacterClass.ControlChars, CharacterClass.LowSurrogates,
            CharacterClass.Surrogates };
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void SoftConsonantsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.SoftConsonants;
        var expectedValues = new[] { CharacterClass.Consonants, CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.UriDataChars, CharacterClass.AsciiChars,
            CharacterClass.Letters, CharacterClass.LettersAndDigits };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper,
            CharacterClass.AsciiLettersUpper, CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower,
            CharacterClass.HardConsonants, CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.ConsonantsLower, CharacterClass.AsciiLettersLower, CharacterClass.Tilde,
            CharacterClass.AsciiSymbols, CharacterClass.PunctuationChars, CharacterClass.Symbols, CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.UpperChars,
            CharacterClass.LowerChars, CharacterClass.HighSurrogates, CharacterClass.ControlChars, CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void ConsonantsLowerCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.ConsonantsLower;
        var expectedValues = new[] { CharacterClass.Consonants, CharacterClass.AsciiLettersLower, CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.UriDataChars,
            CharacterClass.AsciiChars, CharacterClass.LowerChars, CharacterClass.Letters, CharacterClass.LettersAndDigits };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper,
            CharacterClass.AsciiLettersUpper, CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower,
            CharacterClass.HardConsonants, CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.Tilde, CharacterClass.AsciiSymbols,
            CharacterClass.PunctuationChars, CharacterClass.Symbols, CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.UpperChars, CharacterClass.HighSurrogates,
            CharacterClass.ControlChars, CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void ConsonantsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.Consonants;
        var expectedValues = new[] { CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.UriDataChars, CharacterClass.AsciiChars, CharacterClass.Letters,
            CharacterClass.LettersAndDigits };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper,
            CharacterClass.AsciiLettersUpper, CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower,
            CharacterClass.HardConsonants, CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.AsciiLettersLower,
            CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.PunctuationChars, CharacterClass.Symbols, CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.UpperChars,
            CharacterClass.LowerChars, CharacterClass.HighSurrogates, CharacterClass.ControlChars, CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void AsciiLettersLowerCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.AsciiLettersLower;
        var expectedValues = new[] { CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.UriDataChars, CharacterClass.AsciiChars, CharacterClass.LowerChars,
            CharacterClass.Letters, CharacterClass.LettersAndDigits };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper,
            CharacterClass.AsciiLettersUpper, CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower,
            CharacterClass.HardConsonants, CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants,
            CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.PunctuationChars, CharacterClass.Symbols, CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.UpperChars,
            CharacterClass.HighSurrogates, CharacterClass.ControlChars, CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void AsciiLettersCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.AsciiLetters;
        var expectedValues = new[] { CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.UriDataChars, CharacterClass.AsciiChars, CharacterClass.Letters, CharacterClass.LettersAndDigits };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper,
            CharacterClass.AsciiLettersUpper, CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower,
            CharacterClass.HardConsonants, CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants,
            CharacterClass.AsciiLettersLower, CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.PunctuationChars, CharacterClass.Symbols, CharacterClass.WhiteSpaceChars, CharacterClass.Numbers,
            CharacterClass.Digits, CharacterClass.UpperChars, CharacterClass.LowerChars, CharacterClass.HighSurrogates, CharacterClass.ControlChars, CharacterClass.LowSurrogates, CharacterClass.Surrogates,
            CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void AsciiLettersAndDigitsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.AsciiLettersAndDigits;
        var expectedValues = new[] { CharacterClass.CsIdentifierChars, CharacterClass.UriDataChars, CharacterClass.AsciiChars, CharacterClass.LettersAndDigits };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper,
            CharacterClass.AsciiLettersUpper, CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower,
            CharacterClass.HardConsonants, CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants,
            CharacterClass.AsciiLettersLower, CharacterClass.AsciiLetters, CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.PunctuationChars, CharacterClass.Symbols, CharacterClass.WhiteSpaceChars,
            CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.UpperChars, CharacterClass.LowerChars, CharacterClass.Letters, CharacterClass.HighSurrogates, CharacterClass.ControlChars, CharacterClass.LowSurrogates,
            CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void CsIdentifierCharsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.CsIdentifierChars;
        var expectedValues = new[] { CharacterClass.UriDataChars, CharacterClass.AsciiChars };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper,
            CharacterClass.AsciiLettersUpper, CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower,
            CharacterClass.HardConsonants, CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants,
            CharacterClass.AsciiLettersLower, CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits, CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.PunctuationChars, CharacterClass.Symbols,
            CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.UpperChars, CharacterClass.LowerChars, CharacterClass.Letters, CharacterClass.LettersAndDigits,
            CharacterClass.HighSurrogates, CharacterClass.ControlChars, CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void TildeCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.Tilde;
        var expectedValues = new[] { CharacterClass.AsciiSymbols, CharacterClass.AsciiChars, CharacterClass.UriDataChars, CharacterClass.Symbols };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper,
            CharacterClass.AsciiLettersUpper, CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower,
            CharacterClass.HardConsonants, CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants,
            CharacterClass.AsciiLettersLower, CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.PunctuationChars, CharacterClass.WhiteSpaceChars,
            CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.UpperChars, CharacterClass.LowerChars, CharacterClass.Letters, CharacterClass.LettersAndDigits, CharacterClass.HighSurrogates, CharacterClass.ControlChars,
            CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void AsciiSymbolsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.AsciiSymbols;
        var expectedValues = new[] { CharacterClass.AsciiChars, CharacterClass.Symbols };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper,
            CharacterClass.AsciiLettersUpper, CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower,
            CharacterClass.HardConsonants, CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants,
            CharacterClass.AsciiLettersLower, CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.Tilde, CharacterClass.UriDataChars,
            CharacterClass.PunctuationChars, CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.UpperChars, CharacterClass.LowerChars, CharacterClass.Letters,
            CharacterClass.LettersAndDigits, CharacterClass.HighSurrogates, CharacterClass.ControlChars, CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void UriDataCharsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.UriDataChars;
        var expectedValues = new[] { CharacterClass.AsciiChars };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper,
            CharacterClass.AsciiLettersUpper, CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower,
            CharacterClass.HardConsonants, CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants,
            CharacterClass.AsciiLettersLower, CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.Tilde, CharacterClass.AsciiSymbols,
            CharacterClass.PunctuationChars, CharacterClass.Symbols, CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.UpperChars, CharacterClass.LowerChars, CharacterClass.Letters,
            CharacterClass.LettersAndDigits, CharacterClass.HighSurrogates, CharacterClass.ControlChars, CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void AsciiCharsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.AsciiChars;
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper,
            CharacterClass.AsciiLettersUpper, CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower,
            CharacterClass.HardConsonants, CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants,
            CharacterClass.AsciiLettersLower, CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.UriDataChars,
            CharacterClass.PunctuationChars, CharacterClass.Symbols, CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.UpperChars, CharacterClass.LowerChars, CharacterClass.Letters,
            CharacterClass.LettersAndDigits, CharacterClass.HighSurrogates, CharacterClass.ControlChars, CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, null, notExpectedValues);
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void PunctuationCharsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.PunctuationChars;
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper,
            CharacterClass.AsciiLettersUpper, CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower,
            CharacterClass.HardConsonants, CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants,
            CharacterClass.AsciiLettersLower, CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.UriDataChars,
            CharacterClass.AsciiChars, CharacterClass.Symbols, CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.UpperChars, CharacterClass.LowerChars, CharacterClass.Letters,
            CharacterClass.LettersAndDigits, CharacterClass.HighSurrogates, CharacterClass.ControlChars, CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, null, notExpectedValues);
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void SymbolsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.Symbols;
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper,
            CharacterClass.AsciiLettersUpper, CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower,
            CharacterClass.HardConsonants, CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants,
            CharacterClass.AsciiLettersLower, CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.UriDataChars,
            CharacterClass.AsciiChars, CharacterClass.PunctuationChars, CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.UpperChars, CharacterClass.LowerChars, CharacterClass.Letters,
            CharacterClass.LettersAndDigits, CharacterClass.HighSurrogates, CharacterClass.ControlChars, CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, null, notExpectedValues);
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void WhiteSpaceCharsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.WhiteSpaceChars;
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper,
            CharacterClass.AsciiLettersUpper, CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower,
            CharacterClass.HardConsonants, CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants,
            CharacterClass.AsciiLettersLower, CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.UriDataChars,
            CharacterClass.AsciiChars, CharacterClass.PunctuationChars, CharacterClass.Symbols, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.UpperChars, CharacterClass.LowerChars, CharacterClass.Letters,
            CharacterClass.LettersAndDigits, CharacterClass.HighSurrogates, CharacterClass.ControlChars, CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, null, notExpectedValues);
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void NumbersCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.Numbers;
        var expectedValues = new[] { CharacterClass.Digits, CharacterClass.LettersAndDigits };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper,
            CharacterClass.AsciiLettersUpper, CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower,
            CharacterClass.HardConsonants, CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants,
            CharacterClass.AsciiLettersLower, CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.UriDataChars,
            CharacterClass.AsciiChars, CharacterClass.PunctuationChars, CharacterClass.Symbols, CharacterClass.WhiteSpaceChars, CharacterClass.UpperChars, CharacterClass.LowerChars, CharacterClass.Letters,
            CharacterClass.HighSurrogates, CharacterClass.ControlChars, CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void DigitsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.Digits;
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper,
            CharacterClass.AsciiLettersUpper, CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower,
            CharacterClass.HardConsonants, CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants,
            CharacterClass.AsciiLettersLower, CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.UriDataChars,
            CharacterClass.AsciiChars, CharacterClass.PunctuationChars, CharacterClass.Symbols, CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.UpperChars, CharacterClass.LowerChars, CharacterClass.Letters,
            CharacterClass.LettersAndDigits, CharacterClass.HighSurrogates, CharacterClass.ControlChars, CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, null, notExpectedValues);
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void UpperCharsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.UpperChars;
        var expectedValues = new[] { CharacterClass.Letters, CharacterClass.LettersAndDigits };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper,
            CharacterClass.AsciiLettersUpper, CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower,
            CharacterClass.HardConsonants, CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants,
            CharacterClass.AsciiLettersLower, CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.UriDataChars,
            CharacterClass.AsciiChars, CharacterClass.PunctuationChars, CharacterClass.Symbols, CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.LowerChars,
            CharacterClass.HighSurrogates, CharacterClass.ControlChars, CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void LowerCharsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.LowerChars;
        var expectedValues = new[] { CharacterClass.Letters, CharacterClass.LettersAndDigits };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper,
            CharacterClass.AsciiLettersUpper, CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower,
            CharacterClass.HardConsonants, CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants,
            CharacterClass.AsciiLettersLower, CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.UriDataChars,
            CharacterClass.AsciiChars, CharacterClass.PunctuationChars, CharacterClass.Symbols, CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.UpperChars,
            CharacterClass.HighSurrogates, CharacterClass.ControlChars, CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void LettersCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.Letters;
        var expectedValues = new[] { CharacterClass.LettersAndDigits };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper,
            CharacterClass.AsciiLettersUpper, CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower,
            CharacterClass.HardConsonants, CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants,
            CharacterClass.AsciiLettersLower, CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.UriDataChars,
            CharacterClass.AsciiChars, CharacterClass.PunctuationChars, CharacterClass.Symbols, CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.UpperChars, CharacterClass.LowerChars,
            CharacterClass.HighSurrogates, CharacterClass.ControlChars, CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void LettersAndDigitsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.LettersAndDigits;
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper,
            CharacterClass.AsciiLettersUpper, CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower,
            CharacterClass.HardConsonants, CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants,
            CharacterClass.AsciiLettersLower, CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.UriDataChars,
            CharacterClass.AsciiChars, CharacterClass.PunctuationChars, CharacterClass.Symbols, CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.UpperChars, CharacterClass.LowerChars,
            CharacterClass.Letters, CharacterClass.HighSurrogates, CharacterClass.ControlChars, CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, null, notExpectedValues);
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void HighSurrogatesCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.HighSurrogates;
        var expectedValues = new[] { CharacterClass.Surrogates };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper,
            CharacterClass.AsciiLettersUpper, CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower,
            CharacterClass.HardConsonants, CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants,
            CharacterClass.AsciiLettersLower, CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.UriDataChars,
            CharacterClass.AsciiChars, CharacterClass.PunctuationChars, CharacterClass.Symbols, CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.UpperChars, CharacterClass.LowerChars,
            CharacterClass.Letters, CharacterClass.LettersAndDigits, CharacterClass.ControlChars, CharacterClass.LowSurrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void ControlCharsCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.ControlChars;
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper,
            CharacterClass.AsciiLettersUpper, CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower,
            CharacterClass.HardConsonants, CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants,
            CharacterClass.AsciiLettersLower, CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.UriDataChars,
            CharacterClass.AsciiChars, CharacterClass.PunctuationChars, CharacterClass.Symbols, CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.UpperChars, CharacterClass.LowerChars,
            CharacterClass.Letters, CharacterClass.LettersAndDigits, CharacterClass.HighSurrogates, CharacterClass.LowSurrogates, CharacterClass.Surrogates, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, null, notExpectedValues);
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void LowSurrogatesCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.LowSurrogates;
        var expectedValues = new[] { CharacterClass.Surrogates };
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper,
            CharacterClass.AsciiLettersUpper, CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower,
            CharacterClass.HardConsonants, CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants,
            CharacterClass.AsciiLettersLower, CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.UriDataChars,
            CharacterClass.AsciiChars, CharacterClass.PunctuationChars, CharacterClass.Symbols, CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.UpperChars, CharacterClass.LowerChars,
            CharacterClass.Letters, CharacterClass.LettersAndDigits, CharacterClass.HighSurrogates, CharacterClass.ControlChars, CharacterClass.NotSpecified };
        AssertCompleteEnumTestCoverage(flag, expectedValues, notExpectedValues);
        foreach (var target in expectedValues) Assert.That(target.HasFlag(flag), Is.True, $"Target Value: {target:F}");
        foreach (var target in notExpectedValues) Assert.That(target.HasFlag(flag), Is.False, $"Target Value: {target:F}");
    }

    [Test]
    public void SurrogatesCharacterTypeEnumFlagsTest()
    {
        var flag = CharacterClass.Surrogates;
        var notExpectedValues = new[] { CharacterClass.AsciiControlChars, CharacterClass.Space, CharacterClass.AsciiWhiteSpace, CharacterClass.Separators, CharacterClass.AsciiDigits, CharacterClass.Plus, CharacterClass.Dash,
            CharacterClass.Period, CharacterClass.AsciiHexDigitsUpper, CharacterClass.HardConsonantsUpper, CharacterClass.VowelsUpper, CharacterClass.SoftConsonantsUpper, CharacterClass.ConsonantsUpper,
            CharacterClass.AsciiLettersUpper, CharacterClass.Underscore, CharacterClass.AsciiPunctuation, CharacterClass.AsciiHexDigitsLower, CharacterClass.AsciiHexDigits, CharacterClass.HardConsonantsLower,
            CharacterClass.HardConsonants, CharacterClass.VowelsLower, CharacterClass.Vowels, CharacterClass.SoftConsonantsLower, CharacterClass.SoftConsonants, CharacterClass.ConsonantsLower, CharacterClass.Consonants,
            CharacterClass.AsciiLettersLower, CharacterClass.AsciiLetters, CharacterClass.AsciiLettersAndDigits, CharacterClass.CsIdentifierChars, CharacterClass.Tilde, CharacterClass.AsciiSymbols, CharacterClass.UriDataChars,
            CharacterClass.AsciiChars, CharacterClass.PunctuationChars, CharacterClass.Symbols, CharacterClass.WhiteSpaceChars, CharacterClass.Numbers, CharacterClass.Digits, CharacterClass.UpperChars, CharacterClass.LowerChars,
            CharacterClass.Letters, CharacterClass.LettersAndDigits, CharacterClass.HighSurrogates, CharacterClass.ControlChars, CharacterClass.LowSurrogates, CharacterClass.NotSpecified };
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