using AutoFixture;
using Mc2.CrudTest.Domain.BusinessExceptions;
using Mc2.CrudTest.Domain.Customers;
using Mc2.CrudTest.Domain.Services;
using Mc2.CrudTest.Domain.ValueObjects;
using Moq;

namespace Mc2.CrudTest.Domain.Tests.Customes
{
    public class CustomerTestBuilder
    {
        private readonly Fixture _fixture;
        private readonly Mock<ICheckDuplicateCustomerEmailService> _checkDuplicateCustomerEmailService;
        private readonly Mock<ICheckDuplicateInformationService> _checkDuplicateInformationService;

        public long Id { get; set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string BankAccountNumber { get; private set; }

        public CustomerTestBuilder()
        {
            _fixture = new Fixture();
            Id = _fixture.Create<long>();
            Firstname = _fixture.Create<string>();
            Lastname = _fixture.Create<string>();
            DateOfBirth = _fixture.Create<DateTime>();
            PhoneNumber = "+14844731054";
            BankAccountNumber = "123456789";
            Email = _fixture.Create<string>() + "@gmail.com";

            _checkDuplicateCustomerEmailService = new Mock<ICheckDuplicateCustomerEmailService>();
            _checkDuplicateInformationService = new Mock<ICheckDuplicateInformationService>();
        }

        public CustomerTestBuilder WithFirstname(string firstname)
        {
            Firstname = firstname;
            return this;
        }

        public CustomerTestBuilder WithLastname(string lastname)
        {
            Lastname = lastname;
            return this;
        }

        public CustomerTestBuilder WithDateOfBirth(DateTime dateOfBirth)
        {
            DateOfBirth = dateOfBirth;
            return this;
        }

        public CustomerTestBuilder WithPhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
            return this;
        }

        public CustomerTestBuilder WithBankAccountNumber(string bankAccountNumber)
        {
            BankAccountNumber = bankAccountNumber;
            return this;
        }

        public CustomerTestBuilder WithEmail(string email)
        {
            Email = email;
            return this;
        }

        public CustomerTestBuilder WithCheckDuplicateCustomerEmailServiceThrowsDuplicateEmail()
        {
            _checkDuplicateCustomerEmailService
                .Setup(emailRepo => emailRepo.CheckDuplicateCustomerEmail(Email, CancellationToken.None))
                .Throws(new BusinessException("Duplicate Email"));
            return this;
        }

        public CustomerTestBuilder WithCheckDuplicateInformationServiceThrows()
        {
            _checkDuplicateInformationService
                .Setup(infoRepo => infoRepo.CheckDuplicateCustomerInformation(Firstname, Lastname, DateOfBirth, CancellationToken.None))
                .Throws(new BusinessException("Duplicate Information for firstname, lastname, birthdate"));
            return this;
        }

        public Customer Build()
        {
            return Customer.Create(
                Firstname,
                Lastname,
                DateOfBirth,
                PhoneNumber,
                Email,
                BankAccountNumber,
                _checkDuplicateCustomerEmailService.Object,
                _checkDuplicateInformationService.Object,
                CancellationToken.None
            );
        }
    }
}
