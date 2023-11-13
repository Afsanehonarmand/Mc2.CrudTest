using PhoneNumbers;

namespace Mc2.CrudTest.Domain.Services
{
    public static class PhoneNumberValidatorService
    {
        public static bool IsValidPhoneNumber(this string phoneNumber, string regionCode = "US")
        {
            try
            {
                var phoneNumberUtil = PhoneNumberUtil.GetInstance();
                var parsedPhoneNumber = phoneNumberUtil.Parse(phoneNumber, regionCode);
                return phoneNumberUtil.IsValidNumber(parsedPhoneNumber);
            }
            catch (NumberParseException ex) 
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

}
