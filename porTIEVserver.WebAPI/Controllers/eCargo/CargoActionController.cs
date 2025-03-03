using MediatR;
using Microsoft.AspNetCore.Mvc;
using porTIEVserver.Application.Features.eCargo.CargoActions.CreateCargoAction;
using porTIEVserver.Application.Features.eCargo.CargoActions.DeleteCargoAction;
using porTIEVserver.Application.Features.eCargo.CargoActions.GetAllCargoActions;
using porTIEVserver.Application.Features.eCargo.CargoActions.UpdateCargoAction;
using porTIEVserver.WebAPI.Abstractions;

namespace porTIEVserver.WebAPI.Controllers.eCargo
{
    public sealed class CargoActionController : ApiController
    {
        public CargoActionController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllCargoActionsQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCargoActionCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCargoActionCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteCargoActionCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
