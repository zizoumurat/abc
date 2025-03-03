using MediatR;
using porTIEVserver.Application.Features.eTraining.Branchs.DeleteBranch;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eTraining;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.FIN;
using porTIEVserver.Domain.Repositories.eTraining;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Branchs.DeleteBranch
{
    internal sealed class DeleteBranchCommandHandler(
        IBranchRepository branchRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm
        ) : IRequestHandler<DeleteBranchCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "branchs";

            Branch branch = await branchRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (branch is null)
            {
                return Result<string>.Failure(Messages.MSG_Branch + " " + Messages.MSG_NotExist);
            }

            branch.IsDeleted = true;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Branch + " " + Messages.MSG_Delete + "";


        }
    }
}
