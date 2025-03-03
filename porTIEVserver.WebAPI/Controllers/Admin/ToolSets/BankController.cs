using MediatR;
using Microsoft.AspNetCore.Mvc;
using porTIEVserver.Application.Features.Admin.ToolSets.Banks.CreateBank;
using porTIEVserver.Application.Features.Admin.ToolSets.Banks.DeleteBank;
using porTIEVserver.Application.Features.Admin.ToolSets.Banks.GetAllBanks;
using porTIEVserver.Application.Features.Admin.ToolSets.Banks.UpdateBank;
using porTIEVserver.WebAPI.Abstractions;

namespace porTIEVserver.WebAPI.Controllers.Admin.Tools
{
    public sealed class BankController : ApiController
    {
        public BankController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllBanksQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBankCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateBankCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteBankCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }

}
