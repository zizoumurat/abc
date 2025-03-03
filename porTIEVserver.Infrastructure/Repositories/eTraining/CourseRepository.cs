using GenericRepository;
using porTIEVserver.Domain.Entities.ERP.CRM;
using porTIEVserver.Domain.Entities.eTraining;
using porTIEVserver.Domain.Repositories.eTraining;
using porTIEVserver.Infrastructure.Context;

namespace porTIEVserver.Infrastructure.Repositories.eTraining
{
    internal sealed class CourseRepository : Repository<Course, FirmDbContext>, ICourseRepository
    {
        public CourseRepository(FirmDbContext context) : base(context)
        {
        }
    }
}
