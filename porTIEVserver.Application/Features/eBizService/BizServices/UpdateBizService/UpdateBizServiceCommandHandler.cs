using AutoMapper;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eBizService.eBizService;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.eBizService;
using TS.Result;

namespace porTIEVserver.Application.Features.eCargo.BizServices.UpdateBizService
{
    internal sealed class UpdateBizServiceCommandHandler(
            IBizServiceRepository   bizServiceRepository,
            ICacheService           cacheService,
            IUnitOfWorkFirm      unitOfWorkFirm,
            IMapper mapper
    ) : IRequestHandler<UpdateBizServiceCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateBizServiceCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "bizservices";

            BizService bizservice = await bizServiceRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (bizservice is null)
            {
                return Result<string>.Failure(Messages.MSG_BizService + " " + Messages.MSG_NotExist);
            }

            if (bizservice.Code != request.Code)
            {
                bool IsCodeExists = await bizServiceRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

                if (IsCodeExists)
                {
                    return Result<string>.Failure(Messages.MSG_TaxNumber + " " + Messages.MSG_Exist);
                }
            }

            mapper.Map(request, bizservice);

            bizservice.LastUpdatedDate = DateTime.UtcNow;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_BizService + " " + Messages.MSG_Update + "";
        }
    }


}
