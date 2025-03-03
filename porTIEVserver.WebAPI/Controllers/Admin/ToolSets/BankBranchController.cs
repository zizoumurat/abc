using MediatR;
using Microsoft.AspNetCore.Mvc;
using porTIEVserver.Application.Features.Admin.ToolSets.BankBranchs.CreateBankBranch;
using porTIEVserver.Application.Features.Admin.ToolSets.BankBranchs.DeleteBankBranch;
using porTIEVserver.Application.Features.Admin.ToolSets.BankBranchs.GetAllBankBranchs;
using porTIEVserver.Application.Features.Admin.ToolSets.BankBranchs.UpdateBankBranch;
using porTIEVserver.WebAPI.Abstractions;

namespace porTIEVserver.WebAPI.Controllers.Admin.Tools
{
    public sealed class BankBranchController : ApiController
    {
        public BankBranchController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllBankBranchsQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBankBranchCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateBankBranchCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteBankBranchCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }

}
