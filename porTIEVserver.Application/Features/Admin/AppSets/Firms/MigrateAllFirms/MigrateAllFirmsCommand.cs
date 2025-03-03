using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Firms.MigrateAllFirms
{
    public sealed record MigrateAllFirmsCommand() : IRequest<Result<string>>;
}
