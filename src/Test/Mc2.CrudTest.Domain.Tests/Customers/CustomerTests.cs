using FluentAssertions;
using Mc2.CrudTest.Domain.BusinessExceptions;
using Mc2.CrudTest.Domain.Services;
using Mc2.CrudTest.Domain.Tests.Customes;
using Moq;
using System;
using Xunit;

namespace ClinicManagement.Domain.Tests.customer
{
    public class CustomerTests
    {
        private readonly CustomerTestBuilder _customerTestBuilder;

        public CustomerTests()
        {
            _customerTestBuilder = new CustomerTestBuilder();
        }

        [Fact]
        public void construct_properly()
        {
            var customer = _customerTestBuilder.Build();

            customer.Firstname.Should().Be(_customerTestBuilder.Firstname);
            customer.Lastname.Should().Be(_customerTestBuilder.Lastname);
            customer.PhoneNumber.Number.Should().Be(_customerTestBuilder.PhoneNumber);
            customer.Email.Address.Should().Be(_customerTestBuilder.Email);
            customer.BankAccountNumber.Number.Should().Be(_customerTestBuilder.BankAccountNumber);
        }

        [Fact]
        public void construct_when_phone_number_is_invalid_then_throw()
        {
            var phoneNumber = "0000";
            _customerTestBuilder.WithPhoneNumber(phoneNumber);
            Action action = () => _customerTestBuilder.Build();

            action.Should().ThrowExactly<BusinessException>().WithMessage("Invalid phone number");
        }

        [Fact]
        public void construct_when_email_is_invalid_then_throw()
        {
            var email = "aaaaaaaaaaaaaaaa";
            _customerTestBuilder.WithEmail(email);
            Action action = () => _customerTestBuilder.Build();

            action.Should().ThrowExactly<BusinessException>().WithMessage("Invalid email address");
        }

        [Fact]
        public void construct_when_email_is_duplicate_then_throw()
        {
            var email = "MasonChase@gmail.com";

            _customerTestBuilder.WithEmail(email)
                                .WithCheckDuplicateCustomerEmailServiceThrowsDuplicateEmail();

            Action action = () => _customerTestBuilder.Build();

            action.Should().ThrowExactly<BusinessException>().WithMessage("Duplicate Email");
        }

        [Fact]
        public void construct_when_firstname_lastname_and_dateofbirth_is_duplicate_then_throw()
        {
            var firstname = "Mason";
            var lastname = "Chase";
            var dateOfBirth = new DateTime(2000, 01, 01);

            _customerTestBuilder.WithFirstname(firstname)
                                .WithLastname(lastname)
                                .WithDateOfBirth(dateOfBirth)
                                .WithCheckDuplicateInformationServiceThrows();

            Action action = () => _customerTestBuilder.Build();

            action.Should().ThrowExactly<BusinessException>().WithMessage("Duplicate Information for firstname, lastname, birthdate");
        }

        [Fact]
        public void construct_when_bank_account_number_is_invalid_then_throw()
        {
            var bankAccountNumber = "111";
            _customerTestBuilder.WithBankAccountNumber(bankAccountNumber);
            Action action = () => _customerTestBuilder.Build();

            action.Should().ThrowExactly<BusinessException>().WithMessage("Invalid bank account number");
        }
    }
}
