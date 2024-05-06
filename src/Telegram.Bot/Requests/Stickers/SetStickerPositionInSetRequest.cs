

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to move a sticker in a set created by the bot to a specific position.
/// Returns <see langword="true"/> on success.
/// </summary>
public class SetStickerPositionInSetRequest : RequestBase<bool>
{
    /// <summary>
    /// <see cref="InputFileId">File identifier</see> of the sticker
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required InputFileId Sticker { get; init; }

    /// <summary>
    /// New sticker position in the set, zero-based
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required int Position { get; init; }

    /// <summary>
    /// Initializes a new request
    /// </summary>
    public SetStickerPositionInSetRequest()
        : base("setStickerPositionInSet", TelegramBotClientJsonSerializerContext.Instance.SetStickerPositionInSetRequest)
    { }
}
