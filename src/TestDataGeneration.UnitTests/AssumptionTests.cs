using NUnit.Framework.Internal;
using static TestDataGeneration.UnitTests.HelperMethods;

namespace TestDataGeneration.UnitTests;
public class AssumptionTests
{
    
    [Test(Description = "A digit character is always a number")]
    public void DigitAlwaysNumberTest()
    {
        foreach (char c in GetAllTestCharacters())
        {
            if (char.IsDigit(c))
                Assert.That(char.IsNumber(c), Is.True, $"Char: U+{(int)c:x4} ({c})");
        }
    }
    
    [Test(Description = "A separator character is always white-space")]
    public void SeparatorAlwaysWhiteSpaceTest()
    {
        foreach (char c in GetAllTestCharacters())
        {
            if (char.IsSeparator(c))
                Assert.That(char.IsWhiteSpace(c), Is.True, $"Char: U+{(int)c:x4} ({c})");
        }
    }
    
    [Test(Description = "A upper-case character is always a letter")]
    public void UpperAlwaysLetteTest()
    {
        foreach (char c in GetAllTestCharacters())
        {
            if (char.IsUpper(c))
                Assert.That(char.IsLetter(c), Is.True, $"Char: U+{(int)c:x4} ({c})");
        }
    }
    
    [Test(Description = "A lower-case character is always a letter")]
    public void LowerAlwaysLetterTest()
    {
        foreach (char c in GetAllTestCharacters())
        {
            if (char.IsLower(c))
                Assert.That(char.IsLetter(c), Is.True, $"Char: U+{(int)c:x4} ({c})");
        }
    }
    
    [Test(Description = "An ASCII digit is always a number")]
    public void AsciiDigitAlwaysNumberTest()
    {
        foreach (char c in GetAllTestCharacters())
        {
            if (char.IsAsciiDigit(c))
                Assert.That(char.IsNumber(c), Is.True, $"Char: U+{(int)c:x4} ({c})");
        }
    }
    
    [Test(Description = "A character is always exclusively a letter, punctuation, number, white-space, surrogate or symbol at once (except for control can be whitespace, but not separator)")]
    public void MutualExclusivesTest()
    {
        foreach (char c in GetAllTestCharacters())
        {
            if (char.IsControl(c))
                Assert.Multiple(() =>
                {
                    Assert.That(char.IsLetter(c), Is.False, $"Char: U+{(int)c:x4} ({c})");
                    Assert.That(char.IsPunctuation(c), Is.False, $"Char: U+{(int)c:x4} ({c})");
                    Assert.That(char.IsNumber(c), Is.False, $"Char: U+{(int)c:x4} ({c})");
                    Assert.That(char.IsSeparator(c), Is.False, $"Char: U+{(int)c:x4} ({c})");
                    Assert.That(char.IsSurrogate(c), Is.False, $"Char: U+{(int)c:x4} ({c})");
                    Assert.That(char.IsSymbol(c), Is.False, $"Char: U+{(int)c:x4} ({c})");
                });
            else if (char.IsLetter(c))
                Assert.Multiple(() =>
                {
                    Assert.That(char.IsPunctuation(c), Is.False, $"Char: U+{(int)c:x4} ({c})");
                    Assert.That(char.IsNumber(c), Is.False, $"Char: U+{(int)c:x4} ({c})");
                    Assert.That(char.IsWhiteSpace(c), Is.False, $"Char: U+{(int)c:x4} ({c})");
                    Assert.That(char.IsSurrogate(c), Is.False, $"Char: U+{(int)c:x4} ({c})");
                    Assert.That(char.IsSymbol(c), Is.False, $"Char: U+{(int)c:x4} ({c})");
                });
            else if (char.IsPunctuation(c))
                Assert.Multiple(() =>
                {
                    Assert.That(char.IsNumber(c), Is.False, $"Char: U+{(int)c:x4} ({c})");
                    Assert.That(char.IsWhiteSpace(c), Is.False, $"Char: U+{(int)c:x4} ({c})");
                    Assert.That(char.IsSurrogate(c), Is.False, $"Char: U+{(int)c:x4} ({c})");
                    Assert.That(char.IsSymbol(c), Is.False, $"Char: U+{(int)c:x4} ({c})");
                });
            else if (char.IsNumber(c))
                Assert.Multiple(() =>
                {
                    Assert.That(char.IsWhiteSpace(c), Is.False, $"Char: U+{(int)c:x4} ({c})");
                    Assert.That(char.IsSurrogate(c), Is.False, $"Char: U+{(int)c:x4} ({c})");
                    Assert.That(char.IsSymbol(c), Is.False, $"Char: U+{(int)c:x4} ({c})");
                });
            else if (char.IsWhiteSpace(c))
                Assert.Multiple(() =>
                {
                    Assert.That(char.IsSurrogate(c), Is.False, $"Char: U+{(int)c:x4} ({c})");
                    Assert.That(char.IsSymbol(c), Is.False, $"Char: U+{(int)c:x4} ({c})");
                });
            else if (char.IsSurrogate(c))
                Assert.That(char.IsSymbol(c), Is.False, $"Char: U+{(int)c:x4} ({c})");
        }
    }
}