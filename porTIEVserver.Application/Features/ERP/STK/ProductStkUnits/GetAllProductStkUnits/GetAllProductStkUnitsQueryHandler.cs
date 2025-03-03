using MediatR;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.ERP.STK;
using porTIEVserver.Domain.Repositories.ERP.STK;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.STK.ProductStkUnits.GetAllProductStkUnits
{
    internal sealed class GetAllProductStkUnitsQueryHandler(
        IProductStkUnitRepository productstkunitRepository,
        ICacheService cacheService
        ) : IRequestHandler<GetAllProductStkUnitsQuery, Result<List<ProductStkUnit>>>
    {
        public async Task<Result<List<ProductStkUnit>>> Handle(GetAllProductStkUnitsQuery request, CancellationToken cancellationToken)
        {
            string cacheName = "productstkunits";

            List<ProductStkUnit> productstkunits;
            productstkunits = cacheService.Get<List<ProductStkUnit>>(cacheName);
            if (productstkunits is null)
            {
                productstkunits =
                    await productstkunitRepository
                    //.GetAll()
                    .Where(p => p.ProductRef == request.ProductRef)
                    .OrderBy(p => p.ProductRef)
                    .ThenBy(p => p.LineNr)
                    .ToListAsync(cancellationToken);

                cacheService.Set(cacheName, productstkunits);
            }

            return productstkunits;
        }
    }
}
