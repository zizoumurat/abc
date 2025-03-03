using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using porTIEVserver.Domain.Repositories.Admin.AppSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Roles.CreateRole
{
    internal sealed class CreateRoleCommandHandler(
        IRoleRepository     roleRepository,
        IUnitOfWork         unitOfWork,
        IMapper             mapper,
        ICacheService       cacheService
        ) : IRequestHandler<CreateRoleCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "roles";

            bool IsCodeExists = await roleRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

            if (IsCodeExists)
            {
                return Result<string>.Failure(Messages.MSG_Code + " " + Messages.MSG_Exist);
            }

            Role role = mapper.Map<Role>(request);

            await roleRepository.AddAsync(role, cancellationToken);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Role + " " + Messages.MSG_Create + "";
        }
    }

}
