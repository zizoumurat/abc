using MediatR;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Repositories.Admin.ToolSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.BankBranchs.GetAllBankBranchs
{
    internal sealed class GetAllBankBranchsQueryHandler(
        IBankBranchRepository bankBranchRepository,
        ICacheService cacheService
        ) : IRequestHandler<GetAllBankBranchsQuery, Result<List<BankBranch>>>
    {
        public async Task<Result<List<BankBranch>>> Handle(GetAllBankBranchsQuery request, CancellationToken cancellationToken)
        {
            string cacheName = "bankBranchs";

            List<BankBranch> bankBranchs;
            bankBranchs = cacheService.Get<List<BankBranch>>(cacheName);
            if (bankBranchs is null)
            {
                bankBranchs =
                    await bankBranchRepository
                    .GetAll()
                    //.Where(p => p.CountryId == request.CountryId)
                    .OrderBy(p => p.Code)
                    .ToListAsync(cancellationToken);

                cacheService.Set(cacheName, bankBranchs);
            }

            return bankBranchs;
        }
    }
}
