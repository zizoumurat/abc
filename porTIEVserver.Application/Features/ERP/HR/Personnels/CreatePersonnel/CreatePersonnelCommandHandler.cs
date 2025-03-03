using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.ERP.HR;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.HR;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.HR.Personnels.CreatePersonnel
{
    internal sealed class CreatePersonnelCommandHandler(
        IPersonnelRepository personnelRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<CreatePersonnelCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreatePersonnelCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "personnels";

            bool IsCodeExists = await personnelRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

            if (IsCodeExists)
            {
                return Result<string>.Failure(Messages.MSG_Personnel + " " + Messages.MSG_Code + " " + Messages.MSG_Exist);
            }
            bool IsNameExists = await personnelRepository.AnyAsync(p => p.FullName == request.FullName, cancellationToken);

            if (IsNameExists)
            {
                return Result<string>.Failure(Messages.MSG_Personnel + " " + Messages.MSG_Name + " " + Messages.MSG_Exist);
            }

            Personnel personnel = mapper.Map<Personnel>(request);

            await personnelRepository.AddAsync(personnel, cancellationToken);

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Personnel + " " + Messages.MSG_Create + "";
        }
    }

}
