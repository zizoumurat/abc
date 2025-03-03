using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Menus.CreateMenu
{
    public sealed record CreateMenuCommand(


        string      Code,
        string      Name

        ) : IRequest<Result<string>>;
}
