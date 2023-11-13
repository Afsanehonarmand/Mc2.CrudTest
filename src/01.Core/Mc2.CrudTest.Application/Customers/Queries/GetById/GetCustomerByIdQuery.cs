using Mc2.CrudTest.Domain.Customers;
using MediatR;

namespace Mc2.CrudTest.Application.Customers.Queries.GetById
{
    public class GetCustomerByIdQuery : IRequest<Customer>
    {
        public long Id { get; private set; }
        public GetCustomerByIdQuery(long id)
        {
            Id = id;
        }
    }
}