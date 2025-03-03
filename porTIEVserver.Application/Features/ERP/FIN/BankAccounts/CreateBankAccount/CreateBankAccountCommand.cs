using MediatR;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Entities.ERP.CRM;
using porTIEVserver.Domain.Enums;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.FIN.BankAccounts.CreateBankAccount
{
    public sealed record CreateBankAccountCommand(


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
