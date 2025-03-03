using MediatR;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.ERP.FIN;
using porTIEVserver.Domain.Repositories.ERP.FIN;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.FIN.Tradings.GetAllTrading
{
    internal sealed class GetAllTradingsQueryHandler(
        ITradingRepository tradingRepository,
        ICacheService cacheService
        ) : IRequestHandler<GetAllTradingsQuery, Result<List<Trading>>>
    {
        public async Task<Result<List<Trading>>> Handle(GetAllTradingsQuery request, CancellationToken cancellationToken)
        {
            string cacheName = "tradings";

            List<Trading> tradings;
            tradings = cacheService.Get<List<Trading>>(cacheName);
            if (tradings is null)
            {
                tradings =
                    await tradingRepository
                    .GetAll()
                    //                    .Where(p => request.TradingTypeValue > 0 && p.TradingType.Value == request.TradingTypeValue)
                    .OrderBy(p => p.FicheDate)
                     .ThenBy(p => p.FicheNumber)
                    .ToListAsync(cancellationToken);

                cacheService.Set(cacheName, tradings);
            }

            return tradings;
        }
    }
}
