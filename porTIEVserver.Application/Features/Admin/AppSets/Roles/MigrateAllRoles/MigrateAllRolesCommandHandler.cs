using MediatR;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using porTIEVserver.Domain.Repositories.Admin.AppSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Roles.MigrateAllRoles
{
    public sealed class MigrateAllRolesCommandHandler(
        IRoleRepository     roleRepository,
        //IUnitOfWork         unitOfWork,
        //IMapper             mapper,
        ICacheService       cacheService
        ) : IRequestHandler<MigrateAllRolesCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(MigrateAllRolesCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "roles";

            List<Role> roles = await roleRepository.GetAll().ToListAsync(cancellationToken);

            //roleService.MigrateAll(roles);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Database + " " + Messages.MSG_Update + " ";

        }
    }
}

