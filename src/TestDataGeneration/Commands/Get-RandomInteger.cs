using System.Management.Automation;
using static TestDataGeneration.RandomStatic;
using static TestDataGeneration.CmdletStatic;

namespace TestDataGeneration.Commands;

[Cmdlet(VerbsCommon.Get, "RandomInteger", DefaultParameterSetName = ParameterSetName_FixedRepeat)]
public class Get_RandomInteger : PSCmdlet
{
    public const string ParameterSetName_FixedRepeat = "FixedRepeat";

    public const string ParameterSetName_RandomRepeat = "RandomRepeat";

    [Parameter(ValueFromPipelineByPropertyName = true)]
    public int MinValue { get; set; } = int.MinValue;

    [Parameter(ValueFromPipelineByPropertyName = true)]
    public int MaxValue { get; set; } = int.MaxValue;

    [Parameter(ParameterSetName = ParameterSetName_FixedRepeat)]
    [ValidateRange(1, int.MaxValue)]
    public int Repeat { get; set; } = 1;

    [Parameter(ParameterSetName = ParameterSetName_RandomRepeat)]
    [ValidateRange(ValidateRangeKind.NonNegative)]
    public int MinRepeat { get; set; } = 1;

    [Parameter(Mandatory = true, ParameterSetName = ParameterSetName_RandomRepeat)]
    [ValidateRange(1, int.MaxValue)]
    public int MaxRepeat { get; set; }

    protected override void ProcessRecord()
    {
        int repeat = Repeat;
        if (ParameterSetName == ParameterSetName_RandomRepeat)
            try { repeat = GetRandomInteger(MinRepeat, MaxRepeat); }
            catch (ArgumentException exception)
            {
                WriteError(new ErrorRecord(exception, ErrorId_MinRepeatGreaterThanMaxRepeat, ErrorCategory.InvalidArgument, MinRepeat)
                {
                    ErrorDetails = new ErrorDetails($"{nameof(MinRepeat)} cannot be greater than {nameof(MaxRepeat)}.")
                });
                return;
            }
        IEnumerable<int> result;
        try { result = GetRandomIntegers(repeat, MinValue, MaxValue); }
        catch (ArgumentException exception)
        {
            WriteError(new ErrorRecord(exception, ErrorId_MinValueGreaterThanMaxValue, ErrorCategory.InvalidArgument, MinValue)
            {
                ErrorDetails = new ErrorDetails($"{nameof(MinValue)} cannot be greater than {nameof(MaxValue)}.")
            });
            return;
        }
        foreach (int value in result)
            WriteObject(value);
    }
}