using Telegram.Bot.Types.Enums;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types.InlineQueryResults;

/// <summary>
/// Represents a link to a file stored on the Telegram servers. By default, this file will be sent
/// by the user with an optional caption. Alternatively, you can use
/// <see cref="InlineQueryResultCachedDocument.InputMessageContent"/> to send a message with the
/// specified content instead of the file.
/// </summary>
public class InlineQueryResultCachedDocument : InlineQueryResult
{
    /// <summary>
    /// Type of the result, must be document
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override InlineQueryResultType Type => InlineQueryResultType.Document;

    /// <summary>
    /// Title for the result
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string Title { get; init; }

    /// <summary>
    /// A valid file identifier for the file
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string DocumentFileId { get; init; }

    /// <summary>
    /// Optional. Short description of the result
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; set; }

    /// <inheritdoc cref="Documentation.Caption" />
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Caption { get; set; }

    /// <inheritdoc cref="Documentation.ParseMode" />
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ParseMode? ParseMode { get; set; }

    /// <inheritdoc cref="Documentation.CaptionEntities" />
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MessageEntity[]? CaptionEntities { get; set; }

    /// <inheritdoc cref="Documentation.InputMessageContent" />
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public InputMessageContent? InputMessageContent { get; set; }

    /// <summary>
    /// Initializes a new inline query result
    /// </summary>
    public InlineQueryResultCachedDocument()
    { }
}
