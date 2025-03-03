using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.FIN.Customers.DeleteCustomer
{
    public sealed record DeleteCustomerCommand(
        int Ref
        ) : IRequest<Result<string>>;
}
