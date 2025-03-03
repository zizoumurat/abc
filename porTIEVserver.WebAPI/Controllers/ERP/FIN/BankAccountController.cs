using MediatR;
using Microsoft.AspNetCore.Mvc;
using porTIEVserver.Application.Features.ERP.FIN.BankAccounts.CreateBankAccount;
using porTIEVserver.Application.Features.ERP.FIN.BankAccounts.DeleteBankAccount;
using porTIEVserver.Application.Features.ERP.FIN.BankAccounts.GetAllBankAccounts;
using porTIEVserver.Application.Features.ERP.FIN.BankAccounts.UpdateBankAccount;
using porTIEVserver.WebAPI.Abstractions;

namespace porTIEVserver.WebAPI.Controllers.ERP.FIN
{
    public sealed class BankAccountController : ApiController
    {
        public BankAccountController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllBankAccountsQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBankAccountCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateBankAccountCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteBankAccountCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
