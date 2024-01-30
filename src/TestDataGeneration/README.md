# TestDataGeneration PowerShell Module

PowerShell module providing several cmdlets supporting data and code generation.

- [Home](../../README.md)
- [Testing](#testing)
  - [Pester Unit Tests](#pester-unit-tests)
  - [Possible Pester Issues](#possible-pester-issues)
- [TODO](#todo)
- [References](#references)

## Testing

There are 2 different stages of testing. The [TestDataGeneration.UnitTests](../TestDataGeneration.UnitTests/README.md) test the underlying components of the nested binary module.
The second is the Pester unit tests, included in this project, which tests the functionality within PowerShell.

### Pester Unit Tests

Files with the extension `.tests.ps1` contain the code for unit tests. Simply invoking the `Invoke-Pester` command will run these tests.

> Note: Tests will only work if they are invoked from the compilation output folder or from the deployed location of the module.

The [/.vscode/launch.json](../../.vscode/launch.json) provides a launch configuration to allow the Pester tests to be executed from withing VS Code.

### Possible Pester Issues

You may see errors such as `The BeforeAll command may only be used inside a Describe block.` or `RuntimeException: '-Be' is not a valid Should operator.`.
Additionally, you may see a VS code extension error stating `Test Discovery failed: A terminating error was received from PowerShell: Pester 5.2.0 or greater is required`.
This may occur if version 3 or older is installed. To check the version of Pester, execute the following command to make sure you're using at least version 4:

```powershell
Get-Module -Name 'Pester' -ListAvailable
```

You can run the following command to install the latest version:

```Powershell
Install-Module -Name Pester -Force -SkipPublisherCheck
```

## TODO

- [ ] Import [FsInfoCat.Numerics](https://github.com/lerwine/FsInfoCat/tree/main/src/FsInfoCat/Numerics)

### Calculating 'E'

```csharp
public const double EPSILON = 1.0e-15;

ulong fact = 1;
double e = 2.0;
double e0;
uint n = 2;

do
{
    e0 = e;
    fact *= n++;
    e += 1.0 / fact;
}
while (Math.Abs(e - e0) >= EPSILON);
```

## References

General development reference links

- [Math Class in C#](https://code-maze.com/csharp-math/)
- [Character Name Index - unicode.org](https://www.unicode.org/charts/charindex.html)
- [UTF-8, UTF-16, UTF-32 & BOM - unicode.org](https://www.unicode.org/faq/utf_bom.html)
- [U0000.pdf: C0 Controls and Basic Latin - unicode.org](Resources/U0000.pdf)
  - [U0000.pdf on unicode.org](https://www.unicode.org/charts/PDF/U0000.pdf)
- [RFC 3629 - UTF-8, a transformation format of ISO 10646](Resources/rfc3629.txt)
  - [RFC 3629 on datatracker.ietf.org](https://datatracker.ietf.org/doc/html/rfc3629)
- [RFC 2781 - UTF-16, an encoding of ISO 10646](Resources/rfc2781.txt)
  - [RFC 2781 on datatracker.ietf.org](https://datatracker.ietf.org/doc/html/rfc2781)
- [RFC 2152 - UTF-7](Resources/rfc2152.txt)
  - [RFC 2152 - UTF-7](https://datatracker.ietf.org/doc/html/rfc2152)
- [UTF-16 - Wikipedia](https://en.wikipedia.org/wiki/UTF-16)
- [UTF-8 - Wikipedia](https://en.wikipedia.org/wiki/UTF-8)
- [PowerShell](https://github.com/PowerShell/PowerShell)
  - [Examples](https://github.com/PowerShell/vscode-powershell/tree/main/examples)
  - [Pester](https://github.com/pester/Pester)
  - [PSScriptAnalyzer](https://github.com/PowerShell/PSScriptAnalyzer)
  - [Working with local PSRepositories - PowerShell | Microsoft Learn](https://learn.microsoft.com/en-us/powershell/gallery/how-to/working-with-local-psrepositories?view=powershellget-3.x)
  - [Install-Script (PowerShellGet) - PowerShell | Microsoft Learn](https://learn.microsoft.com/en-us/powershell/module/powershellget/install-script?view=powershellget-3.x)
- [c# Documentation Comments](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments)
