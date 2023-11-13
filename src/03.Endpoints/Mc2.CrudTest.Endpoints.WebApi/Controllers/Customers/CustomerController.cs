using Mc2.CrudTest.Application.Customers.Commands.Delete;
using Mc2.CrudTest.Application.Customers.Queries.Get;
using Mc2.CrudTest.Application.Customers.Queries.GetById;
using Mc2.CrudTest.Domain.Customers;
using Mc2.CrudTest.Endpoints.WebApi.Controllers.Customers.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Endpoints.WebApi.Controllers.Customers
{
    [Route("Customer")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task Create([FromBody] CreateCustomerModel model, CancellationToken cancellationToken)
        {
            var command = model.ToCommand();
            await _mediator.Send(command, cancellationToken);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<PagedCollectionQueryResult<Customer>> Get(GetCustomersQueryFilter query, CancellationToken cancellationToken)
        {
            return await _mediator.Send(query, cancellationToken);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Customer> Get([FromRoute] long id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetCustomerByIdQuery(id), cancellationToken);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task Update([FromRoute] long id, [FromBody] UpdateCustomerModel model, CancellationToken cancellationToken)
        {
            var command = model.ToCommand(id);
            await _mediator.Send(command, cancellationToken);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task Update([FromRoute] long id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteCustomerCommand(id), cancellationToken);
        }
    }
}
