using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using Telegram.Bot.Types.Passport;
using Xunit;

namespace Telegram.Bot.Tests.Unit.EnumConverter;

public class Test_EncryptedPassportElementTypeConverter
{
    [Theory]
    [InlineData(EncryptedPassportElementType.PersonalDetails, "personal_details")]
    [InlineData(EncryptedPassportElementType.Passport, "passport")]
    [InlineData(EncryptedPassportElementType.DriverLicence, "driver_licence")]
    [InlineData(EncryptedPassportElementType.IdentityCard, "identity_card")]
    [InlineData(EncryptedPassportElementType.InternalPassport, "internal_passport")]
    [InlineData(EncryptedPassportElementType.Address, "address")]
    [InlineData(EncryptedPassportElementType.UtilityBill, "utility_bill")]
    [InlineData(EncryptedPassportElementType.BankStatement, "bank_statement")]
    [InlineData(EncryptedPassportElementType.RentalAgreement, "rental_agreement")]
    [InlineData(EncryptedPassportElementType.PassportRegistration, "passport_registration")]
    [InlineData(EncryptedPassportElementType.TemporaryRegistration, "temporary_registration")]
    [InlineData(EncryptedPassportElementType.PhoneNumber, "phone_number")]
    [InlineData(EncryptedPassportElementType.Email, "email")]
    public void Sould_Convert_EncryptedPassportElementType_To_String(EncryptedPassportElementType encryptedPassportElementType, string value)
    {
        EncryptedPassportElement encryptedPassportElement = new EncryptedPassportElement() { Type = encryptedPassportElementType };
        string expectedResult = @$"{{""type"":""{value}""}}";

        string result = JsonConvert.SerializeObject(encryptedPassportElement);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(EncryptedPassportElementType.PersonalDetails, "personal_details")]
    [InlineData(EncryptedPassportElementType.Passport, "passport")]
    [InlineData(EncryptedPassportElementType.DriverLicence, "driver_licence")]
    [InlineData(EncryptedPassportElementType.IdentityCard, "identity_card")]
    [InlineData(EncryptedPassportElementType.InternalPassport, "internal_passport")]
    [InlineData(EncryptedPassportElementType.Address, "address")]
    [InlineData(EncryptedPassportElementType.UtilityBill, "utility_bill")]
    [InlineData(EncryptedPassportElementType.BankStatement, "bank_statement")]
    [InlineData(EncryptedPassportElementType.RentalAgreement, "rental_agreement")]
    [InlineData(EncryptedPassportElementType.PassportRegistration, "passport_registration")]
    [InlineData(EncryptedPassportElementType.TemporaryRegistration, "temporary_registration")]
    [InlineData(EncryptedPassportElementType.PhoneNumber, "phone_number")]
    [InlineData(EncryptedPassportElementType.Email, "email")]
    public void Sould_Convert_String_To_EncryptedPassportElementType(EncryptedPassportElementType encryptedPassportElementType, string value)
    {
        EncryptedPassportElement expectedResult = new EncryptedPassportElement() { Type = encryptedPassportElementType };
        string jsonData = @$"{{""type"":""{value}""}}";

        EncryptedPassportElement result = JsonConvert.DeserializeObject<EncryptedPassportElement>(jsonData);

        Assert.Equal(expectedResult.Type, result.Type);
    }

    [Fact]
    public void Sould_Return_Zero_For_Incorrect_EncryptedPassportElementType()
    {
        string jsonData = @$"{{""type"":""{int.MaxValue}""}}";

        EncryptedPassportElement result = JsonConvert.DeserializeObject<EncryptedPassportElement>(jsonData);

        Assert.Equal((EncryptedPassportElementType)0, result.Type);
    }

    [Fact]
    public void Sould_Throw_NotSupportedException_For_Incorrect_EncryptedPassportElementType()
    {
        EncryptedPassportElement encryptedPassportElement = new EncryptedPassportElement() { Type = (EncryptedPassportElementType)int.MaxValue };

        // ToDo: add EncryptedPassportElementType.Unknown ?
        //    protected override string GetStringValue(EncryptedPassportElementType value) =>
        //        EnumToString.TryGetValue(value, out var stringValue)
        //            ? stringValue
        //            : "unknown";
        NotSupportedException ex = Assert.Throws<NotSupportedException>(() =>
            JsonConvert.SerializeObject(encryptedPassportElement));
    }

    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    private class EncryptedPassportElement
    {
        [JsonProperty(Required = Required.Always)]
        public EncryptedPassportElementType Type { get; init; }
    }
}
