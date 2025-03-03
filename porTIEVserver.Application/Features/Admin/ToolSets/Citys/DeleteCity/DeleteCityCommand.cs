using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.Cities.DeleteCity
{
    public sealed record DeleteCityCommand(
        int Ref
        ) : IRequest<Result<string>>;
}
