using Mc2.CrudTest.Domain.Customers;
using Mc2.CrudTest.Domain.Services;
using MediatR;

namespace Mc2.CrudTest.Application.Customers.Commands.Update
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICheckDuplicateCustomerEmailService _checkDuplicateCustomerEmailService;
        private readonly ICheckDuplicateInformationService _checkDuplicateInformationService;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository,
            ICheckDuplicateCustomerEmailService checkDuplicateCustomerEmailService,
            ICheckDuplicateInformationService checkDuplicateInformationService)
        {
            _customerRepository = customerRepository;
            _checkDuplicateCustomerEmailService = checkDuplicateCustomerEmailService;
            _checkDuplicateInformationService = checkDuplicateInformationService;
        }

        public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetAsync(x => x.Id == request.Id, cancellationToken);
            if (customer is null) throw new Exception("Customer Not Found");

            customer.Update(request.Firstname, request.Lastname, request.DateOfBirth, request.PhoneNumber,
                request.Email, request.BankAccountNumber,_checkDuplicateCustomerEmailService,_checkDuplicateInformationService,cancellationToken);
            await _customerRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
