

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to get a sticker set. On success, a <see cref="StickerSet"/> object is returned.
/// </summary>
public class GetStickerSetRequest : RequestBase<StickerSet>
{
    /// <summary>
    /// Name of the sticker set
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string Name { get; init; }

    /// <summary>
    /// Initializes a new request with name
    /// </summary>
    public GetStickerSetRequest()
        : base("getStickerSet", TelegramBotClientJsonSerializerContext.Instance.GetStickerSetRequest)
    { }
}
