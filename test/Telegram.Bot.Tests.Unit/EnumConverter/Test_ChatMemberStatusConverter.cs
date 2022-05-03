using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using Telegram.Bot.Types.Enums;
using Xunit;

namespace Telegram.Bot.Tests.Unit.EnumConverter;

public class Test_ChatMemberStatusConverter
{
    [Theory]
    [InlineData(ChatMemberStatus.Creator, "creator")]
    [InlineData(ChatMemberStatus.Administrator, "administrator")]
    [InlineData(ChatMemberStatus.Member, "member")]
    [InlineData(ChatMemberStatus.Left, "left")]
    [InlineData(ChatMemberStatus.Kicked, "kicked")]
    [InlineData(ChatMemberStatus.Restricted, "restricted")]
    public void Sould_Convert_ChatMemberStatus_To_String(ChatMemberStatus chatMemberStatus, string value)
    {
        ChatMember chatMember = new ChatMember() { Type = chatMemberStatus };
        string expectedResult = @$"{{""type"":""{value}""}}";

        string result = JsonConvert.SerializeObject(chatMember);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(ChatMemberStatus.Creator, "creator")]
    [InlineData(ChatMemberStatus.Administrator, "administrator")]
    [InlineData(ChatMemberStatus.Member, "member")]
    [InlineData(ChatMemberStatus.Left, "left")]
    [InlineData(ChatMemberStatus.Kicked, "kicked")]
    [InlineData(ChatMemberStatus.Restricted, "restricted")]
    public void Sould_Convert_String_To_ChatMemberStatus(ChatMemberStatus chatMemberStatus, string value)
    {
        ChatMember expectedResult = new ChatMember() { Type = chatMemberStatus };
        string jsonData = @$"{{""type"":""{value}""}}";

        ChatMember result = JsonConvert.DeserializeObject<ChatMember>(jsonData);

        Assert.Equal(expectedResult.Type, result.Type);
    }

    [Fact]
    public void Sould_Return_Zero_For_Incorrect_ChatMemberStatus()
    {
        string jsonData = @$"{{""type"":""{int.MaxValue}""}}";

        ChatMember result = JsonConvert.DeserializeObject<ChatMember>(jsonData);

        Assert.Equal((ChatMemberStatus)0, result.Type);
    }

    [Fact]
    public void Sould_Throw_NotSupportedException_For_Incorrect_ChatMemberStatus()
    {
        ChatMember chatMember = new ChatMember() { Type = (ChatMemberStatus)int.MaxValue };

        NotSupportedException ex = Assert.Throws<NotSupportedException>(() =>
            JsonConvert.SerializeObject(chatMember));
    }

    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    private class ChatMember
    {
        [JsonProperty(Required = Required.Always)]
        public ChatMemberStatus Type { get; init; }
    }
}
