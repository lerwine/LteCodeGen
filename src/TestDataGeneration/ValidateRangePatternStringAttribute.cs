using System.Management.Automation;

namespace TestDataGeneration;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
public sealed class ValidateRangePatternStringAttribute : ValidateEnumeratedArgumentsAttribute
{
    public bool AllowEmpty { get; set; }

    public bool AllowNull { get; set; }

    public bool AllowLongValue { get; set; }

    protected override void ValidateElement(object element)
    {
        string? stringValue;
        if (element is null)
        {
            if (!AllowNull) throw new ValidationMetadataException("Pattern cannot be empty or null.");
            return;
        }
        
        var obj = (element is PSObject psObject) ? psObject.BaseObject : element;
        if (obj is int || obj is byte || obj is sbyte || obj is short || obj is ushort) return;
        if ((obj is long || obj is uint) && AllowLongValue) return;
        try { stringValue = LanguagePrimitives.ConvertTo<string>(element).Trim(); }
        catch (PSInvalidCastException exception) { throw new ValidationMetadataException("Value cannot be converted to a string value", exception); }
        if ((stringValue = stringValue.Trim()).Length == 0)
        {
            if (!AllowEmpty) throw new ValidationMetadataException("Pattern cannot be empty or null.");
            return;
        }

        string[] pair = stringValue.Split("..", 2);
        if (pair.Length > 1)
        {
            string minStr = pair[0].Trim();
            if (minStr.Length == 0) throw new ValidationMetadataException("Minimum value cannot be empty.");
            string maxStr = pair[1].Trim();
            if (maxStr.Length == 0) throw new ValidationMetadataException("Maximum value cannot be empty.");
            if (AllowLongValue)
            {
                long minValue;
                try { minValue = long.Parse(minStr); }
                catch (FormatException exception) { throw new ValidationMetadataException($"{minStr} cannot be parsed as a long integer value.", exception); }
                catch (OverflowException exception) { throw new ValidationMetadataException($"{minStr} is too large to be parsed as a long integer value.", exception); }
                long maxValue;
                try { maxValue = long.Parse(maxStr); }
                catch (FormatException exception) { throw new ValidationMetadataException($"{maxStr} cannot be parsed as a long integer value.", exception); }
                catch (OverflowException exception) { throw new ValidationMetadataException($"{maxStr} is too large to be parsed as a long integer value.", exception); }
                if (minValue > maxValue) throw new ValidationMetadataException("Minimum value cannot greater than the maximum value.");
            }
            else
            {
                int minValue;
                try { minValue = int.Parse(minStr); }
                catch (FormatException exception) { throw new ValidationMetadataException($"{minStr} cannot be parsed as an integer value.", exception); }
                catch (OverflowException exception) { throw new ValidationMetadataException($"{minStr} is too large to be parsed as an integer value.", exception); }
                int maxValue;
                try { maxValue = int.Parse(maxStr); }
                catch (FormatException exception) { throw new ValidationMetadataException($"{maxStr} cannot be parsed as an integer value.", exception); }
                catch (OverflowException exception) { throw new ValidationMetadataException($"{maxStr} is too large to be parsed as an integer value.", exception); }
                if (minValue > maxValue) throw new ValidationMetadataException("Minimum value cannot greater than the maximum value.");
            }
        }
        else if (AllowLongValue)
        {
            if (!LanguagePrimitives.TryConvertTo<long>(element, out _)) throw new ValidationMetadataException("Pattern cannot be converted to a long integer value or range pair.");
        }
        else
            if (!LanguagePrimitives.TryConvertTo<int>(element, out _)) throw new ValidationMetadataException("Pattern cannot be converted to a integer value or range pair.");
    }
}
