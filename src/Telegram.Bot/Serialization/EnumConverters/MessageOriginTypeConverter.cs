using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Serialization.EnumConverters;

internal class MessageOriginTypeConverter: JsonConverter<MessageOriginType>
{
    public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(MessageOriginType);

    public override MessageOriginType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();

        return value switch
        {
            Constants.MessageOriginType.User => MessageOriginType.User,
            Constants.MessageOriginType.HiddenUser => MessageOriginType.HiddenUser,
            Constants.MessageOriginType.Chat => MessageOriginType.Chat,
            Constants.MessageOriginType.Channel => MessageOriginType.Channel,

            null or _ => MessageOriginType.FallbackUnsupported
        };
    }

    public override void Write(Utf8JsonWriter writer, MessageOriginType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value switch
        {
            MessageOriginType.User => Constants.MessageOriginType.User,
            MessageOriginType.HiddenUser => Constants.MessageOriginType.HiddenUser,
            MessageOriginType.Chat => Constants.MessageOriginType.Chat,
            MessageOriginType.Channel => Constants.MessageOriginType.Channel,

            _ => throw new JsonException($"Unsupported MessageOriginType {value}")
        });
    }
}
