using MediatR;
using porTIEVserver.Application.Features.eTraining.Participants.DeleteParticipant;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eTraining;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.FIN;
using porTIEVserver.Domain.Repositories.eTraining;
using TS.Result;

namespace porTIEVserver.Application.Features.eTradings.Participants.DeleteParticipant
{
    internal sealed class DeleteParticipantCommandHandler(
        IParticipantRepository participantRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm
        ) : IRequestHandler<DeleteParticipantCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteParticipantCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "participants";

            Participant participant = await participantRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (participant is null)
            {
                return Result<string>.Failure(Messages.MSG_Participant + " " + Messages.MSG_NotExist);
            }

            participant.IsDeleted = true;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Participant + " " + Messages.MSG_Delete + "";


        }
    }
}
