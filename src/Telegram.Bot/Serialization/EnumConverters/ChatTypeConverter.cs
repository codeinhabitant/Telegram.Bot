using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Serialization.EnumConverters;

internal class ChatTypeConverter: JsonConverter<ChatType>
{
    public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(ChatType);

    public override ChatType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();

        return value switch
        {
            Constants.ChatType.Channel => ChatType.Channel,
            Constants.ChatType.Group => ChatType.Group,
            Constants.ChatType.Private => ChatType.Private,
            Constants.ChatType.Supergroup => ChatType.Supergroup,
            Constants.ChatType.Sender => ChatType.Sender,

            null or _ => ChatType.FallbackUnsupported
        };
    }

    public override void Write(Utf8JsonWriter writer, ChatType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value switch
        {
            ChatType.Channel => Constants.ChatType.Channel,
            ChatType.Group => Constants.ChatType.Group,
            ChatType.Private => Constants.ChatType.Private,
            ChatType.Supergroup => Constants.ChatType.Supergroup,
            ChatType.Sender => Constants.ChatType.Sender,

            _ => throw new JsonException($"Unsupported ChatType {value}")
        });
    }
}
