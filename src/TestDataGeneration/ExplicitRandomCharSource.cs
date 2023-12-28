using System.Collections.ObjectModel;

namespace TestDataGeneration;

public sealed class ExplicitRandomCharSource : RandomCharacterSource
{
    private readonly string _characters;
    internal ExplicitRandomCharSource(CharacterType type, string characters, Collection<RandomCharacterSource> includes, Collection<RandomCharacterSource> includedBy) : base(type, includes, includedBy)
    {
        _characters = characters;
    }
    public override IEnumerable<char> GetValues() { return _characters; }
    public override bool Test(char c) { return _characters.Contains(c); }
}
