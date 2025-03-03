using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Features.eTraining.Classrooms.UpdateClassroom;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin;
using porTIEVserver.Domain.Entities.ERP.FIN;
using porTIEVserver.Domain.Entities.eTraining;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.FIN;
using porTIEVserver.Domain.Repositories.eTraining;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Classrooms.UpdateClassroom
{
    internal sealed class UpdateClassroomCommandHandler(
        IClassroomRepository classroomRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<UpdateClassroomCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateClassroomCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "classrooms";

            Classroom classroom = await classroomRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (classroom is null)
            {
                return Result<string>.Failure(Messages.MSG_Classroom + " " + Messages.MSG_NotExist);
            }

            if (classroom.Code != request.Code)
            {
                bool IsCodeExists = await classroomRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

                if (IsCodeExists)
                {
                    return Result<string>.Failure(Messages.MSG_Classroom + " " + Messages.MSG_Exist);
                }
            }

            mapper.Map(request, classroom);

            classroom.LastUpdatedDate = DateTime.UtcNow;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Classroom + " " + Messages.MSG_Update + "";
        }
    }


}
