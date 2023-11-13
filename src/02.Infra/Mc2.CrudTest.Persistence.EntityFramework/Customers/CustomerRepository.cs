using Mc2.CrudTest.Domain.Customers;
using Mc2.CrudTest.Persistence.EntityFramework.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Mc2.CrudTest.Persistence.EntityFramework.Customers
{
    public class CustomerRepository : RepositoryBase<Customer, long>, ICustomerRepository
    {
        private readonly ILogger<CustomerRepository> _logger;
        public CustomerRepository(DbContext context, ILogger<CustomerRepository> logger) : base(context)
        {
        }

        protected override IList<Expression<Func<Customer, object?>>> GetIncludes()
        {
            return new List<Expression<Func<Customer, object?>>>();
        }
    }
}