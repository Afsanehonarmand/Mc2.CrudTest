using Mc2.CrudTest.Domain.BusinessExceptions;
using Mc2.CrudTest.Domain.Customers;
using Mc2.CrudTest.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Services
{
    public class CheckDuplicateInformationService : ICheckDuplicateInformationService
    {
        private readonly ICustomerRepository _repository;

        public CheckDuplicateInformationService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task CheckDuplicateCustomerInformation(string firstname, string lastName,
            DateTime dateOfBirth, CancellationToken cancellationToken)
        {
           bool checkDuplicate=await _repository.IsExistsAsync(a=>a.Firstname==firstname &&
           a.Lastname == lastName && a.DateOfBirth.Date ==dateOfBirth.Date,cancellationToken);
          
            if (checkDuplicate)
                throw new BusinessException(" Duplicate Information for firstname,lastname,birthdate ");

        }

    }
}
