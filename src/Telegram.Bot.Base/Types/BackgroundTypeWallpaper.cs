using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types;

/// <summary>
/// Represents a background is a wallpaper in the JPEG format.
/// </summary>
public class BackgroundTypeWallpaper : BackgroundType
{
    /// <summary>
    /// Type of the background, always “wallpaper”
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override BackgroundTypeType Type => BackgroundTypeType.Wallpaper;

    /// <summary>
    /// Document with the wallpaper
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required Document Document { get; init; }

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

    /// <summary>
    /// Optional. True, if the wallpaper is downscaled to fit in a 450x450 square and then box-blurred with radius 12
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? IsBlurred { get; set; }

    /// <summary>
    /// Optional. True, if the background moves slightly when the device is tilted
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? IsMoving { get; set; }

    [JsonIgnore]
    private readonly int _darkThemeDimming;
}
