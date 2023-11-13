using Mc2.CrudTest.Domain.Customers;
using Mc2.CrudTest.Domain.Services;
using MediatR;

namespace Mc2.CrudTest.Application.Customers.Commands.Create
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICheckDuplicateCustomerEmailService _checkDuplicateCustomerEmailService;
        private readonly ICheckDuplicateInformationService _checkDuplicateInformationService;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository,
            ICheckDuplicateCustomerEmailService checkDuplicateCustomerEmailService,
            ICheckDuplicateInformationService checkDuplicateInformationService)
        {
            _customerRepository = customerRepository;
            _checkDuplicateCustomerEmailService = checkDuplicateCustomerEmailService;
            _checkDuplicateInformationService = checkDuplicateInformationService;
        }

        public async Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = Customer.Create(request.Firstname, request.Lastname, request.DateOfBirth, request.PhoneNumber,
                    request.Email, request.BankAccountNumber,_checkDuplicateCustomerEmailService,_checkDuplicateInformationService,cancellationToken);
                await _customerRepository.InsertAsync(customer, cancellationToken);
                await _customerRepository.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                    throw new Exception("Duplicate information");
            }
        }
    }
}
