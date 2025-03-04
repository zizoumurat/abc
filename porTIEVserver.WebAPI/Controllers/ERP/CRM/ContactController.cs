using MediatR;
using Microsoft.AspNetCore.Mvc;
using porTIEVserver.Application.Features.ERP.CRM.Contacts.CreateContact;
using porTIEVserver.Application.Features.ERP.CRM.Contacts.DeleteContact;
using porTIEVserver.Application.Features.ERP.CRM.Contacts.GetAllContacts;
using porTIEVserver.Application.Features.ERP.CRM.Contacts.UpdateContact;
using porTIEVserver.Domain.Dtos;
using porTIEVserver.Domain.Pagination;
using porTIEVserver.WebAPI.Abstractions;

namespace porTIEVserver.WebAPI.Controllers.ERP.CRM
{
    public sealed class ContactController : ApiController
    {
        public ContactController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ContactFilterDto filter, [FromQuery] PageRequest pagination, CancellationToken cancellationToken)
        {
            var query = new GetAllContactsQuery(filter, pagination);
            var response = await _mediator.Send(query, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{ref}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
