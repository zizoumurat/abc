using MediatR;
using Microsoft.AspNetCore.Identity;
using porTIEVserver.Application.Globals;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using porTIEVserver.Domain.Events;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.Auth.SendConfirmEmail
{
    public sealed class SendConfirmEmailCommandHandler(
        UserManager<AppUser> userManager,
        IMediator mediator
        ) : IRequestHandler<SendConfirmEmailCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(SendConfirmEmailCommand request, CancellationToken cancellationToken)
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

            await mediator.Publish(new AppUserEvent(appUser.Id));

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Email + " " + Messages.MSG_Send + "";

        }
    }
}
