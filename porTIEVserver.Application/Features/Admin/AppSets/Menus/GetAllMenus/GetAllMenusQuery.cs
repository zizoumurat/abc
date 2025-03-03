using MediatR;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Menus.GetAllMenus
{
    public sealed record GetAllMenusQuery(
        ) : IRequest<Result<List<Menu>>>;
}
