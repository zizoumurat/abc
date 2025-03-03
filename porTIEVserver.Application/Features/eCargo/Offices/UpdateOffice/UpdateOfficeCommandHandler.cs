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

namespace porTIEVserver.Application.Features.eCargo.Offices.UpdateOffice
{
    internal sealed class UpdateOfficeCommandHandler(
        IOfficeRepository officeRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<UpdateOfficeCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateOfficeCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "offices";

            Office office = await officeRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (office is null)
            {
                return Result<string>.Failure(Messages.MSG_Office + " " + Messages.MSG_NotExist);
            }

            if (office.Code != request.Code)
            {
                bool IsCodeExists = await officeRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

                if (IsCodeExists)
                {
                    return Result<string>.Failure(Messages.MSG_TaxNumber + " " + Messages.MSG_Exist);
                }
            }

            mapper.Map(request, office);

            office.LastUpdatedDate = DateTime.UtcNow;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Office + " " + Messages.MSG_Update + "";
        }
    }


}
