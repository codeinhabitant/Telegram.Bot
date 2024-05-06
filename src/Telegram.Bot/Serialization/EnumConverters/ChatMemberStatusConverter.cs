using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Serialization.EnumConverters;

internal class ChatMemberStatusConverter: JsonConverter<ChatMemberStatus>
{
    public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(ChatMemberStatus);

    public override ChatMemberStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();

        return value switch
        {
            Constants.ChatMemberStatus.Member => ChatMemberStatus.Member,
            Constants.ChatMemberStatus.Administrator => ChatMemberStatus.Administrator,
            Constants.ChatMemberStatus.Creator => ChatMemberStatus.Creator,
            Constants.ChatMemberStatus.Restricted => ChatMemberStatus.Restricted,
            Constants.ChatMemberStatus.Left => ChatMemberStatus.Left,
            Constants.ChatMemberStatus.Kicked => ChatMemberStatus.Kicked,

            null or _ => ChatMemberStatus.FallbackUnsupported
        };
    }

    public override void Write(Utf8JsonWriter writer, ChatMemberStatus value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value switch
        {
            ChatMemberStatus.Member => Constants.ChatMemberStatus.Member,
            ChatMemberStatus.Administrator => Constants.ChatMemberStatus.Administrator,
            ChatMemberStatus.Creator => Constants.ChatMemberStatus.Creator,
            ChatMemberStatus.Restricted => Constants.ChatMemberStatus.Restricted,
            ChatMemberStatus.Left => Constants.ChatMemberStatus.Left,
            ChatMemberStatus.Kicked => Constants.ChatMemberStatus.Kicked,

            _ => throw new JsonException($"Unsupported ChatMemberStatus {value}")
        });
    }
}
