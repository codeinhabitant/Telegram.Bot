namespace Telegram.Bot.Types.Enums;

/// <summary>
/// Type of a <see cref="InputFile"/>
/// </summary>
public enum FileType
{
    /// <summary>
    /// Represents of a new unsupported type.
    /// </summary>
    FallbackUnsupported = 0,

    /// <summary>
    /// FileStream
    /// </summary>
    Stream = 1,

    /// <summary>
    /// FileId
    /// </summary>
    Id,

    /// <summary>
    /// File URL
    /// </summary>
    Url,
}
