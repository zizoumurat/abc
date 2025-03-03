using MediatR;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Firms.GetAllFirms
{
    public sealed record GetAllFirmsQuery(
        ) : IRequest<Result<List<Firm>>>;
}
