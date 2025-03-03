using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eCargo.eCargo;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.eCargo;
using TS.Result;

namespace porTIEVserver.Application.Features.eCargo.CargoDetails.DeleteCargoDetail
{
    internal sealed class DeleteCargoDetailCommandHandler(
        ICargoDetailRepository cargodetailRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm
        ) : IRequestHandler<DeleteCargoDetailCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteCargoDetailCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "cargodetails";

            CargoDetail cargodetail = await cargodetailRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (cargodetail is null)
            {
                return Result<string>.Failure(Messages.MSG_CargoDetail + " " + Messages.MSG_NotExist);
            }

            cargodetail.IsDeleted = true;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_CargoDetail + " " + Messages.MSG_Delete + "";


        }
    }
}
