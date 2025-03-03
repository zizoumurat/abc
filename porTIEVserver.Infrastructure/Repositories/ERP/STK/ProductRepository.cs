using GenericRepository;
using porTIEVserver.Domain.Entities.ERP.STK;
using porTIEVserver.Domain.Repositories.ERP.STK;
using porTIEVserver.Infrastructure.Context;

namespace porTIEVserver.Infrastructure.Repositories.ERP.STK
{
    internal sealed class ProductRepository : Repository<Product, FirmDbContext>, IProductRepository
    {
        public ProductRepository(FirmDbContext context) : base(context)
        {
        }
    }
}
