using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin;
using porTIEVserver.Domain.Entities.eCargo.eCargo;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.eCargo;
using TS.Result;

namespace porTIEVserver.Application.Features.eCargo.CargoActions.UpdateCargoAction
{
    internal sealed class UpdateCargoActionCommandHandler(
        ICargoActionRepository cargoRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<UpdateCargoActionCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateCargoActionCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "cargodetails";

            CargoAction cargodetail = await cargoRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (cargodetail is null)
            {
                return Result<string>.Failure(Messages.MSG_CargoAction + " " + Messages.MSG_NotExist);
            }

            mapper.Map(request, cargodetail);

            cargodetail.LastUpdatedDate = DateTime.UtcNow;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_CargoAction + " " + Messages.MSG_Update + "";
        }
    }


}
