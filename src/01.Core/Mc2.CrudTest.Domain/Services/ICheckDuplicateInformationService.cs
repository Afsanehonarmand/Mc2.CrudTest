using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Services
{
    public interface ICheckDuplicateInformationService
    {
        Task CheckDuplicateCustomerInformation(string firstname, string lastName, DateTime birthOfDate, CancellationToken cancellationToken);
       
    }
}
