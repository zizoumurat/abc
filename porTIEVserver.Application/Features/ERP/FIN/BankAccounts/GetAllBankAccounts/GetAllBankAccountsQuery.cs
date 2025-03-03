using MediatR;
using porTIEVserver.Domain.Entities.ERP.FIN;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.FIN.BankAccounts.GetAllBankAccounts
{
    public sealed record GetAllBankAccountsQuery(
        ) : IRequest<Result<List<BankAccount>>>;
}
