using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.ERP.HR;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.HR;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.HR.Presences.UpdatePresence
{
    internal sealed class UpdatePresenceCommandHandler(
        IPresenceRepository presenceRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<UpdatePresenceCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdatePresenceCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "presences";

            Presence presence = await presenceRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            mapper.Map(request, presence);

            presence.LastUpdatedDate = DateTime.UtcNow;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Presence + " " + Messages.MSG_Update + "";
        }
    }


}
