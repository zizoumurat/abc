using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.Cities.UpdateCity
{
    public sealed record UpdateCityCommand(

        int Ref,
        string Code,
        string Code2,
        string NameTrk,
        string NameEng,
        string AreaCode,
        string CountryCode

        ) : IRequest<Result<string>>;
}
