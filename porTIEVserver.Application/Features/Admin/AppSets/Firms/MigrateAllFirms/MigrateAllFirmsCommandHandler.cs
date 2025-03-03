using MediatR;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using porTIEVserver.Domain.Repositories.Admin.AppSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Firms.MigrateAllFirms
{
    public sealed class MigrateAllFirmsCommandHandler(
        IFirmRepository firmRepository,
        IFirmService firmService
        ) : IRequestHandler<MigrateAllFirmsCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(MigrateAllFirmsCommand request, CancellationToken cancellationToken)
        {
            List<Firm> firms = await firmRepository.GetAll().ToListAsync(cancellationToken);

            firmService.MigrateAll(firms);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Database + " " + Messages.MSG_Update + " ";

        }
    }
}

