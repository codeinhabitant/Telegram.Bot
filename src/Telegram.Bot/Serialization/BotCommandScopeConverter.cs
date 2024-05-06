namespace Telegram.Bot.Serialization;

internal class BotCommandScopeConverter : JsonConverter<BotCommandScope?>
{
    public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(BotCommandScope);

    public override BotCommandScope? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
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
                "default" => JsonSerializer.Deserialize(root.GetRawText(), TelegramBotClientJsonSerializerContext.Instance.BotCommandScopeDefault),
                "all_private_chats" => JsonSerializer.Deserialize(root.GetRawText(), TelegramBotClientJsonSerializerContext.Instance.BotCommandScopeAllPrivateChats),
                "all_group_chats" => JsonSerializer.Deserialize(root.GetRawText(), TelegramBotClientJsonSerializerContext.Instance.BotCommandScopeAllGroupChats),
                "all_chat_administrators" => JsonSerializer.Deserialize(root.GetRawText(), TelegramBotClientJsonSerializerContext.Instance.BotCommandScopeAllChatAdministrators),
                "chat" => JsonSerializer.Deserialize(root.GetRawText(), TelegramBotClientJsonSerializerContext.Instance.BotCommandScopeChat),
                "chat_administrators" => JsonSerializer.Deserialize(root.GetRawText(), TelegramBotClientJsonSerializerContext.Instance.BotCommandScopeChatAdministrators),
                "chat_member" => JsonSerializer.Deserialize(root.GetRawText(), TelegramBotClientJsonSerializerContext.Instance.BotCommandScopeChatMember),
                null or _ => BotCommandScopeFallbackUnsupported.Instance
            };
        }
        finally
        {
            element.Dispose();
        }
    }

    public override void Write(Utf8JsonWriter writer, BotCommandScope? value, JsonSerializerOptions options)
    {
        if (value is not null)
        {
            writer.WriteRawValue(value switch
            {
                BotCommandScopeDefault backgroundTypeFill =>
                    JsonSerializer.Serialize(backgroundTypeFill, TelegramBotClientJsonSerializerContext.Instance.BotCommandScopeDefault),
                BotCommandScopeAllPrivateChats backgroundTypeWallpaper =>
                    JsonSerializer.Serialize(backgroundTypeWallpaper, TelegramBotClientJsonSerializerContext.Instance.BotCommandScopeAllPrivateChats),
                BotCommandScopeAllGroupChats backgroundTypePattern =>
                    JsonSerializer.Serialize(backgroundTypePattern, TelegramBotClientJsonSerializerContext.Instance.BotCommandScopeAllGroupChats),
                BotCommandScopeAllChatAdministrators nBackgroundTypeChatTheme =>
                    JsonSerializer.Serialize(nBackgroundTypeChatTheme, TelegramBotClientJsonSerializerContext.Instance.BotCommandScopeAllChatAdministrators),
                BotCommandScopeChat nBackgroundTypeChatTheme =>
                    JsonSerializer.Serialize(nBackgroundTypeChatTheme, TelegramBotClientJsonSerializerContext.Instance.BotCommandScopeChat),
                BotCommandScopeChatAdministrators nBackgroundTypeChatTheme =>
                    JsonSerializer.Serialize(nBackgroundTypeChatTheme, TelegramBotClientJsonSerializerContext.Instance.BotCommandScopeChatAdministrators),
                BotCommandScopeChatMember nBackgroundTypeChatTheme =>
                    JsonSerializer.Serialize(nBackgroundTypeChatTheme, TelegramBotClientJsonSerializerContext.Instance.BotCommandScopeChatMember),
                _ => throw new JsonException($"Unsupported BotCommandScope {value}")
            });
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
