using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Serialization.EnumConverters;

internal class ParseModeConverter: JsonConverter<ParseMode>
{
    public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(ParseMode);

    public override ParseMode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();

        return value switch
        {
            Constants.ParseMode.Markdown => ParseMode.Markdown,
            Constants.ParseMode.Html => ParseMode.Html,
            Constants.ParseMode.MarkdownV2 => ParseMode.MarkdownV2,

            null or _ => ParseMode.FallbackUnsupported
        };
    }

    public override void Write(Utf8JsonWriter writer, ParseMode value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value switch
        {
            ParseMode.Markdown => Constants.ParseMode.Markdown,
            ParseMode.Html => Constants.ParseMode.Html,
            ParseMode.MarkdownV2 => Constants.ParseMode.MarkdownV2,

            _ => throw new JsonException($"Unsupported ParseMode {value}")
        });
    }
}
