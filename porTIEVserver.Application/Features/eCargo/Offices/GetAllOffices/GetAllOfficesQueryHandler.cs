using MediatR;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eCargo.eCargo;
using porTIEVserver.Domain.Repositories.eCargo;
using TS.Result;

namespace porTIEVserver.Application.Features.eCargo.Offices.GetAllOffices
{
    internal sealed class GetAllOfficesQueryHandler(
        IOfficeRepository officeRepository,
        ICacheService cacheService
        ) : IRequestHandler<GetAllOfficesQuery, Result<List<Office>>>
    {
        public async Task<Result<List<Office>>> Handle(GetAllOfficesQuery request, CancellationToken cancellationToken)
        {
            string cacheName = "offices";

            List<Office> offices;
            offices = cacheService.Get<List<Office>>(cacheName);
            if (offices is null)
            {
                offices =
                    await officeRepository
                    .GetAll()
//                    .Where(p => request.OfficeTypeValue > 0 && p.OfficeType.Value == request.OfficeTypeValue)
                    .OrderBy(p => p.Name)
                    .ToListAsync(cancellationToken);

                cacheService.Set(cacheName, offices);
            }

            return offices;
        }
    }
}
