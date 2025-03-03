using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eCargo.eCargo;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.eCargo;
using TS.Result;

namespace porTIEVserver.Application.Features.eCargo.Cargos.DeleteCargo
{
    internal sealed class DeleteCargoMainCommandHandler(
        ICargoMainRepository cargomainRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm
        ) : IRequestHandler<DeleteCargoMainCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteCargoMainCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "cargomains";

            CargoMain cargomain = await cargomainRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (cargomain is null)
            {
                return Result<string>.Failure(Messages.MSG_CargoMain + " " + Messages.MSG_NotExist);
            }

            cargomain.IsDeleted = true;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_CargoMain + " " + Messages.MSG_Delete + "";


        }
    }
}
