using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to change the description of a group, a supergroup or a channel.
/// The bot must be an administrator in the chat for this to work and must have the
/// appropriate admin rights. Returns <see langword="true"/> on success.
/// </summary>
public class SetChatDescriptionRequest : RequestBase<bool>, IChatTargetable
{
    /// <inheritdoc />
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required ChatId ChatId { get; init; }

    /// <summary>
    /// New chat Description, 0-255 characters
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; set; }

    /// <summary>
    /// Initializes a new request
    /// </summary>
    public SetChatDescriptionRequest()
        : base("setChatDescription", TelegramBotClientJsonSerializerContext.Instance.SetChatDescriptionRequest)
    { }
}
