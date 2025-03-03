using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Features.eTraining.Statues.CreateStatus;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eTraining;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.eTraining;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Statues.CreateStatus
{
    internal sealed class CreateStatusCommandHandler(
        IStatusRepository courseRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<CreateStatusCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateStatusCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "statues";

            bool IsCodeExists = await courseRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

            if (IsCodeExists)
            {
                return Result<string>.Failure(Messages.MSG_Status + " " + Messages.MSG_Exist);
            }

            Status status = mapper.Map<Status>(request);

            await courseRepository.AddAsync(status, cancellationToken);

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Status + " " + Messages.MSG_Create + "";
        }
    }

}
