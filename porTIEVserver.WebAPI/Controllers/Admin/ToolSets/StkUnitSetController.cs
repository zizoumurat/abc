using MediatR;
using Microsoft.AspNetCore.Mvc;
using porTIEVserver.Application.Features.Admin.ToolSets.StkUnitSets.CreateStkUnitSet;
using porTIEVserver.Application.Features.Admin.ToolSets.StkUnitSets.DeleteStkUnitSet;
using porTIEVserver.Application.Features.Admin.ToolSets.StkUnitSets.GetAllStkUnitSets;
using porTIEVserver.Application.Features.Admin.ToolSets.StkUnitSets.UpdateStkUnitSet;
using porTIEVserver.WebAPI.Abstractions;

namespace porTIEVserver.WebAPI.Controllers.Admin.Tools
{
    public sealed class StkUnitSetController : ApiController
    {
        public StkUnitSetController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllStkUnitSetsQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateStkUnitSetCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateStkUnitSetCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteStkUnitSetCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }

}
