using MediatR;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eTraining;
using porTIEVserver.Domain.Repositories.eTraining;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Classrooms.GetAllClassrooms
{
    internal sealed class GetAllClassroomsQueryHandler(
        IClassroomRepository classroomRepository,
        ICacheService cacheService
        ) : IRequestHandler<GetAllClassroomsQuery, Result<List<Classroom>>>
    {
        public async Task<Result<List<Classroom>>> Handle(GetAllClassroomsQuery request, CancellationToken cancellationToken)
        {
            string cacheName = "classrooms";

            List<Classroom> classrooms;
            classrooms = cacheService.Get<List<Classroom>>(cacheName);
            if (classrooms is null)
            {
                classrooms =
                    await classroomRepository
                    .GetAll()
                    //                    .Where(p => request.TradingTypeValue > 0 && p.TradingType.Value == request.TradingTypeValue)
                    //.OrderBy(p => p.FicheDate)
                   //  .ThenBy(p => p.FicheNumber)
                    .ToListAsync(cancellationToken);

                cacheService.Set(cacheName, classrooms);
            }

            return classrooms;
        }
    }
}
