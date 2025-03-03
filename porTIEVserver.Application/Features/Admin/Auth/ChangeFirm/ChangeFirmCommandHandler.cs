using System.Data;
using System;
using System.Security.Claims;
using System.Xml.Linq;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Features.Admin.Auth.Login;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using porTIEVserver.Domain.Repositories.Admin.AppSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.Auth.ChangeFirm
{
    internal sealed class ChangeFirmCommandHandler(
        UserManager<AppUser> userManager,
        //IFirmRepository firmRepository,
        //IRoleRepository roleRepository,
        //IMenuRepository menuRepository,
        IRiteRepository riteRepository,
        IHttpContextAccessor httpContextAccessor,
        IJwtProvider jwtProvider
        ) : IRequestHandler<ChangeFirmCommand, Result<LoginCommandResponse>>
    {
        public async Task<Result<LoginCommandResponse>> Handle(ChangeFirmCommand request, CancellationToken cancellationToken)
        {
            if (httpContextAccessor.HttpContext is null)
            {
                return Result<LoginCommandResponse>.Failure(Globals.Messages.MSG_NoAuthorised);
            }

            string userIdString = httpContextAccessor.HttpContext.User.FindFirstValue("Id");
            if (userIdString is null)
            {
                return Result<LoginCommandResponse>.Failure(Globals.Messages.MSG_NoAuthorised);
            }

            AppUser appUser = await userManager.FindByIdAsync(userIdString);
            if (appUser == null)
            {
                return Result<LoginCommandResponse>.Failure(Globals.Messages.MSG_User + " " + Globals.Messages.MSG_NotExist);
            }

            #region //CreateToken
            // Firm
            #region Firm

            List<int> firmRefs = await riteRepository
                .Where(p => p.AppUserRef == appUser.Ref && p.BttnRef > 0)
                .Select(p => p.FirmRef)
                .Distinct()
                .ToListAsync(cancellationToken);

            string firmRef = firmRefs.First().ToString();

            #endregion

            // Role
            #region Role

            List<int> roleRefs = await riteRepository
                .Where(p => p.AppUserRef == appUser.Ref && p.BttnRef > 0 && p.FirmRef.ToString() == firmRef)
                .Select(p => p.RoleRef)
                .Distinct()
                .ToListAsync(cancellationToken);

            string roleRef = roleRefs.First().ToString();

            #endregion

            // Menu
            #region Menu

            //List<int> menuRefs = await riteRepository
            //    .Where(p => p.AppUserId == appUser.Id && p.BttnRef > 0 && p.FirmRef.ToString() == firmRef && p.RoleRef.ToString() == roleRef)
            //    .Select(p => p.MenuRef)
            //    .Distinct()
            //    .ToListAsync(cancellationToken);

            //string menuRef = menuRefs.First().ToString();

            #endregion

            //
            var responseToken = await jwtProvider.CreateToken(appUser,
                firmRef, firmRefs,
                roleRef, roleRefs
                //, menuRef, menuRefs
                );

            #endregion

            return responseToken;

        }
    }

}
