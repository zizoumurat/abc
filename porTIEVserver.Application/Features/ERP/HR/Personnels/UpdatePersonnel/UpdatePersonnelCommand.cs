using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.HR.Personnels.UpdatePersonnel
{
    public sealed record UpdatePersonnelCommand(

        int Ref,
        string           Code,
        string           FirstName,
        string           LastName,
        string           FullName,
        string           ImgUrl,
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
