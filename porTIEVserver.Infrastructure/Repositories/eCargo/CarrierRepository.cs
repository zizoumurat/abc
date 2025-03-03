using GenericRepository;
using porTIEVserver.Domain.Entities.eCargo.eCargo;
using porTIEVserver.Domain.Repositories.eCargo;
using porTIEVserver.Infrastructure.Context;

namespace porTIEVserver.Infrastructure.Repositories.eCargo
{
    internal sealed class CarrierRepository : Repository<Carrier, FirmDbContext>, ICarrierRepository
    {
        public CarrierRepository(FirmDbContext context) : base(context)
        {
        }
    }
}
