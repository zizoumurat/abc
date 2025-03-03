using MediatR;
using porTIEVserver.Domain.Entities.Admin;
using porTIEVserver.Domain.Entities.ERP.CRM;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.StkUnits.UpdateStkUnit
{
    public sealed record UpdateStkUnitCommand(

        int Ref,
        string Code,
        string Name,
        double Carpan,
        double Bolen

        ) : IRequest<Result<string>>;
}
