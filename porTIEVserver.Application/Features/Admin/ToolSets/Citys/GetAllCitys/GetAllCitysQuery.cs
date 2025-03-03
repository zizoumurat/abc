using MediatR;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.Cities.GetAllCities
{
    public sealed record GetAllCitysQuery(
        string CountryCode
        ) : IRequest<Result<List<City>>>;
}
