
Function Convert-RangePatternToTuple {
    Param(
        [Parameter(Mandatory = $true, ValueFromPipeline = $true)]
        [string]$Pattern
    )
    Begin {
        if ($null -eq $Script:__Convert_RangePatternToTuple) {
            New-Variable -Name '__Convert_RangePatternToTuple' -Scope 'Script' -Option ReadOnly -Value ([System.Text.RegularExpressions.Regex]::new(
                '^(?<s>\d+)(-(?<e>\d+))?$',
                [System.Text.RegularExpressions.RegexOptions]::Compiled
            )) -Force;
        }
    }

    Process {
        $m = $Script:__Convert_RangePatternToTuple.Match($Pattern);
        if ($m.Success) {
            $Start = 0;
            if ([int]::TryParse($m.Groups['s'].Value, [ref]$Start)) {
                $g = $m.Groups['e'].Value;
                if ($g.Success) {
                    $End = 0;
                    if ([int]::TryParse($g.Value, [ref]$End)) {
                        if ($End -lt $Start) {
                            Write-Error -Message "Range start cannot be greater than the range end" -Category InvalidArgument;
                            Write-Output -InputObject ([ValueTuple]::Create($End, $End)) -NoEnumerate;
                        } else {
                            Write-Output -InputObject ([ValueTuple]::Create($Start, $End)) -NoEnumerate;
                        }
                    } else {
                        Write-Error -Message "Could not parse $($g.Value) as an integer." -Category InvalidArgument;
                        Write-Output -InputObject ([ValueTuple]::Create($Start, $Start)) -NoEnumerate;
                    }
                } else {
                    Write-Output -InputObject ([ValueTuple]::Create($Start, $Start)) -NoEnumerate;
                }
            } else {
                Write-Error -Message "Could not parse $($m.Groups['s'].Value) as an integer." -Category InvalidArgument;
                Write-Output -InputObject ([ValueTuple]::Create(0, 0)) -NoEnumerate;
            }
        }
    }
}

Function Convert-RangeValuesToTuple {
    [CmdletBinding()]
    Param(
        [Parameter(Mandatory = $true, ValueFromPipeline = $true)]
        [int[]]$Values
    )

    Begin { $AllValues = @() }

    Process { $AllValues += $Values }

    End {
        switch ($AllValues.Count) {
            0 {
                Write-Error -Message 'Cannot convert empty collection to Tuple[int,int]' -Category InvalidArgument -ErrorId 'NoValuesGiven';
                return [System.ValueTuple]::Create(0, 0);
                break;
            }
            1 {
                return [System.ValueTuple]::Create($AllValues[0], $AllValues[0]);
            }
            2 {
                if ($AllValues[1] -lt $AllValues[0]) {
                    Write-Error -Message 'First range value cannot be greater than the second' -Category InvalidArgument -ErrorId 'RangeStartAfterEnd' `
                        -CategoryReason "First range value of $($AllValues[0]) is greater than the second value of $($AllValues[1])." `
                        -RecommendedAction 'Pass a single value or pass 2 values with the second one not being less than the first.';
                    if ($AllValues[1] -lt 0 -and [Math]::Abs($AllValues[0]) -lt [Math]::Abs($AllValues[1])) { return [System.ValueTuple]::Create($AllValues[0], $AllValues[0]) }
                    [System.ValueTuple]::Create($AllValues[1], $AllValues[1]);
                }
                return [System.ValueTuple]::Create($AllValues[0], $AllValues[1]);
            }
            default {
                Write-Error -Message "Cannot convert collection of $_ values to Tuple[int,int]" -Category InvalidArgument -ErrorId 'TooManyRangeValues' `
                    -CategoryReason 'More than 2 values were provided.' `
                    -RecommendedAction 'Pass a single value or pass 2 values with the second one not being less than the first.';
                if ($AllValues[1] -lt $AllValues[0]) {
                    if ($AllValues[1] -lt 0 -and [Math]::Abs($AllValues[0]) -lt [Math]::Abs($AllValues[1])) { return [System.ValueTuple]::Create($AllValues[0], $AllValues[0]) }
                    [System.ValueTuple]::Create($AllValues[1], $AllValues[1]);
                }
                return [System.ValueTuple]::Create($AllValues[0], $AllValues[1]);
            }
        }
    }
}
