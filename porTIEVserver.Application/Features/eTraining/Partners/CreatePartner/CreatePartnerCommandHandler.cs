using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Features.eTraining.Partners.CreatePartner;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eTraining;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.eTraining;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Partners.CreatePartner
{
    internal sealed class CreatePartnerCommandHandler(
        IPartnerRepository partnerRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<CreatePartnerCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreatePartnerCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "partners";

            bool IsCodeExists = await partnerRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

            if (IsCodeExists)
            {
                return Result<string>.Failure(Messages.MSG_Partner + " " + Messages.MSG_Exist);
            }

            Partner partner = mapper.Map<Partner>(request);

            await partnerRepository.AddAsync(partner, cancellationToken);

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Partner + " " + Messages.MSG_Create + "";
        }
    }

}
