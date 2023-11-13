using Mc2.CrudTest.Domain.BusinessExceptions;
using Mc2.CrudTest.Domain.Common;
using Mc2.CrudTest.Domain.Services;

namespace Mc2.CrudTest.Domain.ValueObjects
{
    public class PhoneNumber : ValueObject
    {
        public string Number { get; }

        private PhoneNumber() { }

        private PhoneNumber(string number)
        {
            if (!IsValid(number))
            {
                throw new BusinessException("Invalid phone number","1000");
            }

            Number = number;
        }

        public static PhoneNumber Create(string number)
        {
            return new PhoneNumber(number);
        }

        private bool IsValid(string number)
        {
            return number.IsValidPhoneNumber();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Number;
        }
    }


}
