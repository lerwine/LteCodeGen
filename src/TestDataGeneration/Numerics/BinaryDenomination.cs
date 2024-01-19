namespace TestDataGeneration.Numerics;

/// <summary>
/// Byte size denominations.
/// </summary>
public enum BinaryDenomination : ulong
{
    /// <summary>
    /// Length in bytes.
    /// </summary>
    Bytes = 1UL,

    /// <summary>
    /// Length / 1024
    /// </summary>
    Kilobytes = 1024UL,
    /// 
    /// <summary>
    /// Length / (1024 * 1024)
    /// </summary>
    Megabytes = 1048576UL,
    /// /// 
    /// <summary>
    /// Length / (1024 * 1024 * 1024)
    /// </summary>
    Gigabytes = 1073741824UL,
    /// /// /// 
    /// <summary>
    /// Length / (1024 * 1024 * 1024 * 1024)
    /// </summary>
    Terabytes = 1099511627776UL,
    /// /// /// /// 
    /// <summary>
    /// Length / (1024 * 1024 * 1024 * 1024 * 1024)
    /// </summary>
    Petabytes = 1125899906842624UL
}