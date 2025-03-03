using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.ERP.CRM;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.CRM;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.CRM.CrmActions.DeleteCrmAction
{
    internal sealed class DeleteCrmActionCommandHandler(
        ICrmActionRepository crmactionRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm
        ) : IRequestHandler<DeleteCrmActionCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteCrmActionCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "crmactions";

            CrmAction crmaction = await crmactionRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (crmaction is null)
            {
                return Result<string>.Failure(Messages.MSG_CrmAction + " " + Messages.MSG_NotExist);
            }

            crmaction.IsDeleted = true;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_CrmAction + " " + Messages.MSG_Delete + "";


        }
    }
}
