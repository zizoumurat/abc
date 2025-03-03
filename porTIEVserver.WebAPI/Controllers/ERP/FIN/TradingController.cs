using MediatR;
using Microsoft.AspNetCore.Mvc;
using porTIEVserver.Application.Features.ERP.FIN.Tradings.CreateTrading;
using porTIEVserver.Application.Features.ERP.FIN.Tradings.DeleteTrading;
using porTIEVserver.Application.Features.ERP.FIN.Tradings.GetAllTrading;
using porTIEVserver.Application.Features.ERP.FIN.Tradings.UpdateTrading;
using porTIEVserver.WebAPI.Abstractions;

namespace porTIEVserver.WebAPI.Controllers.ERP.FIN
{
    public sealed class TradingController : ApiController
    {
        public TradingController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllTradingsQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTradingCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateTradingCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteTradingCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
