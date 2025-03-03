using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin;
using porTIEVserver.Domain.Entities.ERP.CRM;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.CRM;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.CRM.CrmActions.UpdateCrmAction
{
    internal sealed class UpdateCrmActionCommandHandler(
        ICrmActionRepository crmactionRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<UpdateCrmActionCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateCrmActionCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "crmactions";

            CrmAction crmaction = await crmactionRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (crmaction is null)
            {
                return Result<string>.Failure(Messages.MSG_CrmAction + " " + Messages.MSG_NotExist);
            }

            if (crmaction.FicheNumber != request.FicheNumber)
            {
                bool IsCodeExists = await crmactionRepository.AnyAsync(p => p.FicheNumber == request.FicheNumber, cancellationToken);

                if (IsCodeExists)
                {
                    return Result<string>.Failure(Messages.MSG_TaxNumber + " " + Messages.MSG_Exist);
                }
            }

            mapper.Map(request, crmaction);

            crmaction.LastUpdatedDate = DateTime.UtcNow;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_CrmAction + " " + Messages.MSG_Update + "";
        }
    }


}
