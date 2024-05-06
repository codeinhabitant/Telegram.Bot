using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types;

/// <summary>
/// This object represents the scope to which bot commands are applied
/// </summary>
public abstract class BotCommandScope
{
    /// <summary>
    /// Scope type
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public abstract BotCommandScopeType? Type { get; }
}

public class BotCommandScopeFallbackUnsupported : BotCommandScope
{
    /// <inheritdoc />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override BotCommandScopeType? Type => BotCommandScopeType.FallbackUnsupported;

    private BotCommandScopeFallbackUnsupported() {}

    /// <summary>
    /// For optimization purposes, use this instance instead of creating a new one.
    /// </summary>
    public static BotCommandScopeFallbackUnsupported Instance { get; } = new();
}

/// <inheritdoc cref="BotCommandScopeType.Default"/>
public class BotCommandScopeDefault : BotCommandScope
{
    /// <inheritdoc />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override BotCommandScopeType? Type => BotCommandScopeType.Default;
}

/// <inheritdoc cref="BotCommandScopeType.AllPrivateChats"/>
public class BotCommandScopeAllPrivateChats : BotCommandScope
{
    /// <inheritdoc />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override BotCommandScopeType? Type => BotCommandScopeType.AllPrivateChats;
}

/// <inheritdoc cref="BotCommandScopeType.AllGroupChats"/>
public class BotCommandScopeAllGroupChats : BotCommandScope
{
    /// <inheritdoc />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override BotCommandScopeType? Type => BotCommandScopeType.AllGroupChats;
}

/// <inheritdoc cref="BotCommandScopeType.AllChatAdministrators"/>
public class BotCommandScopeAllChatAdministrators : BotCommandScope
{
    /// <inheritdoc />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override BotCommandScopeType? Type => BotCommandScopeType.AllChatAdministrators;
}

/// <inheritdoc cref="BotCommandScopeType.Chat"/>
public class BotCommandScopeChat : BotCommandScope
{
    /// <inheritdoc />
    public override BotCommandScopeType? Type => BotCommandScopeType.Chat;

    /// <summary>
    /// Unique identifier for the target <see cref="Chat"/> or username of the target supergroup
    /// (in the format @supergroupusername)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public ChatId ChatId { get; set; } = default!;
}

/// <inheritdoc cref="BotCommandScopeType.ChatAdministrators"/>
public class BotCommandScopeChatAdministrators : BotCommandScope
{
    /// <inheritdoc />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override BotCommandScopeType? Type => BotCommandScopeType.ChatAdministrators;

    /// <summary>
    /// Unique identifier for the target <see cref="Chat"/> or username of the target supergroup
    /// (in the format @supergroupusername)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public ChatId ChatId { get; set; } = default!;
}

/// <inheritdoc cref="BotCommandScopeType.ChatMember"/>
public class BotCommandScopeChatMember : BotCommandScope
{
    /// <inheritdoc />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override BotCommandScopeType? Type => BotCommandScopeType.ChatMember;

    /// <summary>
    /// Unique identifier for the target <see cref="Chat"/> or username of the target supergroup
    /// (in the format @supergroupusername)
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public ChatId ChatId { get; set; } = default!;

    /// <summary>
    /// Unique identifier of the target user
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public long UserId { get; set; }
}
