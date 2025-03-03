using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Roles.MigrateAllRoles
{
    public sealed record MigrateAllRolesCommand() : IRequest<Result<string>>;
}
