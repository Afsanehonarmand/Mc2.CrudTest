using Mc2.CrudTest.Domain.BusinessExceptions;
using Mc2.CrudTest.Domain.Customers;

namespace Mc2.CrudTest.Domain.Services
{

    public class CheckDuplicateCustomerEmailService : ICheckDuplicateCustomerEmailService
    {
        private readonly ICustomerRepository _repository;

        public CheckDuplicateCustomerEmailService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task CheckDuplicateCustomerEmail(string emailAddress, CancellationToken cancellationToken)
        {
            bool checkDuplicate = await _repository.IsExistsAsync(a => a.Email.Address == emailAddress, cancellationToken);

            if (checkDuplicate) throw new BusinessException("Duplicate Email");
        }

    }
}
