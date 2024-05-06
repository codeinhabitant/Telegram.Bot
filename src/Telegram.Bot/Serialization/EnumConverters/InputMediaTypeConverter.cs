using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Serialization.EnumConverters;

internal class InputMediaTypeConverter: JsonConverter<InputMediaType>
{
    public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(InputMediaType);

    public override InputMediaType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();

        return value switch
        {
            Constants.InputMediaType.Animation => InputMediaType.Animation,
            Constants.InputMediaType.Audio => InputMediaType.Audio,
            Constants.InputMediaType.Document => InputMediaType.Document,
            Constants.InputMediaType.Photo => InputMediaType.Photo,
            Constants.InputMediaType.Video => InputMediaType.Video,

            null or _ => InputMediaType.FallbackUnsupported
        };
    }

    public override void Write(Utf8JsonWriter writer, InputMediaType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value switch
        {
            InputMediaType.Animation => Constants.InputMediaType.Animation,
            InputMediaType.Audio => Constants.InputMediaType.Audio,
            InputMediaType.Document => Constants.InputMediaType.Document,
            InputMediaType.Photo => Constants.InputMediaType.Photo,
            InputMediaType.Video => Constants.InputMediaType.Video,

            _ => throw new JsonException($"Unsupported InputMediaType {value}")
        });
    }
}
