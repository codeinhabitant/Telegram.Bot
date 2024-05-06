using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Serialization.EnumConverters;

internal class PollTypeConverter: JsonConverter<PollType>
{
    public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(PollType);

    public override PollType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();

        return value switch
        {
            Constants.PollType.Quiz => PollType.Quiz,
            Constants.PollType.Regular => PollType.Regular,

            null or _ => PollType.FallbackUnsupported
        };
    }

    public override void Write(Utf8JsonWriter writer, PollType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value switch
        {
            PollType.Quiz => Constants.PollType.Quiz,
            PollType.Regular => Constants.PollType.Regular,

            _ => throw new JsonException($"Unsupported PollType {value}")
        });
    }
}
