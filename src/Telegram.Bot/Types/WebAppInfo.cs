namespace Telegram.Bot.Types;

/// <summary>
/// Contains information about a <a href="https://core.telegram.org/bots/webapps ">Web App</a>
/// </summary>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class WebAppInfo
{
    /// <summary>
    /// An HTTPS URL of a Web App to be opened with additional data as specified in
    /// <a href="https://core.telegram.org/bots/webapps#initializing-web-apps">Initializing Web Apps</a>
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string Url { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="WebAppInfo"/> class with url
    /// </summary>
    /// <param name="url">
    /// An HTTPS URL of a Web App to be opened with additional data as specified in
    /// <a href="https://core.telegram.org/bots/webapps#initializing-web-apps">Initializing Web Apps</a>
    /// </param>
    public WebAppInfo(string url)
    {
        Url = url;
    }
}
