using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Partners.CreatePartner
{
    public sealed record CreatePartnerCommand(


        string Code,
        string Name,
        string Desc

        ) : IRequest<Result<string>>;
}
