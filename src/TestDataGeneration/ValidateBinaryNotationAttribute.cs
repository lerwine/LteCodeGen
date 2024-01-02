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
        if (pattern.Length == 0 || pattern.All(char.IsWhiteSpace)) throw new ValidationMetadataException("Pattern cannot be empty or null.");
        int maxBits = MaxBitLength;
        int endIndex = pattern.Length;
        switch (pattern[^1])
        {
            case 'L':
            case 'l':
                if (pattern.Length == 1) throw new ValidationMetadataException("Invalid binary notation pattern");
                if (maxBits == 0)
                    maxBits = 64;
                else if (maxBits < 64)
                    throw new ValidationMetadataException("Invalid binary notation pattern");
                switch (pattern[^2])
                {
                    case 'U':
                    case 'u':
                        if (pattern.Length == 2) throw new ValidationMetadataException("Invalid binary notation pattern");
                        endIndex -= 2;
                        break;
                    case '_':
                    case '0':
                    case '1':
                        endIndex--;
                        break;
                    default:
                        throw new ValidationMetadataException("Invalid binary notation pattern");
                }
                break;
            case 'U':
            case 'u':
                if (pattern.Length == 1) throw new ValidationMetadataException("Invalid binary notation pattern");
                if (maxBits == 0 || maxBits > 32)
                    maxBits = 32;
                else if (maxBits < 32)
                    throw new ValidationMetadataException("Invalid binary notation pattern");
                endIndex--;
                break;
            case '_':
            case '0':
            case '1':
                break;
            default:
                throw new ValidationMetadataException("Invalid binary notation pattern");
        }
        int startIndex = 0;
        // 1
        bool moveToFirstOne()
        {
            do
            {
                switch (pattern[startIndex])
                {
                    case '1':
                        return true;
                    case '0':
                    case '_':
                        startIndex++;
                        break;
                }
            }
            while (startIndex < endIndex);
            return false;
        }
        char c;
        switch (pattern[startIndex])
        {
            case '1':
                break;
            case '_':
                startIndex++;
                if (startIndex == endIndex) throw new ValidationMetadataException("Invalid binary notation pattern");
                c = pattern[startIndex];
                while (c == '_')
                {
                    startIndex++;
                    if (startIndex == endIndex) throw new ValidationMetadataException("Invalid binary notation pattern");
                    c = pattern[startIndex];
                }
                switch (c)
                {
                    case '1':
                        break;
                    case '0':
                        startIndex++;
                        if (startIndex == endIndex || !moveToFirstOne()) return;
                        break;
                    default:
                        throw new ValidationMetadataException("Invalid binary notation pattern");
                }
                break;
            case '0':
                startIndex++;
                if (startIndex == endIndex) return;
                c = pattern[startIndex];
                switch (c)
                {
                    case '1':
                        break;
                    case 'B':
                    case 'b':
                        startIndex++;
                        if (startIndex == endIndex) throw new ValidationMetadataException("Invalid binary notation pattern");
                        switch (pattern[startIndex])
                        {
                            case '1':
                                break;
                            case '0':
                                startIndex++;
                                if (startIndex == endIndex || !moveToFirstOne()) return;
                                break;
                            default:
                                throw new ValidationMetadataException("Invalid binary notation pattern");
                        }
                        break;
                    case '0':
                        startIndex++;
                        if (startIndex == endIndex || !moveToFirstOne()) return;
                        break;
                }
                break;
            default:
                throw new ValidationMetadataException("Invalid binary notation pattern");
        }
        // Character at startIndex is '1';
        int bits = 1;
        startIndex++;
        if (startIndex == endIndex) return;
        c = pattern[startIndex];
        while (bits <= maxBits)
        {
            while (c == '_')
            {
                startIndex++;
                if (startIndex == endIndex) return;
                c = pattern[startIndex];
            }
            switch (c)
            {
                case '0':
                case '1':
                    bits++;
                    startIndex++;
                    if (startIndex == endIndex) return;
                    c = pattern[startIndex];
                    break;
                default:
                    throw new ValidationMetadataException("Invalid binary notation pattern");
            }
        }
        throw new ValidationMetadataException("Invalid binary notation pattern");
    }
}
