using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.STK.Products.DeleteProduct
{
    public sealed record DeleteProductCommand(
        int Ref
        ) : IRequest<Result<string>>;
}
