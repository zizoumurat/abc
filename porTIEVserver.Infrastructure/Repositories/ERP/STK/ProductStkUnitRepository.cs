using GenericRepository;
using porTIEVserver.Domain.Entities.ERP.STK;
using porTIEVserver.Domain.Repositories.ERP.STK;
using porTIEVserver.Infrastructure.Context;

namespace porTIEVserver.Infrastructure.Repositories.ERP.STK
{
    internal sealed class ProductStkUnitRepository : Repository<ProductStkUnit, FirmDbContext>, IProductStkUnitRepository
    {
        public ProductStkUnitRepository(FirmDbContext context) : base(context)
        {
        }
    }
}
