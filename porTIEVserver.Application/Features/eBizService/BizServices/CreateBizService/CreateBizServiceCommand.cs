using MediatR;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Entities.ERP.CRM;
using TS.Result;

namespace porTIEVserver.Application.Features.eCargo.BizServices.CreateBizService
{
    public sealed record CreateBizServiceCommand(


        string           Code,
        string           Name,
        Contact         Incharge,
        string           FullAddress,
        City            City,
        Country         Country,
        string           Phone,
        string           Mobile,
        string           Email

        ) : IRequest<Result<string>>;
}
