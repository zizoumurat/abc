using GenericRepository;
using porTIEVserver.Domain.Entities.ERP.CRM;
using porTIEVserver.Domain.Repositories.ERP.CRM;
using porTIEVserver.Infrastructure.Context;

namespace porTIEVserver.Infrastructure.Repositories.ERP.CRM
{
    internal sealed class ClassroomRepository : Repository<Contact, FirmDbContext>, ITrainingRepository
    {
        public ClassroomRepository(FirmDbContext context) : base(context)
        {
        }
    }
}
