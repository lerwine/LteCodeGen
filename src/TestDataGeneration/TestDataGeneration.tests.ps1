
if ($null -eq (Get-Module -Name 'Pester')) { Import-Module -Name 'Pester' }

$PesterPreference = [PesterConfiguration]::Default;
$PesterPreference.Output.Verbosity = 'Detailed';

BeforeAll {
    if ($null -ne (Get-Module -Name 'TestDataGeneration')) { Remove-Module -Name 'TestDataGeneration' }
    Import-Module -Name ($PSScriptRoot | Join-Path -ChildPath 'TestDataGeneration.psd1') -ErrorAction Stop;
}

Describe 'ConvertTo-BinaryNotation' {
    Context 'Values by position' {
        It 'Given a single value of <value>, it should return <expected>' -ForEach @(
            @{ Value = 0; Expected = '0b00000000000000000000000000000000' },
            @{ Value = 2; Expected =  '0b00000000000000000000000000000010' },
            @{ Value = -2; Expected =  '0b11111111111111111111111111111110' },
            @{ Value = [int]::MaxValue; Expected = '0b01111111111111111111111111111111' },
            @{ Value = -1; Expected = '0b11111111111111111111111111111111' },
            @{ Value = [int]::MinValue; Expected = '0b10000000000000000000000000000000' }
        ) {
            $Tuple = ConvertTo-BinaryNotation $Value;
            $Tuple.Item1 | Should -Be $Item1;
            $Tuple.Item2 | Should -Be $Item2;
        }
        It 'Given a values of <value1> and <value2>, it should return (<expected1>, <expected2>)' -ForEach @(
            @{ Value1 = 0; Value2 = 6; Expected1 = '0b00000000000000000000000000000000'; Expected2 = '0b00000000000000000000000000000110' },
            @{ Value1 = 4; Value2 = [int]::MaxValue; Expected1 = '0b00000000000000000000000000000100'; Expected2 = '0b01111111111111111111111111111111' },
            @{ Value1 = -1; Value2 = 7; Expected1 = '0b11111111111111111111111111111111'; Expected2 = '0b00000000000000000000000000000111' }
        ) {
            $Tuple = ConvertTo-BinaryNotation $Value1, $Value2;
            $Tuple.Item1 | Should -Be $Item1;
            $Tuple.Item2 | Should -Be $Item2;
        }
        # It "Given a values of <value1> and <value2>, it should throw error 'First range value cannot be greater than the second'" -ForEach @(
        #     @{ Value1 = 6; Value2 = 0 },
        #     @{ Value1 = [int]::MaxValue; Value2 = 3 },
        #     @{ Value1 = 7; Value2 = -1 }
        # ) {
        #     Convert-RangeValuesToTuple -Values $Value1, $Value2 -ErrorVariable 'err' -ErrorAction SilentlyContinue;
        #     $err.Count | Should -Not -Be 0;
        #     $err[0].Exception.Message | Should -Be 'First range value cannot be greater than the second';
        #     $err[0].CategoryInfo.Category | Should -Be ([System.Management.Automation.ErrorCategory]::InvalidArgument);
        #     $err[0].CategoryInfo.Reason | Should -Be "First range value of $Value1 is greater than the second value of $Value2.";
        #     $error[0].ErrorDetails.RecommendedAction | Should -Be "Pass a single value or pass 2 values with the second one not being less than the first.";
        #     $err[0].FullyQualifiedErrorId | Should -Be 'RangeStartAfterEnd,Convert-RangeValuesToTuple';
        # }
        # It "Given <values>, it should throw error '<message>'" -ForEach @(
        #     @{ Values = @(1, 2, 3); Message = "Cannot convert collection of 3 values to Tuple[int,int]" },
        #     @{ Values = @(0, 0, 0); Message = "Cannot convert collection of 3 values to Tuple[int,int]" },
        #     @{ Values = @([int]::MinValue, 65536, 32768, [int]::MaxValue); Message = "Cannot convert collection of 4 values to Tuple[int,int]" }
        # ) {
        #     Convert-RangeValuesToTuple -Values $Values -ErrorVariable 'err' -ErrorAction SilentlyContinue;
        #     $err.Count | Should -Not -Be 0;
        #     $err[0].Exception.Message | Should -Be $Message;
        #     $err[0].CategoryInfo.Category | Should -Be ([System.Management.Automation.ErrorCategory]::InvalidArgument);
        #     $err[0].CategoryInfo.Reason | Should -Be 'More than 2 values were provided.';
        #     $error[0].ErrorDetails.RecommendedAction | Should -Be "Pass a single value or pass 2 values with the second one not being less than the first.";
        #     $err[0].FullyQualifiedErrorId | Should -Be 'TooManyRangeValues,Convert-RangeValuesToTuple';
        # }
    }
}

Describe "ScriptAnalyzer" {
    It "TestDataGeneration.psm1" {
        # Test scripts
        $DiagnosticRecords = @(Invoke-ScriptAnalyzer -Path ($PSScriptRoot | Join-Path -ChildPath 'TestDataGeneration.psm1'));
        if ($DiagnosticRecords.Count -gt 0)  { $DiagnosticRecords | Out-String | Write-Warning -WarningAction Continue }
        $DiagnosticRecords.Count | Should -Be 0;
    }
    It "TestDataGeneration.psd1" {
        # Test scripts
        $DiagnosticRecords = @(Invoke-ScriptAnalyzer -Path ($PSScriptRoot | Join-Path -ChildPath 'TestDataGeneration.psd1'));
        if ($DiagnosticRecords.Count -gt 0)  { $DiagnosticRecords | Out-String | Write-Warning -WarningAction Continue }
        $DiagnosticRecords.Count | Should -Be 0;
    }
}

# Describe "ScriptFileInfo" {
#     It "TestDataGeneration.psm1" {
#         # Test scripts
#         $DiagnosticRecords = @(Test-ScriptFileInfo  -LiteralPath ($PSScriptRoot | Join-Path -ChildPath 'TestDataGeneration.psm1'));
#         $DiagnosticRecords.Count | Should -Be 0
#     }
# }