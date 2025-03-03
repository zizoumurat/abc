using AutoMapper;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin;
using porTIEVserver.Domain.Entities.eCargo.eCargo;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.eCargo;
using TS.Result;

namespace porTIEVserver.Application.Features.eCargo.Carriers.UpdateCarrier
{
    internal sealed class UpdateCarrierCommandHandler(
        ICarrierRepository carrierRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<UpdateCarrierCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateCarrierCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "carriers";

            Carrier carrier = await carrierRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (carrier is null)
            {
                return Result<string>.Failure(Messages.MSG_Carrier + " " + Messages.MSG_NotExist);
            }

            if (carrier.Code != request.Code)
            {
                bool IsCodeExists = await carrierRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

                if (IsCodeExists)
                {
                    return Result<string>.Failure(Messages.MSG_TaxNumber + " " + Messages.MSG_Exist);
                }
            }

            mapper.Map(request, carrier);

            carrier.LastUpdatedDate = DateTime.UtcNow;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Carrier + " " + Messages.MSG_Update + "";
        }
    }


}
