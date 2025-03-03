using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using porTIEVserver.Domain.Entities.Admin.AppSets;

namespace porTIEVserver.Application.Services
{
    public interface IFirmService
    {
        void MigrateAll(List<Firm> firms);
    }
}
