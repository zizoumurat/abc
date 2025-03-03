using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using porTIEVserver.Domain.Repositories.Admin.AppSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Roles.UpdateRole
{
    internal sealed class UpdateRoleCommandHandler(
        IRoleRepository     roleRepository,
        IUnitOfWork         unitOfWork,
        IMapper             mapper,
        ICacheService       cacheService
        ) : IRequestHandler<UpdateRoleCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "roles";

            Role role = await roleRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (role is null)
            {
                return Result<string>.Failure(Messages.MSG_Role + " " + Messages.MSG_NotExist);
            }

            if (role.Code != request.Code)
            {
                bool IsCodeExists = await roleRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

                if (IsCodeExists)
                {
                    return Result<string>.Failure(Messages.MSG_Code + " " + Messages.MSG_Exist);
                }
            }

            mapper.Map(request, role);

            role.LastUpdatedDate = DateTime.UtcNow;

            await unitOfWork.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Role + " " + Messages.MSG_Update + " ";
        }
    }


}
