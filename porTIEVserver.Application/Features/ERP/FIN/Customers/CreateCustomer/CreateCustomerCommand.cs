using MediatR;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Entities.ERP.CRM;
using porTIEVserver.Domain.Enums;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.FIN.Customers.CreateCustomer
{
    public sealed record CreateCustomerCommand(


        int              CustomerTypeValue,
        int              FirmTypeValue,
        int              CurrencyTypeValue,
        string           Code,
        string           FirstName,
        string           LastName,
        string           FullName,
        string           TaxOffice,
        string           TaxNumber,
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

        ) : IRequest<Result<string>>;
}