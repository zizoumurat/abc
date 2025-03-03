using MediatR;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Features.eCargo.CargoActions.GetAllCargoActions;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eCargo.eCargo;
using porTIEVserver.Domain.Enums;
using porTIEVserver.Domain.Repositories.eCargo;
using TS.Result;

namespace porTIEVserver.Application.Features.eCargo.CargoActions.GetAllCargoActionss
{
    internal sealed class GetAllCargoActionsQueryHandler(
        ICargoActionRepository cargodetailRepository,
        ICacheService cacheService
        ) : IRequestHandler<GetAllCargoActionsQuery, Result<List<CargoAction>>>
    {
        public async Task<Result<List<CargoAction>>> Handle(GetAllCargoActionsQuery request, CancellationToken cancellationToken)
        {
            //
            string cacheName = "cargodetails";

            List<CargoAction> cargodetails;
            cargodetails = cacheService.Get<List<CargoAction>>(cacheName);
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
