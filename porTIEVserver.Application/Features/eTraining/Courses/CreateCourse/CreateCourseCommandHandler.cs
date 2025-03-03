using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Features.eTraining.Courses.CreateCourse;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eTraining;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.eTraining;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Courses.CreateCourse
{
    internal sealed class CreateCourseCommandHandler(
        ICourseRepository courseRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<CreateCourseCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "courses";

            bool IsCodeExists = await courseRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

            if (IsCodeExists)
            {
                return Result<string>.Failure(Messages.MSG_Course + " " + Messages.MSG_Exist);
            }

            Course trading = mapper.Map<Course>(request);

            await courseRepository.AddAsync(trading, cancellationToken);

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Course + " " + Messages.MSG_Create + "";
        }
    }

}
