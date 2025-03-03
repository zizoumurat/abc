using MediatR;
using porTIEVserver.Domain.Entities.Admin;
using porTIEVserver.Domain.Entities.ERP.CRM;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.StkUnitSets.UpdateStkUnitSet
{
    public sealed record UpdateStkUnitSetCommand(

        int Ref,
        string Code,
        string Name

        ) : IRequest<Result<string>>;
}
