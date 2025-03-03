using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Features.eTraining.Participants.CreateParticipant;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eTraining;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.eTraining;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Participants.CreateParticipant
{
    internal sealed class CreateParticipantCommandHandler(
        IParticipantRepository participantRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<CreateParticipantCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateParticipantCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "participants";

            bool IsCodeExists = await participantRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

            if (IsCodeExists)
            {
                return Result<string>.Failure(Messages.MSG_Participant + " " + Messages.MSG_Exist);
            }

            Participant participant = mapper.Map<Participant>(request);

            await participantRepository.AddAsync(participant, cancellationToken);

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Participant + " " + Messages.MSG_Create + "";
        }
    }

}
