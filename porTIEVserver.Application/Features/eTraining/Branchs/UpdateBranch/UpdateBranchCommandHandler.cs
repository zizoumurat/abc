using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Features.eTraining.Branchs.UpdateBranch;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin;
using porTIEVserver.Domain.Entities.ERP.FIN;
using porTIEVserver.Domain.Entities.eTraining;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.FIN;
using porTIEVserver.Domain.Repositories.eTraining;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Branchs.UpdateBranch
{
    internal sealed class UpdateBranchCommandHandler(
        IBranchRepository branchRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<UpdateBranchCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "branchs";

            Branch branch = await branchRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (branch is null)
            {
                return Result<string>.Failure(Messages.MSG_Branch + " " + Messages.MSG_NotExist);
            }

            if (branch.Code != request.Code)
            {
                bool IsCodeExists = await branchRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

                if (IsCodeExists)
                {
                    return Result<string>.Failure(Messages.MSG_Branch + " " + Messages.MSG_Exist);
                }
            }

            mapper.Map(request, branch);

            branch.LastUpdatedDate = DateTime.UtcNow;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Branch + " " + Messages.MSG_Update + "";
        }
    }


}
