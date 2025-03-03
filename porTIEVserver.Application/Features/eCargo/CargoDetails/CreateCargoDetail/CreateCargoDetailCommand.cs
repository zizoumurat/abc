using MediatR;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Entities.eCargo.eCargo;
using porTIEVserver.Domain.Entities.ERP.CRM;
using TS.Result;

namespace porTIEVserver.Application.Features.eCargo.CargoDetails.CreateCargoDetail
{
    public sealed record CreateCargoDetailCommand(


        int                      TradingTypeValue,
        DateOnly                 FicheDate,
        TimeOnly                 FicheTime,
        string                   FicheNumber,
        string                   Description1,
        string                   Description2,
        string                   Description3,
        string                   Description4,
        string                   Description5,
        int                      CargoStatusValue,
        int                      TransportTypeValue,
        string                   SenderOfficeTraderRef,
        string                   SenderTraderRef,
        string                   PickerOfficeTraderRef,
        string                   PickerTraderRef,
        string                   PayerOfficeTraderRef,
        string                   PayerTraderRef,
        string                   CarrierTraderRef

        ) : IRequest<Result<string>>;
}
