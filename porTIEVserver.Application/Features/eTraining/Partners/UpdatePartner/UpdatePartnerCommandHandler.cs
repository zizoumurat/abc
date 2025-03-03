using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Features.eTraining.Partners.UpdatePartner;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin;
using porTIEVserver.Domain.Entities.ERP.FIN;
using porTIEVserver.Domain.Entities.eTraining;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.FIN;
using porTIEVserver.Domain.Repositories.eTraining;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Partners.UpdatePartner
{
    internal sealed class UpdatePartnerCommandHandler(
        IPartnerRepository partnerRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<UpdatePartnerCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdatePartnerCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "partners";

            Partner partner = await partnerRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (partner is null)
            {
                return Result<string>.Failure(Messages.MSG_Partner + " " + Messages.MSG_NotExist);
            }

            if (partner.Code != request.Code)
            {
                bool IsCodeExists = await partnerRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

                if (IsCodeExists)
                {
                    return Result<string>.Failure(Messages.MSG_TaxNumber + " " + Messages.MSG_Exist);
                }
            }

            mapper.Map(request, partner);

            partner.LastUpdatedDate = DateTime.UtcNow;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Partner + " " + Messages.MSG_Update + "";
        }
    }


}
