using MediatR;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.ERP.CRM;
using porTIEVserver.Domain.Repositories.ERP.CRM;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.CRM.CrmActions.GetAllCrmActions
{
    internal sealed class GetAllCrmActionsQueryHandler(
        ICrmActionRepository crmactionRepository,
        ICacheService cacheService
        ) : IRequestHandler<GetAllCrmActionsQuery, Result<List<CrmAction>>>
    {
        public async Task<Result<List<CrmAction>>> Handle(GetAllCrmActionsQuery request, CancellationToken cancellationToken)
        {
            string cacheName = "crmactions";

            List<CrmAction> crmactions;
            crmactions = cacheService.Get<List<CrmAction>>(cacheName);
            if (crmactions is null)
            {
                crmactions =
                    await crmactionRepository
                    .GetAll()
                    //.Where(p => request.CrmActionTypeValue > 0 && p.CrmActionType.Value == request.CrmActionTypeValue)
                    .OrderBy(p => p.FicheDate)
                    .ThenBy(p => p.FicheNumber)
                    .ToListAsync(cancellationToken);

                cacheService.Set(cacheName, crmactions);
            }

            return crmactions;
        }
    }
}
