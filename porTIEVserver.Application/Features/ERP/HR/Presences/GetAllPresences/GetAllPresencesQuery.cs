using MediatR;
using porTIEVserver.Domain.Entities.ERP.HR;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.HR.Presences.GetAllPresences
{
    public sealed record GetAllPresencesQuery(        
        ) : IRequest<Result<List<Presence>>>;
}
