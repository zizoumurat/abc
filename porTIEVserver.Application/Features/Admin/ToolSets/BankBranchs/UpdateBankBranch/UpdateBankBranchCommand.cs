using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.BankBranchs.UpdateBankBranch
{
    public sealed record UpdateBankBranchCommand(

        int Ref,
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
