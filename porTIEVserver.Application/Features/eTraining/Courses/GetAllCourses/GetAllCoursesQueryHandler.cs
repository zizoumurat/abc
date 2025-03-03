using MediatR;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eTraining;
using porTIEVserver.Domain.Repositories.eTraining;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Courses.GetAllCourses
{
    internal sealed class GetAllCoursesQueryHandler(
        ICourseRepository courseRepository,
        ICacheService cacheService
        ) : IRequestHandler<GetAllCoursesQuery, Result<List<Course>>>
    {
        public async Task<Result<List<Course>>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            string cacheName = "courses";

            List<Course> courses;
            courses = cacheService.Get<List<Course>>(cacheName);
            if (courses is null)
            {
                courses =
                    await courseRepository
                    .GetAll()
                    //                    .Where(p => request.TradingTypeValue > 0 && p.TradingType.Value == request.TradingTypeValue)
                    //.OrderBy(p => p.FicheDate)
                   //  .ThenBy(p => p.FicheNumber)
                    .ToListAsync(cancellationToken);

                cacheService.Set(cacheName, courses);
            }

            return courses;
        }
    }
}
