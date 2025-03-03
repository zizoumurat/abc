using GenericRepository;
using porTIEVserver.Domain.Entities.eCargo.eCargo;
using porTIEVserver.Domain.Repositories.eCargo;
using porTIEVserver.Infrastructure.Context;

namespace porTIEVserver.Infrastructure.Repositories.eCargo
{
    internal sealed class CargoDetailRepository : Repository<CargoDetail, FirmDbContext>, ICargoDetailRepository
    {
        public CargoDetailRepository(FirmDbContext context) : base(context)
        {
        }
    }
}
