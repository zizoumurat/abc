using GenericRepository;
using porTIEVserver.Domain.Entities.ERP.HR;
using porTIEVserver.Domain.Repositories.ERP.HR;
using porTIEVserver.Infrastructure.Context;

namespace porTIEVserver.Infrastructure.Repositories.ERP.HR
{
    internal sealed class PersonnelRepository : Repository<Personnel, FirmDbContext>, IPersonnelRepository
    {
        public PersonnelRepository(FirmDbContext context) : base(context)
        {
        }
    }
}
