using Mc2.CrudTest.Domain.Common;
using Mc2.CrudTest.Domain.Services;
using Mc2.CrudTest.Domain.ValueObjects;

namespace Mc2.CrudTest.Domain.Customers
{
    public class Customer : AggregateRoot<long>
    {
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Email Email { get; private set; }
        public BankAccountNumber BankAccountNumber { get; private set; }

        private Customer()
        {
        }
        private Customer(string firstname, string lastname, DateTime dateOfBirth,
            string phoneNumber, string email, string bankAccountNumber, ICheckDuplicateCustomerEmailService checkDuplicateCustomerEmailService,
            ICheckDuplicateInformationService checkDuplicateInformationService, CancellationToken cancellationToken)
        {
            GuardAgainstDuplicateCustomerEmail(email, checkDuplicateCustomerEmailService, cancellationToken);
            GuardAgainstDuplicateCustomerInformation(firstname, lastname, dateOfBirth,
                checkDuplicateInformationService, cancellationToken);

            Firstname = firstname;
            Lastname = lastname;
            DateOfBirth = dateOfBirth;
            PhoneNumber = PhoneNumber.Create(phoneNumber);
            Email = Email.Create(email);
            BankAccountNumber = BankAccountNumber.Create(bankAccountNumber);
        }
        public static Customer Create(string firstname, string lastname,
            DateTime dateOfBirth, string phoneNumber, string email, string bankAccountNumber, ICheckDuplicateCustomerEmailService checkDuplicateCustomerEmailService,
            ICheckDuplicateInformationService checkDuplicateInformationService, CancellationToken cancellationToken)
        {
            return new Customer(firstname, lastname, dateOfBirth, phoneNumber, email,
                bankAccountNumber, checkDuplicateCustomerEmailService, checkDuplicateInformationService, cancellationToken);
        }
        public void Update(string firstname, string lastname, DateTime dateOfBirth,
            string phoneNumber, string email, string bankAccountNumber,
            ICheckDuplicateCustomerEmailService checkDuplicateCustomerEmailService,
            ICheckDuplicateInformationService checkDuplicateInformationService ,CancellationToken cancellationToken)
        {
            GuardAgainstDuplicateCustomerEmail(email, checkDuplicateCustomerEmailService, cancellationToken);
            GuardAgainstDuplicateCustomerInformation(firstname, lastname, dateOfBirth,
               checkDuplicateInformationService, cancellationToken);
            Firstname = firstname;
            Lastname = lastname;
            DateOfBirth = dateOfBirth;
            PhoneNumber = PhoneNumber.Create(phoneNumber);
            Email = Email.Create(email);
            BankAccountNumber = BankAccountNumber.Create(bankAccountNumber);
        }
        private void GuardAgainstDuplicateCustomerInformation(string firstname, string lastname,
            DateTime dateOfBirth, ICheckDuplicateInformationService checkDuplicateInformationService, CancellationToken cancellationToken)
        {
            if (Firstname != firstname || Lastname != lastname || (DateOfBirth != null && DateOfBirth.Date != dateOfBirth.Date))
                checkDuplicateInformationService.CheckDuplicateCustomerInformation(firstname, lastname, dateOfBirth, cancellationToken);
        }

        private void GuardAgainstDuplicateCustomerEmail(string emailAddress, ICheckDuplicateCustomerEmailService checkDuplicateCustomerEmailService, CancellationToken cancellationToken)
        {
            if (Email?.Address != emailAddress)
                checkDuplicateCustomerEmailService.CheckDuplicateCustomerEmail(emailAddress, cancellationToken);
        }

    }

}
