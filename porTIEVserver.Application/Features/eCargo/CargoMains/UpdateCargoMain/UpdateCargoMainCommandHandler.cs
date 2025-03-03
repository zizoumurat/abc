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

namespace porTIEVserver.Application.Features.eCargo.Cargos.UpdateCargo
{
    internal sealed class UpdateCargoMainCommandHandler(
        ICargoMainRepository cargoRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<UpdateCargoMainCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateCargoMainCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "cargos";

            CargoMain cargomain = await cargoRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (cargomain is null)
            {
                return Result<string>.Failure(Messages.MSG_CargoMain + " " + Messages.MSG_NotExist);
            }

            if (cargomain.FicheNumber != request.FicheNumber)
            {
                bool IsCodeExists = await cargoRepository.AnyAsync(p => p.FicheNumber == request.FicheNumber, cancellationToken);

                if (IsCodeExists)
                {
                    return Result<string>.Failure(Messages.MSG_TaxNumber + " " + Messages.MSG_Exist);
                }
            }

            mapper.Map(request, cargomain);

            cargomain.LastUpdatedDate = DateTime.UtcNow;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_CargoMain + " " + Messages.MSG_Update + "";
        }
    }


}
