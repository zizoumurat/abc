using MediatR;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.ERP.FIN;
using porTIEVserver.Domain.Repositories.ERP.FIN;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.FIN.Cashiers.GetAllCashiers
{
    internal sealed class GetAllCashiersQueryHandler(
        ICashierRepository cashierRepository,
        ICacheService cacheService
        ) : IRequestHandler<GetAllCashiersQuery, Result<List<Cashier>>>
    {
        public async Task<Result<List<Cashier>>> Handle(GetAllCashiersQuery request, CancellationToken cancellationToken)
        {
            string cacheName = "cashiers";

            List<Cashier> cashiers;
            cashiers = cacheService.Get<List<Cashier>>(cacheName);
            if (cashiers is null)
            {
                cashiers =
                    await cashierRepository
                    .GetAll()
                    //.Where(p => request.CashierTypeValue > 0 && p.CashierType.Value == request.CashierTypeValue)
                    .OrderBy(p => p.Name)
                    .ToListAsync(cancellationToken);

                cacheService.Set(cacheName, cashiers);
            }

            return cashiers;
        }
    }
}
