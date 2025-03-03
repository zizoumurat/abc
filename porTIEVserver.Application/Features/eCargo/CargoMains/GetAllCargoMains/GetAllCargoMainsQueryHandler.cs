using MediatR;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eCargo.eCargo;
using porTIEVserver.Domain.Enums;
using porTIEVserver.Domain.Repositories.eCargo;
using TS.Result;

namespace porTIEVserver.Application.Features.eCargo.Cargos.GetAllCargos
{
    internal sealed class GetAllCargoMainsQueryHandler(
        ICargoMainRepository cargomainRepository,
        ICacheService cacheService
        ) : IRequestHandler<GetAllCargoMainsQuery, Result<List<CargoMain>>>
    {
        public async Task<Result<List<CargoMain>>> Handle(GetAllCargoMainsQuery request, CancellationToken cancellationToken)
        {
            //
            string cacheName = "cargomains";

            List<CargoMain> cargomains;
            cargomains = cacheService.Get<List<CargoMain>>(cacheName);
            if (cargomains is null)
            {
                cargomains =
                    await cargomainRepository
                    //.GetAll()
                    .Where(p => p.TradingType.Value == TradingTypeEnum.CRG.Value)
                    .OrderBy(p => p.FicheNumber)
                    .ToListAsync(cancellationToken);

                cacheService.Set(cacheName, cargomains);
            }

            return cargomains;
        }
    }
}
