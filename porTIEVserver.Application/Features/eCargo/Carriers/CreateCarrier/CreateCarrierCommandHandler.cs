using System.Diagnostics;
using AutoMapper;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eCargo.eCargo;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.eCargo;
using TS.Result;

namespace porTIEVserver.Application.Features.eCargo.Carriers.CreateCarrier
{
    internal sealed class CreateCarrierCommandHandler(
        ICarrierRepository CarrierRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<CreateCarrierCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateCarrierCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "carriers";

            bool IsCodeExists = await CarrierRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

            if (IsCodeExists)
            {
                return Result<string>.Failure(Messages.MSG_Carrier + " " + Messages.MSG_Exist);
            }

            Carrier carrier = mapper.Map<Carrier>(request);

            await CarrierRepository.AddAsync(carrier, cancellationToken);

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Carrier + " " + Messages.MSG_Create + "";
        }
    }

}
