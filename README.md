# LteCodeGen - Code / Data generation utilities

The purpose of this project is to provide ways to generate test data and source code for development.

## Projects

- [TestDataGeneration](./src/TestDataGeneration/README.md) PowerShell module providing several cmdlets supporting data and code generation.
- [](./src/TestDataGeneration.UnitTests/README.md) NUnit tests for the `TestDataGeneration` project.

## Testing

### Pester Issues

You may see errors such as `The BeforeAll command may only be used inside a Describe block.` or `RuntimeException: '-Be' is not a valid Should operator.`.
Additionally, you may see a VS code extension error stating `Test Discovery failed: A terminating error was received from PowerShell: Pester 5.2.0 or greater is required`.
This may occur if version 3 or older is installed. To check the version of Pester, execute the following command to make sure you're using at least version 4:

```powershell
Get-Module -Name 'Pester'
```

You can run the following command to install the latest version:

```Powershell
Install-Module -Name Pester -Force -SkipPublisherCheck
```

## Solution Development Dependencies

### APIs

| Installer                                                                     | Dev Container Feature                                                                                                   |
|-------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------------|
| [DotNet Core 7.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) | [devcontainers/features/dotnet](https://github.com/devcontainers/features/tree/main/src/dotnet)                         |
| [PowerShell Core](https://github.com/powershell/powershell)                   | [devcontainers/features/powershell](https://github.com/devcontainers/features/tree/main/src/powershell)                 |

### Required / Strongly Suggested VS Code Extensions

- [.NET Core Add Reference](https://marketplace.visualstudio.com/items?itemName=adrianwilczynski.add-reference)
- [.NET Core Test Explorer](https://marketplace.visualstudio.com/items?itemName=formulahendry.dotnet-test-explorer)
- [Better Comments](https://marketplace.visualstudio.com/items?itemName=aaron-bond.better-comments)
- [C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
- [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)
- [C# XML Documentation Comments](https://marketplace.visualstudio.com/items?itemName=k--kato.docomment)
- [MSBuild project tools](https://marketplace.visualstudio.com/items?itemName=tintoy.msbuild-project-tools)
- [NuGet Gallery](https://marketplace.visualstudio.com/items?itemName=patcx.vscode-nuget-gallery)
- [NuGet Package Manager](https://marketplace.visualstudio.com/items?itemName=jmrog.vscode-nuget-package-manager)
- [Pester Tests](https://marketplace.visualstudio.com/items?itemName=pspester.pester-test)
- [PowerShell](https://marketplace.visualstudio.com/items?itemName=ms-vscode.powershell)
- [Test Adapter Converter](https://marketplace.visualstudio.com/items?itemName=ms-vscode.test-adapter-converter)
- [Test Explorer UI](https://marketplace.visualstudio.com/items?itemName=hbenl.vscode-test-explorer)
- [TODO Highlight](https://marketplace.visualstudio.com/items?itemName=wayou.vscode-todo-highlight)
- [Trx viewer](https://marketplace.visualstudio.com/items?itemName=scabana.trxviewer)
- [VS Code .*proj](https://marketplace.visualstudio.com/items?itemName=jRichardeau.vscode-vsproj)

### Suggested VS Code Extensions

- [.NET Core EditorConfig Generator](https://marketplace.visualstudio.com/items?itemName=doggy8088.netcore-editorconfiggenerator)
- [.NET Core Tools](https://marketplace.visualstudio.com/items?itemName=formulahendry.dotnet)
- [ASP.NET Core Switcher](https://marketplace.visualstudio.com/items?itemName=adrianwilczynski.asp-net-core-switcher)
- [Auto Close Tag](https://marketplace.visualstudio.com/items?itemName=formulahendry.auto-close-tag)
- [Bookmarks](https://marketplace.visualstudio.com/items?itemName=alefragnani.Bookmarks)
- [C# Extensions](https://marketplace.visualstudio.com/items?itemName=kreativ-software.csharpextensions)
- [C# Namespace Autocompletion](https://marketplace.visualstudio.com/items?itemName=adrianwilczynski.namespace)
- [C# Snippets](https://marketplace.visualstudio.com/items?itemName=jorgeserrano.vscode-csharp-snippets)
- [Dev Containers](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.remote-containers)
- [devmate](https://marketplace.visualstudio.com/items?itemName=AutomatedSoftwareTestingGmbH.devmate)
- [Essential ASP.NET Core Snippets](https://marketplace.visualstudio.com/items?itemName=doggy8088.netcore-snippets)
- [gitignore](https://marketplace.visualstudio.com/items?itemName=codezombiech.gitignore)
- [IntelliCode API Usage Examples](https://marketplace.visualstudio.com/items?itemName=VisualStudioExptTeam.intellicode-api-usage-examples)
- [IntelliCode](https://marketplace.visualstudio.com/items?itemName=VisualStudioExptTeam.vscodeintellicode)
- [Markdown All in One](https://marketplace.visualstudio.com/items?itemName=yzhang.markdown-all-in-one)
- [Markdown Preview Enhanced](https://marketplace.visualstudio.com/items?itemName=shd101wyy.markdown-preview-enhanced)
- [Markdown](https://marketplace.visualstudio.com/items?itemName=starkwang.markdown)
- [markdownlint](https://marketplace.visualstudio.com/items?itemName=DavidAnson.vscode-markdownlint)
- [Open in GitHub, Bitbucket, Gitlab, VisualStudio.com !](https://marketplace.visualstudio.com/items?itemName=ziyasal.vscode-open-in-github)
- [Paste JSON as Code (Refresh)](https://marketplace.visualstudio.com/items?itemName=doggy8088.quicktype-refresh)
- [Paste JSON as Code](https://marketplace.visualstudio.com/items?itemName=quicktype.quicktype)
- [Path Intellisense](https://marketplace.visualstudio.com/items?itemName=christian-kohler.path-intellisense)
- [Peek Hidden Files](https://marketplace.visualstudio.com/items?itemName=adrianwilczynski.toggle-hidden)
- [Rainbow CSV](https://marketplace.visualstudio.com/items?itemName=mechatroner.rainbow-csv)
- [Run Terminal Command](https://marketplace.visualstudio.com/items?itemName=adrianwilczynski.terminal-commands)
- [vscode-icons](https://marketplace.visualstudio.com/items?itemName=vscode-icons-team.vscode-icons)
- [Xml Complete](https://marketplace.visualstudio.com/items?itemName=rogalmic.vscode-xml-complete)
- [XML Toolkit](https://marketplace.visualstudio.com/items?itemName=SAPOSS.xml-toolkit)
- [XML Tools](https://marketplace.visualstudio.com/items?itemName=DotJoshJohnson.xml)
- [XML](https://marketplace.visualstudio.com/items?itemName=redhat.vscode-xml)

## References

General development reference links

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
- PowerShell
  - [Examples](https://github.com/PowerShell/vscode-powershell/tree/main/examples)
  - [Pester](https://github.com/pester/Pester)
  - [Working with local PSRepositories - PowerShell | Microsoft Learn](https://learn.microsoft.com/en-us/powershell/gallery/how-to/working-with-local-psrepositories?view=powershellget-3.x)
  - [Install-Script (PowerShellGet) - PowerShell | Microsoft Learn](https://learn.microsoft.com/en-us/powershell/module/powershellget/install-script?view=powershellget-3.x)
- [NUnit.org](https://nunit.org/)
  - [NUnit Documentation Site](https://docs.nunit.org/)
  - [Unit testing C# with NUnit and .NET Core](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit)
  - [Most Complete NUnit Unit Testing Framework Cheat Sheet](https://www.automatetheplanet.com/nunit-cheat-sheet/)
  - [CodeProject: Unit Testing Using NUnit](https://www.codeproject.com/articles/178635/unit-testing-using-nunit)
- [c# Documentation Comments](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments)
