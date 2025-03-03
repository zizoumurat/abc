using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.StkUnitSets.DeleteStkUnitSet
{
    public sealed record DeleteStkUnitSetCommand(
        int Ref
        ) : IRequest<Result<string>>;
}
