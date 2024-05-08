using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Xunit;

namespace Telegram.Bot.Tests.Unit.Serialization;

public class ChatSerializationTests
{
    [Fact]
    public void Should_Deserialize_Chat()
    {
        // language=JSON
        const string chat =
            """
            {
              "id": 12345,
              "type": "supergroup"
            }
            """;

        Chat? deserialize = JsonSerializer.Deserialize(chat, TelegramBotClientJsonSerializerContext.Instance.Chat);

        Assert.NotNull(deserialize);
        Assert.Equal(12345, deserialize.Id);
        Assert.Equal(ChatType.Supergroup, deserialize.Type);
    }

    [Fact]
    public void Should_Serialize_Chat()
    {
        Chat chat = new()
        {
            Id = 1000,
            Type = ChatType.Supergroup,
        };

        string json = JsonSerializer.Serialize(chat, TelegramBotClientJsonSerializerContext.Instance.Chat);

        JsonNode? root = JsonNode.Parse(json);
        Assert.NotNull(root);

        JsonObject j = Assert.IsAssignableFrom<JsonObject>(root);

        Assert.Equal(2, j.Count);
        Assert.Equal("supergroup", (string?)j["type"]);
        Assert.Equal(chat.Id, (long?)j["id"]);
    }

    [Fact]
    public void Should_Deserialize_ChatFullInfo()
    {
        // language=JSON
        const string chatFullInfo =
            """
            {
              "id": 12345,
              "type": "supergroup",
              "unrestrict_boost_count": 10,
              "custom_emoji_sticker_set_name": "test_sticker_set",
              "max_reaction_count": 100
            }
            """;

        ChatFullInfo? deserialize = JsonSerializer.Deserialize(chatFullInfo, TelegramBotClientJsonSerializerContext.Instance.ChatFullInfo);

        Assert.NotNull(deserialize);
        Assert.Equal(10, deserialize.UnrestrictBoostCount);
        Assert.Equal(12345, deserialize.Id);
        Assert.Equal(ChatType.Supergroup, deserialize.Type);
        Assert.Equal("test_sticker_set", deserialize.CustomEmojiStickerSetName);
        Assert.Equal(100, deserialize.MaxReactionCount);
    }

    [Fact]
    public void Should_Serialize_ChatFullInfo()
    {
        ChatFullInfo chatFullInfo = new()
        {
            Id = 1000,
            Type = ChatType.Supergroup,
            UnrestrictBoostCount = 10,
            CustomEmojiStickerSetName = "test_sticker_set",
            MaxReactionCount = 100,
        };

        string json = JsonSerializer.Serialize(chatFullInfo, TelegramBotClientJsonSerializerContext.Instance.ChatFullInfo);

        JsonNode? root = JsonNode.Parse(json);
        Assert.NotNull(root);

        JsonObject j = Assert.IsAssignableFrom<JsonObject>(root);

        Assert.Equal(5, j.Count);
        Assert.Equal(chatFullInfo.UnrestrictBoostCount, (int?)j["unrestrict_boost_count"]);
        Assert.Equal("supergroup", (string?)j["type"]);
        Assert.Equal(chatFullInfo.Id, (long?)j["id"]);
        Assert.Equal(chatFullInfo.CustomEmojiStickerSetName, (string?)j["custom_emoji_sticker_set_name"]);
        Assert.Equal(100, (int?)j["max_reaction_count"]);
    }
}
