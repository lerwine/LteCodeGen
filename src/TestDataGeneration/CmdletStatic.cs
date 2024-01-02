using System.Management.Automation;

namespace TestDataGeneration;

public static class CmdletStatic
{
    public const string ErrorId_MinRepeatGreaterThanMaxRepeat = "MinRepeatGreaterThanMaxRepeat";
    public const string ErrorId_MinValueGreaterThanMaxValue = "MinValueGreaterThanMaxValue";
    public const string ErrorId_PathIsInvalid = "PathIsInvalid";
    public const string ErrorId_ItemNotFound = "ItemNotFound";
    public const string ErrorId_PathCannotBeReadAsText = "PathCannotBeReadAsText";

    internal static ErrorRecord CreateArgumentErrorRecord(string message, string errorId, object targetObject, string targetName)
    {
        var errorRecord = new ErrorRecord(new PSArgumentException(message), errorId, ErrorCategory.InvalidArgument, targetObject);
        errorRecord.CategoryInfo.TargetName = targetName;
        return errorRecord;
    }

    internal static ErrorRecord CreateItemNotFoundErrorRecord(string message, string errorId, object targetObject, string targetName)
    {
        var errorRecord = new ErrorRecord(new ItemNotFoundException(message), errorId, ErrorCategory.ObjectNotFound, targetObject);
        errorRecord.CategoryInfo.TargetName = targetName;
        return errorRecord;
    }

    internal static ErrorRecord CreateInvalidOperationErrorRecord(Exception exception, string errorId, object targetObject, string targetName, string reason)
    {
        
        var errorRecord = new ErrorRecord(exception, errorId, ErrorCategory.InvalidOperation, targetObject);
        errorRecord.CategoryInfo.TargetName = targetName;
        errorRecord.CategoryInfo.Reason = reason;
        return errorRecord;
    }

    private static ulong ParseBinary64Bit(string pattern, int start, int end)
    {
        var result = 1UL;
        while (start < end)
        {
            result <<= 1;
            if (pattern[start] == '1') result |= 1;
            start++;
        }
        return result;
    }

    private static uint ParseBinary32Bit(string pattern, int start, int end)
    {
        var result = 1U;
        while (start < end)
        {
            result <<= 1;
            if (pattern[start] == '1') result |= 1;
            start++;
        }
        return result;
    }

    private static uint ParseBinary16Bit(string pattern, int start)
    {
        ushort result = 1;
        while (start < pattern.Length)
        {
            result <<= 1;
            if (pattern[start] == '1') result |= 1;
            start++;
        }
        return result;
    }

    private static byte ParseBinary8Bit(string pattern, int start)
    {
        byte result = 1;
        while (start < pattern.Length)
        {
            result <<= 1;
            if (pattern[start] == '1') result |= 1;
            start++;
        }
        return result;
    }

    internal static ulong ConvertFromBinary64BitNotation(string pattern)
    {
        throw new NotImplementedException();
    }
    
    internal static long ConvertFromBinary64BitNotationAsSigned(string pattern)
    {
        throw new NotImplementedException();
    }
    
    internal static uint ConvertFromBinary32BitNotation(string pattern)
    {
        throw new NotImplementedException();
    }
    
    internal static int ConvertFromBinary32BitNotationAsSigned(string pattern)
    {
        throw new NotImplementedException();
    }
    
    internal static ushort ConvertFromBinary16BitNotation(string pattern)
    {
        throw new NotImplementedException();
    }
    
    internal static short ConvertFromBinary16BitNotationAsSigned(string pattern)
    {
        throw new NotImplementedException();
    }
    
    internal static byte ConvertFromBinary8BitNotation(string pattern)
    {
        throw new NotImplementedException();
    }
    
    internal static sbyte ConvertFromBinary8BitNotationAsSigned(string pattern)
    {
        throw new NotImplementedException();
    }
    
    internal static object ConvertFromBinaryNotation(string pattern)
    {
        int startIndex = pattern.LastIndexOf('1') + 1;
        if (startIndex < 1)
            return pattern[^1] switch
            {
                'l' or 'L' => (pattern.Length == 2) ? 0L : pattern[^2] switch
                {
                    'U' or 'u' => 0UL,
                    _ => 0L,
                },
                'U' or 'u' => 0U,
                _ => 0,
            };
        int endIndex = pattern.Length;
        switch (pattern[^1])
        {
            case 'L':
            case 'l':
                switch (pattern[^2])
                {
                    case 'U':
                    case 'u':
                        return ParseBinary64Bit(pattern, startIndex, endIndex - 2);
                    default:
                        unchecked { return (long)ParseBinary64Bit(pattern, startIndex, endIndex - 1); }
                }
            case 'U':
            case 'u':
                return ParseBinary32Bit(pattern, startIndex, endIndex - 1);
            default:
                int end = pattern.Length;
                int remainingBits = end - startIndex;
                if (remainingBits == 32)
                    return ParseBinary32Bit(pattern, startIndex, end);
                if (remainingBits == 64)
                    return ParseBinary64Bit(pattern, startIndex, end);
                if (remainingBits > 32)
                {
                    long result8 = 1L;
                    do
                    {
                        result8 <<= 1;
                        if (pattern[startIndex++] == '1') result8 |= 1;
                    }
                    while (startIndex < end);
                    return result8;
                }
                int result = 1;
                do
                {
                    result <<= 1;
                    if (pattern[startIndex++] == '1') result |= 1;
                }
                while (startIndex < end);
                return result;
        }
    }
}