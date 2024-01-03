Function Test-RangePatternString {
    Param(
        [Parameter(Mandatory = $true, ValueFromPipeline = $true)]
        [AllowNull()]
        [AllowEmptyString()]
        [string]$Pattern,

        [switch]$WriteValidationError
    )

    Begin { $Success = $true }

    Process {
        if ($WriteValidationError.IsPresent) {
            Write-Debug -Message "Testing $($Pattern | ConvertTo-Json)";
            if ([string]::IsNullOrWhiteSpace($Pattern)) {
                $Success = $false;
                Write-Error -Exception ([System.Management.Automation.ValidationMetadataException]::new("Pattern cannot be null or empty")) -Category InvalidArgument -ErrorId 'EmptyPattern';
            } else {
                ($StartString, $EndString) = $Pattern.Split(',', 2);
                ($StartRangeMinStr, $StartRangeMaxStr) = $StartString.Split('..', 2);
                $StartRangeMinVal = 0;
                if ([int]::TryParse($StartRangeMinStr, [ref]$StartRangeMinVal)) {
                    if ($null -eq $StartRangeMaxStr) {
                        if ($null -ne $EndString) {
                            ($EndRangeMinStr, $EndRangeMaxStr) = $EndString.Split('..', 2);
                            $EndRangeMinVal = 0;
                            if ([int]::TryParse($EndRangeMinStr, [ref]$EndRangeMinVal)) {
                                if ($null -eq $EndRangeMaxStr) {
                                    if ($StartRangeMinVal-gt $EndRangeMinVal) {
                                        $Success = $false;
                                        Write-Error -Exception ([System.Management.Automation.ValidationMetadataException]::new("Start range value cannot be larger than the minimum end range value in $($Pattern | ConvertTo-Json)")) -Category InvalidArgument -ErrorId 'StartExceedsEnd';
                                    }
                                    # N,0
                                } else {
                                    $EndRangeMaxVal = 0;
                                    if ([int]::TryParse($EndRangeMaxStr, [ref]$EndRangeMaxVal)) {
                                        if ($StartRangeMinVal -gt $EndRangeMinVal) {
                                            $Success = $false;
                                            Write-Error -Exception ([System.Management.Automation.ValidationMetadataException]::new("Start range value ($StartRangeMinVal) cannot be larger than the minimum end range value ($EndRangeMinVal) in $($Pattern | ConvertTo-Json)")) -Category InvalidArgument -ErrorId 'StartExceedsEndMin';
                                        }
                                        # N,0..0
                                    } else {
                                        $Success = $false;
                                        Write-Error -Exception ([System.Management.Automation.ValidationMetadataException]::new("$($EndRangeMaxStr | ConvertTo-Json) could not be parsed as an integer for the maximum end range value in $($Pattern | ConvertTo-Json)")) -Category InvalidArgument -ErrorId 'InvalidEndMax';
                                    }
                                }
                            } else {
                                $Success = $false;
                                if ($null -eq $EndRangeMaxStr) {
                                    Write-Error -Exception ([System.Management.Automation.ValidationMetadataException]::new("$($EndString | ConvertTo-Json) could not be parsed as an integer or random range pair for the end range value in $($Pattern | ConvertTo-Json)")) -Category InvalidArgument -ErrorId 'InvalidEnd';
                                } else {
                                    Write-Error -Exception ([System.Management.Automation.ValidationMetadataException]::new("$($EndRangeMinStr | ConvertTo-Json) could not be parsed as an integer for the minimum end range value in $($Pattern | ConvertTo-Json)")) -Category InvalidArgument -ErrorId 'InvalidMinEnd';

                                }
                            }
                        }
                    } else {
                        $StartRangeMaxVal = 0;
                        if ([int]::TryParse($StartRangeMaxStr, [ref]$StartRangeMaxVal)) {
                            if ($StartRangeMinVal -gt $StartRangeMaxVal) {
                                $Success = $false;
                                if ($null -eq $EndString) {
                                    Write-Error -Exception ([System.Management.Automation.ValidationMetadataException]::new("Minimum range value ($StartRangeMinVal) cannot be larger than the maximum range value ($StartRangeMaxVal) in $($Pattern | ConvertTo-Json)")) -Category InvalidArgument -ErrorId 'MinExceedsMax';
                                } else {
                                    Write-Error -Exception ([System.Management.Automation.ValidationMetadataException]::new("Minimum start range value cannot be larger than the maximum start range value for $($StartString | ConvertTo-Json) in $($Pattern | ConvertTo-Json)")) -Category InvalidArgument -ErrorId 'StartMinExceedsMax';
                                }
                            } else {
                                if ($null -ne $EndString) {
                                    ($EndRangeMinStr, $EndRangeMaxStr) = $EndString.Split('..', 2);
                                    $EndRangeMinVal = 0;
                                    if ([int]::TryParse($EndRangeMinStr, [ref]$EndRangeMinVal)) {
                                        if ($null -eq $EndRangeMaxStr) {
                                            if ($EndRangeMinStr -lt $StartRangeMaxVal) {
                                                $Success = $false;
                                                Write-Error -Exception ([System.Management.Automation.ValidationMetadataException]::new("Maximum start range value ($StartRangeMaxVal) cannot be larger than the end range value ($EndRangeMinStr) in $($Pattern | ConvertTo-Json)")) -Category InvalidArgument -ErrorId 'StartMaxExceedsEnd';
                                            }
                                        } else {
                                            $EndRangeMaxVal = 0;
                                            if ([int]::TryParse($EndRangeMaxStr, [ref]$EndRangeMaxVal)) {
                                                if ($StartRangeMinVal -gt $EndRangeMaxVal) {
                                                    $Success = $false;
                                                    Write-Error -Exception ([System.Management.Automation.ValidationMetadataException]::new("Minimum start ($StartRangeMinVal) range value cannot be larger than the maximum end range value ($EndRangeMaxVal) in $($Pattern | ConvertTo-Json)")) -Category InvalidArgument -ErrorId 'StartMinExceedsEndMax';
                                                }
                                            } else {
                                                $Success = $false;
                                                Write-Error -Exception ([System.Management.Automation.ValidationMetadataException]::new("$($EndRangeMaxStr | ConvertTo-Json) could not be parsed as an integer value for $($EndString | ConvertTo-Json) in $($Pattern | ConvertTo-Json)")) -Category InvalidArgument -ErrorId 'InvalidRangeEndMax';
                                            }
                                        }
                                    } else {
                                        $Success = $false;
                                        if ($null -eq $EndRangeMaxStr) {
                                            Write-Error -Exception ([System.Management.Automation.ValidationMetadataException]::new("$($EndRange | ConvertTo-Json) could not be parsed as an integer value or random range pair in $($Pattern | ConvertTo-Json)")) -Category InvalidArgument -ErrorId 'InvalidRangeEndMin';
                                        } else {
                                            Write-Error -Exception ([System.Management.Automation.ValidationMetadataException]::new("$($EndRangeMinStr | ConvertTo-Json) could not be parsed as an integer value for $($EndString | ConvertTo-Json) in $($Pattern | ConvertTo-Json)")) -Category InvalidArgument -ErrorId 'InvalidRangeEndMin';
                                        }
                                    }
                                }
                            }
                        } else {
                            $Success = $false;
                            Write-Error -Exception ([System.Management.Automation.ValidationMetadataException]::new("$($EndRangeMinStr | ConvertTo-Json) could not be parsed as an integer value for $($StartString | ConvertTo-Json) in $($Pattern | ConvertTo-Json)")) -Category InvalidArgument -ErrorId 'InvalidRangeStartMax';
                        }
                    }

                } else {
                    $Success = $false;
                    if ($null -eq $StartRangeMaxStr) {
                        if ($null -eq $EndString) {
                            Write-Error -Exception ([System.Management.Automation.ValidationMetadataException]::new("$($Pattern | ConvertTo-Json) is not a valid range pattern string.")) -Category InvalidArgument -ErrorId 'InvalidRangeString';
                        } else {
                            Write-Error -Exception ([System.Management.Automation.ValidationMetadataException]::new("$($StartRangeMinStr | ConvertTo-Json) could not be parsed as an integer value or random range pair in $($Pattern | ConvertTo-Json)")) -Category InvalidArgument -ErrorId 'InvalidRangeStart';
                        }
                    } else {
                        Write-Error -Exception ([System.Management.Automation.ValidationMetadataException]::new("$($StartRangeMinStr | ConvertTo-Json) could not be parsed as an integer value in $($Pattern | ConvertTo-Json)")) -Category InvalidArgument -ErrorId 'InvalidRangeStartMin';
                    }
                }
            }
        } else {
            if ($Success) {
                if ([string]::IsNullOrWhiteSpace($Pattern)) {
                    $Success = $false;
                } else {
                    ($s, $e) = $Pattern.Split(',', 2);
                    ($n, $x) = $s.Split('..', 2);
                    $sn = 0;
                    if ([int]::TryParse($n, [ref]$sn)) {
                        if ($null -ne $x) {
                            $sx = 0;
                            if ([int]::TryParse($n, [ref]$sx) -and $sx -ge $sn) {
                                if ($null -ne $e) {
                                    ($n, $x) = $e.Split('..', 2);
                                    $en = 0;
                                    if ([int]::TryParse($n, [ref]$en)) {
                                        if ($null -ne $x) {
                                            $ex = 0;
                                            $Success = [int]::TryParse($n, [ref]$ex) -and $ex -ge $en -and $sn -le $ex;
                                        } else {
                                            $Success = $en -ge $ex;
                                        }
                                    } else {
                                        $Success = $false;
                                    }
                                }
                            } else {
                                $Success = $false;
                            }
                        } else {
                            if ($null -ne $e) {
                                ($n, $x) = $e.Split('..', 2);
                                $en = 0;
                                if ([int]::TryParse($n, [ref]$en)) {
                                    if ($null -ne $x) {
                                        $ex = 0;
                                        $Success = [int]::TryParse($n, [ref]$ex) -and $ex -ge $en -and $sn -le $en;
                                    } else {
                                        $Success = $sn -le $en;
                                    }
                                } else {
                                    $Success = $false;
                                }
                            }
                        }
                    } else {
                        $Success = $false;
                    }
                }
            }
        }
    }

    End { $Success | Write-Output }
}


