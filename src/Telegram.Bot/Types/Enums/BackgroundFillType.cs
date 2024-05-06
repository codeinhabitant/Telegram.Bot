using Telegram.Bot.Serialization.EnumConverters;

namespace Telegram.Bot.Types.Enums;

[JsonConverter(typeof(BackgroundFillTypeConverter))]
public enum BackgroundFillType
{
    /// <summary>
    /// Represents of a new unsupported type.
    /// </summary>
    FallbackUnsupported = 0,

    /// <summary>
    /// <see cref="BackgroundFillSolid"/>
    /// </summary>
    Solid = 1,

    /// <summary>
    /// <see cref="BackgroundFillGradient"/>
    /// </summary>
    Gradient,

    /// <summary>
    /// <see cref="BackgroundFillFreeformGradient"/>
    /// </summary>
    FreeformGradient,
}
