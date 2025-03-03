using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.CRM.CrmActions.DeleteCrmAction
{
    public sealed record DeleteCrmActionCommand(
        int Ref
        ) : IRequest<Result<string>>;
}
