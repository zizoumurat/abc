using MediatR;
using Microsoft.AspNetCore.Identity;
using porTIEVserver.Application.Globals;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.Auth.ConfirmEmail
{
    internal sealed class ConfirmEmailCommandHandler(
        UserManager<AppUser> userManager) : IRequestHandler<ConfirmEmailCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            AppUser appUser = await userManager.FindByEmailAsync(request.Email);
            if (appUser is null)
            {
                // mail adresi kayıtlı değil
                return Messages.MSG_Email + " " + Messages.MSG_NotExist;
            }
            if (appUser.IsDeleted)
            {
                // mail adresi aktif değil
                return Messages.MSG_User + " " + Messages.MSG_NotActive;
            }

            appUser.EmailConfirmed = true;
            await userManager.UpdateAsync(appUser);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Email + " " + Messages.MSG_Confirm + "";

        }

    }

}
