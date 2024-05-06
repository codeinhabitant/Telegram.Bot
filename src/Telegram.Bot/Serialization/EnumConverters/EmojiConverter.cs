using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Serialization.EnumConverters;

internal class EmojiConverter: JsonConverter<Emoji>
{
    public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(Emoji);

    public override Emoji Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();

        return value switch
        {
            Constants.Emoji.Basketball => Emoji.Basketball,
            Constants.Emoji.Football => Emoji.Football,
            Constants.Emoji.Dice => Emoji.Dice,
            Constants.Emoji.Darts => Emoji.Darts,
            Constants.Emoji.SlotMachine => Emoji.SlotMachine,
            Constants.Emoji.Bowling => Emoji.Bowling,

            null or _ => Emoji.FallbackUnsupported
        };
    }

    public override void Write(Utf8JsonWriter writer, Emoji value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value switch
        {
            Emoji.Basketball => Constants.Emoji.Basketball,
            Emoji.Football => Constants.Emoji.Football,
            Emoji.Dice => Constants.Emoji.Dice,
            Emoji.Darts => Constants.Emoji.Darts,
            Emoji.SlotMachine => Constants.Emoji.SlotMachine,
            Emoji.Bowling => Constants.Emoji.Bowling,

            _ => throw new JsonException($"Unsupported Emoji {value}")
        });
    }
}
