using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Serialization.EnumConverters;

internal class ChatBoostSourceTypeConverter: JsonConverter<ChatBoostSourceType>
{
    public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(ChatBoostSourceType);

    public override ChatBoostSourceType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();

        return value switch
        {
            Constants.ChatBoostSourceType.Giveaway => ChatBoostSourceType.Giveaway,
            Constants.ChatBoostSourceType.Premium => ChatBoostSourceType.Premium,
            Constants.ChatBoostSourceType.GiftCode => ChatBoostSourceType.GiftCode,

            null or _ => ChatBoostSourceType.FallbackUnsupported
        };
    }

    public override void Write(Utf8JsonWriter writer, ChatBoostSourceType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value switch
        {
            ChatBoostSourceType.Giveaway => Constants.ChatBoostSourceType.Giveaway,
            ChatBoostSourceType.Premium => Constants.ChatBoostSourceType.Premium,
            ChatBoostSourceType.GiftCode => Constants.ChatBoostSourceType.GiftCode,

            _ => throw new JsonException($"Unsupported ChatBoostSourceType {value}")
        });
    }
}
