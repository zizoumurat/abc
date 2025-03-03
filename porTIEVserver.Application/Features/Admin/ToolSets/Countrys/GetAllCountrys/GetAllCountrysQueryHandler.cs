using MediatR;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Repositories.Admin.ToolSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.Countries.GetAllCountries
{
    internal sealed class GetAllCountrysQueryHandler(
        ICountryRepository countryRepository,
        ICacheService cacheService
        ) : IRequestHandler<GetAllCountrysQuery, Result<List<Country>>>
    {
        public async Task<Result<List<Country>>> Handle(GetAllCountrysQuery request, CancellationToken cancellationToken)
        {
            string cacheName = "countries";

            List<Country> countries;
            countries = cacheService.Get<List<Country>>(cacheName);
            if (countries is null)
            {
                countries =
                    await countryRepository
                    .GetAll()
                    //.Where(p => request.CountrTypeValue > 0 && p.CountryType.Value == request.CountrTypeValue)
                    .OrderBy(p => p.Code3)
                    .ToListAsync(cancellationToken);

                cacheService.Set(cacheName, countries);
            }

            return countries;
        }
    }
}
