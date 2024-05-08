using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types;

/// <summary>
/// Represents a background is automatically filled based on the selected colors.
/// </summary>
public class BackgroundTypeFill : BackgroundType
{
    /// <summary>
    /// Type of the background, always “fill”
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override BackgroundTypeType Type => BackgroundTypeType.Fill;

    /// <summary>
    /// The background fill
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required BackgroundFill Fill { get; init; }

    /// <summary>
    /// Dimming of the background in dark themes, as a percentage; 0-100
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required int DarkThemeDimming
    {
        get => _darkThemeDimming;
        init
        {
            if (value is < 0 or > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "DarkThemeDimming must be between 0 and 100.");
            }

            _darkThemeDimming = value;
        }
    }

    [JsonIgnore]
    private readonly int _darkThemeDimming;
}
