using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eCargo.eCargo;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.eCargo;
using TS.Result;

namespace porTIEVserver.Application.Features.eCargo.Carriers.DeleteCarrier
{
    internal sealed class DeleteCarrierCommandHandler(
        ICarrierRepository carrierRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm
        ) : IRequestHandler<DeleteCarrierCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteCarrierCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "carriers";

            Carrier carrier = await carrierRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (carrier is null)
            {
                return Result<string>.Failure(Messages.MSG_Carrier + " " + Messages.MSG_NotExist);
            }

            carrier.IsDeleted = true;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Carrier + " " + Messages.MSG_Delete + "";


        }
    }
}
