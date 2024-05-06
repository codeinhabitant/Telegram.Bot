using Telegram.Bot.Serialization.EnumConverters;

namespace Telegram.Bot.Types.Enums;

/// <summary>
/// Type of chat boost source
/// </summary>
[JsonConverter(typeof(ChatBoostSourceTypeConverter))]
public enum ChatBoostSourceType
{
    /// <summary>
    /// Represents of a new unsupported type.
    /// </summary>
    FallbackUnsupported = 0,

    /// <summary>
    /// The boost was obtained by subscribing to Telegram Premium
    /// or by gifting a Telegram Premium subscription to another user
    /// </summary>
    Premium = 1,

    /// <summary>
    /// The boost was obtained by the creation of Telegram Premium gift codes to boost a chat
    /// </summary>
    GiftCode,

    /// <summary>
    /// The boost was obtained by the creation of a Telegram Premium giveaway
    /// </summary>
    Giveaway,
}
