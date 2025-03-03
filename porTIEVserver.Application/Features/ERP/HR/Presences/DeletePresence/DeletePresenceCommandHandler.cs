using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.ERP.HR;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.HR;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.HR.Presences.DeletePresence
{
    internal sealed class DeletePresenceCommandHandler(
        IPresenceRepository presenceRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm
        ) : IRequestHandler<DeletePresenceCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeletePresenceCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "presences";

            Presence presence = await presenceRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (presence is null)
            {
                return Result<string>.Failure(Messages.MSG_Presence + " " + Messages.MSG_NotExist);
            }

            presence.IsDeleted = true;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Presence + " " + Messages.MSG_Delete + "";


        }
    }
}
