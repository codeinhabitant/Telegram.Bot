using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this request to reopen an open topic in a forum supergroup chat. The bot must be an administrator in the chat
/// for this to work and must have the <see cref="ChatAdministratorRights.CanManageTopics"/> administrator rights,
/// unless it is the creator of the topic. Returns <see langword="true"/> on success.
/// </summary>
public class ReopenForumTopicRequest : RequestBase<bool>, IChatTargetable
{
    /// <inheritdoc />
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required ChatId ChatId { get; init; }

    /// <summary>
    /// Unique identifier for the target message thread of the forum topic
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required int MessageThreadId { get; init; }

    /// <summary>
    /// Initializes a new request
    /// </summary>
    public ReopenForumTopicRequest()
        : base("reopenForumTopic", TelegramBotClientJsonSerializerContext.Instance.ReopenForumTopicRequest)
    { }
}
