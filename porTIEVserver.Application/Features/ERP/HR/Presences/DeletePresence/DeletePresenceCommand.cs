using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.HR.Presences.DeletePresence
{
    public sealed record DeletePresenceCommand(
        int Ref
        ) : IRequest<Result<string>>;
}
