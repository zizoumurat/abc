using MediatR;
using porTIEVserver.Application.Features.eTraining.Courses.DeleteCourse;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eTraining;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.FIN;
using porTIEVserver.Domain.Repositories.eTraining;
using TS.Result;

namespace porTIEVserver.Application.Features.eTradings.Courses.DeleteCourse
{
    internal sealed class DeleteCourseCommandHandler(
        ICourseRepository courseRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm
        ) : IRequestHandler<DeleteCourseCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "courses";

            Course course = await courseRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (course is null)
            {
                return Result<string>.Failure(Messages.MSG_Course + " " + Messages.MSG_NotExist);
            }

            course.IsDeleted = true;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Course + " " + Messages.MSG_Delete + "";


        }
    }
}
