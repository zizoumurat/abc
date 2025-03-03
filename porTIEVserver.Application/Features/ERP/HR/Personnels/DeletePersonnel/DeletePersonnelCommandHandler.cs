using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.ERP.HR;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.HR;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.HR.Personnels.DeletePersonnel
{
    internal sealed class DeletePersonnelCommandHandler(
        IPersonnelRepository personnelRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm
        ) : IRequestHandler<DeletePersonnelCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeletePersonnelCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "personnels";

            Personnel personnel = await personnelRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (personnel is null)
            {
                return Result<string>.Failure(Messages.MSG_Personnel + " " + Messages.MSG_NotExist);
            }

            personnel.IsDeleted = true;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Personnel + " " + Messages.MSG_Delete + "";


        }
    }
}
