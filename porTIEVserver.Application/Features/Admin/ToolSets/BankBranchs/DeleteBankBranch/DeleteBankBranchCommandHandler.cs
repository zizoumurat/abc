using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Repositories.Admin.ToolSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.BankBranchs.DeleteBankBranch
{
    internal sealed class DeleteBankBranchCommandHandler(
        IBankBranchRepository bankBranchRepository,
        ICacheService cacheService,
        IUnitOfWork unitOfWork
        ) : IRequestHandler<DeleteBankBranchCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteBankBranchCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "bankBranchs";

            BankBranch bankBranch = await bankBranchRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (bankBranch is null)
            {
                return Result<string>.Failure(Messages.MSG_BankBranch + " " + Messages.MSG_NotExist);
            }

            bankBranch.IsDeleted = true;

            await unitOfWork.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_BankBranch + " " + Messages.MSG_Delete + "";


        }
    }
}
