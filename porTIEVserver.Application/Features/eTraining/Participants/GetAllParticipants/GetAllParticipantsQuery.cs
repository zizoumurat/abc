using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using porTIEVserver.Domain.Entities.eTraining;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Participants.GetAllParticipants
{
    public sealed record GetAllParticipantsQuery(
        ) : IRequest<Result<List<Participant>>>;
}
