using MediatR;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eBizService.eBizService;
using porTIEVserver.Domain.Entities.eCargo;
using porTIEVserver.Domain.Repositories.eBizService;
using porTIEVserver.Domain.Repositories.eCargo;
using TS.Result;

namespace porTIEVserver.Application.Features.eCargo.BizServices.GetAllBizServices
{
    internal sealed class GetAllBizServicesQueryHandler(
        IBizServiceRepository bizServiceRepository,
        ICacheService cacheService
        ) : IRequestHandler<GetAllBizServicesQuery, Result<List<BizService>>>
    {
        public async Task<Result<List<BizService>>> Handle(GetAllBizServicesQuery request, CancellationToken cancellationToken)
        {
            string cacheName = "bizservices";

            List<BizService> bizservices;
            bizservices = cacheService.Get<List<BizService>>(cacheName);
            if (bizservices is null)
            {
                bizservices =
                    await bizServiceRepository
                    .GetAll()
//                    .Where(p => request.BizServiceTypeValue > 0 && p.BizServiceType.Value == request.BizServiceTypeValue)
                    .OrderBy(p => p.Name)
                    .ToListAsync(cancellationToken);

                cacheService.Set(cacheName, bizservices);
            }

            return bizservices;
        }
    }
}
