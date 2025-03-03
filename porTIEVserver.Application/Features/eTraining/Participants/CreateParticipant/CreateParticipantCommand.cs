using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Participants.CreateParticipant
{
    public sealed record CreateParticipantCommand(


        string Code,
        string Name,
        string Desc

        ) : IRequest<Result<string>>;
}
