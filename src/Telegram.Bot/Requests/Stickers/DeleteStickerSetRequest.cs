

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to delete a sticker set that was created by the bot.
/// Returns <see langword="true"/> on success.
/// </summary>
public class DeleteStickerSetRequest : RequestBase<bool>
{
    //
    /// <summary>
    /// Sticker set name
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string Name { get; init; }

    /// <summary>
    /// Initializes a new request
    /// </summary>
    public DeleteStickerSetRequest()
        : base("deleteStickerSet", TelegramBotClientJsonSerializerContext.Instance.DeleteStickerSetRequest)
    { }
}
