using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Features.eTraining.Participants.UpdateParticipant;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin;
using porTIEVserver.Domain.Entities.ERP.FIN;
using porTIEVserver.Domain.Entities.eTraining;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.FIN;
using porTIEVserver.Domain.Repositories.eTraining;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Participants.UpdateParticipant
{
    internal sealed class UpdateParticipantCommandHandler(
        IParticipantRepository participantRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<UpdateParticipantCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateParticipantCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "participants";

            Participant participant = await participantRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (participant is null)
            {
                return Result<string>.Failure(Messages.MSG_Participant + " " + Messages.MSG_NotExist);
            }

            if (participant.Code != request.Code)
            {
                bool IsCodeExists = await participantRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

                if (IsCodeExists)
                {
                    return Result<string>.Failure(Messages.MSG_TaxNumber + " " + Messages.MSG_Exist);
                }
            }

            mapper.Map(request, participant);

            participant.LastUpdatedDate = DateTime.UtcNow;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Participant + " " + Messages.MSG_Update + "";
        }
    }


}
