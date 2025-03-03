using MediatR;
using Microsoft.AspNetCore.Mvc;
using porTIEVserver.Application.Features.eCargo.CargoDetails.CreateCargoDetail;
using porTIEVserver.Application.Features.eCargo.CargoDetails.DeleteCargoDetail;
using porTIEVserver.Application.Features.eCargo.CargoDetails.GetAllCargoDetails;
using porTIEVserver.Application.Features.eCargo.CargoDetails.UpdateCargoDetail;
using porTIEVserver.WebAPI.Abstractions;

namespace porTIEVserver.WebAPI.Controllers.eCargo
{
    public sealed class CargoDetailController : ApiController
    {
        public CargoDetailController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllCargoDetailsQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCargoDetailCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCargoDetailCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteCargoDetailCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
