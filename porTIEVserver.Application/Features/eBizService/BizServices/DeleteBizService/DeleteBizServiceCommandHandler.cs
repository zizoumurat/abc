using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eBizService.eBizService;
using porTIEVserver.Domain.Entities.eCargo;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.eBizService;
using porTIEVserver.Domain.Repositories.eCargo;
using TS.Result;

namespace porTIEVserver.Application.Features.eCargo.BizServices.DeleteBizService
{
    internal sealed class DeleteBizServiceCommandHandler(
        IBizServiceRepository bizServiceRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm
        ) : IRequestHandler<DeleteBizServiceCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteBizServiceCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "bizservices";

            BizService office = await bizServiceRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (office is null)
            {
                return Result<string>.Failure(Messages.MSG_BizService + " " + Messages.MSG_NotExist);
            }

            office.IsDeleted = true;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_BizService + " " + Messages.MSG_Delete + "";


        }
    }
}
