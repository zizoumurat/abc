using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Roles.DeleteRole
{
    public sealed record DeleteRoleCommand(
        int Ref
        ) : IRequest<Result<string>>;
}
