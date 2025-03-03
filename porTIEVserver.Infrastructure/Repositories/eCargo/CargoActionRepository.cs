using GenericRepository;
using porTIEVserver.Domain.Entities.eCargo.eCargo;
using porTIEVserver.Domain.Repositories.eCargo;
using porTIEVserver.Infrastructure.Context;

namespace porTIEVserver.Infrastructure.Repositories.eCargo
{
    internal sealed class CargoActionRepository : Repository<CargoAction, FirmDbContext>, ICargoActionRepository
    {
        public CargoActionRepository(FirmDbContext context) : base(context)
        {
        }
    }
}
