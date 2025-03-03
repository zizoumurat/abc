using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.Banks.CreateBank
{
    public sealed record CreateBankCommand(


        string Code,
        string Name,
        string Desc,
        string CountryCode

        ) : IRequest<Result<string>>;
}
