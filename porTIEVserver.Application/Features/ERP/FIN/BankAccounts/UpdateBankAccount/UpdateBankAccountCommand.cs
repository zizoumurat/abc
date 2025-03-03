using MediatR;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Entities.ERP.CRM;
using porTIEVserver.Domain.Enums;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.FIN.BankAccounts.UpdateBankAccount
{
    public sealed record UpdateBankAccountCommand(

        int Ref,
        string           Code,
        string           Name,
        int BankRef,
        int BranchRef,
        string           AccountNumber,
        string           IBAN,
        int              CurrencyTypeValue,
        decimal          Debit,
        decimal          Credit,
        decimal          Balance

        ) : IRequest<Result<string>>;
}
