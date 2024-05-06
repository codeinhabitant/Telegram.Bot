using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types;

/// <summary>
/// Base Class describes the type of a background/>
/// </summary>
public abstract class BackgroundType
{
    /// <summary>
    /// Type of the background
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public abstract BackgroundTypeKind? Type { get; }
}

public class BackgroundTypeFallbackUnsupported : BackgroundType
{
    /// <summary>
    /// Type of the background fill, always “fallback_unsupported”
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override BackgroundTypeKind? Type => BackgroundTypeKind.FallbackUnsupported;

    private BackgroundTypeFallbackUnsupported() {}

    /// <summary>
    /// For optimization purposes, use this instance instead of creating a new one.
    /// </summary>
    public static BackgroundTypeFallbackUnsupported Instance { get; } = new();
}

/// <summary>
/// Represents a background is taken directly from a built-in chat theme.
/// </summary>
public class BackgroundTypeChatTheme : BackgroundType
{
    /// <summary>
    /// Type of the background, always “chat_theme”
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override BackgroundTypeKind? Type => BackgroundTypeKind.ChatTheme;

    /// <summary>
    /// Name of the chat theme, which is usually an emoji
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string ThemeName { get; init; }
}

/// <summary>
/// Represents a background is automatically filled based on the selected colors.
/// </summary>
public class BackgroundTypeFill : BackgroundType
{
    /// <summary>
    /// Type of the background, always “fill”
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override BackgroundTypeKind? Type => BackgroundTypeKind.Fill;

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
    public override BackgroundTypeKind? Type => BackgroundTypeKind.Pattern;

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

/// <summary>
/// Represents a background is a wallpaper in the JPEG format.
/// </summary>
public class BackgroundTypeWallpaper : BackgroundType
{
    /// <summary>
    /// Type of the background, always “wallpaper”
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override BackgroundTypeKind? Type => BackgroundTypeKind.Wallpaper;

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
