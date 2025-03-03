using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Firms.DeleteFirm
{
    public sealed record DeleteFirmCommand(
        int Ref
        ) : IRequest<Result<string>>;
}
