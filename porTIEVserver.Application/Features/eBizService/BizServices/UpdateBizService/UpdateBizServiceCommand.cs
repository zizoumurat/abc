using MediatR;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Entities.ERP.CRM;
using TS.Result;

namespace porTIEVserver.Application.Features.eCargo.BizServices.UpdateBizService
{
    public sealed record UpdateBizServiceCommand(

        int Ref,
        string           Code,
        string           Name,
        string           InchargeRef,
        string           FullAddress,
        string           CityRef,
        string           CountryRef,
        string           Phone,
        string           Mobile,
        string           Email

        ) : IRequest<Result<string>>;
}