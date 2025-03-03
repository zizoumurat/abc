using GenericRepository;
using porTIEVserver.Domain.Entities.eTraining;
using porTIEVserver.Domain.Repositories.eTraining;
using porTIEVserver.Infrastructure.Context;

namespace porTIEVserver.Infrastructure.Repositories.eTraining
{
    internal sealed class ClassroomRepository : Repository<Classroom, FirmDbContext>, IClassroomRepository
    {
        public ClassroomRepository(FirmDbContext context) : base(context)
        {
        }
    }
}
