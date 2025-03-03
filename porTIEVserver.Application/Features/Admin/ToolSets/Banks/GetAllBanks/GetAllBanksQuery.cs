using MediatR;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.Banks.GetAllBanks
{
    public sealed record GetAllBanksQuery(
        ) : IRequest<Result<List<Bank>>>;
}
