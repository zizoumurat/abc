using MediatR;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.StkUnits.GetAllStkUnits
{
    public sealed record GetAllStkUnitsQuery(
        ) : IRequest<Result<List<StkUnit>>>;
}
