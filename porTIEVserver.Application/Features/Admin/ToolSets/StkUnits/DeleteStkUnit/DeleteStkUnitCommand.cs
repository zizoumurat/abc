using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.StkUnits.DeleteStkUnit
{
    public sealed record DeleteStkUnitCommand(
        int Ref
        ) : IRequest<Result<string>>;
}
