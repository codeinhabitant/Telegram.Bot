using Telegram.Bot.Serialization.EnumConverters;

namespace Telegram.Bot.Types.Enums;

/// <summary>
/// Type of the <see cref="Sticker"/>
/// </summary>
[JsonConverter(typeof(StickerTypeConverter))]
public enum StickerType
{
    /// <summary>
    /// Represents of a new unsupported type.
    /// </summary>
    FallbackUnsupported = 0,

    /// <summary>
    /// Regular  <see cref="Sticker"/>
    /// </summary>
    Regular = 1,

    /// <summary>
    /// Mask
    /// </summary>
    Mask,

    /// <summary>
    /// Custom emoji
    /// </summary>
    CustomEmoji,
}
