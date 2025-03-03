using GenericRepository;
using porTIEVserver.Domain.Entities.eCargo.eCargo;
using porTIEVserver.Domain.Repositories.eCargo;
using porTIEVserver.Infrastructure.Context;

namespace porTIEVserver.Infrastructure.Repositories.eCargo
{
    internal sealed class CargoMainRepository : Repository<CargoMain, FirmDbContext>, ICargoMainRepository
    {
        public CargoMainRepository(FirmDbContext context) : base(context)
        {
        }
    }
}
