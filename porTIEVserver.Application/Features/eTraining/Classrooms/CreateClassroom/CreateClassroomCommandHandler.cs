using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Features.eTraining.Classrooms.CreateClassroom;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eTraining;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.eTraining;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Classrooms.CreateClassroom
{
    internal sealed class CreateClassroomCommandHandler(
        IClassroomRepository classroomRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<CreateClassroomCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateClassroomCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "classrooms";

            bool IsCodeExists = await classroomRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

            if (IsCodeExists)
            {
                return Result<string>.Failure(Messages.MSG_Classroom + " " + Messages.MSG_Exist);
            }

            Classroom classroom = mapper.Map<Classroom>(request);

            await classroomRepository.AddAsync(classroom, cancellationToken);

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Classroom + " " + Messages.MSG_Create + "";
        }
    }

}
