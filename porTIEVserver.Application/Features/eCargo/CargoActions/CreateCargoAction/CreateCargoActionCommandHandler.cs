using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eCargo.eCargo;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.eCargo;
using TS.Result;

namespace porTIEVserver.Application.Features.eCargo.CargoActions.CreateCargoAction
{
    internal sealed class CreateCargoActionCommandHandler(
        ICargoActionRepository CargoRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<CreateCargoActionCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateCargoActionCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "cargodetails";

            CargoAction cargodetail = mapper.Map<CargoAction>(request);

            await CargoRepository.AddAsync(cargodetail, cancellationToken);

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_CargoAction + " " + Messages.MSG_Create + "";
        }
    }

}
