using MediatR;
using Microsoft.AspNetCore.Mvc;
using porTIEVserver.Application.Features.Admin.AppSets.Roles.CreateRole;
using porTIEVserver.Application.Features.Admin.AppSets.Roles.DeleteRole;
using porTIEVserver.Application.Features.Admin.AppSets.Roles.GetAllRoles;
using porTIEVserver.Application.Features.Admin.AppSets.Roles.MigrateAllRoles;
using porTIEVserver.Application.Features.Admin.AppSets.Roles.UpdateRole;
using porTIEVserver.WebAPI.Abstractions;

namespace porTIEVserver.WebAPI.Controllers.Admin.AppSets
{
    public sealed class RoleController : ApiController
    {
        public RoleController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> MigrateAll(MigrateAllRolesCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
