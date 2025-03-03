using GenericRepository;
using porTIEVserver.Domain.Entities.eTraining;
using porTIEVserver.Domain.Repositories.eTraining;
using porTIEVserver.Infrastructure.Context;

namespace porTIEVserver.Infrastructure.Repositories.eTraining
{
    internal sealed class StatusRepository : Repository<Status, FirmDbContext>, IStatusRepository
    {
        public StatusRepository(FirmDbContext context) : base(context)
        {
        }
    }
}
