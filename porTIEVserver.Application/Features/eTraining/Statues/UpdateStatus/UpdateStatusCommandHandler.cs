using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Features.eTraining.Statues.UpdateStatus;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin;
using porTIEVserver.Domain.Entities.ERP.FIN;
using porTIEVserver.Domain.Entities.eTraining;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.FIN;
using porTIEVserver.Domain.Repositories.eTraining;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Statues.UpdateStatus
{
    internal sealed class UpdateStatusCommandHandler(
        IStatusRepository tradingRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<UpdateStatusCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateStatusCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "statues";

            Status status = await tradingRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (status is null)
            {
                return Result<string>.Failure(Messages.MSG_Status + " " + Messages.MSG_NotExist);
            }

            if (status.Code != request.Code)
            {
                bool IsCodeExists = await tradingRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

                if (IsCodeExists)
                {
                    return Result<string>.Failure(Messages.MSG_TaxNumber + " " + Messages.MSG_Exist);
                }
            }

            mapper.Map(request, status);

            status.LastUpdatedDate = DateTime.UtcNow;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Status + " " + Messages.MSG_Update + "";
        }
    }


}
