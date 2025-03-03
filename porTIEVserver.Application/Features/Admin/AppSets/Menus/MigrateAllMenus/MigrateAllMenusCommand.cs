using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Menus.MigrateAllMenus
{
    public sealed record MigrateAllMenusCommand() : IRequest<Result<string>>;
}
