using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Customers.Commands.Delete
{
    public class DeleteCustomerCommand : IRequest
    {
        public long Id { get; private set; }
        public DeleteCustomerCommand(long id)
        {
            Id = id;
        }
    }
}
