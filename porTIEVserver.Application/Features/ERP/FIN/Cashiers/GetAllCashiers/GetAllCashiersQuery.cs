using MediatR;
using porTIEVserver.Domain.Entities.ERP.FIN;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.FIN.Cashiers.GetAllCashiers
{
    public sealed record GetAllCashiersQuery(
        ) : IRequest<Result<List<Cashier>>>;
}
