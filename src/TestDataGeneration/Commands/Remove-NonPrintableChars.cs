using System.Collections;
using System.Collections.ObjectModel;
using System.Formats.Asn1;
using System.Management.Automation;
using System.Management.Automation.Provider;
using System.Text;
using static TestDataGeneration.CmdletStatic;

namespace TestDataGeneration.Commands;

// [Cmdlet(VerbsCommon.Remove, "NonPrintableChars", SupportsShouldProcess = true, DefaultParameterSetName = ParameterSetName_WcPath)]
[Cmdlet(VerbsCommon.Remove, "NonPrintableChars")]
public partial class Remove_NonPrintableChars : PSCmdlet
{
    [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "Text to remove unprintable characters from.")]
    [ValidateNotNull()]
    [AllowEmptyString()]
    public string[] Text { get; set; } = null!;

    private static string RemoveInValidCodePoints(string source)
    {
        if (string.IsNullOrEmpty(source)) return string.Empty;
        bool charOmitted = false;
        StringBuilder builder = new();
        for (int index = 0; index < source.Length; index++)
        {
            char c = source[index];
            switch (c)
            {
                case '\t':
                case '\r':
                case '\n':
                    builder.Append(c);
                    break;
                default:
                    if (char.IsAscii(c))
                    {
                        if (char.IsControl(c))
                            charOmitted = true;
                        else
                            builder.Append(c);
                    }
                    else if (char.IsHighSurrogate(c))
                    {
                        index++;
                        if (index >= source.Length) return builder.ToString();
                        char p = source[index];
                        if (char.IsSurrogatePair(c, p))
                        {
                            builder.Append(c);
                            builder.Append(p);
                        }
                        else
                        {
                            index--;
                            charOmitted = true;
                        }
                    }
                    else if (char.IsLetterOrDigit(c) || char.IsSymbol(c) || char.IsPunctuation(c))
                        builder.Append(c);
                    else
                        charOmitted = true;
                    break;
            }
        }
        return charOmitted ? builder.ToString() : source;
    }

    protected override void ProcessRecord()
    {
        if (Text is null) return;
        foreach (string source in Text)
            WriteObject(RemoveInValidCodePoints(source));
    }

    // public const string ParameterSetName_WcPath = "WcPath";
    // public const string ParameterSetName_LiteralPath = "LiteralPath";
    // public const string ParameterSetName_InputOutput = "InputOutput";
    // public const string ParameterSetName_Text = "TextParameterSetName_Text";
    // private const string HelpMessage_WriteBackToFile = "Write text with characters removed back to the source file instead of writing it to the output.";
    // private const string HelpMessage_SaveAs = "Literal path to save the text with characters removed.";
    // private const string HelpMessage_Force = "Force overwrite of existing file.";

    // [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSetName_WcPath,
    //     HelpMessage = "Path to one or more text files.")]
    // [ValidateNotNullOrEmpty()]
    // [SupportsWildcards()]
    // public string[] Path { get; set; } = null!;

    // [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSetName_LiteralPath,
    //     HelpMessage = "Literal path to one or more text files.")]
    // [Alias("PSPath")]
    // [ValidateNotNullOrEmpty()]
    // public string[] LiteralPath { get; set; } = null!;

    // [Parameter(Mandatory = true, ParameterSetName = ParameterSetName_InputOutput, HelpMessage = "Literal path to the input text file.")]
    // public string FilePath { get; set; } = null!;

    // [Parameter(ParameterSetName = ParameterSetName_InputOutput, HelpMessage = HelpMessage_SaveAs)]
    // [Parameter(ParameterSetName = ParameterSetName_Text, HelpMessage = HelpMessage_SaveAs)]
    // public string SaveAs { get; set; } = null!;

    // [Parameter(ParameterSetName = ParameterSetName_InputOutput, HelpMessage = HelpMessage_Force)]
    // [Parameter(ParameterSetName = ParameterSetName_Text, HelpMessage = HelpMessage_Force)]
    // public SwitchParameter Force { get; set; }

    // [Parameter(ParameterSetName = ParameterSetName_LiteralPath, HelpMessage = HelpMessage_WriteBackToFile)]
    // [Parameter(ParameterSetName = ParameterSetName_WcPath, HelpMessage = HelpMessage_WriteBackToFile)]
    // public SwitchParameter WriteBackToFile { get; set; }

    // [Parameter(Mandatory = true, ParameterSetName = ParameterSetName_Text,
    //     HelpMessage = "Text to remove unprintable characters from.")]
    // [ValidateNotNull()]
    // [AllowEmptyString()]
    // public string[] Text { get; set; } = null!;

    // private Collection<string> _allPaths = null!;

    // protected override void BeginProcessing()
    // {
    //     if (ParameterSetName != ParameterSetName_Text) _allPaths = new();
    // }

    // protected override void ProcessRecord()
    // {
    //     switch (ParameterSetName)
    //     {
    //         case ParameterSetName_Text:
    //             if (Text is not null)
    //                 foreach (string text in Text)
    //                     WriteObject(RemoveInValidCodePoints(text));
    //             break;
    //         case ParameterSetName_InputOutput:
    //             if (!SessionState.Path.IsValid(FilePath))
    //             {
    //                 WriteError(CreateArgumentErrorRecord($"Path string {FilePath} is not valid.", ErrorId_PathIsInvalid, FilePath, nameof(FilePath)));
    //                 break;
    //             }
    //             if (InvokeProvider.Item.Exists(FilePath))
    //             {
    //                 string providerPath = SessionState.Path.GetUnresolvedProviderPathFromPSPath(FilePath);
    //                 if (providerPath is not null)
    //                 {
    //                     _allPaths.Add(providerPath);
    //                     break;
    //                 }
    //             }
    //             WriteError(CreateItemNotFoundErrorRecord($"Item referenced by path {FilePath} was not found.", ErrorId_ItemNotFound, FilePath, nameof(FilePath)));
    //             break;
    //         case ParameterSetName_LiteralPath:
    //             foreach (string path in LiteralPath)
    //             {
    //                 if (!SessionState.Path.IsValid(path))
    //                 {
    //                     WriteError(CreateArgumentErrorRecord($"Path string {path} is not valid.", ErrorId_PathIsInvalid, path, nameof(LiteralPath)));
    //                     continue;
    //                 }
    //                 if (InvokeProvider.Item.Exists(path))
    //                 {
    //                     string providerPath = SessionState.Path.GetUnresolvedProviderPathFromPSPath(path);
    //                     if (providerPath is not null)
    //                     {
    //                         _allPaths.Add(providerPath);
    //                         continue;
    //                     }
    //                 }
    //                 WriteError(CreateItemNotFoundErrorRecord($"Item referenced by path {path} was not found.", ErrorId_ItemNotFound, path, nameof(LiteralPath)));
    //             }
    //             break;
    //         default:
    //             foreach (string path in Path)
    //             {
    //                 if (!SessionState.Path.IsValid(path))
    //                 {
    //                     WriteError(CreateArgumentErrorRecord($"Path string {path} is not valid.", ErrorId_PathIsInvalid, path, nameof(Path)));
    //                     continue;
    //                 }
    //                 if (InvokeProvider.Item.Exists(path))
    //                 {
    //                     Collection<string> providerPaths = SessionState.Path.GetResolvedProviderPathFromPSPath(path, out ProviderInfo provider);
    //                     if (providerPaths is not null && providerPaths.Count > 0)
    //                     {
    //                         foreach (string p in providerPaths)
    //                             _allPaths.Add(p);
    //                         continue;
    //                     }
    //                 }
    //                 WriteError(CreateItemNotFoundErrorRecord($"Item referenced by path {path} was not found.", ErrorId_ItemNotFound, path, nameof(Path)));
    //             }
    //             break;
    //     }
    // }

    // private bool ReadContentBlocks(Collection<IContentReader> _readerCollection, string _path, TextWriter writer)
    // {
    //     foreach (var _currentReader in _readerCollection)
    //     {
    //         IList blocks = _currentReader.Read(32);
    //         while (blocks is not null && blocks.Count > 0)
    //         {
    //             foreach (object o in blocks)
    //             {
    //                 if (o is char c)
    //                     writer.WriteLine(c);
    //                 else
    //                 {
    //                     try
    //                     {
    //                         var s = LanguagePrimitives.ConvertTo(o, typeof(string));
    //                         if (s is string str)
    //                             writer.WriteLine(s);
    //                         else
    //                         {
    //                             WriteError(CreateInvalidOperationErrorRecord(new PSInvalidCastException("Unable to convert input to a string"), ErrorId_PathCannotBeReadAsText, _path, ParameterSetName switch
    //                             {
    //                                 ParameterSetName_InputOutput => nameof(FilePath),
    //                                 ParameterSetName_LiteralPath => nameof(LiteralPath),
    //                                 _ => nameof(Path),
    //                             }, $"Contents of item referred to by path {_path} could not be converted to a string value"));
    //                             return false;
    //                         }
    //                     }
    //                     catch (PSInvalidCastException exception)
    //                     {
    //                         WriteError(CreateInvalidOperationErrorRecord(exception, ErrorId_PathCannotBeReadAsText, _path, ParameterSetName switch
    //                         {
    //                             ParameterSetName_InputOutput => nameof(FilePath),
    //                             ParameterSetName_LiteralPath => nameof(LiteralPath),
    //                             _ => nameof(Path),
    //                         }, $"An exception was thrown while trying to conver the contents of the item referred to by path {_path} to a string value"));
    //                         return false;
    //                     }
    //                 }
    //             }
    //         }
    //     }
    //     return true;
    // }

    // protected override void EndProcessing()
    // {
    //     if (_allPaths is null) return;
    //     if (MyInvocation.BoundParameters.ContainsKey(nameof(SaveAs)))
    //     {

    //     }
    //     else
    //         foreach (string path in _allPaths)
    //         {
    //             Collection<IContentReader> readerCollection;
    //             try { readerCollection = InvokeProvider.Content.GetReader(path); }
    //             catch (PSNotSupportedException ex)
    //             {
    //                 WriteError(new ErrorRecord(ex, "ContentAccessNotSupported", ErrorCategory.NotImplemented, path));
    //                 continue;
    //             }
    //             using StringWriter writer = new();
    //             if (ReadContentBlocks(readerCollection, path, writer))
    //                 WriteObject(writer.ToString());
    //         }
    // }
}