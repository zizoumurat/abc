using MediatR;
using Microsoft.AspNetCore.Identity;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Users.DeleteUser
{
    internal sealed class DeleteUserCommandHandler(
        UserManager<AppUser> userManager,
        ICacheService cacheService
        ) : IRequestHandler<DeleteUserCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "users";

            AppUser appUser = await userManager.FindByIdAsync(request.Id.ToString());

            if (appUser is null)
            {
                return Result<string>.Failure(Messages.MSG_User + " " + Messages.MSG_NotExist);
            }

            appUser.IsDeleted = true;

            IdentityResult identityResult = await userManager.UpdateAsync(appUser);

            if (!identityResult.Succeeded)
            {
                return Result<string>.Failure(identityResult.Errors.Select(s => s.Description).ToList());
            }

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_User + " " + Messages.MSG_Delete + "";
        }
    }
}
