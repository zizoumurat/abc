using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.ERP.HR;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.HR;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.HR.Presences.CreatePresence
{
    internal sealed class CreatePresenceCommandHandler(
        IPresenceRepository presenceRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<CreatePresenceCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreatePresenceCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "presences";

            //bool IsCodeExists = await presenceRepository.AnyAsync(p => p.ScanCode == request.Code, cancellationToken);

            //if (IsCodeExists)
            //{
            //    return Result<string>.Failure(Messages.MSG_Presence + " " + Messages.MSG_Code + " " + Messages.MSG_Exist);
            //}
            //bool IsNameExists = await presenceRepository.AnyAsync(p => p.FullName == request.FullName, cancellationToken);

            //if (IsNameExists)
            //{
            //    return Result<string>.Failure(Messages.MSG_Presence + " " + Messages.MSG_Name + " " + Messages.MSG_Exist);
            //}

            Presence presence = mapper.Map<Presence>(request);

            await presenceRepository.AddAsync(presence, cancellationToken);

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Presence + " " + Messages.MSG_Create + "";
        }
    }

}
