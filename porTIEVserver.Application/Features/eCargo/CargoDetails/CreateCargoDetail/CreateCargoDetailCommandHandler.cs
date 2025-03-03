using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eCargo.eCargo;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.eCargo;
using TS.Result;

namespace porTIEVserver.Application.Features.eCargo.CargoDetails.CreateCargoDetail
{
    internal sealed class CreateCargoDetailCommandHandler(
        ICargoDetailRepository CargoRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<CreateCargoDetailCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateCargoDetailCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "cargodetails";

            CargoDetail cargodetail = mapper.Map<CargoDetail>(request);

            await CargoRepository.AddAsync(cargodetail, cancellationToken);

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_CargoDetail + " " + Messages.MSG_Create + " ";
        }
    }

}
