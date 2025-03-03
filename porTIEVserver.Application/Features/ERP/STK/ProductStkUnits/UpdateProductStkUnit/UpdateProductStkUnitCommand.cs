using MediatR;
using porTIEVserver.Domain.Entities.Admin;
using porTIEVserver.Domain.Entities.ERP.CRM;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.STK.ProductStkUnits.UpdateProductStkUnit
{
    public sealed record UpdateProductStkUnitCommand(

        int Ref,
        int          LineNr,   
        string       StkUnitRef,
        string       ProductRef,
        double       Carpan,
        double       Bolen

        ) : IRequest<Result<string>>;
}