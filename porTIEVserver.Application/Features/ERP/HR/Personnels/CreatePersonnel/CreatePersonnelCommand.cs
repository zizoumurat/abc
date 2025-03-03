using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.HR.Personnels.CreatePersonnel
{
    public sealed record CreatePersonnelCommand(


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
