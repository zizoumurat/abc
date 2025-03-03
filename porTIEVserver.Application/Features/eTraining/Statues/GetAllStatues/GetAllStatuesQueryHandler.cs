using MediatR;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eTraining;
using porTIEVserver.Domain.Repositories.eTraining;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Statues.GetAllStatues
{
    internal sealed class GetAllStatuesQueryHandler(
        IStatusRepository courseRepository,
        ICacheService cacheService
        ) : IRequestHandler<GetAllStatuesQuery, Result<List<Status>>>
    {
        public async Task<Result<List<Status>>> Handle(GetAllStatuesQuery request, CancellationToken cancellationToken)
        {
            string cacheName = "statues";

            List<Status> statues;
            statues = cacheService.Get<List<Status>>(cacheName);
            if (statues is null)
            {
                statues =
                    await courseRepository
                    .GetAll()
                    //                    .Where(p => request.TradingTypeValue > 0 && p.TradingType.Value == request.TradingTypeValue)
                    //.OrderBy(p => p.FicheDate)
                   //  .ThenBy(p => p.FicheNumber)
                    .ToListAsync(cancellationToken);

                cacheService.Set(cacheName, statues);
            }

            return statues;
        }
    }
}
