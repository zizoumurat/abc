using MediatR;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eTraining;
using porTIEVserver.Domain.Repositories.eTraining;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Branchs.GetAllBranchs
{
    internal sealed class GetAllBranchsQueryHandler(
        IBranchRepository branchRepository,
        ICacheService cacheService
        ) : IRequestHandler<GetAllBranchsQuery, Result<List<Branch>>>
    {
        public async Task<Result<List<Branch>>> Handle(GetAllBranchsQuery request, CancellationToken cancellationToken)
        {
            string cacheName = "branchs";

            List<Branch> branchs;
            branchs = cacheService.Get<List<Branch>>(cacheName);
            if (branchs is null)
            {
                branchs =
                    await branchRepository
                    .GetAll()
                    //                    .Where(p => request.TradingTypeValue > 0 && p.TradingType.Value == request.TradingTypeValue)
                    //.OrderBy(p => p.FicheDate)
                   //  .ThenBy(p => p.FicheNumber)
                    .ToListAsync(cancellationToken);

                cacheService.Set(cacheName, branchs);
            }

            return branchs;
        }
    }
}
