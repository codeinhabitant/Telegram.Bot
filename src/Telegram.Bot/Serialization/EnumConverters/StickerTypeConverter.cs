using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Serialization.EnumConverters;

internal class StickerTypeConverter: JsonConverter<StickerType>
{
    public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(StickerType);

    public override StickerType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();

        return value switch
        {
            Constants.StickerType.Regular => StickerType.Regular,
            Constants.StickerType.Mask => StickerType.Mask,
            Constants.StickerType.CustomEmoji => StickerType.CustomEmoji,

            null or _ => StickerType.FallbackUnsupported
        };
    }

    public override void Write(Utf8JsonWriter writer, StickerType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value switch
        {
            StickerType.Regular => Constants.StickerType.Regular,
            StickerType.Mask => Constants.StickerType.Mask,
            StickerType.CustomEmoji => Constants.StickerType.CustomEmoji,

            _ => throw new JsonException($"Unsupported StickerType {value}")
        });

    }
}
