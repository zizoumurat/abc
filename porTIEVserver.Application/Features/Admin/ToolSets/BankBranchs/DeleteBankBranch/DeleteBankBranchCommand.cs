using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.BankBranchs.DeleteBankBranch
{
    public sealed record DeleteBankBranchCommand(
        int Ref
        ) : IRequest<Result<string>>;
}
