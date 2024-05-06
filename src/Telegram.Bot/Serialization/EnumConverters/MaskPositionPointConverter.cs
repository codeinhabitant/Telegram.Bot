using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Serialization.EnumConverters;

internal class MaskPositionPointConverter: JsonConverter<MaskPositionPoint>
{
    public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(MaskPositionPoint);

    public override MaskPositionPoint Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();

        return value switch
        {
            Constants.MaskPositionPoint.Chin => MaskPositionPoint.Chin,
            Constants.MaskPositionPoint.Eyes => MaskPositionPoint.Eyes,
            Constants.MaskPositionPoint.Forehead => MaskPositionPoint.Forehead,
            Constants.MaskPositionPoint.Mouth => MaskPositionPoint.Mouth,

            null or _ => MaskPositionPoint.FallbackUnsupported
        };
    }

    public override void Write(Utf8JsonWriter writer, MaskPositionPoint value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value switch
        {
            MaskPositionPoint.Chin => Constants.MaskPositionPoint.Chin,
            MaskPositionPoint.Eyes => Constants.MaskPositionPoint.Eyes,
            MaskPositionPoint.Forehead => Constants.MaskPositionPoint.Forehead,
            MaskPositionPoint.Mouth => Constants.MaskPositionPoint.Mouth,

            _ => throw new JsonException($"Unsupported MaskPositionPoint {value}")
        });
    }
}
