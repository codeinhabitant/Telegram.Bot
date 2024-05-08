using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types;

public abstract class BackgroundFill
{
    /// <summary>
    /// Type of the background fill
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public abstract BackgroundFillType Type { get; }
}
