using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Repositories.Admin.ToolSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.BankBranchs.UpdateBankBranch
{
    internal sealed class UpdateBankBranchCommandHandler(
    IBankBranchRepository bankBranchRepository,
    ICacheService cacheService,
    IUnitOfWork unitOfWork,
    IMapper mapper
    ) : IRequestHandler<UpdateBankBranchCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateBankBranchCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "bankBranchs";

            BankBranch bankBranch = await bankBranchRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (bankBranch is null)
            {
                return Result<string>.Failure(Messages.MSG_BankBranch + " " + Messages.MSG_NotExist);
            }

            if (bankBranch.Code != request.Code)
            {
                bool IsTaxNumberExists = await bankBranchRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

                if (IsTaxNumberExists)
                {
                    return Result<string>.Failure(Messages.MSG_TaxNumber + " " + Messages.MSG_Exist);
                }
            }

            mapper.Map(request, bankBranch);

            bankBranch.LastUpdatedDate = DateTime.UtcNow;

            await unitOfWork.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_BankBranch + " " + Messages.MSG_Update + "";
        }
    }


}
