using MediatR;
using porTIEVserver.Domain.Entities.ERP.CRM;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.CRM.CrmActions.GetAllCrmActions
{
    public sealed record GetAllCrmActionsQuery(
        int CargoActionType
        ) : IRequest<Result<List<CrmAction>>>;
}
