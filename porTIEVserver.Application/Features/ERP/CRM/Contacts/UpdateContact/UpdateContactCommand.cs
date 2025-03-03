using MediatR;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Entities.ERP.CRM;
using porTIEVserver.Domain.Enums;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.CRM.Contacts.UpdateContact
{
    public sealed record UpdateContactCommand(

        int Ref,
        int              ContactTypeValue,   
        string           Code,
        string           FirstName,
        string           LastName,
        string           FullName,
        string           ImgUrl,
        string           InchargeRef,
        string           FullAddress,
        string           CityRef,
        string           CountryRef,
        string           Phone,
        string           Mobile,
        string           Email
        
        ) : IRequest<Result<string>>;
}