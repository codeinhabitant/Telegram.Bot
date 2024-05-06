using System.Net.Http;
using Telegram.Bot.Extensions;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to edit animation, audio, document, photo, or video messages. If a message is part
/// of a message album, then it can be edited only to an audio for audio albums, only to a
/// document for document albums and to a photo or a video otherwise. Use a previously uploaded
/// file via its <see cref="InputFileId"/> or specify a URL.
/// On success the edited <see cref="Message"/> is returned.
/// </summary>
public class EditMessageMediaRequest : FileRequestBase<Message>, IChatTargetable
{
    /// <inheritdoc />
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required ChatId ChatId { get; init; }

    /// <summary>
    /// Identifier of the message to edit
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required int MessageId { get; init; }

    /// <summary>
    /// A new media content of the message
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required InputMedia Media { get; init; }

    /// <inheritdoc cref="Documentation.InlineReplyMarkup"/>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public InlineKeyboardMarkup? ReplyMarkup { get; set; }

    /// <summary>
    /// Initializes a new
    /// </summary>
    public EditMessageMediaRequest()
        : base("editMessageMedia", TelegramBotClientJsonSerializerContext.Instance.EditMessageMediaRequest)
    { }

    /// <inheritdoc />
    public override HttpContent? ToHttpContent()
    {
        if (Media.Media.FileType is not FileType.Stream &&
            Media is not IInputMediaThumb { Thumbnail.FileType: FileType.Stream })
        {
            return base.ToHttpContent();
        }

        var multipartContent = GenerateMultipartFormDataContent(TelegramBotClientJsonSerializerContext.Instance.EditMessageMediaRequest);

        if (Media.Media is InputFileStream file)
        {
            multipartContent.AddContentIfInputFile(file, file.FileName!);
        }
        if (Media is IInputMediaThumb { Thumbnail: InputFileStream thumbnail })
        {
            multipartContent.AddContentIfInputFile(thumbnail, thumbnail.FileName!);
        }

        return multipartContent;
    }
}
