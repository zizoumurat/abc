using GenericRepository;
using porTIEVserver.Domain.Entities.ERP.CRM;
using porTIEVserver.Domain.Repositories.ERP.CRM;
using porTIEVserver.Infrastructure.Context;

namespace porTIEVserver.Infrastructure.Repositories.ERP.CRM
{
    internal sealed class CrmActionRepository : Repository<CrmAction, FirmDbContext>, ICrmActionRepository
    {
        public CrmActionRepository(FirmDbContext context) : base(context)
        {
        }
    }
}
