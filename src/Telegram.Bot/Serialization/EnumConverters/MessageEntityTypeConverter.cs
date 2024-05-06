using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Serialization.EnumConverters;

internal class MessageEntityTypeConverter: JsonConverter<MessageEntityType>
{
    public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(MessageEntityType);

    public override MessageEntityType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();

        return value switch
        {
            Constants.MessageEntityType.CustomEmoji => MessageEntityType.CustomEmoji,
            Constants.MessageEntityType.BotCommand => MessageEntityType.BotCommand,
            Constants.MessageEntityType.Url => MessageEntityType.Url,
            Constants.MessageEntityType.Email => MessageEntityType.Email,
            Constants.MessageEntityType.Bold => MessageEntityType.Bold,
            Constants.MessageEntityType.Italic => MessageEntityType.Italic,
            Constants.MessageEntityType.Code => MessageEntityType.Code,
            Constants.MessageEntityType.Pre => MessageEntityType.Pre,
            Constants.MessageEntityType.TextLink => MessageEntityType.TextLink,
            Constants.MessageEntityType.TextMention => MessageEntityType.TextMention,
            Constants.MessageEntityType.Hashtag => MessageEntityType.Hashtag,
            Constants.MessageEntityType.Cashtag => MessageEntityType.Cashtag,
            Constants.MessageEntityType.PhoneNumber => MessageEntityType.PhoneNumber,
            Constants.MessageEntityType.Mention => MessageEntityType.Mention,
            Constants.MessageEntityType.Blockquote => MessageEntityType.Blockquote,
            Constants.MessageEntityType.Spoiler => MessageEntityType.Spoiler,
            Constants.MessageEntityType.Strikethrough => MessageEntityType.Strikethrough,
            Constants.MessageEntityType.Underline => MessageEntityType.Underline,

            null or _ => MessageEntityType.FallbackUnsupported
        };
    }

    public override void Write(Utf8JsonWriter writer, MessageEntityType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value switch
        {
            MessageEntityType.CustomEmoji => Constants.MessageEntityType.CustomEmoji,
            MessageEntityType.BotCommand => Constants.MessageEntityType.BotCommand,
            MessageEntityType.Url => Constants.MessageEntityType.Url,
            MessageEntityType.Email => Constants.MessageEntityType.Email,
            MessageEntityType.Bold => Constants.MessageEntityType.Bold,
            MessageEntityType.Italic => Constants.MessageEntityType.Italic,
            MessageEntityType.Code => Constants.MessageEntityType.Code,
            MessageEntityType.Pre => Constants.MessageEntityType.Pre,
            MessageEntityType.TextLink => Constants.MessageEntityType.TextLink,
            MessageEntityType.TextMention => Constants.MessageEntityType.TextMention,
            MessageEntityType.Hashtag => Constants.MessageEntityType.Hashtag,
            MessageEntityType.Cashtag => Constants.MessageEntityType.Cashtag,
            MessageEntityType.PhoneNumber => Constants.MessageEntityType.PhoneNumber,
            MessageEntityType.Mention => Constants.MessageEntityType.Mention,
            MessageEntityType.Blockquote => Constants.MessageEntityType.Blockquote,
            MessageEntityType.Spoiler => Constants.MessageEntityType.Spoiler,
            MessageEntityType.Strikethrough => Constants.MessageEntityType.Strikethrough,
            MessageEntityType.Underline => Constants.MessageEntityType.Underline,

            _ => throw new JsonException($"Unsupported MessageEntityType {value}")
        });
    }
}
