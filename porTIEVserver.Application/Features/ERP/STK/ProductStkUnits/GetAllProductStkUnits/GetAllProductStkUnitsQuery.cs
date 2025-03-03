using MediatR;
using porTIEVserver.Domain.Entities.ERP.STK;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.STK.ProductStkUnits.GetAllProductStkUnits
{
    public sealed record GetAllProductStkUnitsQuery(
        string ProductRef
        ) : IRequest<Result<List<ProductStkUnit>>>;
}
