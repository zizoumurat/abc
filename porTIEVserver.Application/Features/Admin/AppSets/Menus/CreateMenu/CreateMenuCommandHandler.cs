using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using porTIEVserver.Domain.Repositories.Admin.AppSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Menus.CreateMenu
{
    internal sealed class CreateMenuCommandHandler(
        IMenuRepository     menuRepository,
        IUnitOfWork         unitOfWork,
        IMapper             mapper,
        ICacheService       cacheService
        ) : IRequestHandler<CreateMenuCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "menus";

            bool IsCodeExists = await menuRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

            if (IsCodeExists)
            {
                return Result<string>.Failure(Messages.MSG_Code + " " + Messages.MSG_Exist);
            }

            Menu menu = mapper.Map<Menu>(request);

            await menuRepository.AddAsync(menu, cancellationToken);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Menu + " " + Messages.MSG_Create + "";
        }
    }

}
