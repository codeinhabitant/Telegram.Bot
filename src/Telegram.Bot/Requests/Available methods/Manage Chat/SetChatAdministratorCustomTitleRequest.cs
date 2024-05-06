using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to set a custom title for an administrator in a supergroup promoted by the bot.
/// Returns <see langword="true"/> on success.
/// </summary>
public class SetChatAdministratorCustomTitleRequest : RequestBase<bool>, IChatTargetable, IUserTargetable
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
    /// New custom title for the administrator; 0-16 characters, emoji are not allowed
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string CustomTitle { get; init; }

    /// <summary>
    /// Initializes a new request
    /// </summary>
    public SetChatAdministratorCustomTitleRequest()
        : base("setChatAdministratorCustomTitle", TelegramBotClientJsonSerializerContext.Instance.SetChatAdministratorCustomTitleRequest)
    { }
}
