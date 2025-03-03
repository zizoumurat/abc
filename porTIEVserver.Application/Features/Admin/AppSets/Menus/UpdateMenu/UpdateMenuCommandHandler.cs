using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using porTIEVserver.Domain.Repositories.Admin.AppSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Menus.UpdateMenu
{
    internal sealed class UpdateMenuCommandHandler(
        IMenuRepository     menuRepository,
        IUnitOfWork         unitOfWork,
        IMapper             mapper,
        ICacheService       cacheService
        ) : IRequestHandler<UpdateMenuCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateMenuCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "menus";

            Menu menu = await menuRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (menu is null)
            {
                return Result<string>.Failure(Messages.MSG_Menu + " " + Messages.MSG_NotExist);
            }

            if (menu.Code != request.Code)
            {
                bool IsCodeExists = await menuRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

                if (IsCodeExists)
                {
                    return Result<string>.Failure(Messages.MSG_Code + " " + Messages.MSG_Exist);
                }
            }

            mapper.Map(request, menu);

            menu.LastUpdatedDate = DateTime.UtcNow;

            await unitOfWork.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Menu + " " + Messages.MSG_Update + " ";
        }
    }


}
