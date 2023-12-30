using System.Management.Automation;

namespace TestDataGeneration.Commands;

[Cmdlet(VerbsCommon.Get, "RandomCharacterSource")]
public class Get_RandomCharacterSource : PSCmdlet
{
    [Parameter(HelpMessage = "The character type(s) to include.")]
    public CharacterType[]? Include { get; set; }

    [Parameter(HelpMessage = "The character(s) to explicitly include.")]
    public char[]? ExplicitInclude { get; set; }

    [Parameter(HelpMessage = "The character type(s) to exclude.")]
    public CharacterType[]? Exclude { get; set; }

    [Parameter(HelpMessage = "The character(s) to explicitly exclude.")]
    public char[]? ExplicitExclude { get; set; }

    protected override void ProcessRecord()
    {
        if (Include is null || Include.Length == 0)
        {
            
        }
        base.ProcessRecord();
    }
}