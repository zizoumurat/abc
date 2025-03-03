using MediatR;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Roles.GetAllRoles
{
    public sealed record GetAllRolesQuery(
        ) : IRequest<Result<List<Role>>>;
}
