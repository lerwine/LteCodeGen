using System.Management.Automation;
using System.Text;

namespace TestDataGeneration;

public static class CmdletStatic
{
    public const string ErrorId_MinRepeatGreaterThanMaxRepeat = "MinRepeatGreaterThanMaxRepeat";
    public const string ErrorId_MinValueGreaterThanMaxValue = "MinValueGreaterThanMaxValue";
    public const string ErrorId_PathIsInvalid = "PathIsInvalid";
    public const string ErrorId_ItemNotFound = "ItemNotFound";
    public const string ErrorId_PathCannotBeReadAsText = "PathCannotBeReadAsText";
    private const char Suffix_Long_UC = 'L';
    private const char Suffix_Long_LC = 'l';
    private const char Suffix_Unsigned_UC = 'U';
    private const char Suffix_Unsigned_LC = 'u';
    private const char Char_Underscore = '_';
    private const char Char_Zero = '0';
    private const char Char_One = '1';
    private const char Prefix_Binary_Amp = '&';
    private const char Prefix_Binary_LC = 'b';
    private const char Prefix_Binary_UC = 'B';
    public const string BinaryFormatPrefix_0b = "0b";
    public const string BinaryFormatPrefix_0B = "0B";
    public const string BinaryFormatPrefix_Amp_b = "&b";
    public const string BinaryFormatPrefix_Amp_B = "&B";

