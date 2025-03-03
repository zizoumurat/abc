using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Repositories.Admin.ToolSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.StkUnitSets.UpdateStkUnitSet
{
    internal sealed class UpdateStkUnitSetCommandHandler(
            IStkUnitSetRepository   stkUnitSetRepository,
            ICacheService           cacheService,
            IUnitOfWork             unitOfWork,
            IMapper                 mapper
    ) : IRequestHandler<UpdateStkUnitSetCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateStkUnitSetCommand request, CancellationToken cancellationToken)
        {
            //
            string cacheName = "unitsets";
            //
            StkUnitSet stkUnitSet = await stkUnitSetRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);
            //
            if (stkUnitSet is null)
            {
                return Result<string>.Failure(Messages.MSG_StkUnitSet + " " + Messages.MSG_NotExist);
            }
            //
            if (stkUnitSet.Code != request.Code)
            {
                bool IsCodeExists = await stkUnitSetRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

                if (IsCodeExists)
                {
                    return Result<string>.Failure(Messages.MSG_Code + " " + Messages.MSG_Exist);
                }
            }
            //
            if (stkUnitSet.Name != request.Name)
            {
                bool IsNameExists = await stkUnitSetRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);

                if (IsNameExists)
                {
                    return Result<string>.Failure(Messages.MSG_Name + " " + Messages.MSG_Exist);
                }
            }
            //
            mapper.Map(request, stkUnitSet);

            stkUnitSet.LastUpdatedDate = DateTime.UtcNow;
            //
            await unitOfWork.SaveChangesAsync(cancellationToken);
            //
            cacheService.Remove(cacheName);
            //
            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_StkUnitSet + " " + Messages.MSG_Update + "";
        }
    }


}
