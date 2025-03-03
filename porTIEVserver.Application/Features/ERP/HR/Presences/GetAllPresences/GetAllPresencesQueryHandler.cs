using MediatR;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.ERP.HR;
using porTIEVserver.Domain.Repositories.ERP.HR;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.HR.Presences.GetAllPresences
{
    internal sealed class GetAllPresencesQueryHandler(
        IPresenceRepository presenceRepository,
        ICacheService cacheService
        ) : IRequestHandler<GetAllPresencesQuery, Result<List<Presence>>>
    {
        public async Task<Result<List<Presence>>> Handle(GetAllPresencesQuery request, CancellationToken cancellationToken)
        {
            string cacheName = "presences";

            List<Presence> presences;

            presences = cacheService.Get<List<Presence>>(cacheName);
            if (presences is null)
            {
                presences =
                    await presenceRepository
                    .GetAll()
                    .OrderBy(p => p.ScanTime)
                    .ToListAsync(cancellationToken);

                cacheService.Set(cacheName, presences);
            }

            return presences;
        }
    }
}
