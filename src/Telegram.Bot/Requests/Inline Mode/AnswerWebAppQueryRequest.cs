using Telegram.Bot.Types.InlineQueryResults;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to set the result of an interaction with a
/// <a href="https://core.telegram.org/bots/webapps">Web App</a> and send a corresponding message on behalf of the
/// user to the chat from which the query originated. On success, a <see cref="SentWebAppMessage"/> object is returned.
/// </summary>
public class AnswerWebAppQueryRequest : RequestBase<SentWebAppMessage>
{
    /// <summary>
    /// Unique identifier for the query to be answered
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string WebAppQueryId { get; init; }

    /// <summary>
    /// An object describing the message to be sent
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required InlineQueryResult Result { get; init; }

    /// <summary>
    /// Initializes a new request
    /// </summary>
    public AnswerWebAppQueryRequest()
        : base("answerWebAppQuery", TelegramBotClientJsonSerializerContext.Instance.AnswerWebAppQueryRequest)
    { }
}
