using MediatR;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Repositories.Admin.ToolSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.Cities.GetAllCities
{
    internal sealed class GetAllCitysQueryHandler(
        ICityRepository cityRepository,
        ICacheService cacheService
        ) : IRequestHandler<GetAllCitysQuery, Result<List<City>>>
    {
        public async Task<Result<List<City>>> Handle(GetAllCitysQuery request, CancellationToken cancellationToken)
        {
            string cacheName = "cities" + request.CountryCode;

            List<City> cities;
            cities = cacheService.Get<List<City>>(cacheName);
            if (cities is null || cities.Count == 0)
            {
                cities =
                    await cityRepository
                    .GetAll()
                    //.Where(p => request.CountryRef != null &&p.CountryRef == request.CountryRef)
                    .OrderBy(p => p.Code3)
                    .ToListAsync(cancellationToken);

                cacheService.Set(cacheName + request.CountryCode, cities);
            }

            return cities;
        }
    }
}
