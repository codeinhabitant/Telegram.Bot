using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to delete a group sticker set from a supergroup. The bot must be an administrator
/// in the chat for this to work and must have the appropriate admin rights. Use the field
/// <see cref="Types.Chat.CanSetStickerSet"/> optionally returned in <see cref="GetChatRequest"/>
/// requests to check if the bot can use this method. Returns <see langword="true"/> on success.
/// </summary>
public class DeleteChatStickerSetRequest : RequestBase<bool>, IChatTargetable
{
    /// <inheritdoc />
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required ChatId ChatId { get; init; }

    /// <summary>
    /// Initializes a new request
    /// </summary>
    public DeleteChatStickerSetRequest()
        : base("deleteChatStickerSet", TelegramBotClientJsonSerializerContext.Instance.DeleteChatStickerSetRequest)
    { }
}
