using GenericRepository;
using porTIEVserver.Domain.Entities.ERP.FIN;
using porTIEVserver.Domain.Repositories.ERP.FIN;
using porTIEVserver.Infrastructure.Context;

namespace porTIEVserver.Infrastructure.Repositories.ERP.FIN
{
    internal sealed class TradingRepository : Repository<Trading, FirmDbContext>, ITradingRepository
    {
        public TradingRepository(FirmDbContext context) : base(context)
        {
        }
    }
}
