using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.StkUnits.CreateStkUnit
{
    public sealed record CreateStkUnitCommand(


        string Code,
        string Name,
        double Carpan,
        double Bolen

        ) : IRequest<Result<string>>;
}
