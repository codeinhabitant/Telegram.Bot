using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types;

/// <summary>
/// Represents a background is a gradient fill
/// </summary>
public class BackgroundFillGradient : BackgroundFill
{
    /// <summary>
    /// Type of the background fill, always “gradient”
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override BackgroundFillType Type => BackgroundFillType.Gradient;

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
