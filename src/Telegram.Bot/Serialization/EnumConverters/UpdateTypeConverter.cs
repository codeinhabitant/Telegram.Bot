using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Serialization.EnumConverters;

internal class UpdateTypeConverter: JsonConverter<UpdateType>
{
    public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(UpdateType);

    public override UpdateType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();

        return value switch
        {
            Constants.UpdateType.Message => UpdateType.Message,
            Constants.UpdateType.InlineQuery => UpdateType.InlineQuery,
            Constants.UpdateType.ChosenInlineResult => UpdateType.ChosenInlineResult,
            Constants.UpdateType.CallbackQuery => UpdateType.CallbackQuery,
            Constants.UpdateType.EditedMessage => UpdateType.EditedMessage,
            Constants.UpdateType.ChannelPost => UpdateType.ChannelPost,
            Constants.UpdateType.EditedChannelPost => UpdateType.EditedChannelPost,
            Constants.UpdateType.ShippingQuery => UpdateType.ShippingQuery,
            Constants.UpdateType.PreCheckoutQuery => UpdateType.PreCheckoutQuery,
            Constants.UpdateType.Poll => UpdateType.Poll,
            Constants.UpdateType.PollAnswer => UpdateType.PollAnswer,
            Constants.UpdateType.MyChatMember => UpdateType.MyChatMember,
            Constants.UpdateType.ChatMember => UpdateType.ChatMember,
            Constants.UpdateType.ChatJoinRequest => UpdateType.ChatJoinRequest,
            Constants.UpdateType.MessageReaction => UpdateType.MessageReaction,
            Constants.UpdateType.MessageReactionCount => UpdateType.MessageReactionCount,
            Constants.UpdateType.ChatBoost => UpdateType.ChatBoost,
            Constants.UpdateType.RemovedChatBoost => UpdateType.RemovedChatBoost,
            Constants.UpdateType.BusinessConnection => UpdateType.BusinessConnection,
            Constants.UpdateType.BusinessMessage => UpdateType.BusinessMessage,
            Constants.UpdateType.EditedBusinessMessage => UpdateType.EditedBusinessMessage,
            Constants.UpdateType.DeletedBusinessMessages => UpdateType.DeletedBusinessMessages,

            null or _ => UpdateType.FallbackUnsupported
        };
    }

    public override void Write(Utf8JsonWriter writer, UpdateType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value switch
        {
            UpdateType.Message => Constants.UpdateType.Message,
            UpdateType.InlineQuery => Constants.UpdateType.InlineQuery,
            UpdateType.ChosenInlineResult => Constants.UpdateType.ChosenInlineResult,
            UpdateType.CallbackQuery => Constants.UpdateType.CallbackQuery,
            UpdateType.EditedMessage => Constants.UpdateType.EditedMessage,
            UpdateType.ChannelPost => Constants.UpdateType.ChannelPost,
            UpdateType.EditedChannelPost => Constants.UpdateType.EditedChannelPost,
            UpdateType.ShippingQuery => Constants.UpdateType.ShippingQuery,
            UpdateType.PreCheckoutQuery => Constants.UpdateType.PreCheckoutQuery,
            UpdateType.Poll => Constants.UpdateType.Poll,
            UpdateType.PollAnswer => Constants.UpdateType.PollAnswer,
            UpdateType.MyChatMember => Constants.UpdateType.MyChatMember,
            UpdateType.ChatMember => Constants.UpdateType.ChatMember,
            UpdateType.ChatJoinRequest => Constants.UpdateType.ChatJoinRequest,
            UpdateType.MessageReaction => Constants.UpdateType.MessageReaction,
            UpdateType.MessageReactionCount => Constants.UpdateType.MessageReactionCount,
            UpdateType.ChatBoost => Constants.UpdateType.ChatBoost,
            UpdateType.RemovedChatBoost => Constants.UpdateType.RemovedChatBoost,
            UpdateType.BusinessConnection => Constants.UpdateType.BusinessConnection,
            UpdateType.BusinessMessage => Constants.UpdateType.BusinessMessage,
            UpdateType.EditedBusinessMessage => Constants.UpdateType.EditedBusinessMessage,
            UpdateType.DeletedBusinessMessages => Constants.UpdateType.DeletedBusinessMessages,

            _ => throw new JsonException($"Unsupported UpdateType {value}")
        });
    }
}
