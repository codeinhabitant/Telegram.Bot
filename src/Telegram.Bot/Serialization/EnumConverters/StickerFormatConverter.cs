using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Serialization.EnumConverters;

internal class StickerFormatConverter: JsonConverter<StickerFormat>
{
    public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(StickerFormat);

    public override StickerFormat Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();

        return value switch
        {
            Constants.StickerFormat.Animated => StickerFormat.Animated,
            Constants.StickerFormat.Video => StickerFormat.Video,
            Constants.StickerFormat.Static => StickerFormat.Static,

            null or _ => StickerFormat.FallbackUnsupported
        };
    }

    public override void Write(Utf8JsonWriter writer, StickerFormat value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value switch
        {
            StickerFormat.Animated => Constants.StickerFormat.Animated,
            StickerFormat.Video => Constants.StickerFormat.Video,
            StickerFormat.Static => Constants.StickerFormat.Static,

            _ => throw new JsonException($"Unsupported StickerFormat {value}")
        });
    }
}
