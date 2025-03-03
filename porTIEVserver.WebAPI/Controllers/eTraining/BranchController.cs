using MediatR;
using Microsoft.AspNetCore.Mvc;
using porTIEVserver.Application.Features.eTraining.Branchs.CreateBranch;
using porTIEVserver.Application.Features.eTraining.Branchs.DeleteBranch;
using porTIEVserver.Application.Features.eTraining.Branchs.GetAllBranchs;
using porTIEVserver.Application.Features.eTraining.Branchs.UpdateBranch;
using porTIEVserver.WebAPI.Abstractions;

namespace porTIEVserver.WebAPI.Controllers.eTraining
{
    public sealed class BranchController : ApiController
    {
        public BranchController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllBranchsQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateBranchCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }

}
