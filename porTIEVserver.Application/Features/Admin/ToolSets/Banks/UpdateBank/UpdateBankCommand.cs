using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.Banks.UpdateBank
{
    public sealed record UpdateBankCommand(

        int Ref,
        string Code,
        string Name,
        string Desc,
        string CountryCode

        ) : IRequest<Result<string>>;
}
