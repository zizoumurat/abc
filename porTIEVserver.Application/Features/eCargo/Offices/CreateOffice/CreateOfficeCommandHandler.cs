using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eCargo.eCargo;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.eCargo;
using TS.Result;

namespace porTIEVserver.Application.Features.eCargo.Offices.CreateOffice
{
    internal sealed class CreateOfficeCommandHandler(
        IOfficeRepository officeRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<CreateOfficeCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateOfficeCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "offices";

            bool IsCodeExists = await officeRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

            if (IsCodeExists)
            {
                return Result<string>.Failure(Messages.MSG_Office + " " + Messages.MSG_Exist);
            }

            Office Office = mapper.Map<Office>(request);

            await officeRepository.AddAsync(Office, cancellationToken);

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Office + " " + Messages.MSG_Create + "";
        }
    }

}
