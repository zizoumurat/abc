using MediatR;
using Microsoft.AspNetCore.Mvc;
using porTIEVserver.Application.Features.eTraining.Partners.CreatePartner;
using porTIEVserver.Application.Features.eTraining.Partners.DeletePartner;
using porTIEVserver.Application.Features.eTraining.Partners.GetAllPartners;
using porTIEVserver.Application.Features.eTraining.Partners.UpdatePartner;
using porTIEVserver.WebAPI.Abstractions;

namespace porTIEVserver.WebAPI.Controllers.eTraining
{
    public sealed class PartnerController : ApiController
    {
        public PartnerController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllPartnersQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatePartnerCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdatePartnerCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DeletePartnerCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }

}
