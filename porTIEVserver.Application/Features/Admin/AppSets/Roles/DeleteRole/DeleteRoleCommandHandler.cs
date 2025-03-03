using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Features.Admin.AppSets.Roles.DeleteRole;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using porTIEVserver.Domain.Repositories.Admin.AppSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Roles.DeleteRole
{
    internal sealed class DeleteRoleCommandHandler(
        IRoleRepository     roleRepository,
        IUnitOfWork         unitOfWork,
        //IMapper             mapper,
        ICacheService       cacheService
        ) : IRequestHandler<DeleteRoleCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "roles";

            Role role = await roleRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (role is null)
            {
                return Result<string>.Failure(Messages.MSG_Role + " " + Messages.MSG_NotExist);
            }

            role.IsDeleted = true;

            await unitOfWork.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Role + " " + Messages.MSG_Delete + " ";


        }
    }
}
