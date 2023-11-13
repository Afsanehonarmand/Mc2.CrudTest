using Mc2.CrudTest.Domain.BusinessExceptions;
using Mc2.CrudTest.Domain.Common;

namespace Mc2.CrudTest.Domain.ValueObjects
{
    public class BankAccountNumber : ValueObject
    {
        public string Number { get; }

        private BankAccountNumber() { }

        private BankAccountNumber(string number)
        {
            if (!IsValid(number))
            {
                throw new BusinessException("Invalid bank account number");
            }

            Number = number;
        }

        public static BankAccountNumber Create(string number)
        {
            return new BankAccountNumber(number);
        }

        private bool IsValid(string number)
        {
            return !string.IsNullOrWhiteSpace(number) && number.Length >= 5 && number.Length <= 20;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Number;
        }
    }

}
