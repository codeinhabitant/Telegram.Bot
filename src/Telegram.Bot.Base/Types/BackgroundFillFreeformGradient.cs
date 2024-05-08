using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types;

/// <summary>
/// Represents a background is filled using the selected color.
/// </summary>
public class BackgroundFillFreeformGradient : BackgroundFill
{
    /// <summary>
    /// Type of the background fill, always “freeform_gradient”
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override BackgroundFillType Type => BackgroundFillType.FreeformGradient;

    /// <summary>
    /// A list of the 3 or 4 base colors that are used to generate the freeform gradient in the RGB24 format
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required Color[] Colors { get; init; }
}
