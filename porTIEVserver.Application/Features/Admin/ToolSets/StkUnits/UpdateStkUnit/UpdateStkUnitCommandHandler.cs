using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Repositories.Admin.ToolSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.StkUnits.UpdateStkUnit
{
    internal sealed class UpdateStkUnitCommandHandler(
            IStkUnitRepository  stkUnitRepository,
            ICacheService       cacheService,
            IUnitOfWork         unitOfWork,
            IMapper             mapper
    ) : IRequestHandler<UpdateStkUnitCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateStkUnitCommand request, CancellationToken cancellationToken)
        {
            //
            string cacheName = "stkunits";
            //
            StkUnit stkUnit = await stkUnitRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);
            //
            if (stkUnit is null)
            {
                return Result<string>.Failure(Messages.MSG_StkUnit + " " + Messages.MSG_NotExist);
            }
            //
            if (!Parameters.CanStkUnitCodeChange && stkUnit.Code != request.Code)
            {
                bool IsCodeExists = await stkUnitRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

                if (IsCodeExists)
                {
                    return Result<string>.Failure(Messages.MSG_StkUnit + " " + Messages.MSG_Code + " " + Messages.MSG_Exist);
                }
            }
            //
            if (!Parameters.CanStkUnitNameChange && stkUnit.Name != request.Name)
            {
                bool IsNameExists = await stkUnitRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);

                if (IsNameExists)
                {
                    return Result<string>.Failure(Messages.MSG_StkUnit + " " + Messages.MSG_Name + " " + Messages.MSG_Exist);
                }
            }
            //
            mapper.Map(request, stkUnit);

            stkUnit.LastUpdatedDate = DateTime.UtcNow;
            //
            await unitOfWork.SaveChangesAsync(cancellationToken);
            //
            cacheService.Remove(cacheName);
            //
            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_StkUnit + " " + Messages.MSG_Update + "";
        }
    }


}
