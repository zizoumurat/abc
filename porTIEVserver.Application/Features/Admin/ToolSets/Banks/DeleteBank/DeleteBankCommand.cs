using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.Banks.DeleteBank
{
    public sealed record DeleteBankCommand(
        int Ref
        ) : IRequest<Result<string>>;
}
