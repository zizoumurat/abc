﻿using GenericRepository;
using porTIEVserver.Domain.Entities.eCargo.eCargo;
using porTIEVserver.Domain.Repositories.eCargo;
using porTIEVserver.Infrastructure.Context;

namespace porTIEVserver.Infrastructure.Repositories.eCargo
{
    internal sealed class OfficeRepository : Repository<Office, FirmDbContext>, IOfficeRepository
    {
        public OfficeRepository(FirmDbContext context) : base(context)
        {
        }
    }
}
