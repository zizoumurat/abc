using GenericRepository;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Repositories.Admin.ToolSets;
using porTIEVserver.Infrastructure.Context;

namespace porTIEVserver.Infrastructure.Repositories.Admin.ToolSets
{
    internal sealed class BankRepository : Repository<Bank, AppDbContext>, IBankRepository
    {
        public BankRepository(AppDbContext context) : base(context)
        {
        }
    }
}
