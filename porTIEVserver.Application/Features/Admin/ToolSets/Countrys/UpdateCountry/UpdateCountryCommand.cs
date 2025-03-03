using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.Countries.UpdateCountry
{
    public sealed record UpdateCountryCommand(

        int Ref,
        string Code,
        string Code2,
        string NameTrk,
        string NameEng,
        string AreaCode

        ) : IRequest<Result<string>>;
}
