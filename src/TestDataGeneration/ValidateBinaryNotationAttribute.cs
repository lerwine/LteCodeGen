using System.Management.Automation;

namespace TestDataGeneration;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
public sealed class ValidateBinaryNotationAttribute : ValidateEnumeratedArgumentsAttribute
{
    // This is a positional argument
    public ValidateBinaryNotationAttribute(int maxBitLength = 0) => MaxBitLength = (maxBitLength > 64) ? 64 : maxBitLength;

    public int MaxBitLength { get; }

    protected override void ValidateElement(object element)
    {
        if (element is null) throw new ValidationMetadataException("Pattern cannot be empty or null.");

        try { element = LanguagePrimitives.ConvertTo(element, typeof(string)); }
        catch (PSInvalidCastException exception) { throw new ValidationMetadataException("Value cannot be converted to a string value", exception); }
        if (element is not string pattern) throw new ValidationMetadataException("Value cannot be converted to a string value");
        try { CmdletStatic.AssertValidPattern(pattern, MaxBitLength); }
        catch (ArgumentException exception) { throw new ValidationMetadataException(exception.Message, exception); }
    }
}
