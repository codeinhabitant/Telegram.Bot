using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types;

/// <summary>
/// Represents a background is filled using the selected color.
/// </summary>
public class BackgroundFillSolid : BackgroundFill
{
    /// <summary>
    /// Type of the background fill, always “solid”
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override BackgroundFillType Type => BackgroundFillType.Solid;

    /// <summary>
    /// The color of the background fill in the RGB24 format
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required Color Color { get; init; }
}
