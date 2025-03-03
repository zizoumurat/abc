using MediatR;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eCargo.eCargo;
using porTIEVserver.Domain.Repositories.eCargo;
using TS.Result;

namespace porTIEVserver.Application.Features.eCargo.Carriers.GetAllCarriers
{
    internal sealed class GetAllCarriersQueryHandler(
        ICarrierRepository carrierRepository,
        ICacheService cacheService
        ) : IRequestHandler<GetAllCarriersQuery, Result<List<Carrier>>>
    {
        public async Task<Result<List<Carrier>>> Handle(GetAllCarriersQuery request, CancellationToken cancellationToken)
        {
            string cacheName = "carriers";

            List<Carrier> carriers;
            carriers = cacheService.Get<List<Carrier>>(cacheName);
            if (carriers is null)
            {
                carriers =
                    await carrierRepository
                    .GetAll()
                    //.Where(p=> request.CarrierTypeValue > 0 && p.CarrierType.Value == request.CarrierTypeValue)
                    .OrderBy(p => p.Name)
                    .ToListAsync(cancellationToken);

                cacheService.Set(cacheName, carriers);
            }

            return carriers;
        }
    }
}
