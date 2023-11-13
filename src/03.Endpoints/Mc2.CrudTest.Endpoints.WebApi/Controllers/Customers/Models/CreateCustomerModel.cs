using Mc2.CrudTest.Application.Customers.Commands.Create;

namespace Mc2.CrudTest.Endpoints.WebApi.Controllers.Customers.Models
{
    public class CreateCustomerModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
        public CreateCustomerCommand ToCommand()
        {
            return new(Firstname, Lastname, DateOfBirth, PhoneNumber, Email, BankAccountNumber);
        }
    }
}
