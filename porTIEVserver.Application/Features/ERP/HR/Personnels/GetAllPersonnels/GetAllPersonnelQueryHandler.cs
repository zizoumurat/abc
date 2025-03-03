using MediatR;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.ERP.HR;
using porTIEVserver.Domain.Repositories.ERP.HR;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.HR.Personnels.GetAllPersonnels
{
    internal sealed class GetAllPersonnelsQueryHandler(
        IPersonnelRepository personnelRepository,
        ICacheService cacheService
        ) : IRequestHandler<GetAllPersonnelsQuery, Result<List<Personnel>>>
    {
        public async Task<Result<List<Personnel>>> Handle(GetAllPersonnelsQuery request, CancellationToken cancellationToken)
        {
            string cacheName = "personnels";

            List<Personnel> personnels;

            personnels = cacheService.Get<List<Personnel>>(cacheName);
            if (personnels is null)
            {
                personnels =
                    await personnelRepository
                    .GetAll()
                    .OrderBy(p => p.FullName)
                    .ToListAsync(cancellationToken);

                cacheService.Set(cacheName, personnels);
            }

            return personnels;
        }
    }
}
