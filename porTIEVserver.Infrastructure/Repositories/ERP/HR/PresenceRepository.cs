using GenericRepository;
using porTIEVserver.Domain.Entities.ERP.HR;
using porTIEVserver.Domain.Repositories.ERP.HR;
using porTIEVserver.Infrastructure.Context;

namespace porTIEVserver.Infrastructure.Repositories.ERP.HR
{
    internal sealed class PresenceRepository : Repository<Presence, FirmDbContext>, IPresenceRepository
    {
        public PresenceRepository(FirmDbContext context) : base(context)
        {
        }
    }
}
