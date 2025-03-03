using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.StkUnitSets.CreateStkUnitSet
{
    public sealed record CreateStkUnitSetCommand(


        string Code,
        string Name

        ) : IRequest<Result<string>>;
}
