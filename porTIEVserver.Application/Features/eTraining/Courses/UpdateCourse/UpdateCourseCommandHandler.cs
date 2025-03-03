using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Features.eTraining.Courses.UpdateCourse;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin;
using porTIEVserver.Domain.Entities.ERP.FIN;
using porTIEVserver.Domain.Entities.eTraining;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.FIN;
using porTIEVserver.Domain.Repositories.eTraining;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Courses.UpdateCourse
{
    internal sealed class UpdateCourseCommandHandler(
        ICourseRepository tradingRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<UpdateCourseCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "courses";

            Course course = await tradingRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (course is null)
            {
                return Result<string>.Failure(Messages.MSG_Course + " " + Messages.MSG_NotExist);
            }

            if (course.Code != request.Code)
            {
                bool IsCodeExists = await tradingRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

                if (IsCodeExists)
                {
                    return Result<string>.Failure(Messages.MSG_TaxNumber + " " + Messages.MSG_Exist);
                }
            }

            mapper.Map(request, course);

            course.LastUpdatedDate = DateTime.UtcNow;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Course + " " + Messages.MSG_Update + "";
        }
    }


}
