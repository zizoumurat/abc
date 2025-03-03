using System.Text.RegularExpressions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using porTIEVserver.Domain.Repositories;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Users.GetAllUsers
{
    internal sealed class GetAllUsersQueryHandler(
        UserManager<AppUser> userManager,
        ICacheService cacheService
        ) : IRequestHandler<GetAllUsersQuery, Result<List<AppUser>>>
    {
        public async Task<Result<List<AppUser>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            string cacheName = "users";

            List<AppUser> users;
            users = cacheService.Get<List<AppUser>>(cacheName);
            if (users is null)
            {
                users = await userManager.Users
                        //.Include(p => p.RiteRefs!)
                        //.ThenInclude(p => p.Firm)
                        //.Include(p => p.UsersMenus!)
                        //.ThenInclude(p => p.Menu)
                        //.Include(p => p.UsersRoles!)
                        //.ThenInclude(p => p.Role)
                        .OrderBy(p => p.FirstName)
                        .ToListAsync(cancellationToken);

                cacheService.Set(cacheName, users);
            }

            return users;
        }
    }
}
