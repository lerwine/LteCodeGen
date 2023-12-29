namespace TestDataGeneration;

[Obsolete("Logic is invalid. Some types have overlapping character sets, such as AsciiPunctuation and CsIdentifierChars")]
public sealed class DelegatedRandomCharSource : RandomCharacterSource
{
    private readonly Func<IEnumerable<char>> _getValues;

    private readonly Predicate<char> _test;

    private IEnumerable<char> GetValuesDefault()
    {
        for (char c = char.MinValue; c < char.MaxValue; c++)
        {
            if (_test(c)) yield return c;
        }
        if (_test(char.MaxValue)) yield return char.MaxValue;
    }

    public DelegatedRandomCharSource(CharacterType type, Predicate<char> test, Func<IEnumerable<char>> getValues) : base(type)
    {
        _test = test;
        _getValues = getValues ?? GetValuesDefault;
    }

    public override IEnumerable<char> GetValues() { return _getValues(); }

    public override bool Test(char c) { return _test(c); }
}