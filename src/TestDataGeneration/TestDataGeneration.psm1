Function Select-Random {
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
        if ($NoDuplicates.IsPresent) {
            if ($AllValues.Count -lt 2) {
                Write-Output -InputObject $AllValues[0] -NoEnumerate
            } else {
                [System.Collections.ObjectModel.Collection[int]]$CanEmit = @([System.Linq.Enumerable]::Range(0, $AllValues.Count));
                for ($i = 0; $i -lt $Repeat; $i++) {
                    if ($CanEmit.Count -lt 2) {
                        Write-Output -InputObject $AllValues[$CanEmit[0]] -NoEnumerate;
                        break;
                    }
                    $n = $CanEmit[(Get-RandomInteger -MinValue 0 -Maxvalue $CanEmit.Count)];
                    $CanEmit.Remove($n) | Out-Null;
                    Write-Output -InputObject $AllValues[$n] -NoEnumerate;
                }
            }
        } else {
            if ($AllValues.Count -lt 2) {
                $obj = $AllValues[0];
                for ($i = 0; $i -lt $Repeat; $i++) { Write-Output -InputObject $obj -NoEnumerate }
            } else {
                for ($i = 0; $i -lt $Repeat; $i++) {
                    Write-Output -InputObject $AllValues[(Get-RandomInteger -MinValue 0 -Maxvalue $AllValues.Count)] -NoEnumerate;
                }
            }
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

Function Test-IPNetworkPrefixLength {
    [CmdletBinding()]
    Param(
        [Parameter(Mandatory = $true, Position = 0, ValueFromPipeline = $true, HelpMessage = 'Network prefix length to test')]
        [Alias('Prefix', 'MaskLength', 'NetMask', 'NetMaskLength', 'Bits')]
        [int[]]$PrefixLength,

        [Parameter(Mandatory = $true, Position = 1, HelpMessage = 'Target IP addresss')]
        [Alias('Address', 'IP')]
        [IPAddress]$IPAddress,

        [switch]$ThrowValidationMetadataException
    )

    Begin {
        $MaxValue = 32;
        if ($IPAddress.AddressFamily -eq [System.Net.Sockets.AddressFamily]::InterNetworkV6) { $MaxValue = 128 }
    }

    Process {
        $Passed = $true;
        foreach ($p in $PrefixLength) {
            if ($p -lt 0) {
                $Passed = $false;
                if ($ThrowValidationMetadataException.IsPresent) {
                    throw ([System.Management.Automation.ValidationMetadataException]::new("The $p argument is less than the minimum allowed range of 0."));
                }
            } else {
                if ($p -gt $MaxValue) {
                    $Passed = $false;
                    if ($ThrowValidationMetadataException.IsPresent) {
                        throw ([System.Management.Automation.ValidationMetadataException]::new("The $p argument is greater than the maximum allowed range of $MaxValue."));
                    }
                }
            }
        }
        if (-not $Passed) {
            $false | Write-Output
            break;
        }
    }

    End {
        $true | Write-Output
    }
}

Function Get-FirstIPAddress {
    Param(
        [Parameter(Mandatory = $true, Position = 0, ValueFromPipeline = $true, HelpMessage = 'IP in target CIDR block')]
        [Alias('Address', 'IP')]
        [IPAddress[]]$IPAddress
    )

    Begin {
        $FirstIPAddress = $null;
    }

    Process {
        if ($null -eq $FirstIPAddress -or [TestDataGeneration.Net.IPAddressComparer]::Compare($IPAddress[0], $FirstIPAddress) -lt 0) {
            $FirstIPAddress = $IPAddress[0];
        }
        foreach ($ip in ($IPAddress | Select-Object -Skip 1)) {
            if ([TestDataGeneration.Net.IPAddressComparer]::Compare($ip, $FirstIPAddress) -lt 0) {
                $FirstIPAddress = $ip;
            }
        }
    }
    
    End {
        $FirstIPAddress | Write-Output;
    }
}

Function Get-LastIPAddress {
    Param(
        [Parameter(Mandatory = $true, Position = 0, ValueFromPipeline = $true, HelpMessage = 'IP in target CIDR block')]
        [Alias('Address', 'IP')]
        [IPAddress[]]$IPAddress
    )

    Begin {
        $LastIPAddress = $null;
    }

    Process {
        if ($null -eq $LastIPAddress -or [TestDataGeneration.Net.IPAddressComparer]::Compare($IPAddress[0], $LastIPAddress) -gt 0) {
            $LastIPAddress = $IPAddress[0];
        }
        foreach ($ip in ($IPAddress | Select-Object -Skip 1)) {
            if ([TestDataGeneration.Net.IPAddressComparer]::Compare($ip, $LastIPAddress) -gt 0) {
                $LastIPAddress = $ip;
            }
        }
    }
    
    End {
        $LastIPAddress | Write-Output;
    }
}

Function Get-FirstIPNetworkAddress {
    Param(
        [Parameter(Mandatory = $true, Position = 0, HelpMessage = 'IP in target CIDR block')]
        [Alias('Address', 'IP')]
        [IPAddress]$IPAddress,

        [Parameter(Mandatory = $true, Position = 1, HelpMessage = 'Number of bits in prefix representing the CIDR block')]
        [ValidateScript({ $_ | Test-IPNetworkPrefixLength -IPAddress $IPAddress -ThrowValidationMetadataException })]
        [Alias('Prefix', 'MaskLength', 'NetMask', 'NetMaskLength', 'Bits')]
        [int]$PrefixLength
    )

    [TestDataGeneration.Net.IPNetwork]::GetFirstAddressInBlock($IPAddress, $PrefixLength) | Write-Output;
}

Function Get-LastIPNetworkAddress {
    Param(
        [Parameter(Mandatory = $true, Position = 0, HelpMessage = 'IP in target CIDR block')]
        [Alias('Address', 'IP')]
        [IPAddress]$IPAddress,

        [Parameter(Mandatory = $true, Position = 1, HelpMessage = 'Number of bits in prefix representing the CIDR block')]
        [ValidateScript({ $_ | Test-IPNetworkPrefixLength -IPAddress $IPAddress -ThrowValidationMetadataException })]
        [Alias('Prefix', 'MaskLength', 'NetMask', 'NetMaskLength', 'Bits')]
        [int]$PrefixLength
    )

    [TestDataGeneration.Net.IPNetwork]::GetLastAddressInBlock($IPAddress, $PrefixLength) | Write-Output;
}

Function Get-IPNetworkAddressExtents {
    Param(
        [Parameter(Mandatory = $true, Position = 0, HelpMessage = 'IP in target CIDR block')]
        [Alias('Address', 'IP')]
        [IPAddress]$IPAddress,

        [Parameter(Mandatory = $true, Position = 1, HelpMessage = 'Number of bits in prefix representing the CIDR block')]
        [ValidateScript({ $_ | Test-IPNetworkPrefixLength -IPAddress $IPAddress -ThrowValidationMetadataException })]
        [Alias('Prefix', 'MaskLength', 'NetMask', 'NetMaskLength', 'Bits')]
        [int]$PrefixLength
    )

    Process {
        [IPAddress]$Last = $null;
        $First = [TestDataGeneration.Net.IPNetwork]::GetIPAddressBlockExtents($IPAddress, $PrefixLength, [ref]$Last)
        [PSCustomObject]@{
            First = $First;
            Last = $Last;
            MaskLength = $PrefixLength;
            Target = $IPAddress;
        } | Write-Output;
    }
}

Function Test-IPNetworkContains {
    [CmdletBinding()]
    Param(
        [Parameter(Mandatory = $true, Position = 0, ValueFromPipeline = $true, HelpMessage = 'IP address to test')]
        [Alias('Address', 'IP')]
        [IPAddress[]]$IPAddress,

        [Parameter(Mandatory = $true, Position = 0, HelpMessage = 'IP in target CIDR block')]
        [Alias('CIDR', 'IPNetwork', 'Block')]
        [IPAddress]$Network,

        [Parameter(Mandatory = $true, Position = 1, HelpMessage = 'Number of bits in prefix representing the CIDR block')]
        [ValidateScript({ $_ | Test-IPNetworkPrefixLength -IPAddress $IPAddress -ThrowValidationMetadataException })]
        [Alias('Prefix', 'MaskLength', 'NetMask', 'NetMaskLength', 'Bits')]
        [int]$PrefixLength
    )

    Begin {
        $IPNetwork = [TestDataGeneration.Net.IPNetwork]::new($Network, $PrefixLength);
    }

    Process {
        $Passed = $true;
        foreach ($ip in $IPAddress) {
            if (-not $IPNetwork.Contains($ip)) {
                $Passed = $false;
                break;
            }
        }
        if (-not $Passed) {
            $False | Write-Output;
            break;
        }
    }

    End { $true | Write-Output }
}

Function Get-SortedIPNetworks {
    [CmdletBinding()]
    Param(
        [Parameter(Mandatory = $true, Position = 0, ValueFromPipeline = $true, HelpMessage = 'IP address to sort')]
        [Alias('Address', 'IP')]
        [IPAddress[]]$IPAddress,

        [switch]$Unique,

        [switch]$Descending
    )

    Begin { $AllAddresses = @() }

    Process { $AllAddresses += $IPAddress }

    End {
        if ($Unique.IsPresent) { $AllAddresses = @([TestDataGeneration.Net.IPAddressComparer]::Distinct($AllAddresses)) }
        [TestDataGeneration.Net.IPAddressComparer]::Sort($AllAddresses, $Descending.IsPresent) | Write-Output;
    }
}

Function Get-UniqueIPNetworks {
    [CmdletBinding()]
    Param(
        [Parameter(Mandatory = $true, Position = 0, ValueFromPipeline = $true, HelpMessage = 'IP address to filter')]
        [Alias('Address', 'IP')]
        [IPAddress[]]$IPAddress
    )

    Begin { $AllAddresses = @() }

    Process { $AllAddresses += $IPAddress }

    End {
        [TestDataGeneration.Net.IPAddressComparer]::Distinct($AllAddresses) | Write-Output;
    }
}
