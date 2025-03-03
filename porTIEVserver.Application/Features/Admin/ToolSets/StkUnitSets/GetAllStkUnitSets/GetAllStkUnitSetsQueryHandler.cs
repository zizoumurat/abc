using MediatR;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Repositories.Admin.ToolSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.StkUnitSets.GetAllStkUnitSets
{
    internal sealed class GetAllStkUnitSetsQueryHandler(
        IStkUnitSetRepository   stkUnitSetRepository,
        ICacheService           cacheService
        ) : IRequestHandler<GetAllStkUnitSetsQuery, Result<List<StkUnitSet>>>
    {
        public async Task<Result<List<StkUnitSet>>> Handle(GetAllStkUnitSetsQuery request, CancellationToken cancellationToken)
        {
            string cacheName = "unitsets";

            List<StkUnitSet> unitSets;
            unitSets = cacheService.Get<List<StkUnitSet>>(cacheName);
            if (unitSets is null)
            {
                unitSets =
                    await stkUnitSetRepository
                    .GetAll()
                    //.Where(p => request.UnitSetTypeValue > 0 && p.UnitSetType.Value == request.UnitSetTypeValue)
                    .OrderBy(p => p.Name)
                    .ToListAsync(cancellationToken);

                cacheService.Set(cacheName, unitSets);
            }

            return unitSets;
        }
    }
}
