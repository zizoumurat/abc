using GenericRepository;
using porTIEVserver.Domain.Entities.eTraining;
using porTIEVserver.Domain.Repositories.eTraining;
using porTIEVserver.Infrastructure.Context;

namespace porTIEVserver.Infrastructure.Repositories.eTraining
{
    internal sealed class PartnerRepository : Repository<Partner, FirmDbContext>, IPartnerRepository
    {
        public PartnerRepository(FirmDbContext context) : base(context)
        {
        }
    }
}
