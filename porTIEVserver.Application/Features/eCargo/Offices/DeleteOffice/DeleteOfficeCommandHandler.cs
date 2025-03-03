using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eCargo.eCargo;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.eCargo;
using TS.Result;

namespace porTIEVserver.Application.Features.eCargo.Offices.DeleteOffice
{
    internal sealed class DeleteOfficeCommandHandler(
        IOfficeRepository OfficeRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm
        ) : IRequestHandler<DeleteOfficeCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteOfficeCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "offices";

            Office office = await OfficeRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (office is null)
            {
                return Result<string>.Failure(Messages.MSG_Office + " " + Messages.MSG_NotExist);
            }

            office.IsDeleted = true;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Office + " " + Messages.MSG_Delete + " ";


        }
    }
}
