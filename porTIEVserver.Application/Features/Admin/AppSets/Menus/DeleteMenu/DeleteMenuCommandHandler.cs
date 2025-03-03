using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Features.Admin.AppSets.Menus.DeleteMenu;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using porTIEVserver.Domain.Repositories.Admin.AppSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Menus.DeleteMenu
{
    internal sealed class DeleteMenuCommandHandler(
        IMenuRepository     menuRepository,
        IUnitOfWork         unitOfWork,
        //IMapper             mapper,
        ICacheService       cacheService
        ) : IRequestHandler<DeleteMenuCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "menus";

            Menu menu = await menuRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (menu is null)
            {
                return Result<string>.Failure(Messages.MSG_Menu + " " + Messages.MSG_NotExist);
            }

            menu.IsDeleted = true;

            await unitOfWork.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Menu + " " + Messages.MSG_Delete + " ";


        }
    }
}
