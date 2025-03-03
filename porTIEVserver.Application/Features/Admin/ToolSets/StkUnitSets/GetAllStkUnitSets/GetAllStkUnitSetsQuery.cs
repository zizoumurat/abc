using MediatR;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.StkUnitSets.GetAllStkUnitSets
{
    public sealed record GetAllStkUnitSetsQuery(
        ) : IRequest<Result<List<StkUnitSet>>>;
}
