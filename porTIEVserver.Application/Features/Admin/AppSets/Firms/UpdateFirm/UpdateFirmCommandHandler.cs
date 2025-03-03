using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using porTIEVserver.Domain.Repositories.Admin.AppSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Firms.UpdateFirm
{
    internal sealed class UpdateFirmCommandHandler(
    //ICacheService cacheService,
    IFirmRepository firmRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
    ) : IRequestHandler<UpdateFirmCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateFirmCommand request, CancellationToken cancellationToken)
        {
            //string cacheName = "firms";

            Firm firm = await firmRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (firm is null)
            {
                return Result<string>.Failure(Messages.MSG_Firm + " " + Messages.MSG_NotExist);
            }

            if (firm.TaxNumber != request.TaxNumber)
            {
                bool IsTaxNumberExists = await firmRepository.AnyAsync(p => p.TaxNumber == request.TaxNumber, cancellationToken);

                if (IsTaxNumberExists)
                {
                    return Result<string>.Failure(Messages.MSG_TaxNumber + " " + Messages.MSG_Exist);
                }
            }

            mapper.Map(request, firm);

            firm.LastUpdatedDate = DateTime.UtcNow;

            await unitOfWork.SaveChangesAsync(cancellationToken);

            //cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Firm + " " + Messages.MSG_Update + " ";
        }
    }


}
