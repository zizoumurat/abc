using MediatR;
using porTIEVserver.Application.Features.eTraining.Partners.DeletePartner;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eTraining;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.FIN;
using porTIEVserver.Domain.Repositories.eTraining;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Partners.DeletePartner
{
    internal sealed class DeletePartnerCommandHandler(
        IPartnerRepository partnerRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm
        ) : IRequestHandler<DeletePartnerCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeletePartnerCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "partners";

            Partner partner = await partnerRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (partner is null)
            {
                return Result<string>.Failure(Messages.MSG_Partner + " " + Messages.MSG_NotExist);
            }

            partner.IsDeleted = true;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Partner + " " + Messages.MSG_Delete + "";


        }
    }
}
