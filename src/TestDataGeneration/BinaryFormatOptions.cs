namespace TestDataGeneration;

/// <summary>
/// Indicates how to format a binary data string.
/// </summary>
[Flags]
public enum BinaryFormatOptions : byte
{
    /// <summary>
    /// Prefix with <c>"0b"</c> and separate each nibble (4 bits) by an underscore..
    /// </summary>
    Default = 0b0111_0001,

    /// <summary>
    /// Do not use prefix or underscore characters.
    /// </summary>
    DigitsOnly = 0b0000_0000,

    /// <summary>
    /// Prefix with <c>"0b"</c>.
    /// </summary>
    Lc0B = 0b0111_0000,

    /// <summary>
    /// Prefix with <c>"0B"</c>.
    /// </summary>
    Uc0B = 0b0110_0000,

    /// <summary>
    /// Prefix with <c>"&amp;b"</c>.
    /// </summary>
    AmpersandLcB = 0b0011_0000,
    
    /// <summary>
    /// Prefix with <c>"&amp;B"</c>.
    /// </summary>
    AmpersandUcB = 0b0010_0000,

    /// <summary>
    /// Separate each nibble (4 bits) by an underscore.
    /// </summary>
    SplitNibble = 0b0000_0001,
    
    /// <summary>
    /// Separate each byte (8 bits) by an underscore.
    /// </summary>
    SplitByte = 0b0000_0011,
    
    /// <summary>
    /// Separate each Word (16 bits) by an underscore.
    /// </summary>
    SplitWord = 0b0000_0111,
    
    /// <summary>
    /// Separate each DWord (32 bits) by an underscore.
    /// </summary>
    SplitDWord = 0b0000_1111
}