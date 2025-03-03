using GenericRepository;
using porTIEVserver.Domain.Entities.eBizService.eBizService;
using porTIEVserver.Domain.Repositories.eBizService;
using porTIEVserver.Infrastructure.Context;

namespace porTIEVserver.Infrastructure.Repositories.eBizService
{
    internal sealed class BizServiceRepository : Repository<BizService, FirmDbContext>, IBizServiceRepository
    {
        public BizServiceRepository(FirmDbContext context) : base(context)
        {
        }
    }
}
