using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Serialization.EnumConverters;

internal class BotCommandScopeTypeConverter: JsonConverter<BotCommandScopeType>
{
    public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(BotCommandScopeType);

    public override BotCommandScopeType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();

        return value switch
        {
            Constants.BotCommandScopeType.Chat => BotCommandScopeType.Chat,
            Constants.BotCommandScopeType.ChatAdministrators => BotCommandScopeType.ChatAdministrators,
            Constants.BotCommandScopeType.ChatMember => BotCommandScopeType.ChatMember,
            Constants.BotCommandScopeType.AllChatAdministrators => BotCommandScopeType.AllChatAdministrators,
            Constants.BotCommandScopeType.AllGroupChats => BotCommandScopeType.AllGroupChats,
            Constants.BotCommandScopeType.AllPrivateChats => BotCommandScopeType.AllPrivateChats,
            Constants.BotCommandScopeType.Default => BotCommandScopeType.Default,

            null or _ => BotCommandScopeType.FallbackUnsupported
        };
    }

    public override void Write(Utf8JsonWriter writer, BotCommandScopeType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value switch
        {
            BotCommandScopeType.Chat => Constants.BotCommandScopeType.Chat,
            BotCommandScopeType.ChatAdministrators => Constants.BotCommandScopeType.ChatAdministrators,
            BotCommandScopeType.ChatMember => Constants.BotCommandScopeType.ChatMember,
            BotCommandScopeType.AllChatAdministrators => Constants.BotCommandScopeType.AllChatAdministrators,
            BotCommandScopeType.AllGroupChats => Constants.BotCommandScopeType.AllGroupChats,
            BotCommandScopeType.AllPrivateChats => Constants.BotCommandScopeType.AllPrivateChats,
            BotCommandScopeType.Default => Constants.BotCommandScopeType.Default,

            _ => throw new JsonException($"Unsupported BotCommandScopeType {value}")
        });
    }
}
