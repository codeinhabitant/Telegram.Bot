using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to unban a previously banned user in a supergroup or channel. The user will
/// <b>not</b> return to the group or channel automatically, but will be able to join via link,
/// etc. The bot must be an administrator for this to work. By default, this method guarantees
/// that after the call the user is not a member of the chat, but will be able to join it.
/// So if the user is a member of the chat they will also be <b>removed</b> from the chat.
/// If you don't want this, use the parameter <see cref="OnlyIfBanned"/>. Returns <see langword="true"/> on success.
/// </summary>
public class UnbanChatMemberRequest : RequestBase<bool>, IChatTargetable, IUserTargetable
{
    /// <inheritdoc />
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required ChatId ChatId { get; init; }

    /// <inheritdoc />
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required long UserId { get; init; }

    /// <summary>
    /// Do nothing if the user is not banned
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? OnlyIfBanned { get; set; }

    /// <summary>
    /// Initializes a new request
    /// </summary>
    public UnbanChatMemberRequest()
        : base("unbanChatMember", TelegramBotClientJsonSerializerContext.Instance.UnbanChatMemberRequest)
    { }
}
