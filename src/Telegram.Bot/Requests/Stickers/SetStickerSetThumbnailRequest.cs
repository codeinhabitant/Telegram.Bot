using System.Net.Http;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.Enums;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to set the thumbnail of a regular or mask sticker set.
/// The format of the thumbnail file must match the format of the stickers in the set.
/// Returns <see langword="true"/> on success.
/// </summary>
public class SetStickerSetThumbnailRequest : FileRequestBase<bool>, IUserTargetable
{
    /// <summary>
    /// Sticker set name
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string Name { get; init; }

    /// <inheritdoc />
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required long UserId { get; init; }

    /// <summary>
    /// A <b>.WEBP</b> or <b>.PNG</b> image with the thumbnail, must be up to 128 kilobytes in size and have
    /// a width and height of exactly 100px, or a <b>.TGS</b> animation with a thumbnail up to 32 kilobytes in
    /// size (see <a href="https://core.telegram.org/animated_stickers#technical-requirements"/> for animated
    /// sticker technical requirements), or a <b>WEBM</b> video with the thumbnail up to 32 kilobytes in size; see
    /// <a href="https://core.telegram.org/stickers#video-sticker-requirements"/> for video sticker technical
    /// requirements. Pass a <see cref="InputFileId"/> as a String to send a file that already exists on the
    /// Telegram servers, pass an HTTP URL as a String for Telegram to get a file from the Internet, or
    /// upload a new one using multipart/form-data. Animated and video sticker set thumbnails can't be uploaded
    /// via HTTP URL. If omitted, then the thumbnail is dropped and the first sticker is used as the thumbnail.
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public InputFile? Thumbnail { get; set; }

    /// <summary>
    /// Format of the thumbnail
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required StickerFormat Format { get; init; }

    /// <summary>
    /// Initializes a new request
    /// </summary>
    public SetStickerSetThumbnailRequest()
        : base("setStickerSetThumbnail", TelegramBotClientJsonSerializerContext.Instance.SetStickerSetThumbnailRequest)
    { }

    /// <inheritdoc />
    public override HttpContent? ToHttpContent() =>
        Thumbnail switch
        {
            InputFileStream thumbnail =>
                ToMultipartFormDataContent(TelegramBotClientJsonSerializerContext.Instance.SetStickerSetThumbnailRequest, fileParameterName: "thumbnail", inputFile: thumbnail),
            _                         => base.ToHttpContent()
        };
}
