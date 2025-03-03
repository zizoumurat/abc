using MediatR;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using porTIEVserver.Domain.Repositories.Admin.AppSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Firms.GetAllFirms
{
    internal sealed class GetAllFirmsQueryHandler(
        IFirmRepository firmRepository
        //ICacheService cacheService
        ) : IRequestHandler<GetAllFirmsQuery, Result<List<Firm>>>
    {
        public async Task<Result<List<Firm>>> Handle(GetAllFirmsQuery request, CancellationToken cancellationToken)
        {
            //string cacheName = "firms";

            //List<AppFirm>? firms;
            //firms = cacheService.Get<List<AppFirm>>(cacheName);
            //if (firms is null)
            //{
                List<Firm> firms =
                    await firmRepository
                    .GetAll()
                    //.Where(p => request.FirmTypeValue > 0 && p.FirmType.Value == request.FirmTypeValue)
                    .OrderBy(p => p.Name)
                    .ToListAsync(cancellationToken);

                //cacheService.Set(cacheName, firms);
            //}

            return firms;
        }
    }
}
