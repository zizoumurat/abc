using GenericRepository;
using MediatR;
using porTIEVserver.Application.Features.Admin.AppSets.Firms.DeleteFirm;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using porTIEVserver.Domain.Repositories.Admin.AppSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Firms.DeleteFirm
{
    internal sealed class DeleteFirmCommandHandler(
        IFirmRepository firmRepository,
        //ICacheService cacheService,
        IUnitOfWork unitOfWork
        ) : IRequestHandler<DeleteFirmCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteFirmCommand request, CancellationToken cancellationToken)
        {
            //string cacheName = "firms";

            Firm firm = await firmRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (firm is null)
            {
                return Result<string>.Failure(Messages.MSG_Firm + " " + Messages.MSG_NotExist);
            }

            firm.IsDeleted = true;

            await unitOfWork.SaveChangesAsync(cancellationToken);

            //cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Firm + " " + Messages.MSG_Delete + " ";


        }
    }
}