    internal static object EnsureBaseObject(object value) => (value is PSObject psObject) ? psObject.BaseObject : value;

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
            if (pattern[start] == Char_One) result |= 1;
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
            if (pattern[start] == Char_One) result |= 1;
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
            if (pattern[start] == Char_One) result |= 1;
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
            if (pattern[start] == Char_One) result |= 1;
            start++;
        }
        return result;
    }

    
    private static void FormatBits(BinaryFormatOptions format, TextWriter writer, params bool[] bitArr)
    {
        var length = bitArr.Length;
        if (length < 1) return;
        var step = format.HasFlag(BinaryFormatOptions.SplitNibble) ? 4 : format.HasFlag(BinaryFormatOptions.SplitByte) ? 8 :
            format.HasFlag(BinaryFormatOptions.SplitWord) ? 16 : format.HasFlag(BinaryFormatOptions.SplitDWord) ? 32 : 0;
        if (format.HasFlag(BinaryFormatOptions.Lc0B))
            writer.Write(BinaryFormatPrefix_0b);
        else if (format.HasFlag(BinaryFormatOptions.Uc0B))
            writer.Write(BinaryFormatPrefix_0B);
        else if (format.HasFlag(BinaryFormatOptions.AmpersandLcB))
            writer.Write(BinaryFormatPrefix_Amp_b);
        else if (format.HasFlag(BinaryFormatOptions.AmpersandUcB))
            writer.Write(BinaryFormatPrefix_Amp_B);
        if (step < 1)
        {
            foreach (var b in bitArr)
                writer.Write(b ? Char_One : Char_Zero);
        }
        else
        {
            var position = length % step;
            if (position == 0) position = step;
            for (var i = 0; i < position; i++) writer.Write(bitArr[i] ? Char_One : Char_Zero);
            do
            {
                writer.Write(Char_Underscore);
                for (var i = 0; i < step; i++)
                {
                    position++;
                    writer.Write(bitArr[position] ? Char_One : Char_Zero);
                }
            }
            while (position < length);
        }
    }

    private static void FormatBits(BinaryFormatOptions format, StringBuilder stringBuilder, params bool[] bitArr)
    {
        var length = bitArr.Length;
        if (length < 1) return;
        var step = format.HasFlag(BinaryFormatOptions.SplitNibble) ? 4 : format.HasFlag(BinaryFormatOptions.SplitByte) ? 8 :
            format.HasFlag(BinaryFormatOptions.SplitWord) ? 16 : format.HasFlag(BinaryFormatOptions.SplitDWord) ? 32 : 0;
        if (format.HasFlag(BinaryFormatOptions.Lc0B))
            stringBuilder.Append(BinaryFormatPrefix_0b);
        else if (format.HasFlag(BinaryFormatOptions.Uc0B))
            stringBuilder.Append(BinaryFormatPrefix_0b);
        else if (format.HasFlag(BinaryFormatOptions.AmpersandLcB))
            stringBuilder.Append(BinaryFormatPrefix_Amp_b);
        else if (format.HasFlag(BinaryFormatOptions.AmpersandUcB))
            stringBuilder.Append(BinaryFormatPrefix_Amp_B);
        if (step < 1)
        {
            foreach (var b in bitArr)
                stringBuilder.Append(b ? Char_One : Char_Zero);
        }
        else
        {
            var position = length % step;
            if (position == 0) position = step;
            for (var i = 0; i < position; i++) stringBuilder.Append(bitArr[i] ? Char_One : Char_Zero);
            do
            {
                stringBuilder.Append(Char_Underscore);
                for (var i = 0; i < step; i++)
                {
                    position++;
                    stringBuilder.Append(bitArr[position] ? Char_One : Char_Zero);
                }
            }
            while (position < length);
        }
    }

    private static string FormatBits(IEnumerable<bool> bits, BinaryFormatOptions format)
    {
        var bitArr = bits.ToArray();
        if (bitArr.Length < 1) return string.Empty;
        StringBuilder sb = new();
        FormatBits(format, sb, bitArr);
        return sb.ToString();
    }

    [Obsolete("Use FormatBits(IEnumerable<bool>, BinaryFormatOptions)")]
    private static string FormatBits(IEnumerable<bool> bits, BinaryFormatOptions format, bool noPrefix)
    {
        var bitArr = bits.ToList();
        var length = bitArr.Count;
        var step = format switch
        {
            BinaryFormatOptions.SplitNibble => 4,
            BinaryFormatOptions.SplitByte => 8,
            BinaryFormatOptions.SplitWord => 16,
            BinaryFormatOptions.SplitDWord => 32,
            _ => length,
        };
        if (length >= step) return noPrefix ? new string(bitArr.Select(b => b ? Char_One : Char_Zero).ToArray()) : "0b" + new string(bitArr.Select(b => b ? Char_One : Char_Zero).ToArray());
        var position = length % step;
        if (position == 0) position = step;
        var sb = new StringBuilder();
        if (!noPrefix) sb.Append("0b");
        for (var i = 0; i < position; i++) sb.Append(bitArr[i] ? Char_One : Char_Zero);
        do
        {
            sb.Append(Char_Underscore);
            for (var i = 0; i < step; i++)
            {
                position++;
                sb.Append(bitArr[position] ? Char_One : Char_Zero);
            }
        }
        while (position < length);
        return sb.ToString();
    }

    public static string ConvertUInt64ToBinaryNotation(ulong value, BinaryFormatOptions format = BinaryFormatOptions.DigitsOnly, int minBits = 1)
    {
        if (minBits < 1) minBits = 1;
        LinkedList<bool> bits = new();
        foreach (byte b in BitConverter.GetBytes(value))
            for (int i = 1; i <= 0b1000_000; i <<= 1) bits.AddFirst((b & i) != 0);
        while (bits.Count > minBits && !bits.First!.Value) bits.RemoveFirst();
        return FormatBits(bits, format);
    }

    public static string ConvertInt64ToBinaryNotation(long value, BinaryFormatOptions format = BinaryFormatOptions.DigitsOnly, int minBits = 1)
    {
        if (minBits < 1) minBits = 1;
        LinkedList<bool> bits = new();
        foreach (byte b in BitConverter.GetBytes(value))
            for (int i = 1; i <= 0b1000_000; i <<= 1) bits.AddFirst((b & i) != 0);
        while (bits.Count > minBits && !bits.First!.Value) bits.RemoveFirst();
        return FormatBits(bits, format);
    }

    public static string ConvertUInt32ToBinaryNotation(uint value, BinaryFormatOptions format = BinaryFormatOptions.DigitsOnly, int minBits = 1)
    {
        if (minBits < 1) minBits = 1;
        LinkedList<bool> bits = new();
        foreach (byte b in BitConverter.GetBytes(value))
            for (int i = 1; i <= 0b1000_000; i <<= 1) bits.AddFirst((b & i) != 0);
        while (bits.Count > minBits && !bits.First!.Value) bits.RemoveFirst();
        return FormatBits(bits, format);
    }

    public static string ConvertInt32ToBinaryNotation(int value, BinaryFormatOptions format = BinaryFormatOptions.DigitsOnly, int minBits = 1)
    {
        if (minBits < 1) minBits = 1;
        LinkedList<bool> bits = new();
        foreach (byte b in BitConverter.GetBytes(value))
            for (int i = 1; i <= 0b1000_000; i <<= 1) bits.AddFirst((b & i) != 0);
        while (bits.Count > minBits && !bits.First!.Value) bits.RemoveFirst();
        return FormatBits(bits, format);
    }

    public static string ConvertUInt16ToBinaryNotation(ushort value, BinaryFormatOptions format = BinaryFormatOptions.DigitsOnly,int minBits = 1)
    {
        if (minBits < 1) minBits = 1;
        LinkedList<bool> bits = new();
        foreach (byte b in BitConverter.GetBytes(value))
            for (int i = 1; i <= 0b1000_000; i <<= 1) bits.AddFirst((b & i) != 0);
        while (bits.Count > minBits && !bits.First!.Value) bits.RemoveFirst();
        return FormatBits(bits, format);
    }

    public static string ConvertInt16ToBinaryNotation(short value, BinaryFormatOptions format = BinaryFormatOptions.DigitsOnly,int minBits = 1)
    {
        if (minBits < 1) minBits = 1;
        LinkedList<bool> bits = new();
        foreach (byte b in BitConverter.GetBytes(value))
            for (int i = 1; i <= 0b1000_000; i <<= 1) bits.AddFirst((b & i) != 0);
        while (bits.Count > minBits && !bits.First!.Value) bits.RemoveFirst();
        return FormatBits(bits, format);
    }

    public static string ConvertByteToBinaryNotation(byte value, BinaryFormatOptions format = BinaryFormatOptions.DigitsOnly, int minBits = 1)
    {
        if (minBits < 1) minBits = 1;
        LinkedList<bool> bits = new();
        for (int i = 1; i <= 0b1000_000; i <<= 1) bits.AddFirst((value & i) != 0);
        while (bits.Count > minBits && !bits.First!.Value) bits.RemoveFirst();
        return FormatBits(bits, format);
    }

    public static string ConvertSByteToBinaryNotation(sbyte value, BinaryFormatOptions format = BinaryFormatOptions.DigitsOnly, int minBits = 1)
    {
        if (minBits < 1) minBits = 1;
        LinkedList<bool> bits = new();
        if (value < 0)
        {
            bits.AddFirst((value & 1) != 0);
            for (var i = 1; i < 8; i++) bits.AddFirst((sbyte.RotateRight(value, i) & 1) != 0);
        }
        else
            for (int i = 1; i <= 0b1000_000; i <<= 1) bits.AddFirst((value & i) != 0);
        while (bits.Count > minBits && !bits.First!.Value) bits.RemoveFirst();
        return FormatBits(bits, format);
    }

    public static void AssertValidPattern(string pattern, int maxBits = 0)
    {
        if (string.IsNullOrWhiteSpace(pattern)) throw new ArgumentException($"'{nameof(pattern)}' cannot be null or whitespace.", nameof(pattern));
        if (maxBits > 64) maxBits = 64;
        int endIndex = pattern.Length;
        switch (pattern[^1])
        {
            case Suffix_Long_UC:
            case Suffix_Long_LC:
                if (pattern.Length == 1) throw new ArgumentException("Invalid binary notation pattern", nameof(pattern));
                if (maxBits == 0)
                    maxBits = 64;
                else if (maxBits < 64)
                    throw new ArgumentException("Invalid binary notation pattern", nameof(pattern));
                switch (pattern[^2])
                {
                    case Suffix_Unsigned_UC:
                    case Suffix_Unsigned_LC:
                        if (pattern.Length == 2) throw new ArgumentException("Invalid binary notation pattern", nameof(pattern));
                        endIndex -= 2;
                        break;
                    case Char_Underscore:
                    case Char_Zero:
                    case Char_One:
                        endIndex--;
                        break;
                    default:
                        throw new ArgumentException("Invalid binary notation pattern", nameof(pattern));
                }
                break;
            case Suffix_Unsigned_UC:
            case Suffix_Unsigned_LC:
                if (pattern.Length == 1) throw new ArgumentException("Invalid binary notation pattern", nameof(pattern));
                if (maxBits == 0 || maxBits > 32)
                    maxBits = 32;
                else if (maxBits < 32)
                    throw new ArgumentException("Invalid binary notation pattern", nameof(pattern));
                endIndex--;
                break;
            case Char_Underscore:
            case Char_Zero:
            case Char_One:
                break;
            default:
                throw new ArgumentException("Invalid binary notation pattern", nameof(pattern));
        }
        int startIndex = 0;
        // 1
        bool moveToFirstOne()
        {
            do
            {
                switch (pattern[startIndex])
                {
                    case Char_One:
                        return true;
                    case Char_Zero:
                    case Char_Underscore:
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
            case Char_One:
                break;
            case Char_Underscore:
                startIndex++;
                if (startIndex == endIndex) throw new ArgumentException("Invalid binary notation pattern", nameof(pattern));
                c = pattern[startIndex];
                while (c == Char_Underscore)
                {
                    startIndex++;
                    if (startIndex == endIndex) throw new ArgumentException("Invalid binary notation pattern", nameof(pattern));
                    c = pattern[startIndex];
                }
                switch (c)
                {
                    case Char_One:
                        break;
                    case Char_Zero:
                        startIndex++;
                        if (startIndex == endIndex || !moveToFirstOne()) return;
                        break;
                    default:
                        throw new ArgumentException("Invalid binary notation pattern", nameof(pattern));
                }
                break;
            case Prefix_Binary_Amp:
                startIndex++;
                if (startIndex == endIndex) throw new ArgumentException("Invalid binary notation pattern", nameof(pattern));
                switch (pattern[startIndex])
                { 
                    case Prefix_Binary_UC:
                    case Prefix_Binary_LC:
                        startIndex++;
                        if (startIndex == endIndex) throw new ArgumentException("Invalid binary notation pattern", nameof(pattern));
                        switch (pattern[startIndex])
                        {
                            case Char_One:
                                break;
                            case Char_Zero:
                                startIndex++;
                                if (startIndex == endIndex || !moveToFirstOne()) return;
                                break;
                            default:
                                throw new ArgumentException("Invalid binary notation pattern", nameof(pattern));
                        }
                        break;
                    default:
                        throw new ArgumentException("Invalid binary notation pattern", nameof(pattern));
                }
                break;
            case Char_Zero:
                startIndex++;
                if (startIndex == endIndex) return;
                switch (pattern[startIndex])
                {
                    case Char_One:
                        break;
                    case Prefix_Binary_UC:
                    case Prefix_Binary_LC:
                        startIndex++;
                        if (startIndex == endIndex) throw new ArgumentException("Invalid binary notation pattern", nameof(pattern));
                        switch (pattern[startIndex])
                        {
                            case Char_One:
                                break;
                            case Char_Zero:
                                startIndex++;
                                if (startIndex == endIndex || !moveToFirstOne()) return;
                                break;
                            default:
                                throw new ArgumentException("Invalid binary notation pattern", nameof(pattern));
                        }
                        break;
                    case Char_Zero:
                        startIndex++;
                        if (startIndex == endIndex || !moveToFirstOne()) return;
                        break;
                }
                break;
            default:
                throw new ArgumentException("Invalid binary notation pattern", nameof(pattern));
        }
        // Character at startIndex is '1';
        int bits = 1;
        startIndex++;
        if (startIndex == endIndex) return;
        c = pattern[startIndex];
        while (bits <= maxBits)
        {
            while (c == Char_Underscore)
            {
                startIndex++;
                if (startIndex == endIndex) return;
                c = pattern[startIndex];
            }
            switch (c)
            {
                case Char_Zero:
                case Char_One:
                    bits++;
                    startIndex++;
                    if (startIndex == endIndex) return;
                    c = pattern[startIndex];
                    break;
                default:
                    throw new ArgumentException("Invalid binary notation pattern", nameof(pattern));
            }
        }
        throw new ArgumentException("Invalid binary notation pattern", nameof(pattern));
    }

    private static List<bool> ParseBits(string pattern, out bool unsigned, out bool longValue)
    {
        if (string.IsNullOrWhiteSpace(pattern)) throw new ArgumentException($"'{nameof(pattern)}' cannot be null or whitespace.", nameof(pattern));
        int endIndex = pattern.Length;
        switch (pattern[^1])
        {
            case Suffix_Long_UC:
            case Suffix_Long_LC:
                longValue = true;
                switch (pattern[^2])
                {
                    case Suffix_Unsigned_UC:
                    case Suffix_Unsigned_LC:
                        unsigned = true;
                        endIndex -= 2;
                        break;
                    default:
                        unsigned = false;
                        endIndex--;
                        break;
                }
                break;
            case Suffix_Unsigned_UC:
            case Suffix_Unsigned_LC:
                longValue = false;
                unsigned = true;
                endIndex--;
                break;
            default:
                longValue = false;
                unsigned = false;
                break;
        }
        List<bool> result = new();
        for (var i = 0; i < endIndex; i++)
        {
            switch (pattern[i])
            {
                case Char_One:
                    result.Add(true);
                    break;
                case Char_Zero:
                    result.Add(false);
                    break;
            }
        }
        return result;
    }

    private static List<bool> ParseBits(string pattern, out bool unsigned)
    {
        if (string.IsNullOrWhiteSpace(pattern)) throw new ArgumentException($"'{nameof(pattern)}' cannot be null or whitespace.", nameof(pattern));
        int endIndex = pattern.Length;
        switch (pattern[^1])
        {
            case Suffix_Long_UC:
            case Suffix_Long_LC:
                switch (pattern[^2])
                {
                    case Suffix_Unsigned_UC:
                    case Suffix_Unsigned_LC:
                        unsigned = true;
                        endIndex -= 2;
                        break;
                    default:
                        unsigned = false;
                        endIndex--;
                        break;
                }
                break;
            case Suffix_Unsigned_UC:
            case Suffix_Unsigned_LC:
                unsigned = true;
                endIndex--;
                break;
            default:
                unsigned = false;
                break;
        }
        List<bool> result = new();
        for (var i = 0; i < endIndex; i++)
        {
            switch (pattern[i])
            {
                case Char_One:
                    result.Add(true);
                    break;
                case Char_Zero:
                    result.Add(false);
                    break;
            }
        }
        return result;
    }

    private static List<bool> ParseBits(string pattern)
    {
        if (string.IsNullOrWhiteSpace(pattern)) throw new ArgumentException($"'{nameof(pattern)}' cannot be null or whitespace.", nameof(pattern));
        int endIndex = pattern.Length;
        switch (pattern[^1])
        {
            case Suffix_Long_UC:
            case Suffix_Long_LC:
                switch (pattern[^2])
                {
                    case Suffix_Unsigned_UC:
                    case Suffix_Unsigned_LC:
                        endIndex -= 2;
                        break;
                    default:
                        endIndex--;
                        break;
                }
                break;
            case Suffix_Unsigned_UC:
            case Suffix_Unsigned_LC:
                endIndex--;
                break;
        }
        List<bool> result = new();
        for (var i = 0; i < endIndex; i++)
        {
            switch (pattern[i])
            {
                case Char_One:
                    result.Add(true);
                    break;
                case Char_Zero:
                    result.Add(false);
                    break;
            }
        }
        return result;
    }

    private static ulong ConvertFromBinary64Bits(List<bool> bits)
    {
        ulong results = 0UL;
        foreach (var b in bits)
        {
            results <<= 1;
            if (b) results |= 1UL;
        }
        return results;
    }

    public static ulong ConvertFromBinary64BitNotation(string pattern)
    {
        AssertValidPattern(pattern, 64);
        return ConvertFromBinary64Bits(ParseBits(pattern));
    }

    private static long ConvertFromBinary64BitsAsSigned(List<bool> bits, bool forceUnsigned)
    {
        if (forceUnsigned) return (long)ConvertFromBinary64Bits(bits);
        long results = 0L;
        foreach (var b in bits)
        {
            results <<= 1;
            if (b) results |= 1L;
        }
        return results;
    }

    public static long ConvertFromBinary64BitNotationAsSigned(string pattern)
    {
        AssertValidPattern(pattern, 64);
        var bits = ParseBits(pattern, out bool forceUnsigned);
        return ConvertFromBinary64BitsAsSigned(bits, forceUnsigned);
    }

    private static uint ConvertFromBinary32its(List<bool> bits)
    {
        uint results = 0;
        foreach (var b in bits)
        {
            results <<= 1;
            if (b) results |= 1;
        }
        return results;
    }

    public static uint ConvertFromBinary32BitNotation(string pattern)
    {
        AssertValidPattern(pattern, 32);
        return ConvertFromBinary32its(ParseBits(pattern));
    }

    private static int ConvertFromBinary32BitsAsSigned(List<bool> bits, bool forceUnsigned)
    {
        if (forceUnsigned) return (int)ConvertFromBinary32its(bits);
        int results = 0;
        foreach (var b in bits)
        {
            results <<= 1;
            if (b) results |= 1;
        }
        return results;
    }

    public static int ConvertFromBinary32BitNotationAsSigned(string pattern)
    {
        AssertValidPattern(pattern, 32);
        var bits = ParseBits(pattern, out bool forceUnsigned);
        return ConvertFromBinary32BitsAsSigned(bits, forceUnsigned);
    }

    private static ushort ConvertFromBinary16Bits(List<bool> bits)
    {
        ushort results = 0;
        foreach (var b in bits)
        {
            results <<= 1;
            if (b) results |= 1;
        }
        return results;
    }

    public static ushort ConvertFromBinary16BitNotation(string pattern)
    {
        AssertValidPattern(pattern, 16);
        return ConvertFromBinary16Bits(ParseBits(pattern));
    }

    public static short ConvertFromBinary16BitNotationAsSigned(string pattern)
    {
        AssertValidPattern(pattern, 16);
        var bits = ParseBits(pattern, out bool forceUnsigned);
        if (forceUnsigned) return (short)ConvertFromBinary16Bits(bits);
        short results = 0;
        foreach (var b in bits)
        {
            results <<= 1;
            if (b) results |= 1;
        }
        return results;
    }

    private static byte ConvertFromBinary8Bits(List<bool> bits)
    {
        byte results = 0;
        foreach (var b in bits)
        {
            results <<= 1;
            if (b) results |= 1;
        }
        return results;
    }

    public static byte ConvertFromBinary8BitNotation(string pattern)
    {
        AssertValidPattern(pattern, 8);
        return ConvertFromBinary8Bits(ParseBits(pattern));
    }

    public static sbyte ConvertFromBinary8BitNotationAsSigned(string pattern)
    {
        AssertValidPattern(pattern, 8);
        var bits = ParseBits(pattern, out bool forceUnsigned);
        if (forceUnsigned) return (sbyte)ConvertFromBinary8Bits(bits);
        sbyte results = 0;
        foreach (var b in bits)
        {
            results <<= 1;
            if (b) results |= 1;
        }
        return results;
    }

    public static object ConvertFromBinaryNotation(string pattern)
    {
        AssertValidPattern(pattern);
        var bits = ParseBits(pattern, out bool unsigned, out bool longValue);
        if (longValue)
        {
            if (unsigned) return ConvertFromBinary64Bits(bits);
            return ConvertFromBinary64BitsAsSigned(bits, false);
        }
        if (unsigned) return ConvertFromBinary32its(bits);
        int i = bits.IndexOf(true);
        if (i < 0 || (i = bits.Count - i) < 32) return ConvertFromBinary32BitsAsSigned(bits, false);
        if (i == 32) return ConvertFromBinary32its(bits);
        if (i < 64) return ConvertFromBinary64BitsAsSigned(bits, false);
        return ConvertFromBinary64Bits(bits);
    }
}