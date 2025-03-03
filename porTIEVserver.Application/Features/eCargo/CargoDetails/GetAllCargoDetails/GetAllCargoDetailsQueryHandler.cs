using MediatR;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Features.eCargo.CargoDetails.GetAllCargoDetails;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eCargo.eCargo;
using porTIEVserver.Domain.Enums;
using porTIEVserver.Domain.Repositories.eCargo;
using TS.Result;

namespace porTIEVserver.Application.Features.eCargo.CargoDetails.GetAllCargoDetailss
{
    internal sealed class GetAllCargoDetailsQueryHandler(
        ICargoDetailRepository cargodetailRepository,
        ICacheService cacheService
        ) : IRequestHandler<GetAllCargoDetailsQuery, Result<List<CargoDetail>>>
    {
        public async Task<Result<List<CargoDetail>>> Handle(GetAllCargoDetailsQuery request, CancellationToken cancellationToken)
        {
            //
            string cacheName = "cargodetails";

            List<CargoDetail> cargodetails;
            cargodetails = cacheService.Get<List<CargoDetail>>(cacheName);
            if (cargodetails is null)
            {                
                cargodetails =
                    await cargodetailRepository
                    //.GetAll()
                    .Where(p => p.CargoMainRef == request.CargoMainRef)
                    .OrderBy(p => p.CargoMainRef)
                    .ToListAsync(cancellationToken);

                cacheService.Set(cacheName, cargodetails);
            }

            return cargodetails;
        }
    }
}
