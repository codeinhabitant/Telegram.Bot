using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Serialization.EnumConverters;

internal class ChatActionConverter: JsonConverter<ChatAction>
{
    public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(ChatAction);

    public override ChatAction Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();

        return value switch
        {
            Constants.ChatAction.Typing => ChatAction.Typing,
            Constants.ChatAction.UploadPhoto => ChatAction.UploadPhoto,
            Constants.ChatAction.RecordVideo => ChatAction.RecordVideo,
            Constants.ChatAction.UploadVideo => ChatAction.UploadVideo,
            Constants.ChatAction.RecordVoice => ChatAction.RecordVoice,
            Constants.ChatAction.UploadVoice => ChatAction.UploadVoice,
            Constants.ChatAction.UploadDocument => ChatAction.UploadDocument,
            Constants.ChatAction.FindLocation => ChatAction.FindLocation,
            Constants.ChatAction.RecordVideoNote => ChatAction.RecordVideoNote,
            Constants.ChatAction.UploadVideoNote => ChatAction.UploadVideoNote,
            Constants.ChatAction.ChooseSticker => ChatAction.ChooseSticker,

            null or _ => ChatAction.FallbackUnsupported
        };
    }

    public override void Write(Utf8JsonWriter writer, ChatAction value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value switch
        {
            ChatAction.Typing => Constants.ChatAction.Typing,
            ChatAction.UploadPhoto => Constants.ChatAction.UploadPhoto,
            ChatAction.RecordVideo => Constants.ChatAction.RecordVideo,
            ChatAction.UploadVideo => Constants.ChatAction.UploadVideo,
            ChatAction.RecordVoice => Constants.ChatAction.RecordVoice,
            ChatAction.UploadVoice => Constants.ChatAction.UploadVoice,
            ChatAction.UploadDocument => Constants.ChatAction.UploadDocument,
            ChatAction.FindLocation => Constants.ChatAction.FindLocation,
            ChatAction.RecordVideoNote => Constants.ChatAction.RecordVideoNote,
            ChatAction.UploadVideoNote => Constants.ChatAction.UploadVideoNote,
            ChatAction.ChooseSticker => Constants.ChatAction.ChooseSticker,

            _ => throw new JsonException($"Unsupported ChatAction {value}")
        });

    }
}
