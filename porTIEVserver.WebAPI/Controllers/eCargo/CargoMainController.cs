using MediatR;
using Microsoft.AspNetCore.Mvc;
using porTIEVserver.Application.Features.eCargo.Cargos.CreateCargo;
using porTIEVserver.Application.Features.eCargo.Cargos.DeleteCargo;
using porTIEVserver.Application.Features.eCargo.Cargos.GetAllCargos;
using porTIEVserver.Application.Features.eCargo.Cargos.UpdateCargo;
using porTIEVserver.WebAPI.Abstractions;

namespace porTIEVserver.WebAPI.Controllers.eCargo
{
    public sealed class CargoMainController : ApiController
    {
        public CargoMainController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllCargoMainsQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCargoMainCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCargoMainCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteCargoMainCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
