using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eCargo.eCargo;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.eCargo;
using TS.Result;

namespace porTIEVserver.Application.Features.eCargo.Cargos.CreateCargo
{
    internal sealed class CreateCargoMainCommandHandler(
        ICargoMainRepository CargoRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<CreateCargoMainCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateCargoMainCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "cargomains";

            bool IsCodeExists = await CargoRepository.AnyAsync(p => p.FicheNumber == request.FicheNumber, cancellationToken);

            if (IsCodeExists)
            {
                return Result<string>.Failure(Messages.MSG_CargoMain + " " + Messages.MSG_Exist);
            }

            CargoMain cargomain = mapper.Map<CargoMain>(request);

            await CargoRepository.AddAsync(cargomain, cancellationToken);

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_CargoMain + " " + Messages.MSG_Create + " ";
        }
    }

}
