using Telegram.Bot.Types.Enums;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types;

/// <summary>
/// This object represents the content of a media message to be sent
/// </summary>
public class InputMediaFallbackUnsupported : InputMedia
{
    /// <summary>
    /// Type of the media
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override InputMediaType Type => InputMediaType.FallbackUnsupported;

    /// <summary>
    /// Initialize an object
    /// </summary>
    public InputMediaFallbackUnsupported()
    { }
}
