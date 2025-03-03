using AutoMapper;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.ERP.CRM;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.CRM;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.CRM.CrmActions.CreateCrmAction
{
    internal sealed class CreateCrmActionCommandHandler(
        ICrmActionRepository crmactionRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<CreateCrmActionCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateCrmActionCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "crmactions";

            bool IsCodeExists = await crmactionRepository.AnyAsync(p => p.FicheNumber == request.FicheNumber, cancellationToken);

            if (IsCodeExists)
            {
                return Result<string>.Failure(Messages.MSG_CrmAction + " " + Messages.MSG_Exist);
            }

            CrmAction CrmAction = mapper.Map<CrmAction>(request);

            await crmactionRepository.AddAsync(CrmAction, cancellationToken);

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_CrmAction + " " + Messages.MSG_Create + "";
        }
    }

}
