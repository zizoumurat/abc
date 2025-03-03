using MediatR;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Entities.ERP.CRM;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.FIN.Tradings.CreateTrading
{
    public sealed record CreateTradingCommand(


        DateOnly         FicheDate,
        TimeOnly         FicheTime,
        string           FicheNumber,
        string           DocumentNumber,
        string           Description1,
        string           Description2,
        string           Description3,
        string           Description4,
        string           Description5,

        int              TradingTypeValue,
        int              DebitTraderTypeValue,
        string           DebitTraderRef,
        int              DebitCurrTypeValue,
        decimal          DebitCurrRate,
        decimal          DebitAmount,
        string           DebitDesc,

        string           ContraRef,
        int              CreditTraderTypeValue,
        string           CreditTraderRef,
        int              CreditCurrTypeValue,
        decimal          CreditCurrRate,
        decimal          CreditAmount,
        string           CreditDesc

        ) : IRequest<Result<string>>;
}
