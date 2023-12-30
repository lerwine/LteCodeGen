using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
using static TestDataGeneration.CharacterTypes;
using static TestDataGeneration.UnitTests.HelperMethods;

namespace TestDataGeneration.UnitTests;

public class CharacterTypesTests
{
    [Test]
    public void FlagsTest()
    {
        ulong[] bitValues = new[]{ Flag_AsciiNonWsControlChars, Flag_AsciiWhitespaceControlChars, Flag_Space, Flag_NonAsciiSeparator, Flag_AsciiPunctuation, Flag_AsciiDigits, Flag_AsciiSymbols, Flag_Plus, Flag_Dash,
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
    public void EnumTest()
    {
        var target = CharacterType.AsciiControlChars;
        Assert.That(CharacterType.AsciiChars.HasFlag(target), Is.True);

        target = CharacterType.Space;
        foreach (var includedBy in new[] { CharacterType.Separators, CharacterType.AsciiChars, CharacterType.WhiteSpaceChars })
            Assert.That(includedBy.HasFlag(target), Is.True, $"IncludedBy: {includedBy:F}");

        target = CharacterType.Separators;
        Assert.That(CharacterType.WhiteSpaceChars.HasFlag(target), Is.True);

        target = CharacterType.AsciiDigits;
        foreach (var includedBy in new[] { CharacterType.AsciiHexDigitsUpper, CharacterType.AsciiHexDigitsLower, CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars,
                CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.Digits, CharacterType.Digits, CharacterType.LettersAndDigits })
            Assert.That(includedBy.HasFlag(target), Is.True, $"IncludedBy: {includedBy:F}");

        target = CharacterType.Plus;
        foreach (var includedBy in new[] { CharacterType.AsciiSymbols, CharacterType.AsciiChars, CharacterType.Symbols })
            Assert.That(includedBy.HasFlag(target), Is.True, $"IncludedBy: {includedBy:F}");

        target = CharacterType.Dash;
        foreach (var includedBy in new[] { CharacterType.AsciiPunctuation, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.PunctuationChars })
            Assert.That(includedBy.HasFlag(target), Is.True, $"IncludedBy: {includedBy:F}");

        target = CharacterType.Period;
        foreach (var includedBy in new[] { CharacterType.AsciiPunctuation, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.PunctuationChars })
            Assert.That(includedBy.HasFlag(target), Is.True, $"IncludedBy: {includedBy:F}");

        target = CharacterType.AsciiHexDigitsUpper;
        foreach (var includedBy in new[] { CharacterType.AsciiHexDigits, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars,
                CharacterType.LettersAndDigits })
            Assert.That(includedBy.HasFlag(target), Is.True, $"IncludedBy: {includedBy:F}");

        target = CharacterType.HardConsonantsUpper;
        foreach (var includedBy in new[] { CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper, CharacterType.HardConsonants, CharacterType.Consonants, CharacterType.AsciiLetters,
                CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.UpperChars, CharacterType.Letters, CharacterType.LettersAndDigits })
            Assert.That(includedBy.HasFlag(target), Is.True, $"IncludedBy: {includedBy:F}");

        target = CharacterType.VowelsUpper;
        foreach (var includedBy in new[] { CharacterType.AsciiLettersUpper, CharacterType.Vowels, CharacterType.AsciiLetters, CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars,
                CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.UpperChars, CharacterType.Letters, CharacterType.LettersAndDigits })
            Assert.That(includedBy.HasFlag(target), Is.True, $"IncludedBy: {includedBy:F}");

        target = CharacterType.SoftConsonantsUpper;
        foreach (var includedBy in new[] { CharacterType.ConsonantsUpper, CharacterType.AsciiLettersUpper, CharacterType.SoftConsonants, CharacterType.Consonants, CharacterType.AsciiLetters,
                CharacterType.AsciiLettersAndDigits, CharacterType.CsIdentifierChars, CharacterType.UriDataChars, CharacterType.AsciiChars, CharacterType.UpperChars, CharacterType.Letters, CharacterType.LettersAndDigits })
            Assert.That(includedBy.HasFlag(target), Is.True, $"IncludedBy: {includedBy:F}");
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

}