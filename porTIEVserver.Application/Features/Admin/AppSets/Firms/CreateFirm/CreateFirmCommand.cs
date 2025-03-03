using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Firms.CreateFirm
{
    public sealed record CreateFirmCommand(


        int         FirmTypeValue,
        string      Code,
        string      Name,
        string      FullAddress,
        string      CityRef,
        string      CountryRef,
        string      TaxOffice,
        string      TaxNumber,
        string      ImgUrl,
        int         CurrencyTypeValue,
        string      DbServ,  
        string      DbName,  
        string      DbUser,  
        string      DbPass

        ) : IRequest<Result<string>>;
}
