using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Statues.CreateStatus
{
    public sealed record CreateStatusCommand(


        string Code,
        string Name,
        string Desc

        ) : IRequest<Result<string>>;
}
