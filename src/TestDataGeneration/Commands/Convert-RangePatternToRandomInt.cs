using System.Management.Automation;
using static TestDataGeneration.RandomStatic;
using static TestDataGeneration.CmdletStatic;

namespace TestDataGeneration.Commands;

[Cmdlet(VerbsData.Convert, "RangePatternToRandomInt", DefaultParameterSetName = ParameterSetName_FixedRepeat)]
public class Convert_RangePatternToRandomInt : PSCmdlet
{
    public const string ParameterSetName_FixedRepeat = "FixedRepeat";

    public const string ParameterSetName_RandomRepeat = "RandomRepeat";

    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    [ValidateRangePatternString()]
    public object[] Pattern { get; set; } = null!;

    [Parameter(ParameterSetName = ParameterSetName_FixedRepeat)]
    [ValidateRange(1, int.MaxValue)]
    public int Repeat { get; set; } = 1;

    [Parameter(ParameterSetName = ParameterSetName_RandomRepeat)]
    [ValidateRange(ValidateRangeKind.NonNegative)]
    public int MinRepeat { get; set; } = 1;

    [Parameter(Mandatory = true, ParameterSetName = ParameterSetName_RandomRepeat)]
    [ValidateRange(1, int.MaxValue)]
    public int MaxRepeat { get; set; }

    protected override void BeginProcessing()
    {
        if (ParameterSetName == ParameterSetName_RandomRepeat)
            try { Repeat = GetRandomInteger(MinRepeat, MaxRepeat); }
            catch (ArgumentException exception)
            {
                WriteError(new ErrorRecord(exception, ErrorId_MinRepeatGreaterThanMaxRepeat, ErrorCategory.InvalidArgument, MinRepeat)
                {
                    ErrorDetails = new ErrorDetails($"{nameof(MinRepeat)} cannot be greater than {nameof(MaxRepeat)}.")
                });
                return;
            }
    }

    protected override void ProcessRecord()
    {
        if (Repeat < 1) return;
        foreach (object element in Pattern)
        {
            if (element is null) continue;
            var obj = (element is PSObject psObject) ? psObject.BaseObject : element;
            if (obj is int i)
            {
                for (var r = 0; r < Repeat; r++)
                    WriteObject(i);
            }
            if (obj is int || obj is byte || obj is sbyte || obj is short || obj is ushort)
            {
                for (var r = 0; r < Repeat; r++)
                    WriteObject(Convert.ToInt32(obj));
            }
            else
            {
                string pattern = LanguagePrimitives.ConvertTo<string>(element);
                string[] pair = pattern.Split("..", 2);
                int start = int.Parse(pair[0].Trim());
                if (pair.Length == 0)
                    WriteObject(start);
                else
                {
                    int end = int.Parse(pair[1].Trim());
                    if (end == start)
                    {
                        for (var r = 0; r < Repeat; r++)
                            WriteObject(start);
                    }
                    else if (Repeat == 1)
                        WriteObject(GetRandomInteger(start, end));
                    else
                        foreach (var r in GetRandomIntegers(Repeat, start, end))
                            WriteObject(r);
                }
            }
        }

    }
}