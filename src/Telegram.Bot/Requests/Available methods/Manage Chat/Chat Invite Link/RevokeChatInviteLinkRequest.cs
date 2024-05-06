using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to revoke an invite link created by the bot. If the primary link is revoked, a new
/// link is automatically generated. The bot must be an administrator in the chat for this to work and
/// must have the appropriate admin rights. Returns the revoked invite link as
/// <see cref="ChatInviteLink"/> object.
/// </summary>
public class RevokeChatInviteLinkRequest : RequestBase<ChatInviteLink>, IChatTargetable
{
    /// <inheritdoc />
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required ChatId ChatId { get; init; }

    /// <summary>
    /// The invite link to revoke
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string InviteLink { get; init; }

    /// <summary>
    /// Initializes a new request with chatId and inviteLink
    /// </summary>
    public RevokeChatInviteLinkRequest()
        : base("revokeChatInviteLink", TelegramBotClientJsonSerializerContext.Instance.RevokeChatInviteLinkRequest)
    { }
}
