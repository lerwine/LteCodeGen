using System.Management.Automation;
using static TestDataGeneration.CmdletStatic;

namespace TestDataGeneration.Commands;

[Cmdlet(VerbsData.ConvertFrom, "BinaryNotation", DefaultParameterSetName = ParameterSetName_AutoDetect)]
public class ConvertFrom_BinaryNotation : PSCmdlet
{
    public const string ParameterSetName_AutoDetect = "AutoDetect";
    public const string ParameterSetName_64Bit = "64-bit";
    public const string ParameterSetName_32Bit = "32-bit";
    public const string ParameterSetName_16Bit = "16-bit";
    public const string ParameterSetName_8Bit = "8-bit";

    [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "Binary notation string to convert.", ParameterSetName = ParameterSetName_AutoDetect)]
    [ValidateNotNullOrEmpty()]
    [ValidateBinaryNotation()]
    public string[] Pattern { get; set; } = null!;

    [Parameter(Mandatory = true, HelpMessage = "64-bit binary notation string to convert.", ParameterSetName = ParameterSetName_64Bit)]
    [ValidateNotNullOrEmpty()]
    [ValidateBinaryNotation()]
    public string[] Pattern64 { get; set; } = null!;

    [Parameter(Mandatory = true, HelpMessage = "32-bit binary notation string to convert.", ParameterSetName = ParameterSetName_32Bit)]
    [ValidateNotNullOrEmpty()]
    [ValidateBinaryNotation(32)]
    public string[] Pattern32 { get; set; } = null!;

    [Parameter(Mandatory = true, HelpMessage = "16-bit binary notation string to convert.", ParameterSetName = ParameterSetName_16Bit)]
    [ValidateNotNullOrEmpty()]
    [ValidateBinaryNotation(16)]
    public string[] Pattern16 { get; set; } = null!;

    [Parameter(Mandatory = true, HelpMessage = "8-bit binary notation string to convert.", ParameterSetName = ParameterSetName_8Bit)]
    [ValidateNotNullOrEmpty()]
    [ValidateBinaryNotation(8)]
    public string[] Pattern8 { get; set; } = null!;

    [Parameter(ParameterSetName = ParameterSetName_64Bit)]
    [Parameter(ParameterSetName = ParameterSetName_32Bit)]
    [Parameter(ParameterSetName = ParameterSetName_16Bit)]
    [Parameter(ParameterSetName = ParameterSetName_8Bit)]
    public SwitchParameter Signed { get; set; }

    protected override void ProcessRecord()
    {
        switch (ParameterSetName)
        {
             case ParameterSetName_64Bit:
                if (Signed.IsPresent)
                    foreach (string pattern in Pattern64)
                        WriteObject(ConvertFromBinary64BitNotationAsSigned(pattern));
                else
                    foreach (string pattern in Pattern64)
                        WriteObject(ConvertFromBinary64BitNotation(pattern));
                break;
             case ParameterSetName_32Bit:
                if (Signed.IsPresent)
                    foreach (string pattern in Pattern32)
                        WriteObject(ConvertFromBinary32BitNotationAsSigned(pattern));
                else
                    foreach (string pattern in Pattern32)
                        WriteObject(ConvertFromBinary32BitNotation(pattern));
                break;
             case ParameterSetName_16Bit:
                if (Signed.IsPresent)
                    foreach (string pattern in Pattern16)
                        WriteObject(ConvertFromBinary16BitNotationAsSigned(pattern));
                else
                    foreach (string pattern in Pattern16)
                        WriteObject(ConvertFromBinary16BitNotation(pattern));
                break;
             case ParameterSetName_8Bit:
                if (Signed.IsPresent)
                    foreach (string pattern in Pattern8)
                        WriteObject(ConvertFromBinary8BitNotationAsSigned(pattern));
                else
                    foreach (string pattern in Pattern8)
                        WriteObject(ConvertFromBinary8BitNotation(pattern));
                break;
            default:
                foreach (string pattern in Pattern)
                    WriteObject(ConvertFromBinaryNotation(pattern));
                break;
        }
    }

}