using System.Collections.Generic;
using System.Net.Http;
using Telegram.Bot.Extensions;
using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to send a group of photos, videos, documents or audios as an album. Documents and
/// audio files can be only grouped in an album with messages of the same type. On success, an array
/// of <see cref="Message"/>s that were sent is returned.
/// </summary>
public class SendMediaGroupRequest : FileRequestBase<Message[]>, IChatTargetable, IBusinessConnectable
{
    /// <inheritdoc />
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BusinessConnectionId { get; set; }

    /// <inheritdoc />
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required ChatId ChatId { get; init; }

    /// <summary>
    /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MessageThreadId { get; set; }

    /// <summary>
    /// An array describing messages to be sent, must include 2-10 items
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required IEnumerable<IAlbumInputMedia> Media { get; init; }

    /// <inheritdoc cref="Abstractions.Documentation.DisableNotification"/>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? DisableNotification { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ProtectContent"/>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ProtectContent { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ReplyParameters"/>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ReplyParameters? ReplyParameters { get; set; }

    /// <summary>
    /// Initializes a request
    /// </summary>
    public SendMediaGroupRequest()
        : base("sendMediaGroup", TelegramBotClientJsonSerializerContext.Instance.SendMediaGroupRequest)
    { }

    /// <inheritdoc />
    public override HttpContent ToHttpContent()
    {
        var multipartContent = GenerateMultipartFormDataContent(TelegramBotClientJsonSerializerContext.Instance.SendMediaGroupRequest);

        foreach (var mediaItem in Media)
        {
            if (mediaItem is InputMedia { Media: InputFileStream file })
            {
                multipartContent.AddContentIfInputFile(file, file.FileName!);
            }

            if (mediaItem is IInputMediaThumb { Thumbnail: InputFileStream thumbnail })
            {
                multipartContent.AddContentIfInputFile(thumbnail, thumbnail.FileName!);
            }
        }

        return multipartContent;
    }
}
