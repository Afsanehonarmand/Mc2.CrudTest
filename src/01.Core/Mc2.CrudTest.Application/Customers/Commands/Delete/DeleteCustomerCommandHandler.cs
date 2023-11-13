using Mc2.CrudTest.Application.Customers.Commands.Update;
using Mc2.CrudTest.Domain.Customers;
using MediatR;

namespace Mc2.CrudTest.Application.Customers.Commands.Delete
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetAsync(x => x.Id == request.Id, cancellationToken);
            if (customer is null) throw new Exception("Customer Not Found");

            _customerRepository.Remove(customer);
            await _customerRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
