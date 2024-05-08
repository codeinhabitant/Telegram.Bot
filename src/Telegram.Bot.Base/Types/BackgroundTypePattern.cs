using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types;

/// <summary>
/// Represents a background is a PNG or TGV (gzipped subset of SVG with MIME type “application/x-tgwallpattern”)
/// pattern to be combined with the background fill chosen by the user.
/// </summary>
public class BackgroundTypePattern : BackgroundType
{
    /// <summary>
    /// Type of the background, always “pattern”
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override BackgroundTypeType Type => BackgroundTypeType.Pattern;

    /// <summary>
    /// Document with the pattern
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required Document Document { get; init; }

    /// <summary>
    /// The background fill
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required BackgroundFill Fill { get; init; }

    /// <summary>
    /// Intensity of the pattern when it is shown above the filled background; 0-100
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required int Intensity
    {
        get => _intensity;
        init
        {
            if (value is < 0 or > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "DarkThemeDimming must be between 0 and 100.");
            }

            _intensity = value;
        }
    }

    /// <summary>
    /// Optional. True, if the background fill must be applied only to the pattern itself.
    /// All other pixels are black in this case. For dark themes only
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? IsInverted { get; set; }

    /// <summary>
    /// Optional. True, if the background moves slightly when the device is tilted
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? IsMoving { get; set; }

    [JsonIgnore]
    private readonly int _intensity;
}
