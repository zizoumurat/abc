using MediatR;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.Cities.CreateCity
{
    public sealed record CreateCityCommand(


        string Code,
        string Code2,
        string NameTrk,
        string NameEng,
        string AreaCode,
        string CountryCode

        ) : IRequest<Result<string>>;
}
