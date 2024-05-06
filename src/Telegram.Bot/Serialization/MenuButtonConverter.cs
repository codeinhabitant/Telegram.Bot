namespace Telegram.Bot.Serialization;

internal class MenuButtonConverter : JsonConverter<MenuButton?>
{
    public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(MenuButton);

    public override MenuButton? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
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
                "default" => JsonSerializer.Deserialize(root.GetRawText(), TelegramBotClientJsonSerializerContext.Instance.MenuButtonDefault),
                "commands" => JsonSerializer.Deserialize(root.GetRawText(), TelegramBotClientJsonSerializerContext.Instance.MenuButtonCommands),
                "web_app" => JsonSerializer.Deserialize(root.GetRawText(), TelegramBotClientJsonSerializerContext.Instance.MenuButtonWebApp),
                null or _ => MenuButtonFallbackUnsupported.Instance
            };
        }
        finally
        {
            element.Dispose();
        }
    }

    public override void Write(Utf8JsonWriter writer, MenuButton? value, JsonSerializerOptions options)
    {
        if (value is not null)
        {
            writer.WriteRawValue(value switch
            {
                MenuButtonDefault menuButtonDefault =>
                    JsonSerializer.Serialize(menuButtonDefault, TelegramBotClientJsonSerializerContext.Instance.MenuButtonDefault),
                MenuButtonCommands menuButtonCommands =>
                    JsonSerializer.Serialize(menuButtonCommands, TelegramBotClientJsonSerializerContext.Instance.MenuButtonCommands),
                MenuButtonWebApp menuButtonWebApp =>
                    JsonSerializer.Serialize(menuButtonWebApp, TelegramBotClientJsonSerializerContext.Instance.MenuButtonWebApp),
                _ => throw new JsonException($"Unsupported MenuButton {value}")
            });
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
