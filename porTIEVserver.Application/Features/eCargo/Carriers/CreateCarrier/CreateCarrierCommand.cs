using MediatR;
using porTIEVserver.Domain.Entities.ERP.CRM;
using TS.Result;

namespace porTIEVserver.Application.Features.eCargo.Carriers.CreateCarrier
{
    public sealed record CreateCarrierCommand(


        int              CurrencyTypeValue,
        string           Code,
        string           Name,
        string           Desc,
        string           ImgUrl,
        string           InchargeRef,
        string           FullAddress,
        string           CityRef,
        string           CountryRef,
        string           Phone,
        string           Mobile,
        string           Email,
        decimal          Debit,
        decimal          Credit,
        decimal          Balance
        
        //List<Trading>?   Tradings      

        ) : IRequest<Result<string>>;
}
