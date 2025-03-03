using MediatR;
using Microsoft.AspNetCore.Mvc;
using porTIEVserver.Application.Features.eTraining.Statues.CreateStatus;
using porTIEVserver.Application.Features.eTraining.Statues.DeleteStatus;
using porTIEVserver.Application.Features.eTraining.Statues.GetAllStatues;
using porTIEVserver.Application.Features.eTraining.Statues.UpdateStatus;
using porTIEVserver.WebAPI.Abstractions;

namespace porTIEVserver.WebAPI.Controllers.eTraining
{
    public sealed class StatusController : ApiController
    {
        public StatusController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllStatuesQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateStatusCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateStatusCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteStatusCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }

}
