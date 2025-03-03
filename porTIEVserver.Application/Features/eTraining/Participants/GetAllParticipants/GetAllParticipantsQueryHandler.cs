using MediatR;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eTraining;
using porTIEVserver.Domain.Repositories.eTraining;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Participants.GetAllParticipants
{
    internal sealed class GetAllParticipantsQueryHandler(
        IParticipantRepository participantRepository,
        ICacheService cacheService
        ) : IRequestHandler<GetAllParticipantsQuery, Result<List<Participant>>>
    {
        public async Task<Result<List<Participant>>> Handle(GetAllParticipantsQuery request, CancellationToken cancellationToken)
        {
            string cacheName = "participants";

            List<Participant> participants;
            participants = cacheService.Get<List<Participant>>(cacheName);
            if (participants is null)
            {
                participants =
                    await participantRepository
                    .GetAll()
                    //                    .Where(p => request.TradingTypeValue > 0 && p.TradingType.Value == request.TradingTypeValue)
                    //.OrderBy(p => p.FicheDate)
                   //  .ThenBy(p => p.FicheNumber)
                    .ToListAsync(cancellationToken);

                cacheService.Set(cacheName, participants);
            }

            return participants;
        }
    }
}
