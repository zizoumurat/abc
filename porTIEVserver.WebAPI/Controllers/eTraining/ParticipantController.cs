using MediatR;
using Microsoft.AspNetCore.Mvc;
using porTIEVserver.Application.Features.eTraining.Participants.CreateParticipant;
using porTIEVserver.Application.Features.eTraining.Participants.DeleteParticipant;
using porTIEVserver.Application.Features.eTraining.Participants.GetAllParticipants;
using porTIEVserver.Application.Features.eTraining.Participants.UpdateParticipant;
using porTIEVserver.WebAPI.Abstractions;

namespace porTIEVserver.WebAPI.Controllers.eTraining
{
    public sealed class ParticipantController : ApiController
    {
        public ParticipantController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllParticipantsQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateParticipantCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateParticipantCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteParticipantCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }

}
