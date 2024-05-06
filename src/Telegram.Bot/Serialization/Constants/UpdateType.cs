namespace Telegram.Bot.Serialization.Constants;

internal sealed class UpdateType
{
    public const string Message = "message";
    public const string InlineQuery = "inline_query";
    public const string ChosenInlineResult = "chosen_inline_result";
    public const string CallbackQuery = "callback_query";
    public const string EditedMessage = "edited_message";
    public const string ChannelPost = "channel_post";
    public const string EditedChannelPost = "edited_channel_post";
    public const string ShippingQuery = "shipping_query";
    public const string PreCheckoutQuery = "pre_checkout_query";
    public const string Poll = "poll";
    public const string PollAnswer = "poll_answer";
    public const string MyChatMember = "my_chat_member";
    public const string ChatMember = "chat_member";
    public const string ChatJoinRequest = "chat_join_request";
    public const string MessageReaction = "message_reaction";
    public const string MessageReactionCount = "message_reaction_count";
    public const string ChatBoost = "chat_boost";
    public const string RemovedChatBoost = "removed_chat_boost";
    public const string BusinessConnection = "business_connection";
    public const string BusinessMessage = "business_message";
    public const string EditedBusinessMessage = "edited_business_message";
    public const string DeletedBusinessMessages = "deleted_business_messages";
}
