using MediatR;
using porTIEVserver.Domain.Entities.Admin;
using porTIEVserver.Domain.Entities.ERP.CRM;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.STK.Products.UpdateProduct
{
    public sealed record UpdateProductCommand(

        int Ref,
        int         ProductTypeValue,
        string      Code,
        string      Name,
        string      Name2,
        string      Name3,
        string      Name4,
        string      SpeCode,
        string      SpeCode2,
        string      SpeCode3,
        string      SpeCode4,
        string      SpeCode5,
        string      StkGroup,
        decimal     Debit,
        decimal     Credit,
        decimal     Balance

        ) : IRequest<Result<string>>;
}