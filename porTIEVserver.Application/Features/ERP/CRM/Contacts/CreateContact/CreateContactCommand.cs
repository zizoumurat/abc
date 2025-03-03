using MediatR;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.CRM.Contacts.CreateContact
{
    public sealed record CreateContactCommand(


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