namespace Telegram.Bot.Serialization;

internal class BackgroundFillConverter : JsonConverter<BackgroundFill?>
{
    public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(BackgroundFill);

    public override BackgroundFill? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (!JsonDocument.TryParseValue(ref reader, out var element))
        {
            throw new JsonException("Could not read JSON value");
        }

        try
        {
            var root = element.RootElement;
            var type = root.GetProperty("type").GetString();

            return type switch
            {
                "solid" => JsonSerializer.Deserialize(root.GetRawText(), TelegramBotClientJsonSerializerContext.Instance.BackgroundFillSolid),
                "gradient" => JsonSerializer.Deserialize(root.GetRawText(), TelegramBotClientJsonSerializerContext.Instance.BackgroundFillGradient),
                "freeform_gradient" => JsonSerializer.Deserialize(root.GetRawText(), TelegramBotClientJsonSerializerContext.Instance.BackgroundFillFreeformGradient),
                null or _ => BackgroundFillFallbackUnsupported.Instance,
            };
        }
        finally
        {
            element.Dispose();
        }
    }

    public override void Write(Utf8JsonWriter writer, BackgroundFill? value, JsonSerializerOptions options)
    {
        if (value is not null)
        {
            writer.WriteRawValue(value switch
            {
                BackgroundFillSolid backgroundFillSolid =>
                    JsonSerializer.Serialize(backgroundFillSolid, TelegramBotClientJsonSerializerContext.Instance.BackgroundFillSolid),
                BackgroundFillGradient backgroundFillGradient =>
                    JsonSerializer.Serialize(backgroundFillGradient, TelegramBotClientJsonSerializerContext.Instance.BackgroundFillGradient),
                BackgroundFillFreeformGradient backgroundFillFreeformGradient =>
                    JsonSerializer.Serialize(backgroundFillFreeformGradient, TelegramBotClientJsonSerializerContext.Instance.BackgroundFillFreeformGradient),
                _ => throw new JsonException($"Unsupported BackgroundFill {value}")
            });
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
