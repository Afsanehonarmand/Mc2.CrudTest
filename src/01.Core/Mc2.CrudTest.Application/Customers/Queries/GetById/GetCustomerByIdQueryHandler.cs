using Mc2.CrudTest.Application.Customers.Commands.Delete;
using Mc2.CrudTest.Application.Customers.Commands.Update;
using Mc2.CrudTest.Domain.Customers;
using MediatR;

namespace Mc2.CrudTest.Application.Customers.Queries.GetById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
    {
        private readonly ICustomerRepository _customerRepository;
        public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetAsync(x => x.Id == request.Id, cancellationToken);
            if (customer is null) throw new Exception("Customer Not Found");

            return customer;

        }
    }
}
