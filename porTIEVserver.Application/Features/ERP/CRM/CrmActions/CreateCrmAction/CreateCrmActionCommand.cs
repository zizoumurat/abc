using MediatR;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Entities.ERP.CRM;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.CRM.CrmActions.CreateCrmAction
{
    public sealed record CreateCrmActionCommand(


        int                      CrmActionTypeValue, 
        DateOnly                 FicheDate,
        TimeOnly                 FicheTime,
        string                   FicheNumber,
        string                   DocumentNumber,
        string                   Description1,
        string                   Description2,
        string                   Description3,
        string                   Description4,
        string                   Description5,
        Guid                     TraderId1,
        Contact                 Trader1       

        ) : IRequest<Result<string>>;
}
