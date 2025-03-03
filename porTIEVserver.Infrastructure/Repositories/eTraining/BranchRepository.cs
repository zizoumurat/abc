using GenericRepository;
using porTIEVserver.Domain.Entities.eTraining;
using porTIEVserver.Domain.Repositories.eTraining;
using porTIEVserver.Infrastructure.Context;

namespace porTIEVserver.Infrastructure.Repositories.eTraining
{
    internal sealed class BranchRepository : Repository<Branch, FirmDbContext>, IBranchRepository
    {
        public BranchRepository(FirmDbContext context) : base(context)
        {
        }
    }
}
