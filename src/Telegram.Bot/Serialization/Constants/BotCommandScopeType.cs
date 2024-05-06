namespace Telegram.Bot.Serialization.Constants;

internal sealed class BotCommandScopeType
{
    public const string Default = "default";
    public const string AllPrivateChats = "all_private_chats";
    public const string AllGroupChats = "all_group_chats";
    public const string AllChatAdministrators = "all_chat_administrators";
    public const string Chat = "chat";
    public const string ChatAdministrators = "chat_administrators";
    public const string ChatMember = "chat_member";
}
