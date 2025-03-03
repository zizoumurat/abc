using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.ERP.HR;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.HR;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.HR.Personnels.UpdatePersonnel
{
    internal sealed class UpdatePersonnelCommandHandler(
        IPersonnelRepository personnelRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<UpdatePersonnelCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdatePersonnelCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "personnels";

            Personnel personnel = await personnelRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (personnel is null)
            {
                return Result<string>.Failure(Messages.MSG_Personnel + " " + Messages.MSG_NotExist);
            }

            if (!Parameters.CanPersonnelCodeChange && personnel.Code != request.Code)
            {
                bool IsCodeExists = await personnelRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

                if (IsCodeExists)
                {
                    return Result<string>.Failure(Messages.MSG_Personnel + " " + Messages.MSG_Code + " " + Messages.MSG_Exist);
                }
            }

            if (!Parameters.CanPersonnelNameChange && personnel.FullName != request.FullName)
            {
                bool IsNameExists = await personnelRepository.AnyAsync(p => p.FullName == request.FirstName, cancellationToken);

                if (IsNameExists)
                {
                    return Result<string>.Failure(Messages.MSG_Personnel + " " + Messages.MSG_Name + " " + Messages.MSG_Exist);
                }
            }

            mapper.Map(request, personnel);

            personnel.LastUpdatedDate = DateTime.UtcNow;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Personnel + " " + Messages.MSG_Update + "";
        }
    }


}
