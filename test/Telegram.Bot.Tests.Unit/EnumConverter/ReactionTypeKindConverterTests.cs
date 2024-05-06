using System.Collections;
using System.Collections.Generic;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Xunit;

namespace Telegram.Bot.Tests.Unit.EnumConverter;

public class ReactionTypeKindConverterTests
{
    [Theory]
    [ClassData(typeof(ReactionTypeData))]
    public void Should_Convert_ReactionType_To_String(ReactionType container, string expectedResult)
    {
        string result = JsonSerializer.Serialize(container, TelegramBotClientJsonSerializerContext.Instance.ReactionType);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [ClassData(typeof(ReactionTypeData))]
    public void Should_Convert_String_ToReactionType(ReactionType expectedResult, string value)
    {
        ReactionType? result = JsonSerializer.Deserialize(value, TelegramBotClientJsonSerializerContext.Instance.ReactionType);

        Assert.NotNull(result);
        Assert.Equal(expectedResult.Type, result.Type);
    }

    [Fact]
    public void Should_Return_FallbackUnsupported_For_Incorrect_ReactionType()
    {
        string jsonData = """{"type":"very_very_new","emoji":"\uD83D\uDC4D"}""";
        ReactionType? result = JsonSerializer.Deserialize(jsonData, TelegramBotClientJsonSerializerContext.Instance.ReactionType);

        Assert.NotNull(result);
        Assert.Equal(ReactionTypeKind.FallbackUnsupported, result.Type);
    }

    [Fact]
    public void Should_Throw_JsonException_For_Incorrect_ReactionType()
    {
        Assert.Throws<JsonException>(() =>
            JsonSerializer.Serialize((ReactionTypeKind)int.MaxValue, TelegramBotClientJsonSerializerContext.Instance.ReactionTypeKind));
    }

    private class ReactionTypeData : IEnumerable<object[]>
    {
        internal static ReactionType NewReactionType(ReactionTypeKind reactionTypeKind)
        {
            return reactionTypeKind switch
            {
                ReactionTypeKind.Emoji => new ReactionTypeEmoji { Emoji = "👍" },
                ReactionTypeKind.CustomEmoji => new ReactionTypeCustomEmoji { CustomEmojiId = "1" },
                _ => throw new ArgumentOutOfRangeException(nameof(reactionTypeKind), reactionTypeKind, null)
            };
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return [NewReactionType(ReactionTypeKind.Emoji), """{"type":"emoji","emoji":"\uD83D\uDC4D"}"""];
            yield return [NewReactionType(ReactionTypeKind.CustomEmoji), """{"type":"custom_emoji","custom_emoji_id":"1"}"""];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
