using MediatR;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Repositories.Admin.ToolSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.Banks.GetAllBanks
{
    internal sealed class GetAllBanksQueryHandler(
        IBankRepository bankRepository,
        ICacheService cacheService
        ) : IRequestHandler<GetAllBanksQuery, Result<List<Bank>>>
    {
        public async Task<Result<List<Bank>>> Handle(GetAllBanksQuery request, CancellationToken cancellationToken)
        {
            string cacheName = "banks";

            List<Bank> banks;
            banks = cacheService.Get<List<Bank>>(cacheName);
            if (banks is null)
            {
                banks =
                    await bankRepository
                    .GetAll()
                    //.Where(p => p.CountryId == request.CountryId)
                    .OrderBy(p => p.Code)
                    .ToListAsync(cancellationToken);

                cacheService.Set(cacheName, banks);
            }

            return banks;
        }
    }
}
