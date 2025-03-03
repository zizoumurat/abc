using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Menus.DeleteMenu
{
    public sealed record DeleteMenuCommand(
        int Ref
        ) : IRequest<Result<string>>;
}
