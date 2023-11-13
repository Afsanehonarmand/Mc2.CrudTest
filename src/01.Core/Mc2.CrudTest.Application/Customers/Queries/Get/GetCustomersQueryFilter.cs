using Mc2.CrudTest.Domain.Customers;
using MediatR;

namespace Mc2.CrudTest.Application.Customers.Queries.Get
{
    public class GetCustomersQueryFilter : IRequest<PagedCollectionQueryResult<Customer>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}