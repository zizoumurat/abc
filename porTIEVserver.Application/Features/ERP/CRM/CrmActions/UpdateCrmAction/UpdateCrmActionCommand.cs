using MediatR;
using porTIEVserver.Domain.Entities.ERP.CRM;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.CRM.CrmActions.UpdateCrmAction
{
    public sealed record UpdateCrmActionCommand(

        int Ref,
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
        string                   TraderRef1

        ) : IRequest<Result<string>>;
}
