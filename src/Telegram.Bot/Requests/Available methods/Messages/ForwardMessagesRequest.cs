using System.Collections.Generic;
using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to forward multiple messages of any kind. If some of the specified messages can't be found
/// or forwarded, they are skipped. Service messages and messages with protected content can't be forwarded.
/// Album grouping is kept for forwarded messages.
/// On success, an array of <see cref="MessageId"/> of the sent messages is returned.
/// </summary>
public class ForwardMessagesRequest : RequestBase<MessageId[]>, IChatTargetable
{
    /// <summary>
    /// Unique identifier for the target chat or username of the target channel
    /// (in the format <c>@channelusername</c>)
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required ChatId ChatId { get; init; }

    /// <summary>
    /// Unique identifier for the chat where the original messages were sent
    /// (or channel username in the format <c>@channelusername</c>)
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required ChatId FromChatId { get; init; }

    /// <summary>
    /// Identifiers of 1-100 messages in the chat from_chat_id to forward.
    /// The identifiers must be specified in a strictly increasing order.
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required IEnumerable<int> MessageIds { get; init; }

    /// <summary>
    /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MessageThreadId { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.DisableNotification"/>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? DisableNotification { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ProtectContent"/>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ProtectContent { get; set; }

    /// <summary>
    /// Initializes a new request
    /// </summary>
    public ForwardMessagesRequest()
        :base("forwardMessages", TelegramBotClientJsonSerializerContext.Instance.ForwardMessagesRequest)
    { }
}
