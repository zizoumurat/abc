using MediatR;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.Countries.GetAllCountries
{
    public sealed record GetAllCountrysQuery(
        ) : IRequest<Result<List<Country>>>;
}
