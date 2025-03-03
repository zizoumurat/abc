using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Roles.CreateRole
{
    public sealed record CreateRoleCommand(


        string      Code,
        string      Name

        ) : IRequest<Result<string>>;
}
