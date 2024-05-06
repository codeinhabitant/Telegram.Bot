using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Serialization.EnumConverters;

internal class BackgroundTypeKindConverter: JsonConverter<BackgroundTypeKind>
{
    public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(BackgroundTypeKind);

    public override BackgroundTypeKind Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();

        return value switch
        {
            Constants.BackgroundTypeKind.Fill => BackgroundTypeKind.Fill,
            Constants.BackgroundTypeKind.Pattern => BackgroundTypeKind.Pattern,
            Constants.BackgroundTypeKind.Wallpaper => BackgroundTypeKind.Wallpaper,
            Constants.BackgroundTypeKind.ChatTheme => BackgroundTypeKind.ChatTheme,

            null or _ => BackgroundTypeKind.FallbackUnsupported
        };
    }

    public override void Write(Utf8JsonWriter writer, BackgroundTypeKind value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value switch
        {
            BackgroundTypeKind.Fill => Constants.BackgroundTypeKind.Fill,
            BackgroundTypeKind.Pattern => Constants.BackgroundTypeKind.Pattern,
            BackgroundTypeKind.Wallpaper => Constants.BackgroundTypeKind.Wallpaper,
            BackgroundTypeKind.ChatTheme => Constants.BackgroundTypeKind.ChatTheme,

            _ => throw new JsonException($"Unsupported BackgroundTypeKind {value}")
        });
    }
}
