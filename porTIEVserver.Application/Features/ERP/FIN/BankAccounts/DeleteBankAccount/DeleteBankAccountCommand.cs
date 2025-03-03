using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.FIN.BankAccounts.DeleteBankAccount
{
    public sealed record DeleteBankAccountCommand(
        int Ref
        ) : IRequest<Result<string>>;
}
