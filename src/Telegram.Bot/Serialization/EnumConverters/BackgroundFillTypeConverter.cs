using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Serialization.EnumConverters;

internal class BackgroundFillTypeConverter: JsonConverter<BackgroundFillType>
{
    public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(BackgroundFillType);

    public override BackgroundFillType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();

        return value switch
        {
            Constants.BackgroundFillType.Solid => BackgroundFillType.Solid,
            Constants.BackgroundFillType.Gradient => BackgroundFillType.Gradient,
            Constants.BackgroundFillType.FreeformGradient => BackgroundFillType.FreeformGradient,

            null or _ => BackgroundFillType.FallbackUnsupported
        };
    }

    public override void Write(Utf8JsonWriter writer, BackgroundFillType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value switch
        {
            BackgroundFillType.Solid => Constants.BackgroundFillType.Solid,
            BackgroundFillType.Gradient => Constants.BackgroundFillType.Gradient,
            BackgroundFillType.FreeformGradient => Constants.BackgroundFillType.FreeformGradient,

            _ => throw new JsonException($"Unsupported BackgroundFillType {value}")
        });
    }
}
