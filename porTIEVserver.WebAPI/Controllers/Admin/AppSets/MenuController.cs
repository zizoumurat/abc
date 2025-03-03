using MediatR;
using Microsoft.AspNetCore.Mvc;
using porTIEVserver.Application.Features.Admin.AppSets.Menus.CreateMenu;
using porTIEVserver.Application.Features.Admin.AppSets.Menus.DeleteMenu;
using porTIEVserver.Application.Features.Admin.AppSets.Menus.GetAllMenus;
using porTIEVserver.Application.Features.Admin.AppSets.Menus.MigrateAllMenus;
using porTIEVserver.Application.Features.Admin.AppSets.Menus.UpdateMenu;
using porTIEVserver.WebAPI.Abstractions;

namespace porTIEVserver.WebAPI.Controllers.Admin.AppSets
{
    public sealed class MenuController : ApiController
    {
        public MenuController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllMenusQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateMenuCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteMenuCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> MigrateAll(MigrateAllMenusCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
