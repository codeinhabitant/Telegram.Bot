using Telegram.Bot.Types.Passport;

namespace Telegram.Bot.Serialization.EnumConverters;

internal class EncryptedPassportElementTypeConverter: JsonConverter<EncryptedPassportElementType>
{
    public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(EncryptedPassportElementType);

    public override EncryptedPassportElementType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();

        return value switch
        {
            Constants.EncryptedPassportElementType.PersonalDetails => EncryptedPassportElementType.PersonalDetails,
            Constants.EncryptedPassportElementType.Passport => EncryptedPassportElementType.Passport,
            Constants.EncryptedPassportElementType.DriverLicence => EncryptedPassportElementType.DriverLicence,
            Constants.EncryptedPassportElementType.IdentityCard => EncryptedPassportElementType.IdentityCard,
            Constants.EncryptedPassportElementType.InternalPassport => EncryptedPassportElementType.InternalPassport,
            Constants.EncryptedPassportElementType.Address => EncryptedPassportElementType.Address,
            Constants.EncryptedPassportElementType.UtilityBill => EncryptedPassportElementType.UtilityBill,
            Constants.EncryptedPassportElementType.BankStatement => EncryptedPassportElementType.BankStatement,
            Constants.EncryptedPassportElementType.RentalAgreement => EncryptedPassportElementType.RentalAgreement,
            Constants.EncryptedPassportElementType.PassportRegistration => EncryptedPassportElementType.PassportRegistration,
            Constants.EncryptedPassportElementType.TemporaryRegistration => EncryptedPassportElementType.TemporaryRegistration,
            Constants.EncryptedPassportElementType.PhoneNumber => EncryptedPassportElementType.PhoneNumber,
            Constants.EncryptedPassportElementType.Email => EncryptedPassportElementType.Email,

            null or _ => EncryptedPassportElementType.FallbackUnsupported
        };
    }

    public override void Write(Utf8JsonWriter writer, EncryptedPassportElementType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value switch
        {
            EncryptedPassportElementType.PersonalDetails => Constants.EncryptedPassportElementType.PersonalDetails,
            EncryptedPassportElementType.Passport => Constants.EncryptedPassportElementType.Passport,
            EncryptedPassportElementType.DriverLicence => Constants.EncryptedPassportElementType.DriverLicence,
            EncryptedPassportElementType.IdentityCard => Constants.EncryptedPassportElementType.IdentityCard,
            EncryptedPassportElementType.InternalPassport => Constants.EncryptedPassportElementType.InternalPassport,
            EncryptedPassportElementType.Address => Constants.EncryptedPassportElementType.Address,
            EncryptedPassportElementType.UtilityBill => Constants.EncryptedPassportElementType.UtilityBill,
            EncryptedPassportElementType.BankStatement => Constants.EncryptedPassportElementType.BankStatement,
            EncryptedPassportElementType.RentalAgreement => Constants.EncryptedPassportElementType.RentalAgreement,
            EncryptedPassportElementType.PassportRegistration => Constants.EncryptedPassportElementType.PassportRegistration,
            EncryptedPassportElementType.TemporaryRegistration => Constants.EncryptedPassportElementType.TemporaryRegistration,
            EncryptedPassportElementType.PhoneNumber => Constants.EncryptedPassportElementType.PhoneNumber,
            EncryptedPassportElementType.Email => Constants.EncryptedPassportElementType.Email,

            _ => throw new JsonException($"Unsupported EncryptedPassportElementType {value}")
        });

    }
}
