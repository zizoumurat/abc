using MediatR;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eTraining;
using porTIEVserver.Domain.Repositories.eTraining;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Partners.GetAllPartners
{
    internal sealed class GetAllPartnersQueryHandler(
        IPartnerRepository partnerRepository,
        ICacheService cacheService
        ) : IRequestHandler<GetAllPartnersQuery, Result<List<Partner>>>
    {
        public async Task<Result<List<Partner>>> Handle(GetAllPartnersQuery request, CancellationToken cancellationToken)
        {
            string cacheName = "partners";

            List<Partner> partners;
            partners = cacheService.Get<List<Partner>>(cacheName);
            if (partners is null)
            {
                partners =
                    await partnerRepository
                    .GetAll()
                    //                    .Where(p => request.TradingTypeValue > 0 && p.TradingType.Value == request.TradingTypeValue)
                    //.OrderBy(p => p.FicheDate)
                   //  .ThenBy(p => p.FicheNumber)
                    .ToListAsync(cancellationToken);

                cacheService.Set(cacheName, partners);
            }

            return partners;
        }
    }
}
