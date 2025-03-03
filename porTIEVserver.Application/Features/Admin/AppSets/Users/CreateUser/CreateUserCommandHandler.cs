using AutoMapper;
using GenericRepository;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using porTIEVserver.Domain.Events;
using porTIEVserver.Domain.Repositories.Admin.AppSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Users.CreateUser
{
    internal sealed class CreateUserCommandHandler(
        ICacheService cacheService,
        IMediator mediator,
        UserManager<AppUser> userManager,
        IRiteRepository riteRepository,
        //IRoleUserMenuRepository roleUserRepository,
        //IMenuUserRepository menuUserRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper
        ) : IRequestHandler<CreateUserCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "users";

            bool isUserNameExist = await userManager.Users.AnyAsync(p => p.UserName == request.UserName, cancellationToken);

            if (isUserNameExist)
            {
                return Result<string>.Failure(Messages.MSG_User + " " + Messages.MSG_Exist);
            }

            bool isUserEmailExist = await userManager.Users.AnyAsync(p => p.UserName == request.UserName, cancellationToken);

            if (isUserEmailExist)
            {
                return Result<string>.Failure(Messages.MSG_Email + " " + Messages.MSG_Exist);
            }

            AppUser appUser = mapper.Map<AppUser>(request);
            /* Pasword boş ise GlobalMessages Password */
            string request_PassWord = request.Password ?? "";

            if (request_PassWord == null || request_PassWord == "")
                request_PassWord = Parameters.AdminUser_Password;
            //
            IdentityResult identityResult = await userManager.CreateAsync(appUser, request_PassWord);
            //
            if (!identityResult.Succeeded)
            {
                return Result<string>.Failure(identityResult.Errors.Select(s => s.Description).ToList());
            }

            // Rite
            List<Rite> usersRites = request.RiteRefs!.Select(s => new Rite { AppUserRef = appUser.Ref}).ToList();
            //
            await riteRepository.AddRangeAsync(usersRites, cancellationToken);
            //
            await unitOfWork.SaveChangesAsync(cancellationToken);
            //
            cacheService.Remove(cacheName);
            // onay maili gönderme
            string mailSend = "";
            try
            {
                await mediator.Publish(new AppUserEvent(appUser.Id));
            }
            catch (Exception ex)
            {
                mailSend = "!!! " + Messages.MSG_NotSendConfirmMail + "(" + (ex.InnerException?.Message ?? "") + "-" + (ex.Message ?? "") + ")" + " !!!";
            }

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_User + " " + Messages.MSG_Create + " " + mailSend;
        }
    }
}
