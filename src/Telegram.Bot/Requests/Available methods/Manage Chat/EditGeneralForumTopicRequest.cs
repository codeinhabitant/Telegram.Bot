using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this request to edit the name of the 'General' topic in a forum supergroup chat. The bot must be an
/// administrator in the chat for this to work and must have <see cref="ChatAdministratorRights.CanManageTopics"/>
/// administrator rights. Returns <see langword="true"/> on success.
/// </summary>
public class EditGeneralForumTopicRequest : RequestBase<bool>, IChatTargetable
{
    /// <inheritdoc />
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required ChatId ChatId { get; init; }

    /// <summary>
    /// New topic name, 1-128 characters
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string Name { get; init; }

    /// <summary>
    /// Initializes a new request
    /// </summary>
    public EditGeneralForumTopicRequest()
        : base("editGeneralForumTopic", TelegramBotClientJsonSerializerContext.Instance.EditGeneralForumTopicRequest)
    { }
}
