using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using porTIEVserver.Infrastructure.Context;

namespace porTIEVserver.Infrastructure.Services
{
    internal sealed class FirmService : IFirmService
    {
        public void MigrateAll(List<Firm> firms)
        {
            foreach (var firm in firms)
            {
                FirmDbContext context = new(firm);

                context.Database.Migrate();
            }
        }
    }
}



