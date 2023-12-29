namespace TestDataGeneration;

[Obsolete("Logic is invalid. Some types have overlapping character sets, such as AsciiPunctuation and CsIdentifierChars")]
public sealed class ExplicitRandomCharSource : RandomCharacterSource
{
    private readonly string _characters;

    internal ExplicitRandomCharSource(CharacterType type, string characters) : base(type)
    {
        _characters = characters;
    }

    public override IEnumerable<char> GetValues() { return _characters; }

    public override bool Test(char c) { return _characters.Contains(c); }
}
