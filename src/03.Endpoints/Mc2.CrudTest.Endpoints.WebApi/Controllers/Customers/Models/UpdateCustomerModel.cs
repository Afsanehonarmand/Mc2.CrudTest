using Mc2.CrudTest.Application.Customers.Commands.Update;

namespace Mc2.CrudTest.Endpoints.WebApi.Controllers.Customers.Models
{
    public class UpdateCustomerModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
        public UpdateCustomerCommand ToCommand(long id)
        {
            return new(id, Firstname, Lastname, DateOfBirth, PhoneNumber, Email, BankAccountNumber);
        }
    }
}
