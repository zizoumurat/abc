using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.STK.ProductStkUnits.DeleteProductStkUnit
{
    public sealed record DeleteProductStkUnitCommand(
        int Ref
        ) : IRequest<Result<string>>;
}
