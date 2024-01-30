using System.Management.Automation;
using static TestDataGeneration.CmdletStatic;

namespace TestDataGeneration.Commands;

[Cmdlet(VerbsData.ConvertTo, "BinaryNotation", DefaultParameterSetName = ParameterSetName_AutoDetect)]
public class ConvertTo_BinaryNotation : PSCmdlet
{
    public const string ParameterSetName_AutoDetect = "AutoDetect";
    public const string ParameterSetName_UInt64 = "UInt64";
    public const string ParameterSetName_Int64 = "Int64";
    public const string ParameterSetName_UInt32 = "UInt32";
    public const string ParameterSetName_Int32 = "Int32";
    public const string ParameterSetName_UInt16 = "UInt16";
    public const string ParameterSetName_Int16 = "Int16";
    public const string ParameterSetName_Byte = "Byte";
    public const string ParameterSetName_SByte = "SByte";

    
    [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0, HelpMessage = "Value to convert.", ParameterSetName = ParameterSetName_AutoDetect)]
    [ValidateWholeNumber()]
    public object[] InputObject { get; set; } = null!;

    [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "Value to convert.", ParameterSetName = ParameterSetName_UInt64)]
    public ulong[] UInt64 { get; set; } = null!;

    [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "Value to convert.", ParameterSetName = ParameterSetName_Int64)]
    public long[] Int64 { get; set; } = null!;

    [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "Value to convert.", ParameterSetName = ParameterSetName_UInt32)]
    public uint[] UInt32 { get; set; } = null!;

    [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "Value to convert.", ParameterSetName = ParameterSetName_Int32)]
    public int[] Int32 { get; set; } = null!;

    [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "Value to convert.", ParameterSetName = ParameterSetName_UInt16)]
    public ushort[] UInt16 { get; set; } = null!;

    [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "Value to convert.", ParameterSetName = ParameterSetName_Int16)]
    public short[] Int16 { get; set; } = null!;

    [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "Value to convert.", ParameterSetName = ParameterSetName_Byte)]
    public byte[] Byte { get; set; } = null!;

    [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "Value to convert.", ParameterSetName = ParameterSetName_SByte)]
    public sbyte[] SByte { get; set; } = null!;

    [Parameter(HelpMessage = "Minimum number of bits.", ParameterSetName = ParameterSetName_AutoDetect)]
    [ValidateRange(1, 64)]
    public int MinimumBits { get; set; }

    [Parameter(HelpMessage = "How to format/group the bit values.")]
    public BinaryFormatOptions[] Format { get; set; } = null!;

    private void ConvertToBn<T>(T[] values, BinaryFormatOptions format, int minimumBits, Func<T,BinaryFormatOptions, int, string> func)
    {
        foreach (T v in values)
            WriteObject(func(v, format, minimumBits));
    }

    protected override void ProcessRecord()
    {
        BinaryFormatOptions format;
        if (MyInvocation.BoundParameters.ContainsKey(nameof(Format)))
            format = (Format.Length == 1) ? Format[0] : Format.Aggregate(BinaryFormatOptions.DigitsOnly, (a, b) => a | b);
        else
            format = BinaryFormatOptions.Default;
        switch (ParameterSetName)
        {
            case ParameterSetName_UInt64:
                ConvertToBn(UInt64, format, 64, ConvertUInt64ToBinaryNotation);
                break;
            case ParameterSetName_Int64:
                ConvertToBn(Int64, format, 64, ConvertInt64ToBinaryNotation);
                break;
            case ParameterSetName_UInt32:
                ConvertToBn(UInt32, format, 32, ConvertUInt32ToBinaryNotation);
                break;
            case ParameterSetName_Int32:
                ConvertToBn(Int32, format, 32, ConvertInt32ToBinaryNotation);
                break;
            case ParameterSetName_UInt16:
                ConvertToBn(UInt16, format, 16, ConvertUInt16ToBinaryNotation);
                break;
            case ParameterSetName_Int16:
                ConvertToBn(Int16, format, 16, ConvertInt16ToBinaryNotation);
                break;
            case ParameterSetName_Byte:
                ConvertToBn(Byte, format, 8, ConvertByteToBinaryNotation);
                break;
            case ParameterSetName_SByte:
                ConvertToBn(SByte, format, 8, ConvertSByteToBinaryNotation);
                break;
            default:
                int minimumBits = MyInvocation.BoundParameters.ContainsKey(nameof(MinimumBits)) ? MinimumBits : 1;
                foreach (object element in InputObject)
                {
                    var obj = EnsureBaseObject(element);
                    if (obj is ulong ul)
                        ConvertUInt64ToBinaryNotation(ul, format, minimumBits);
                    else if (obj is long l)
                        ConvertInt64ToBinaryNotation(l, format, minimumBits);
                    else if (obj is uint u)
                        ConvertUInt32ToBinaryNotation(u, format, minimumBits);
                    else if (obj is int i)
                        ConvertInt32ToBinaryNotation(i, format, minimumBits);
                    else if (obj is ushort uint16)
                        ConvertUInt16ToBinaryNotation(uint16, format, minimumBits);
                    else if (obj is short int16)
                        ConvertInt16ToBinaryNotation(int16, format, minimumBits);
                    else if (obj is byte b)
                        ConvertByteToBinaryNotation(b, format, minimumBits);
                    else if (obj is sbyte s)
                        ConvertSByteToBinaryNotation(s, format, minimumBits);
                    else if (LanguagePrimitives.TryConvertTo(element, out i))
                        ConvertInt32ToBinaryNotation(i, format, minimumBits);
                    else if (LanguagePrimitives.TryConvertTo(element, out l))
                        ConvertInt64ToBinaryNotation(l, format, minimumBits);
                    else if (LanguagePrimitives.TryConvertTo(element, out ul))
                        ConvertUInt64ToBinaryNotation(ul, format, minimumBits);
                }
                break;
        }
    }
}
