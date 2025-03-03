using MediatR;
using porTIEVserver.Application.Features.eTraining.Classrooms.DeleteClassroom;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eTraining;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.FIN;
using porTIEVserver.Domain.Repositories.eTraining;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Classrooms.DeleteClassroom
{
    internal sealed class DeleteClassroomCommandHandler(
        IClassroomRepository classroomRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm
        ) : IRequestHandler<DeleteClassroomCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteClassroomCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "classrooms";

            Classroom classroom = await classroomRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (classroom is null)
            {
                return Result<string>.Failure(Messages.MSG_Classroom + " " + Messages.MSG_NotExist);
            }

            classroom.IsDeleted = true;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Classroom + " " + Messages.MSG_Delete + "";


        }
    }
}
