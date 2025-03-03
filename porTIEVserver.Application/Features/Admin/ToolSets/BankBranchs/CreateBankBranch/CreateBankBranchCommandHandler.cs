using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Repositories.Admin.ToolSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.BankBranchs.CreateBankBranch
{
    internal sealed class CreateBankBranchCommandHandler(
        IBankBranchRepository bankBranchRepository,
        ICacheService cacheService,
        IUnitOfWork unitOfWork,
        IMapper mapper
        ) : IRequestHandler<CreateBankBranchCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateBankBranchCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "bankBranchs";

            bool IsBankBranchExists = await bankBranchRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

            if (IsBankBranchExists)
            {
                return Result<string>.Failure(Messages.MSG_BankBranch + " " + Messages.MSG_Exist);
            }

            BankBranch bankBranch = mapper.Map<BankBranch>(request);

            await bankBranchRepository.AddAsync(bankBranch, cancellationToken);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_BankBranch + " " + Messages.MSG_Create + "";
        }
    }

}
