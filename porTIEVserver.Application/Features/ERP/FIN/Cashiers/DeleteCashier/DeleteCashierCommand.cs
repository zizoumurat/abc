using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.FIN.Cashiers.DeleteCashier
{
    public sealed record DeleteCashierCommand(
        int Ref
        ) : IRequest<Result<string>>;
}
