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

namespace porTIEVserver.Application.Features.eCargo.CargoDetails.UpdateCargoDetail
{
    internal sealed class UpdateCargoDetailCommandHandler(
        ICargoDetailRepository cargoRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<UpdateCargoDetailCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateCargoDetailCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "cargodetails";

            CargoDetail cargodetail = await cargoRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (cargodetail is null)
            {
                return Result<string>.Failure(Messages.MSG_CargoDetail + " " + Messages.MSG_NotExist);
            }

            mapper.Map(request, cargodetail);

            cargodetail.LastUpdatedDate = DateTime.UtcNow;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_CargoDetail + " " + Messages.MSG_Update + "";
        }
    }


}
