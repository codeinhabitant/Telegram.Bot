// ReSharper disable once CheckNamespace

using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types;

/// <summary>
/// Base Class describes the type of a background/>
/// </summary>
public abstract class BackgroundType
{
    /// <summary>
    /// Type of the background
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public abstract BackgroundTypeType Type { get; }
}
