namespace Telegram.Bot.Serialization;

internal class ChatBoostSourceConverter : JsonConverter<ChatBoostSource?>
{
    public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(ChatBoostSource);

    public override ChatBoostSource? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (!JsonDocument.TryParseValue(ref reader, out var element))
        {
            throw new JsonException("Could not read JSON value");
        }

        try
        {
            var root = element.RootElement;
            var source = root.GetProperty("source").GetString();

            return source switch
            {
                "premium" => JsonSerializer.Deserialize(root.GetRawText(), TelegramBotClientJsonSerializerContext.Instance.ChatBoostSourcePremium),
                "gift_code" => JsonSerializer.Deserialize(root.GetRawText(), TelegramBotClientJsonSerializerContext.Instance.ChatBoostSourceGiftCode),
                "giveaway" => JsonSerializer.Deserialize(root.GetRawText(), TelegramBotClientJsonSerializerContext.Instance.ChatBoostSourceGiveaway),
                null or _ => ChatBoostSourceFallbackUnsupported.Instance
            };
        }
        finally
        {
            element.Dispose();
        }
    }

    public override void Write(Utf8JsonWriter writer, ChatBoostSource? value, JsonSerializerOptions options)
    {
        if (value is not null)
        {
            writer.WriteRawValue(value switch
            {
                ChatBoostSourcePremium premium => JsonSerializer.Serialize(premium, TelegramBotClientJsonSerializerContext.Instance.ChatBoostSourcePremium),
                ChatBoostSourceGiftCode giftCode => JsonSerializer.Serialize(giftCode, TelegramBotClientJsonSerializerContext.Instance.ChatBoostSourceGiftCode),
                ChatBoostSourceGiveaway giveaway => JsonSerializer.Serialize(giveaway, TelegramBotClientJsonSerializerContext.Instance.ChatBoostSourceGiveaway),
                _ => throw new JsonException($"Unsupported ChatBoostSource {value}")
            });
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
