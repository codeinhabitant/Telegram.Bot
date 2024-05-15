using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types;

/// <summary>
/// This object describes the type of a reaction. Currently, it can be one of
/// <list type="bullet">
/// <item><see cref="ReactionTypeEmoji"/></item>
/// <item><see cref="ReactionTypeCustomEmoji"/></item>
/// </list>
/// </summary>
public abstract class ReactionType
{
    /// <summary>
    /// Type of the reaction
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public abstract ReactionTypeKind? Type { get; }
}

public class ReactionTypeFallbackUnsupported : ReactionType
{
    /// <inheritdoc />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override ReactionTypeKind? Type => ReactionTypeKind.FallbackUnsupported;

    private ReactionTypeFallbackUnsupported() {}

    /// <summary>
    /// For optimization purposes, use this instance instead of creating a new one.
    /// </summary>
    public static ReactionTypeFallbackUnsupported Instance { get; } = new();
}

/// <summary>
/// The reaction is based on an emoji.
/// </summary>
public class ReactionTypeEmoji : ReactionType
{
    /// <summary>
    /// Type of the reaction, always "emoji"
    /// </summary>
    public override ReactionTypeKind? Type => ReactionTypeKind.Emoji;

    /// <summary>
    /// Reaction emoji. Currently, it can be one of "👍", "👎", "❤", "🔥", "🥰", "👏", "😁",
    /// "🤔", "🤯", "😱", "🤬", "😢", "🎉", "🤩", "🤮", "💩", "🙏", "👌", "🕊", "🤡", "🥱",
    /// "🥴", "😍", "🐳", "❤‍🔥", "🌚", "🌭", "💯", "🤣", "⚡", "🍌", "🏆", "💔", "🤨",
    /// "😐", "🍓", "🍾", "💋", "🖕", "😈", "😴", "😭", "🤓", "👻", "👨‍💻", "👀", "🎃",
    /// "🙈", "😇", "😨", "🤝", "✍", "🤗", "🫡", "🎅", "🎄", "☃", "💅", "🤪", "🗿", "🆒",
    /// "💘", "🙉", "🦄", "😘", "💊", "🙊", "😎", "👾", "🤷‍♂", "🤷", "🤷‍♀", "😡"
    /// </summary>
    /// <remarks>
    /// Available shortcuts: <see cref="Enums.KnownReactionTypeEmoji"/>
    /// </remarks>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string Emoji { get; set; } = default!;
}

/// <summary>
/// The reaction is based on an emoji.
/// </summary>
public class ReactionTypeCustomEmoji : ReactionType
{
    /// <summary>
    /// Type of the reaction, always "custom_emoji"
    /// </summary>
    public override ReactionTypeKind? Type => ReactionTypeKind.CustomEmoji;

    /// <summary>
    /// Custom emoji identifier
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string CustomEmojiId { get; set; } = default!;
}
