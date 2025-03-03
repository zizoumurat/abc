using MediatR;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Repositories.Admin.ToolSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.StkUnits.GetAllStkUnits
{
    internal sealed class GetAllStkUnitsQueryHandler(

            IStkUnitRepository stkUnitRepository,
            ICacheService cacheService



        ) : IRequestHandler<GetAllStkUnitsQuery, Result<List<StkUnit>>>
    {
        public async Task<Result<List<StkUnit>>> Handle(GetAllStkUnitsQuery request, CancellationToken cancellationToken)
        {
            string cacheName = "stkunits";

            List<StkUnit> units;
            units = cacheService.Get<List<StkUnit>>(cacheName);
            if (units is null)
            {
                units =
                    await stkUnitRepository
                    .GetAll()
                    //.Where(p => request.UnitSetTypeValue > 0 && p.UnitSetType.Value == request.UnitSetTypeValue)
                    .OrderBy(p => p.Name)
                    .ToListAsync(cancellationToken);

                cacheService.Set(cacheName, units);
            }

            return units;
        }
    }
}
