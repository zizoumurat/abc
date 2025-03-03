using MediatR;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.BankBranchs.CreateBankBranch
{
    public sealed record CreateBankBranchCommand(


        string           Code,
        string           Name,
        int BankRef,
        int InchargeRef,
        string           FullAddress,
        string           CityCode,
        string           CountryCode,
        string           Phone,
        string           Mobile,
        string           Email

        ) : IRequest<Result<string>>;
}
