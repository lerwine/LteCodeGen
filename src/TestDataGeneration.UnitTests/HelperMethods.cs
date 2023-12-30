namespace TestDataGeneration.UnitTests;

public static class HelperMethods
{
    public static IEnumerable<char> GetAllTestCharacters()
    {
        for (char c = char.MinValue; c < char.MaxValue; c++)
            yield return c;
        yield return char.MaxValue;
    }
}
