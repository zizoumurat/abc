using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Repositories.Admin.ToolSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.StkUnits.DeleteStkUnit
{
    internal sealed class DeleteStkUnitCommandHandler(

            IStkUnitRepository      stkUnitRepository,
            ICacheService           cacheService,
            IUnitOfWork             unitOfWork


        ) : IRequestHandler<DeleteStkUnitCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteStkUnitCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "stkunits";

            StkUnit stkUnit = await stkUnitRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (stkUnit is null)
            {
                return Result<string>.Failure(Messages.MSG_StkUnit + " " + Messages.MSG_NotExist);
            }

            stkUnit.IsDeleted = true;

            await unitOfWork.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_StkUnit + " " + Messages.MSG_Delete + ")";

        }
    }
}
