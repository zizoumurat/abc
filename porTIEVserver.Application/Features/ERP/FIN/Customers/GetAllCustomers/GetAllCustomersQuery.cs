using MediatR;
using porTIEVserver.Domain.Entities.ERP.FIN;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.FIN.Customers.GetAllCustomers
{
    public sealed record GetAllCustomersQuery(
        ) : IRequest<Result<List<Customer>>>;
}
