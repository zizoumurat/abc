using MediatR;
using porTIEVserver.Domain.Entities.ERP.STK;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.STK.Products.GetAllProducts
{
    public sealed record GetAllProductsQuery(
        int? ProductTypeValue
        ) : IRequest<Result<List<Product>>>;
}
