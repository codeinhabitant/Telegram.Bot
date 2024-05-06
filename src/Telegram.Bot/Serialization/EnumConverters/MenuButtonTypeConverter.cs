using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Serialization.EnumConverters;

internal class MenuButtonTypeConverter: JsonConverter<MenuButtonType>
{
    public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(MenuButtonType);

    public override MenuButtonType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();

        return value switch
        {
            Constants.MenuButtonType.Default => MenuButtonType.Default,
            Constants.MenuButtonType.Commands => MenuButtonType.Commands,
            Constants.MenuButtonType.WebApp => MenuButtonType.WebApp,

            null or _ => MenuButtonType.FallbackUnsupported
        };
    }

    public override void Write(Utf8JsonWriter writer, MenuButtonType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value switch
        {
            MenuButtonType.Default => Constants.MenuButtonType.Default,
            MenuButtonType.Commands => Constants.MenuButtonType.Commands,
            MenuButtonType.WebApp => Constants.MenuButtonType.WebApp,

            _ => throw new JsonException($"Unsupported MenuButtonType {value}")
        });
    }
}
