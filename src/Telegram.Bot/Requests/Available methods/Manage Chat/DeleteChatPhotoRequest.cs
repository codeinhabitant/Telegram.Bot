using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to delete a chat photo. Photos can't be changed for private chats. The bot
/// must be an administrator in the chat for this to work and must have the appropriate
/// admin rights. Returns <see langword="true"/> on success.
/// </summary>
public class DeleteChatPhotoRequest : RequestBase<bool>, IChatTargetable
{
    /// <inheritdoc />
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required ChatId ChatId { get; init; }

    /// <summary>
    /// Initializes a new request
    /// </summary>
    public DeleteChatPhotoRequest()
        : base("deleteChatPhoto", TelegramBotClientJsonSerializerContext.Instance.DeleteChatPhotoRequest)
    { }
}
