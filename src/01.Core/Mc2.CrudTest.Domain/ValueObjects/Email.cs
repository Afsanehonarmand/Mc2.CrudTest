using Mc2.CrudTest.Domain.BusinessExceptions;
using Mc2.CrudTest.Domain.Common;
using Mc2.CrudTest.Domain.Services;

namespace Mc2.CrudTest.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string Address { get; }

        private Email() { }

        private Email(string address)
        {
           
            if (!IsValid(address))
            {
                throw new BusinessException("Invalid email address");
            }

            Address = address;
        }

        public static Email Create(string address)
        {
            return new Email(address);
        }

        private bool IsValid(string address)
        {
            return new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(address);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Address;
        }
    }

}
