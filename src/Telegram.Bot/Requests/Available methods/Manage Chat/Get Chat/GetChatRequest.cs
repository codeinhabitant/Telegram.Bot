using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Serialization;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to get up to date information about the chat (current name of the user for
/// one-on-one conversations, current username of a user, group or channel, etc.).
/// Returns a <see cref="Chat"/> object on success.
/// </summary>
public class GetChatRequest : RequestBase<ChatFullInfo>, IChatTargetable
{
    /// <inheritdoc />
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [JsonConverter(typeof(ChatIdConverter))]
    public required ChatId ChatId { get; init; }

    /// <summary>
    /// Initializes a new request with chatId
    /// </summary>
    [JsonConstructor]
    public GetChatRequest()
        : base("getChat", TelegramBotClientJsonSerializerContext.Instance.GetChatRequest)
    { }
}
