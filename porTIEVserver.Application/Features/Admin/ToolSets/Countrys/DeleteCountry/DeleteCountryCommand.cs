using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.Countries.DeleteCountry
{
    public sealed record DeleteCountryCommand(
        int Ref
        ) : IRequest<Result<string>>;
}
