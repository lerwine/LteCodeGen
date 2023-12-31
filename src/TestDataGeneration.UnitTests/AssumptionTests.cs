using NUnit.Framework.Internal;
using static TestDataGeneration.UnitTests.HelperMethods;

namespace TestDataGeneration.UnitTests;
public class AssumptionTests
{

    [Test(Description = "A digit character is always a number")]
    public void DigitAlwaysNumberTest()
    {
        foreach (char c in GetAllTestCharacters().Where(char.IsDigit))
            Assert.That(char.IsNumber(c), Is.True, $"Char: U+{(int)c:x4} ({c})");
    }

    [Test(Description = "An ASCII digit is always a number")]
    public void AsciiDigitAlwaysNumberTest()
    {
        foreach (char c in GetAllTestCharacters().Where(char.IsAsciiDigit))
            Assert.That(char.IsNumber(c), Is.True, $"Char: U+{(int)c:x4} ({c})");
    }

    [Test(Description = "A separator character is always white-space")]
    public void SeparatorAlwaysWhiteSpaceTest()
    {
        foreach (char c in GetAllTestCharacters().Where(char.IsSeparator))
            Assert.That(char.IsWhiteSpace(c), Is.True, $"Char: U+{(int)c:x4} ({c})");
    }

    [Test(Description = "A upper-case character is always a letter")]
    public void UpperAlwaysLetterTest()
    {
        foreach (char c in GetAllTestCharacters().Where(char.IsUpper))
            Assert.That(char.IsLetter(c), Is.True, $"Char: U+{(int)c:x4} ({c})");
    }

    [Test(Description = "A lower-case character is always a letter")]
    public void LowerAlwaysLetterTest()
    {
        foreach (char c in GetAllTestCharacters().Where(char.IsLower))
            Assert.That(char.IsLetter(c), Is.True, $"Char: U+{(int)c:x4} ({c})");
    }

    [Test(Description = "A Control character is never a Letter, Punctuation, Number, Separator, Surrogate, or Symbol character")]
    public void ControlCharExclusiveTest()
    {
        foreach (char c in GetAllTestCharacters().Where(char.IsControl))
            Assert.Multiple(() =>
            {
                Assert.That(char.IsLetter(c), Is.False, $"Char.IsLetter: U+{(int)c:x4} ({c})");
                Assert.That(char.IsPunctuation(c), Is.False, $"Char.IsPunctuation: U+{(int)c:x4} ({c})");
                Assert.That(char.IsNumber(c), Is.False, $"Char.IsNumber: U+{(int)c:x4} ({c})");
                Assert.That(char.IsSeparator(c), Is.False, $"Char.IsSeparator: U+{(int)c:x4} ({c})");
                Assert.That(char.IsSurrogate(c), Is.False, $"Char.IsSurrogate: U+{(int)c:x4} ({c})");
                Assert.That(char.IsSymbol(c), Is.False, $"Char.IsSymbol: U+{(int)c:x4} ({c})");
            });
    }

    [Test(Description = "A Letter character is never a Control, Punctuation, Number, WhiteSpace, Surrogate, or Symbol character")]
    public void LetterCharExclusiveTest()
    {
        foreach (char c in GetAllTestCharacters().Where(char.IsLetter))
            Assert.Multiple(() =>
            {
                Assert.That(char.IsControl(c), Is.False, $"Char.IsControl: U+{(int)c:x4} ({c})");
                Assert.That(char.IsPunctuation(c), Is.False, $"Char.IsPunctuation: U+{(int)c:x4} ({c})");
                Assert.That(char.IsNumber(c), Is.False, $"Char.IsNumber: U+{(int)c:x4} ({c})");
                Assert.That(char.IsWhiteSpace(c), Is.False, $"Char.IsWhiteSpace: U+{(int)c:x4} ({c})");
                Assert.That(char.IsSurrogate(c), Is.False, $"Char.IsSurrogate: U+{(int)c:x4} ({c})");
                Assert.That(char.IsSymbol(c), Is.False, $"Char.IsSymbol: U+{(int)c:x4} ({c})");
            });
    }

    [Test(Description = "A Punctuation character is never a Control, Letter, Number, WhiteSpace, Surrogate, or Symbol character")]
    public void PunctuationCharExclusiveTest()
    {
        foreach (char c in GetAllTestCharacters().Where(char.IsPunctuation))
            Assert.Multiple(() =>
            {
                Assert.That(char.IsControl(c), Is.False, $"Char.IsControl: U+{(int)c:x4} ({c})");
                Assert.That(char.IsLetter(c), Is.False, $"Char.IsLetter: U+{(int)c:x4} ({c})");
                Assert.That(char.IsNumber(c), Is.False, $"Char.IsNumber: U+{(int)c:x4} ({c})");
                Assert.That(char.IsWhiteSpace(c), Is.False, $"Char.IsWhiteSpace: U+{(int)c:x4} ({c})");
                Assert.That(char.IsSurrogate(c), Is.False, $"Char.IsSurrogate: U+{(int)c:x4} ({c})");
                Assert.That(char.IsSymbol(c), Is.False, $"Char.IsSymbol: U+{(int)c:x4} ({c})");
            });
    }

