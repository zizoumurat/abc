using AutoMapper;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using porTIEVserver.Domain.Repositories.Admin.AppSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Menus.GetAllMenus
{
    internal sealed class GetAllMenusQueryHandler(
        IMenuRepository     menuRepository,
        //IUnitOfWork         unitOfWork,
        //IMapper             mapper,
        ICacheService       cacheService
        ) : IRequestHandler<GetAllMenusQuery, Result<List<Menu>>>
    {
        public async Task<Result<List<Menu>>> Handle(GetAllMenusQuery request, CancellationToken cancellationToken)
        {
            string cacheName = "menus";

            List<Menu> menus;
            menus = cacheService.Get<List<Menu>>(cacheName);
            if (menus is null)
            {
                menus =
                    await menuRepository
                    .GetAll()
                    //.Where(p => request.MenuTypeValue > 0 && p.MenuType.Value == request.MenuTypeValue)
                    .OrderBy(p => p.Code)
                    .ToListAsync(cancellationToken);

                cacheService.Set(cacheName, menus);
            }

            return menus;
        }
    }
}
