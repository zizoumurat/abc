using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Repositories.Admin.ToolSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.StkUnits.CreateStkUnit
{
    internal sealed class CreateStkUnitCommandHandler(

            IStkUnitRepository      stkUnitRepository,
            ICacheService           cacheService,
            IUnitOfWork             unitOfWork,
            IMapper                 mapper

        ) : IRequestHandler<CreateStkUnitCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateStkUnitCommand request, CancellationToken cancellationToken)
        {
            //
            string cacheName = "stkunits";
            //
            bool IsCodeExists = await stkUnitRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);
            if (IsCodeExists)
            {
                return Result<string>.Failure(Messages.MSG_StkUnit + " " + Messages.MSG_Code + "-" + Messages.MSG_Exist);
            }
            //
            bool IsNameExists = await stkUnitRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);
            if (IsNameExists)
            {
                return Result<string>.Failure(Messages.MSG_StkUnit + " " + Messages.MSG_Name + " " + Messages.MSG_Exist);
            }
            //
            StkUnit stkUnit = mapper.Map<StkUnit>(request);
            //
            await stkUnitRepository.AddAsync(stkUnit, cancellationToken);
            //
            await unitOfWork.SaveChangesAsync(cancellationToken);
            //
            cacheService.Remove(cacheName);
            //
            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_StkUnit + " " + Messages.MSG_Create + "";
        }
    }

}