Function Convert-RangePatternToTuple {
    Param(
        [Parameter(Mandatory = $true, ValueFromPipeline = $true)]
        [ValidateScript({ $_ | Test-RangePatternString -WriteValidationError })]
        # A range pattern string.
        [string]$Pattern
    )

    Process {
        ($StartString, $EndString) = $Pattern.Split(',', 2);
        ($MinString, $MaxString) = $StartString.Split('..', 2);
        $Value1 = [int]::Parse($MinString);
        if ($null -eq $EndString) {
            if ($null -ne $MaxString) { $Value1 = Get-RandomInteger -MinValue $Value1 -MaxValue ([int]::Parse($MaxString)) }
            [System.Tuple[int,int]]($Value1, $Value1) | Write-Output;
        } else {
            ($MinString, $MaxString) = $EndString.Split('..', 2);
            $Value2 = [int]::Parse($MinString);
            if ($null -ne $MaxString) { $Value2 = Get-RandomInteger -MinValue $Value2 -MaxValue ([int]::Parse($MaxString)) }
            [System.Tuple[int,int]]($Value1, $Value2) | Write-Output;
        }
    }
    <#
        .SYNOPSIS

        Converts a range pattern string to a Tuple object.

        .DESCRIPTION

        Converts a formatted range pattern string to a [System.Tuple[int,int]] object.
        The first and second values are separated by a comma.
        Each value can be a positive or negative integer, or it can specify a random range with the minimum and maximum values separated by '..'.
        When specifying a random range, both range values are inclusive.


        .INPUTS

        System.String. Objects to randomly select from.

        .OUTPUTS

        System.Tuple[int,int]. Returns an object with a pair of integer values.

        .EXAMPLE

        PS> '7,12' | Convert-RangePatternToTuple;
        
        Item1 Item2 Length
        ----- ----- ------
            7    12      2

        .EXAMPLE

        PS> '-12..5,1..100' | Convert-RangePatternToTuple;
        
        Item1 Item2 Length
        ----- ----- ------
           -3    31      2

        .EXAMPLE

        PS> '1..10,40' | Convert-RangePatternToTuple;
        
        Item1 Item2 Length
        ----- ----- ------
            8    40      2
    #>
}

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
