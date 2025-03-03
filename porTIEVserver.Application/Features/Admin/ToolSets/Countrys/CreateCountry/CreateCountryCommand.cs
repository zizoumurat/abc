using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.Countries.CreateCountry
{
    public sealed record CreateCountryCommand(


        string Code,
        string Code2,
        string NameTrk,
        string NameEng,
        string AreaCode

        ) : IRequest<Result<string>>;
}
