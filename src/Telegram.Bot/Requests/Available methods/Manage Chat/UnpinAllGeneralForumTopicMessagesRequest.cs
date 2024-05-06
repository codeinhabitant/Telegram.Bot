using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to clear the list of pinned messages in a General forum topic. The bot must be an administrator in
/// the chat for this to work and must have the <see cref="ChatAdministratorRights.CanPinMessages"/> administrator
/// right in the supergroup. Returns <see langword="true"/> on success.
/// </summary>
public class UnpinAllGeneralForumTopicMessagesRequest : RequestBase<bool>, IChatTargetable
{
    /// <inheritdoc />
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required ChatId ChatId { get; init; }

    /// <summary>
    /// Initializes a new request
    /// </summary>
    public UnpinAllGeneralForumTopicMessagesRequest()
        : base("unpinAllGeneralForumTopicMessages", TelegramBotClientJsonSerializerContext.Instance.UnpinAllGeneralForumTopicMessagesRequest)
    { }
}
