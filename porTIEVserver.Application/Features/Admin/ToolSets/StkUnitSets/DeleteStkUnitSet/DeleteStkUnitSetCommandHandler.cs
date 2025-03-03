using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Repositories.Admin.ToolSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.StkUnitSets.DeleteStkUnitSet
{
    internal sealed class DeleteStkUnitSetCommandHandler(
            IStkUnitSetRepository   stkUnitSetRepository,
            ICacheService           cacheService,
            IUnitOfWork             unitOfWork
        ) : IRequestHandler<DeleteStkUnitSetCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteStkUnitSetCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "unitsets";

            StkUnitSet stkUnitSet = await stkUnitSetRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (stkUnitSet is null)
            {
                return Result<string>.Failure(Messages.MSG_StkUnitSet + " " + Messages.MSG_NotExist);
            }

            stkUnitSet.IsDeleted = true;

            await unitOfWork.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_StkUnitSet + " " + Messages.MSG_Delete + "";


        }
    }
}
