using Mc2.CrudTest.Domain.Common;
using System.Linq.Expressions;

namespace Mc2.CrudTest.Domain.Customers
{
    public interface ICustomerRepository
    {
        Task<Customer> GetAsync(Expression<Func<Customer, bool>> predicate,CancellationToken cancellationToken);
        Task InsertAsync(Customer doctor,CancellationToken cancellationToken);
        void Remove(Customer customer);
        Task<PagedCollectionQueryResult<Customer>> GetPaginatedListAsync(
        int pageNumber, int pageSize, Expression<Func<Customer, bool>> predicate, CancellationToken cancellationToken);
        Task<bool> IsExistsAsync(Expression<Func<Customer, bool>> predicate, CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
