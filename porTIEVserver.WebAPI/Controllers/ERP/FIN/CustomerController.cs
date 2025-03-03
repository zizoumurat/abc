using MediatR;
using Microsoft.AspNetCore.Mvc;
using porTIEVserver.Application.Features.ERP.FIN.Customers.CreateCustomer;
using porTIEVserver.Application.Features.ERP.FIN.Customers.DeleteCustomer;
using porTIEVserver.Application.Features.ERP.FIN.Customers.GetAllCustomers;
using porTIEVserver.Application.Features.ERP.FIN.Customers.UpdateCustomer;
using porTIEVserver.WebAPI.Abstractions;

namespace porTIEVserver.WebAPI.Controllers.ERP.FIN
{
    public sealed class CustomerController : ApiController
    {
        public CustomerController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
