using MediatR;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Entities.ERP.CRM;
using porTIEVserver.Domain.Enums;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.FIN.Cashiers.CreateCashier
{
    public sealed record CreateCashierCommand(


        int              CurrencyTypeValue, 
        string           Code,
        string           Name,
        decimal          Debit,
        decimal          Credit,
        decimal          Balance

        ) : IRequest<Result<string>>;
}

