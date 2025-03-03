using AutoMapper;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using porTIEVserver.Domain.Repositories.Admin.AppSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Roles.GetAllRoles
{
    internal sealed class GetAllRolesQueryHandler(
        IRoleRepository     roleRepository,
        //IUnitOfWork         unitOfWork,
        //IMapper             mapper,
        ICacheService       cacheService
        ) : IRequestHandler<GetAllRolesQuery, Result<List<Role>>>
    {
        public async Task<Result<List<Role>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            string cacheName = "roles";

            List<Role> roles;
            roles = cacheService.Get<List<Role>>(cacheName);
            if (roles is null)
            {
                roles =
                    await roleRepository
                    .GetAll()
                    //.Where(p => request.RoleTypeValue > 0 && p.RoleType.Value == request.RoleTypeValue)
                    .OrderBy(p => p.Code)
                    .ToListAsync(cancellationToken);

                cacheService.Set(cacheName, roles);
            }

            return roles;
        }
    }
}
