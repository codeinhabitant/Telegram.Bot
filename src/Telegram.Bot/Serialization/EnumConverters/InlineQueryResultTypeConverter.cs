using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;

namespace Telegram.Bot.Serialization.EnumConverters;

internal class InlineQueryResultTypeConverter: JsonConverter<InlineQueryResultType>
{
    public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(InlineQueryResultType);

    public override InlineQueryResultType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();

        return value switch
        {
            Constants.InlineQueryResultType.Article => InlineQueryResultType.Article,
            Constants.InlineQueryResultType.Photo => InlineQueryResultType.Photo,
            Constants.InlineQueryResultType.Gif => InlineQueryResultType.Gif,
            Constants.InlineQueryResultType.Mpeg4Gif => InlineQueryResultType.Mpeg4Gif,
            Constants.InlineQueryResultType.Video => InlineQueryResultType.Video,
            Constants.InlineQueryResultType.Audio => InlineQueryResultType.Audio,
            Constants.InlineQueryResultType.Contact => InlineQueryResultType.Contact,
            Constants.InlineQueryResultType.Document => InlineQueryResultType.Document,
            Constants.InlineQueryResultType.Location => InlineQueryResultType.Location,
            Constants.InlineQueryResultType.Venue => InlineQueryResultType.Venue,
            Constants.InlineQueryResultType.Voice => InlineQueryResultType.Voice,
            Constants.InlineQueryResultType.Game => InlineQueryResultType.Game,
            Constants.InlineQueryResultType.Sticker => InlineQueryResultType.Sticker,

            null or _ => InlineQueryResultType.FallbackUnsupported
        };
    }

    public override void Write(Utf8JsonWriter writer, InlineQueryResultType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value switch
        {
            InlineQueryResultType.Article => Constants.InlineQueryResultType.Article,
            InlineQueryResultType.Photo => Constants.InlineQueryResultType.Photo,
            InlineQueryResultType.Gif => Constants.InlineQueryResultType.Gif,
            InlineQueryResultType.Mpeg4Gif => Constants.InlineQueryResultType.Mpeg4Gif,
            InlineQueryResultType.Video => Constants.InlineQueryResultType.Video,
            InlineQueryResultType.Audio => Constants.InlineQueryResultType.Audio,
            InlineQueryResultType.Contact => Constants.InlineQueryResultType.Contact,
            InlineQueryResultType.Document => Constants.InlineQueryResultType.Document,
            InlineQueryResultType.Location => Constants.InlineQueryResultType.Location,
            InlineQueryResultType.Venue => Constants.InlineQueryResultType.Venue,
            InlineQueryResultType.Voice => Constants.InlineQueryResultType.Voice,
            InlineQueryResultType.Game => Constants.InlineQueryResultType.Game,
            InlineQueryResultType.Sticker => Constants.InlineQueryResultType.Sticker,

            _ => throw new JsonException($"Unsupported InlineQueryResultType {value}")
        });
    }
}
