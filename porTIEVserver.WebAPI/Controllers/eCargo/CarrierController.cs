using MediatR;
using Microsoft.AspNetCore.Mvc;
using porTIEVserver.Application.Features.eCargo.Carriers.CreateCarrier;
using porTIEVserver.Application.Features.eCargo.Carriers.DeleteCarrier;
using porTIEVserver.Application.Features.eCargo.Carriers.GetAllCarriers;
using porTIEVserver.Application.Features.eCargo.Carriers.UpdateCarrier;
using porTIEVserver.WebAPI.Abstractions;

namespace porTIEVserver.WebAPI.Controllers.eCargo
{
    public sealed class CarrierController : ApiController
    {
        public CarrierController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllCarriersQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCarrierCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCarrierCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteCarrierCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
