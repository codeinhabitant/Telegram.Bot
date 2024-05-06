using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Serialization.EnumConverters;

internal class ReactionTypeKindConverter: JsonConverter<ReactionTypeKind>
{
    public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(ReactionTypeKind);

    public override ReactionTypeKind Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();

        return value switch
        {
            Constants.ReactionTypeKind.Emoji => ReactionTypeKind.Emoji,
            Constants.ReactionTypeKind.CustomEmoji => ReactionTypeKind.CustomEmoji,

            null or _ => ReactionTypeKind.FallbackUnsupported
        };
    }

    public override void Write(Utf8JsonWriter writer, ReactionTypeKind value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value switch
        {
           ReactionTypeKind.Emoji => Constants.ReactionTypeKind.Emoji,
           ReactionTypeKind.CustomEmoji => Constants.ReactionTypeKind.CustomEmoji,

            _ => throw new JsonException($"Unsupported ReactionTypeKind {value}")
        });
    }
}
