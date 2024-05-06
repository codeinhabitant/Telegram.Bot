using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to change the list of emoji assigned to a regular or custom emoji sticker.
/// The sticker must belong to a sticker set created by the bot.
/// Returns <see langword="true"/> on success.
/// </summary>
public class SetStickerEmojiListRequest : RequestBase<bool>
{
    /// <summary>
    /// <see cref="InputFileId">File identifier</see> of the sticker
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required InputFileId Sticker { get; init; }

    /// <summary>
    /// A list of 1-20 emoji associated with the sticker
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required IEnumerable<string> EmojiList { get; init; }

    /// <summary>
    /// Initializes a new request
    /// </summary>
    public SetStickerEmojiListRequest()
        : base("setStickerEmojiList", TelegramBotClientJsonSerializerContext.Instance.SetStickerEmojiListRequest)
    { }
}
