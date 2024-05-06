using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to get the number of members in a chat. Returns <c>int</c> on success.
/// </summary>
public class GetChatMemberCountRequest : RequestBase<int>, IChatTargetable
{
    /// <inheritdoc />
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required ChatId ChatId { get; init; }

    /// <summary>
    /// Initializes a new request with chatId
    /// </summary>
    [JsonConstructor]
    public GetChatMemberCountRequest()
        : base("getChatMemberCount", TelegramBotClientJsonSerializerContext.Instance.GetChatMemberCountRequest)
    { }
}
