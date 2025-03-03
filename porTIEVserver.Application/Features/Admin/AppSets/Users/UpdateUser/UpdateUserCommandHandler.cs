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

namespace porTIEVserver.Application.Features.Admin.AppSets.Users.UpdateUser
{
    internal sealed class UpdateUserCommandHandler(
        ICacheService cacheService,
        IMediator mediator,
        UserManager<AppUser> userManager,
        IRiteRepository riteRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper
        ) : IRequestHandler<UpdateUserCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "users";

            AppUser appUser =
                await userManager.Users
                .Where(p => p.Id == request.Id)
                //.Include(p => p.RiteRefs)
                //.Include(p => p.UsersMenus)
                //.Include(p => p.UsersRoles)
                .FirstOrDefaultAsync(cancellationToken);

            if (appUser is null)
            {
                return Result<string>.Failure(Messages.MSG_User + " " + Messages.MSG_NotExist);
            }

            if (appUser.UserName != request.UserName)
            {
                bool isUserNameExist = await userManager.Users.AnyAsync(p => p.UserName == request.UserName, cancellationToken);
                if (isUserNameExist)
                {
                    return Result<string>.Failure(Messages.MSG_User + " " + Messages.MSG_Exist);
                }

            }
            bool isEmailChanged = false;
            if (appUser.Email != request.Email)
            {
                bool isUserEmailExist = await userManager.Users.AnyAsync(p => p.Email == request.Email, cancellationToken);
                if (isUserEmailExist)
                {
                    return Result<string>.Failure(Messages.MSG_Email + " " + Messages.MSG_Exist);
                }

                isEmailChanged = true;
                appUser.EmailConfirmed = false;

            }

            mapper.Map(request, appUser);

            IdentityResult identityResult = await userManager.UpdateAsync(appUser);

            if (!identityResult.Succeeded)
            {
                return Result<string>.Failure(identityResult.Errors.Select(s => s.Description).ToList());
            }

            if (request.Password is not null)
            {
                string token = await userManager.GeneratePasswordResetTokenAsync(appUser);

                identityResult = await userManager.ResetPasswordAsync(appUser, token, request.Password);

                if (!identityResult.Succeeded)
                {
                    return Result<string>.Failure(identityResult.Errors.Select(s => s.Description).ToList());
                }
            }

            // Rite
            //riteRepository.DeleteRange(appUser.RiteRefs);
            //
            List<Rite> usersRites = request.RiteRefs!.Select(s => new Rite { AppUserRef = appUser.Ref }).ToList();
            //
            await riteRepository.AddRangeAsync(usersRites, cancellationToken);
            //
            appUser.LastUpdatedDate = DateTime.UtcNow;

            await unitOfWork.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            if (isEmailChanged)
            {
                // onay maili gönder                
                try
                {
                    await mediator.Publish(new AppUserEvent(appUser.Id));
                }
                catch (Exception ex)
                {
                    return Result<string>.Failure(ex.InnerException?.Message ?? ex.Message);
                }
            }

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_User + " " + Messages.MSG_Update + "";
        }
    }

}
