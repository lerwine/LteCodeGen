using System.Management.Automation;

namespace TestDataGeneration.Commands;

[Cmdlet(VerbsCommon.Get, "RandomCharacterSource")]
[OutputType(typeof(RandomCharacterSource))]
public class Get_RandomCharacterSource : PSCmdlet
{
    [Parameter(HelpMessage = "The character type(s) to include.")]
    public CharacterClass[]? Include { get; set; }

    [Parameter(HelpMessage = "The character(s) to explicitly include.")]
    public char[]? ExplicitInclude { get; set; }

    [Parameter(HelpMessage = "The character type(s) to exclude.")]
    public CharacterClass[]? Exclude { get; set; }

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