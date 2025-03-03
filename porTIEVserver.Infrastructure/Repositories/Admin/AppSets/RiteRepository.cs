using GenericRepository;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using porTIEVserver.Domain.Repositories.Admin.AppSets;
using porTIEVserver.Infrastructure.Context;

namespace porTIEVserver.Infrastructure.Repositories.Admin.AppSets
{
    internal sealed class RiteRepository : Repository<Rite, AppDbContext>, IRiteRepository
    {
        public RiteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
