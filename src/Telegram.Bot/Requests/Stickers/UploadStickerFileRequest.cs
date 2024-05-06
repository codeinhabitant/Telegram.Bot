using System.Net.Http;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.Enums;
using File = Telegram.Bot.Types.File;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to upload a file with a sticker for later use in the
/// <see cref="CreateNewStickerSetRequest"/> and <see cref="AddStickerToSetRequest"/>
/// methods (the file can be used multiple times).
/// Returns the uploaded <see cref="File"/> on success.
/// </summary>
public class UploadStickerFileRequest : FileRequestBase<File>, IUserTargetable
{
    /// <inheritdoc />
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required long UserId { get; init; }

    /// <summary>
    /// A file with the sticker in .WEBP, .PNG, .TGS, or .WEBM format.
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required InputFileStream Sticker { get; init; }

    /// <summary>
    /// Format of the sticker
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required StickerFormat StickerFormat { get; init; }

    /// <summary>
    /// Initializes a new request
    /// </summary>
    public UploadStickerFileRequest()
        : base("uploadStickerFile", TelegramBotClientJsonSerializerContext.Instance.UploadStickerFileRequest)
    { }

    /// <inheritdoc />
    public override HttpContent? ToHttpContent()
        => ToMultipartFormDataContent(TelegramBotClientJsonSerializerContext.Instance.UploadStickerFileRequest, fileParameterName: "sticker", inputFile: Sticker);
}
