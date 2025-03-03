using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eCargo.eCargo;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.eCargo;
using TS.Result;

namespace porTIEVserver.Application.Features.eCargo.CargoActions.DeleteCargoAction
{
    internal sealed class DeleteCargoActionCommandHandler(
        ICargoActionRepository cargodetailRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm
        ) : IRequestHandler<DeleteCargoActionCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteCargoActionCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "cargodetails";

            CargoAction cargodetail = await cargodetailRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (cargodetail is null)
            {
                return Result<string>.Failure(Messages.MSG_CargoAction + " " + Messages.MSG_NotExist);
            }

            cargodetail.IsDeleted = true;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_CargoAction + " " + Messages.MSG_Delete + "";


        }
    }
}
