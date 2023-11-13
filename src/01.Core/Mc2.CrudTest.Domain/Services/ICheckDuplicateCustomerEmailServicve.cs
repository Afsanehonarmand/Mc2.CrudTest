namespace Mc2.CrudTest.Domain.Services
{
    public interface ICheckDuplicateCustomerEmailService
    {
        Task CheckDuplicateCustomerEmail(string emailAddress, CancellationToken cancellationToken);
    }
}
