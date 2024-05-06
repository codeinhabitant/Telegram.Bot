using Telegram.Bot.Serialization.EnumConverters;

namespace Telegram.Bot.Types.Enums;

[JsonConverter(typeof(BackgroundTypeKindConverter))]
public enum BackgroundTypeKind
{
    /// <summary>
    /// Represents of a new unsupported type.
    /// </summary>
    FallbackUnsupported = 0,

    /// <summary>
    /// <see cref="BackgroundTypeFill"/>
    /// </summary>
    Fill = 1,

    /// <summary>
    /// <see cref="BackgroundTypeWallpaper"/>
    /// </summary>
    Wallpaper,

    /// <summary>
    /// <see cref="BackgroundTypePattern"/>
    /// </summary>
    Pattern,

    /// <summary>
    /// <see cref="BackgroundTypeChatTheme"/>
    /// </summary>
    ChatTheme,
}
