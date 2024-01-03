using System.Management.Automation;
using static TestDataGeneration.CmdletStatic;

namespace TestDataGeneration;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
public sealed class ValidateWholeNumberAttribute : ValidateEnumeratedArgumentsAttribute
{
    public ValidateWholeNumberAttribute() { }

    public ValidateWholeNumberAttribute(ValidateRangeKind kind)
    {
        Kind = kind;
    }
    
    public ValidateRangeKind? Kind { get; }

    public bool AllowNull { get; set; }

    protected override void ValidateElement(object element)
    {
        if (element is null)
        {
            if (!AllowNull) throw new ValidationMetadataException("Pattern cannot be empty or null.");
            return;
        }
        object obj;
        int i;
        long l;
        ulong u;
        if (Kind.HasValue)
        {
            switch (Kind.Value)
            {
                case ValidateRangeKind.NonNegative:
                    if ((obj = EnsureBaseObject(element)) is byte || obj is ushort || obj is uint || obj is ulong) return;
                    if (LanguagePrimitives.TryConvertTo(element, out i))
                    {
                        if (i < 0) throw new ValidationMetadataException("Value cannot be negative");
                        return;
                    }
                    if (LanguagePrimitives.TryConvertTo(element, out l))
                    {
                        if (l < 0) throw new ValidationMetadataException("Value cannot be negative");
                        return;
                    }
                    try { _ = LanguagePrimitives.ConvertTo<ulong>(element); }
                    catch (PSInvalidCastException exception) { throw new ValidationMetadataException("Value cannot be converted to a whole number", exception); }
                    break;
                case ValidateRangeKind.Negative:
                    if ((obj = EnsureBaseObject(element)) is byte || obj is ushort || obj is uint || obj is ulong || LanguagePrimitives.TryConvertTo<uint>(element, out _)) throw new ValidationMetadataException("Value must be negative");
                    if (LanguagePrimitives.TryConvertTo(element, out i))
                    {
                        if (i > -1) throw new ValidationMetadataException("Value must be negative");
                    }
                    try { l = LanguagePrimitives.ConvertTo<long>(element); }
                    catch (PSInvalidCastException exception) { throw new ValidationMetadataException("Value cannot be converted to a whole number", exception); }
                    if (l > -1L) throw new ValidationMetadataException("Value must be negative");
                    break;
                case ValidateRangeKind.NonPositive:
                    if (LanguagePrimitives.TryConvertTo(element, out i))
                    {
                        if (i < 1) throw new ValidationMetadataException("Value cannot be positive");
                        return;
                    }
                    if (LanguagePrimitives.TryConvertTo(element, out l))
                    {
                        if (l < 1) throw new ValidationMetadataException("Value cannot be positive");
                        return;
                    }
                    try { u = LanguagePrimitives.ConvertTo<ulong>(element); }
                    catch (PSInvalidCastException exception) { throw new ValidationMetadataException("Value cannot be converted to a whole number", exception); }
                    if (u != 0UL) throw new ValidationMetadataException("Value cannot be positive");
                    break;
                default:
                    if (LanguagePrimitives.TryConvertTo(element, out i))
                    {
                        if (i < 1) throw new ValidationMetadataException("Value must be positive");
                        return;
                    }
                    if (LanguagePrimitives.TryConvertTo(element, out l))
                    {
                        if (l < 1) throw new ValidationMetadataException("Value must be positive");
                        return;
                    }
                    try { u = LanguagePrimitives.ConvertTo<ulong>(element); }
                    catch (PSInvalidCastException exception) { throw new ValidationMetadataException("Value cannot be converted to a whole number", exception); }
                    if (u == 0UL) throw new ValidationMetadataException("Value must be positive");
                    break;
            }
        }
        else
        {
            if ((obj = EnsureBaseObject(element)) is int || obj is byte || obj is sbyte || obj is short || obj is ushort || obj is long || obj is uint || obj is long || obj is ulong || LanguagePrimitives.TryConvertTo<int>(element, out _) || LanguagePrimitives.TryConvertTo<long>(element, out _)) return;
            try { _ = LanguagePrimitives.ConvertTo<ulong>(element); }
            catch (PSInvalidCastException exception) { throw new ValidationMetadataException("Value cannot be converted to a whole number", exception); }
        }
    }
}
