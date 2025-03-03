using MediatR;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.BankBranchs.GetAllBankBranchs
{
    public sealed record GetAllBankBranchsQuery(
        ) : IRequest<Result<List<BankBranch>>>;
}
