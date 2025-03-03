using FluentEmail.Core;
using MediatR;
using Microsoft.AspNetCore.Identity;
using porTIEVserver.Domain.Entities.Admin.AppSets;

namespace porTIEVserver.Domain.Events
{
    public sealed class SendConfirmedMailEvent(
        UserManager<AppUser> userManager,
        IFluentEmail fluentEmail) : INotificationHandler<AppUserEvent>
    {
        public async Task Handle(AppUserEvent notification, CancellationToken cancellationToken)
        {
            AppUser? appUser = await userManager.FindByIdAsync(notification.UserRef.ToString());
            if (appUser is not null)
            {
                // onay maili gönder
                await fluentEmail
                .To("ufuktanaci@hotmail.com")
                .Subject("Test mail")
                .Body(CreateBody(appUser), true)
                .SendAsync(cancellationToken);
            }
        }
        private string CreateBody(AppUser appUser)
        {
            string body = "";
            if (appUser is not null)
            {                
                body = $@"<h1>Mail adresinizi onaylamak için aşağıdaki linke tılayın</h1><a href='http://localhost:4200/confirm-email/{appUser.Email}' taget='_blank'>Mail adresinizi onaylamak Buraya tıklayın</a>";
            }
            return body;
        }
    }
}
