using MediatR;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.ERP.STK;
using porTIEVserver.Domain.Repositories.ERP.STK;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.STK.Products.GetAllProducts
{
    internal sealed class GetAllProductsQueryHandler(
        IProductRepository productRepository,
        ICacheService cacheService
        ) : IRequestHandler<GetAllProductsQuery, Result<List<Product>>>
    {
        public async Task<Result<List<Product>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            string cacheName = "products";

            List<Product> products;
            products = cacheService.Get<List<Product>>(cacheName);
            if (products is null)
            {
                products =
                    await productRepository
                    //.GetAll()
                    .Where(p => request.ProductTypeValue > 0 && p.ProductType.Value == request.ProductTypeValue)
                    .OrderBy(p => p.Name)
                    .ToListAsync(cancellationToken);

                cacheService.Set(cacheName, products);
            }

            return products;
        }
    }
}
