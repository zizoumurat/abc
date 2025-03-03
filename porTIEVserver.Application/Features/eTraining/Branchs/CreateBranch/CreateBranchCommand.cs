using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Branchs.CreateBranch
{
    public sealed record CreateBranchCommand(


        string Code,
        string Name,
        string Desc

        ) : IRequest<Result<string>>;
}
