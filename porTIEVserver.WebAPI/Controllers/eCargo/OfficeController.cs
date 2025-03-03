using MediatR;
using Microsoft.AspNetCore.Mvc;
using porTIEVserver.Application.Features.eCargo.Offices.CreateOffice;
using porTIEVserver.Application.Features.eCargo.Offices.DeleteOffice;
using porTIEVserver.Application.Features.eCargo.Offices.GetAllOffices;
using porTIEVserver.Application.Features.eCargo.Offices.UpdateOffice;
using porTIEVserver.WebAPI.Abstractions;

namespace porTIEVserver.WebAPI.Controllers.eCargo
{
    public sealed class OfficeController : ApiController
    {
        public OfficeController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllOfficesQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateOfficeCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateOfficeCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteOfficeCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
