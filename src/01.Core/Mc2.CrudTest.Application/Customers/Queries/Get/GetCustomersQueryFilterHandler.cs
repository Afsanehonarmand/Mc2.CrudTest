using Mc2.CrudTest.Domain.Customers;
using MediatR;

namespace Mc2.CrudTest.Application.Customers.Queries.Get
{
    public class GetCustomersQueryFilterHandler : IRequestHandler<GetCustomersQueryFilter, PagedCollectionQueryResult<Customer>>
    {
        private readonly ICustomerRepository _customerRepository;
        public GetCustomersQueryFilterHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<PagedCollectionQueryResult<Customer>> Handle(GetCustomersQueryFilter request, CancellationToken cancellationToken)
        {
           return await _customerRepository.GetPaginatedListAsync(request.PageNumber,request.PageSize,x=>true,cancellationToken);
        }
    }
}
