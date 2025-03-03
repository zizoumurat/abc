using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Roles.UpdateRole
{
    public sealed record UpdateRoleCommand(

        int Ref,
        string      Code,
        string      Name

        ) : IRequest<Result<string>>;
}
