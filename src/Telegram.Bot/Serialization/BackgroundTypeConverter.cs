namespace Telegram.Bot.Serialization;

public class BackgroundTypeConverter: JsonConverter<BackgroundType?>
{
    public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(BackgroundType);

    public override BackgroundType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (!JsonDocument.TryParseValue(ref reader, out var element))
        {
            throw new JsonException("Could not read JSON value");
        }

        try
        {
            var root = element.RootElement;
            var type = root.GetProperty("type").GetString() ?? throw new JsonException("Type property not found");

            return type switch
            {
                "fill" => JsonSerializer.Deserialize(root.GetRawText(), TelegramBotClientJsonSerializerContext.Instance.BackgroundTypeFill),
                "wallpaper" => JsonSerializer.Deserialize(root.GetRawText(), TelegramBotClientJsonSerializerContext.Instance.BackgroundTypeWallpaper),
                "pattern" => JsonSerializer.Deserialize(root.GetRawText(), TelegramBotClientJsonSerializerContext.Instance.BackgroundTypePattern),
                "chat_theme" => JsonSerializer.Deserialize(root.GetRawText(), TelegramBotClientJsonSerializerContext.Instance.BackgroundTypeChatTheme),
                null => null,
                _ => throw new JsonException($"Unsupported background type: {type}")
            };
        }
        finally
        {
            element.Dispose();
        }
    }

    public override void Write(Utf8JsonWriter writer, BackgroundType? value, JsonSerializerOptions options)
    {
        if (value is not null)
        {
            writer.WriteRawValue(value switch
            {
                BackgroundTypeFill backgroundTypeFill =>
                    JsonSerializer.Serialize(backgroundTypeFill, TelegramBotClientJsonSerializerContext.Instance.BackgroundTypeFill),
                BackgroundTypeWallpaper backgroundTypeWallpaper =>
                    JsonSerializer.Serialize(backgroundTypeWallpaper, TelegramBotClientJsonSerializerContext.Instance.BackgroundTypeWallpaper),
                BackgroundTypePattern backgroundTypePattern =>
                    JsonSerializer.Serialize(backgroundTypePattern, TelegramBotClientJsonSerializerContext.Instance.BackgroundTypePattern),
                BackgroundTypeChatTheme nBackgroundTypeChatTheme =>
                    JsonSerializer.Serialize(nBackgroundTypeChatTheme, TelegramBotClientJsonSerializerContext.Instance.BackgroundTypeChatTheme),
                _ => throw new JsonException("Unsupported background type")
            });
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
