using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types;

/// <summary>
/// Represents a background is taken directly from a built-in chat theme.
/// </summary>
public class BackgroundTypeChatTheme : BackgroundType
{
    /// <summary>
    /// Type of the background, always “chat_theme”
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override BackgroundTypeType Type => BackgroundTypeType.ChatTheme;

    /// <summary>
    /// Name of the chat theme, which is usually an emoji
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string ThemeName { get; init; }
}
