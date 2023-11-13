using Mc2.CrudTest.Domain.ValueObjects;
using MediatR;

namespace Mc2.CrudTest.Application.Customers.Commands.Update
{
    public class UpdateCustomerCommand : IRequest
    {
        public long Id { get; set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string BankAccountNumber { get; private set; }

        public UpdateCustomerCommand(long id, string firstname, string lastname, DateTime dateOfBirth, string phoneNumber, string email, string bankAccountNumber)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            BankAccountNumber = bankAccountNumber;
        }
    }
}