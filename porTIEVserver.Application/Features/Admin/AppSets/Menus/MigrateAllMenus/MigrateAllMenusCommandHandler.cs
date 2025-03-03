using MediatR;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using porTIEVserver.Domain.Repositories.Admin.AppSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Menus.MigrateAllMenus
{
    public sealed class MigrateAllMenusCommandHandler(
        IMenuRepository     menuRepository,
        //IUnitOfWork         unitOfWork,
        //IMapper             mapper,
        ICacheService       cacheService
        ) : IRequestHandler<MigrateAllMenusCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(MigrateAllMenusCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "menus";

            List<Menu> menus = await menuRepository.GetAll().ToListAsync(cancellationToken);

            //menuService.MigrateAll(menus);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Database + " " + Messages.MSG_Update + " ";

        }
    }
}

