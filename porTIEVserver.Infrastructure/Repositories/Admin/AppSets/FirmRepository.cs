using GenericRepository;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using porTIEVserver.Domain.Repositories.Admin.AppSets;
using porTIEVserver.Infrastructure.Context;

namespace porTIEVserver.Infrastructure.Repositories.Admin.AppSets
{
    internal sealed class FirmRepository : Repository<Firm, AppDbContext>, IFirmRepository
    {
        public FirmRepository(AppDbContext context) : base(context)
        {
        }
    }
}
