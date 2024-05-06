using Telegram.Bot.Serialization.EnumConverters;

namespace Telegram.Bot.Types.Enums;

/// <summary>
/// Type of the reaction
/// </summary>
[JsonConverter(typeof(ReactionTypeKindConverter))]
public enum ReactionTypeKind
{
    /// <summary>
    /// Represents of a new unsupported type.
    /// </summary>
    FallbackUnsupported = 0,

    /// <summary>
    /// The reaction is based on an emoji.
    /// </summary>
    Emoji = 1,

    /// <summary>
    /// The reaction is based on a custom emoji.
    /// </summary>
    CustomEmoji,
}
