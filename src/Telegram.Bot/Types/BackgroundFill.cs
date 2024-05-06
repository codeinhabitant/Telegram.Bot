using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types;

public abstract class BackgroundFill
{
    /// <summary>
    /// Type of the background fill
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public abstract BackgroundFillType? Type { get; }
}

public class BackgroundFillFallbackUnsupported : BackgroundFill
{
    /// <summary>
    /// Type of the background fill, always “fallback_unsupported”
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override BackgroundFillType? Type => BackgroundFillType.FallbackUnsupported;

    private BackgroundFillFallbackUnsupported() {}

    /// <summary>
    /// For optimization purposes, use this instance instead of creating a new one.
    /// </summary>
    public static BackgroundFillFallbackUnsupported Instance { get; } = new();
}

/// <summary>
/// Represents a background is filled using the selected color.
/// </summary>
public class BackgroundFillFreeformGradient : BackgroundFill
{
    /// <summary>
    /// Type of the background fill, always “freeform_gradient”
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override BackgroundFillType? Type => BackgroundFillType.FreeformGradient;

    /// <summary>
    /// A list of the 3 or 4 base colors that are used to generate the freeform gradient in the RGB24 format
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required Color[] Colors { get; init; }
}

/// <summary>
/// Represents a background is a gradient fill
/// </summary>
public class BackgroundFillGradient : BackgroundFill
{
    /// <summary>
    /// Type of the background fill, always “gradient”
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override BackgroundFillType? Type => BackgroundFillType.Gradient;

    /// <summary>
    /// Top color of the gradient in the RGB24 format
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required Color TopColor { get; init; }

    /// <summary>
    /// Bottom color of the gradient in the RGB24 format
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required Color BottomColor { get; init; }

    /// <summary>
    /// Clockwise rotation angle of the background fill in degrees; 0-359
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required int RotationAngle
    {
        get => _rotationAngle;
        init
        {
            if (value is < 0 or > 359)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "RotationAngle must be between 0 and 359.");
            }

            _rotationAngle = value;
        }
    }

    [JsonIgnore]
    private readonly int _rotationAngle;
}

/// <summary>
/// Represents a background is filled using the selected color.
/// </summary>
public class BackgroundFillSolid : BackgroundFill
{
    /// <summary>
    /// Type of the background fill, always “solid”
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override BackgroundFillType? Type => BackgroundFillType.Solid;

    /// <summary>
    /// The color of the background fill in the RGB24 format
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required Color Color { get; init; }
}
