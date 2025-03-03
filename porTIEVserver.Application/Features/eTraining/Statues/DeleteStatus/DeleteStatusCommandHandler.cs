using MediatR;
using porTIEVserver.Application.Features.eTraining.Statues.DeleteStatus;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eTraining;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.FIN;
using porTIEVserver.Domain.Repositories.eTraining;
using TS.Result;

namespace porTIEVserver.Application.Features.eTradings.Statues.DeleteStatus
{
    internal sealed class DeleteStatusCommandHandler(
        IStatusRepository courseRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm
        ) : IRequestHandler<DeleteStatusCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteStatusCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "statues";

            Status status = await courseRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (status is null)
            {
                return Result<string>.Failure(Messages.MSG_Status + " " + Messages.MSG_NotExist);
            }

            status.IsDeleted = true;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Status + " " + Messages.MSG_Delete + "";


        }
    }
}
