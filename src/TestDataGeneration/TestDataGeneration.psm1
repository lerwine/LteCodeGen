function Select-Random {
    [CmdletBinding(DefaultParameterSetName = "NoRepeat")]
    Param (
        [Parameter(Mandatory = $true, ValueFromPipeline = $true)]
        [AllowNull()]
        [AllowEmptyString()]
        # Items to randomly select from.
        [object[]]$InputObject,

        [Parameter(Mandatory = $true, ParameterSetName = "FixedRepeat")]
        [ValidateRange([System.Management.Automation.ValidateRangeKind]::Positive)]
        # Number of times to repeat random selection.
        [int]$Repeat,

        [Parameter(ParameterSetName = "RandomRepeat")]
        [ValidateRange([System.Management.Automation.ValidateRangeKind]::NonNegative)]
        # Mininum number of times to repeat random selection (defaults to 1).
        [int]$MinRepeat = 1,

        [Parameter(Mandatory = $true, ParameterSetName = "RandomRepeat")]
        [ValidateRange([System.Management.Automation.ValidateRangeKind]::Positive)]
        # The maximum number of times to repeat random selection.
        [int]$MaxRepeat = 1,

        [Parameter(ParameterSetName = "RandomRepeat")]
        [Parameter(ParameterSetName = "FixedRepeat")]
        # Ensures that the same input item is not emitted more than once.
        [switch]$NoDuplicates
    )
    
    Begin {
        $AllValues = [System.Collections.ObjectModel.Collection[object]]::new();
        switch ($PSCmdlet.ParameterSetName) {
            'NoRepeat' {
                $Repeat = 1;
                break;
            }
            'RandomRepeat' {
                if ($MaxRepeat -lt $MinRepeat) {
                    Write-Error -Message 'The MinRepeat parameter cannot be greater than the MaxRepeat parameter' -Category InvalidArgument -ErrorId 'MinRepeatGreaterThanMaxRepeat' -TargetObject $MinRepeat -CategoryTargetName 'MinRepeat';
                    return;
                }
                $Repeat = Get-RandomInteger -MinValue $MinRepeat -Maxvalue -$MaxRepeat;
                break;
            }
        }
    }
    
    Process {
        foreach ($obj in $InputObject) { $AllValues.Add($obj) }
    }
    
    End {
        if ($AllValues.Count -lt 2) {
            $obj = $AllValues[0];
            for ($i = 0; $i -lt $Repeat; $i++) { Write-Output -InputObject $obj -NoEnumerate }
        } else {
            Write-Output -InputObject $AllValues[(Get-RandomInteger -MinValue 0 -Maxvalue $AllValues.Count)] -NoEnumerate;
        }
    }
    <#
        .SYNOPSIS

        Randomly select from input values.

        .DESCRIPTION

        Randomly selects one or more items from the provided input values.

        .INPUTS

        System.Object[]. Objects to randomly select from.

        .OUTPUTS

        System.Object[]. Returns the object or objects that have been randomly selected.

        .EXAMPLE

        PS> ('Cat', 'Dog', 'Parakeet', 'Hamster', 'Fish', 'Bearded Dragon', 'Rabbit', 'Ferret') | Select-Random;

        Dog

        .EXAMPLE

        PS> ('Cat', 'Dog') | Select-Random -Repeat 6;

        Dog
        Cat
        Cat
        Dog
        Cat
        Dog

        .EXAMPLE

        PS> ('Cat', 'Dog', 'Parakeet', 'Hamster', 'Fish', 'Bearded Dragon', 'Rabbit', 'Ferret') | Select-Random -MinRepeat 1 -MaxRepeat 10 -NoDuplicates;

        Bearded Dragon
        Rabbit
        Dog
        Fish

        .EXAMPLE

        PS> ('Cat', 'Dog') | Select-Random -Repeat 6 -NoDuplicates;

        Dog
        Cat
    #>
}

Function Get-RandomIpV4Address {
    [CmdletBinding()]
    Param(
        [ValidateRange(1, 32768)]
        [int]$Count = 1,

        [System.IO.TextWriter]$Writer
    )
    if ($PSBoundParameters.ContainsKey('Writer')) {
        $Writer.Write((Get-RandomInteger -MinValue 0 -Maxvalue 255));
        for ($i = 0; $i -lt 3; $i++) {
            $Writer.Write('.');
            $Writer.Write((Get-RandomInteger -MinValue 0 -Maxvalue 255));
        }
        for ($i = 1; $i -lt $Count; $i++) {
            $Writer.Write(";");
            $Writer.Write((Get-RandomInteger -MinValue 0 -Maxvalue 255));
            for ($i = 0; $i -lt 3; $i++) {
                $Writer.Write('.');
                $Writer.Write((Get-RandomInteger -MinValue 0 -Maxvalue 255));
            }
        }
    } else {
        if ($Count -gt 1) {
            $Value = "$(Get-RandomInteger -MinValue 0 -Maxvalue 255).$(Get-RandomInteger -MinValue 0 -Maxvalue 255).$(Get-RandomInteger -MinValue 0 -Maxvalue 255).$(Get-RandomInteger -MinValue 0 -Maxvalue 255)";
            $Value | Write-Output;
            $Emitted = @($Value);
            for ($i = 1; $i -lt $Count; $i++) {
                $Value = "$(Get-RandomInteger -MinValue 0 -Maxvalue 255).$(Get-RandomInteger -MinValue 0 -Maxvalue 255).$(Get-RandomInteger -MinValue 0 -Maxvalue 255).$(Get-RandomInteger -MinValue 0 -Maxvalue 255)";
                while ($Emitted -contains $Value) {
                    $Value = "$(Get-RandomInteger -MinValue 0 -Maxvalue 255).$(Get-RandomInteger -MinValue 0 -Maxvalue 255).$(Get-RandomInteger -MinValue 0 -Maxvalue 255).$(Get-RandomInteger -MinValue 0 -Maxvalue 255)";
                }
                $Value | Write-Output;
                $Emitted += $Value;
            }
        } else {
            "$(Get-RandomInteger -MinValue 0 -Maxvalue 255).$(Get-RandomInteger -MinValue 0 -Maxvalue 255).$(Get-RandomInteger -MinValue 0 -Maxvalue 255).$(Get-RandomInteger -MinValue 0 -Maxvalue 255)" | Write-Output;
        }
    }
}
