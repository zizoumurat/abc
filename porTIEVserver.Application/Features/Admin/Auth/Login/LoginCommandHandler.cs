using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using porTIEVserver.Domain.Repositories.Admin.AppSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.Auth.Login
{
    internal sealed class LoginCommandHandler(
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        //IFirmRepository firmRepository,
        //IRoleRepository roleRepository,
        //IMenuRepository menuRepository,
        IRiteRepository riteRepository,
        IJwtProvider jwtProvider) : IRequestHandler<LoginCommand, Result<LoginCommandResponse>>
    {
        public async Task<Result<LoginCommandResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            AppUser appUser = await userManager.Users
                .FirstOrDefaultAsync(p =>
                p.UserName == request.EmailOrUserName ||
                p.Email == request.EmailOrUserName,
                cancellationToken);

            if (appUser is null)
            {
                return (500, Messages.MSG_User + " " + Messages.MSG_NotExist);
            }

            SignInResult signInResult = await signInManager.CheckPasswordSignInAsync(appUser, request.Password, true);

            if (signInResult.IsLockedOut)
            {
                TimeSpan? timeSpan = appUser.LockoutEnd - DateTime.UtcNow;
                string msgBlocked = Messages.MSG_MaxFailedAccessAttempts.Replace("{MaxFailedAccessAttempts}", Parameters.MaxFailedAccessAttempts.ToString());
                if (timeSpan is null) // " 3 kez yanlış şifre girildiği için Kullanıcınız 5 dakika süreyle bloke edilmiştir";
                    msgBlocked = msgBlocked.Replace("{DefaultLockoutTimeSpan}", Parameters.DefaultLockoutTimeSpan.ToString());
                else // // $" 3 kez yanlış şifre girildiği için Kullanıcınız timeSpan.Value.TotalMinutes.ToString() dakika süreyle bloke edilmiştir";
                    msgBlocked = msgBlocked.Replace("{DefaultLockoutTimeSpan}", timeSpan.Value.TotalMinutes.ToString());

                return (500, msgBlocked);
            }

            if (signInResult.IsNotAllowed)
            {
                return (500, Messages.MSG_Email + " " + Messages.MSG_NotConfirmed); // "Mail adresiniz onaylı değil");
            }

            if (!signInResult.Succeeded)
            {
                return (500, Messages.MSG_Wrong_Password); // "Şifreniz yanlış");
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