    [Test(Description = "A Number character is never a Control, Letter, Punctuation, WhiteSpace, Surrogate, or Symbol character")]
    public void NumberCharExclusiveTest()
    {
        foreach (char c in GetAllTestCharacters().Where(char.IsNumber))
            Assert.Multiple(() =>
            {
                Assert.That(char.IsControl(c), Is.False, $"Char.IsControl: U+{(int)c:x4} ({c})");
                Assert.That(char.IsLetter(c), Is.False, $"Char.IsLetter: U+{(int)c:x4} ({c})");
                Assert.That(char.IsPunctuation(c), Is.False, $"Char.IsPunctuation: U+{(int)c:x4} ({c})");
                Assert.That(char.IsWhiteSpace(c), Is.False, $"Char.IsWhiteSpace: U+{(int)c:x4} ({c})");
                Assert.That(char.IsSurrogate(c), Is.False, $"Char.IsSurrogate: U+{(int)c:x4} ({c})");
                Assert.That(char.IsSymbol(c), Is.False, $"Char.IsSymbol: U+{(int)c:x4} ({c})");
            });
    }

    [Test(Description = "A Separator character is never a Control, Letter, Punctuation, Number, Surrogate, or Symbol character")]
    public void SeparatorCharExclusiveTest()
    {
        foreach (char c in GetAllTestCharacters().Where(char.IsSeparator))
            Assert.Multiple(() =>
            {
                Assert.That(char.IsControl(c), Is.False, $"Char.IsControl: U+{(int)c:x4} ({c})");
                Assert.That(char.IsLetter(c), Is.False, $"Char.IsLetter: U+{(int)c:x4} ({c})");
                Assert.That(char.IsPunctuation(c), Is.False, $"Char.IsPunctuation: U+{(int)c:x4} ({c})");
                Assert.That(char.IsNumber(c), Is.False, $"Char.IsNumber: U+{(int)c:x4} ({c})");
                Assert.That(char.IsSurrogate(c), Is.False, $"Char.IsSurrogate: U+{(int)c:x4} ({c})");
                Assert.That(char.IsSymbol(c), Is.False, $"Char.IsSymbol: U+{(int)c:x4} ({c})");
            });
    }

    [Test(Description = "A WhiteSpace character is never a Letter, Punctuation, Number, Surrogate, or Symbol character")]
    public void WhiteSpaceCharExclusiveTest()
    {
        foreach (char c in GetAllTestCharacters().Where(char.IsWhiteSpace))
            Assert.Multiple(() =>
            {
                Assert.That(char.IsLetter(c), Is.False, $"Char.IsLetter: U+{(int)c:x4} ({c})");
                Assert.That(char.IsPunctuation(c), Is.False, $"Char.IsPunctuation: U+{(int)c:x4} ({c})");
                Assert.That(char.IsNumber(c), Is.False, $"Char.IsNumber: U+{(int)c:x4} ({c})");
                Assert.That(char.IsSurrogate(c), Is.False, $"Char.IsSurrogate: U+{(int)c:x4} ({c})");
                Assert.That(char.IsSymbol(c), Is.False, $"Char.IsSymbol: U+{(int)c:x4} ({c})");
            });
    }

    [Test(Description = "A Surrogate character is never a Control, Letter, Punctuation, Number, WhiteSpace, or Symbol character")]
    public void SurrogateCharExclusiveTest()
    {
        foreach (char c in GetAllTestCharacters().Where(char.IsSurrogate))
            Assert.Multiple(() =>
            {
                Assert.That(char.IsControl(c), Is.False, $"Char.IsControl: U+{(int)c:x4} ({c})");
                Assert.That(char.IsLetter(c), Is.False, $"Char.IsLetter: U+{(int)c:x4} ({c})");
                Assert.That(char.IsPunctuation(c), Is.False, $"Char.IsPunctuation: U+{(int)c:x4} ({c})");
                Assert.That(char.IsNumber(c), Is.False, $"Char.IsNumber: U+{(int)c:x4} ({c})");
                Assert.That(char.IsWhiteSpace(c), Is.False, $"Char.IsWhiteSpace: U+{(int)c:x4} ({c})");
                Assert.That(char.IsSymbol(c), Is.False, $"Char.IsSymbol: U+{(int)c:x4} ({c})");
            });
    }

    [Test(Description = "A Symbol character is never a Control, Letter, Punctuation, Number, WhiteSpace, or Surrogate character")]
    public void SymbolCharExclusiveTest()
    {
        foreach (char c in GetAllTestCharacters().Where(char.IsSymbol))
            Assert.Multiple(() =>
            {
                Assert.That(char.IsControl(c), Is.False, $"Char.IsControl: U+{(int)c:x4} ({c})");
                Assert.That(char.IsLetter(c), Is.False, $"Char.IsLetter: U+{(int)c:x4} ({c})");
                Assert.That(char.IsPunctuation(c), Is.False, $"Char.IsPunctuation: U+{(int)c:x4} ({c})");
                Assert.That(char.IsNumber(c), Is.False, $"Char.IsNumber: U+{(int)c:x4} ({c})");
                Assert.That(char.IsWhiteSpace(c), Is.False, $"Char.IsWhiteSpace: U+{(int)c:x4} ({c})");
                Assert.That(char.IsSurrogate(c), Is.False, $"Char.IsSurrogate: U+{(int)c:x4} ({c})");
            });
    }
}