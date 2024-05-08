namespace Telegram.Bot.Types.Enums;

[JsonConverter(typeof(BackgroundFillTypeConverter))]
public enum BackgroundFillType
{
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
