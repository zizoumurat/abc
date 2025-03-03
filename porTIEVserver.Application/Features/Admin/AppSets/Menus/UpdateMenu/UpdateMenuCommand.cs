using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Menus.UpdateMenu
{
    public sealed record UpdateMenuCommand(

        int Ref,
        string      Code,
        string      Name

        ) : IRequest<Result<string>>;
}
