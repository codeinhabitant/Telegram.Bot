

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to set the thumbnail of a custom emoji sticker set.
/// Returns <see langword="true"/> on success.
/// </summary>
public class SetCustomEmojiStickerSetThumbnailRequest : RequestBase<bool>
{
    /// <summary>
    /// Sticker set name
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string Name { get; init; }

    /// <summary>
    /// Optional. Custom emoji identifier of a <see cref="Sticker"/> from the <see cref="StickerSet"/>;
    /// pass an <see langword="null"/> to drop the thumbnail and use the first sticker as the thumbnail.
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? CustomEmojiId { get; set; }

    /// <summary>
    /// Initializes a new request
    /// </summary>
    public SetCustomEmojiStickerSetThumbnailRequest()
        : base("setCustomEmojiStickerSetThumbnail", TelegramBotClientJsonSerializerContext.Instance.SetCustomEmojiStickerSetThumbnailRequest)
    { }
}
