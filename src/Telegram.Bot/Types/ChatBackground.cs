namespace Telegram.Bot.Types;

/// <summary>
/// Represents a chat background.
/// </summary>
public class ChatBackground
{
    /// <summary>
    /// Type of the background
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required BackgroundType Type { get; init; } = default!;
}
