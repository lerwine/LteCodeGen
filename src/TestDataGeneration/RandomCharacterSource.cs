namespace TestDataGeneration;

public class RandomCharacterSource
{
    public CharacterType Type { get; }

    public bool Test(char c)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<char> GetValues()
    {
        throw new NotImplementedException();
    }

    public RandomCharacterSource(CharacterType type)
    {
        Type = type;
    }
}
