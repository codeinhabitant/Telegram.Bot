using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this request to close an open 'General' topic in a forum supergroup chat. The bot must be an administrator in
/// the chat for this to work and must have the <see cref="ChatAdministratorRights.CanManageTopics"/> administrator
/// rights. Returns <see langword="true"/> on success.
/// </summary>
public class CloseGeneralForumTopicRequest : RequestBase<bool>, IChatTargetable
{
    /// <inheritdoc />
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required ChatId ChatId { get; init; }

    /// <summary>
    /// Initializes a new request
    /// </summary>
    public CloseGeneralForumTopicRequest()
        : base("closeGeneralForumTopic", TelegramBotClientJsonSerializerContext.Instance.CloseGeneralForumTopicRequest)
    { }
}
