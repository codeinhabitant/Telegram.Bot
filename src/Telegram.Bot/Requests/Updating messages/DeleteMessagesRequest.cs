using System.Collections.Generic;
using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to delete multiple messages simultaneously.
/// If some of the specified messages can't be found, they are skipped.
/// Returns <see langword="true"/> on success.
/// </summary>
public class DeleteMessagesRequest : RequestBase<bool>, IChatTargetable
{
    /// <inheritdoc />
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required ChatId ChatId { get; init; }

    /// <summary>
    /// Identifiers of 1-100 messages to delete. See <see cref="DeleteMessageRequest"/>
    /// for limitations on which messages can be deleted
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required IEnumerable<int> MessageIds { get; init; }

    /// <summary>
    /// Initializes a new request with chatId and messageIds
    /// </summary>
    public DeleteMessagesRequest()
        : base("deleteMessages", TelegramBotClientJsonSerializerContext.Instance.DeleteMessagesRequest)
    { }
}
