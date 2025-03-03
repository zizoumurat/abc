using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.HR.Personnels.DeletePersonnel
{
    public sealed record DeletePersonnelCommand(
        int Ref
        ) : IRequest<Result<string>>;
}
