using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Repositories.Admin.ToolSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.StkUnitSets.CreateStkUnitSet
{
    internal sealed class CreateStkUnitSetCommandHandler(
 
            IStkUnitSetRepository   stkUnitSetRepository,
            ICacheService           cacheService,
            IUnitOfWork             unitOfWork,
            IMapper                 mapper

        ) : IRequestHandler<CreateStkUnitSetCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateStkUnitSetCommand request, CancellationToken cancellationToken)
        {
            //
            string cacheName = "stkunitsets";
            //
            bool IsCodeExists = await stkUnitSetRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);
            if (IsCodeExists)
            {
                return Result<string>.Failure(Messages.MSG_StkUnitSet + " " + Messages.MSG_Code + " " + Messages.MSG_Exist);
            }
            //
            bool IsNameExists = await stkUnitSetRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);
            if (IsNameExists)
            {
                return Result<string>.Failure(Messages.MSG_StkUnitSet + " " + Messages.MSG_Name + " " + Messages.MSG_Exist);
            }
            //
            StkUnitSet stkUnitSet = mapper.Map<StkUnitSet>(request);
            //
            await stkUnitSetRepository.AddAsync(stkUnitSet, cancellationToken);
            //
            await unitOfWork.SaveChangesAsync(cancellationToken);
            //
            cacheService.Remove(cacheName);
            //
            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_StkUnitSet + " " + Messages.MSG_Create + "";
        }
    }

}
