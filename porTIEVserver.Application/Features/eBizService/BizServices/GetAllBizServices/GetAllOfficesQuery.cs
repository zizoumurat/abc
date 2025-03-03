using MediatR;
using porTIEVserver.Domain.Entities.eBizService.eBizService;
using TS.Result;

namespace porTIEVserver.Application.Features.eCargo.BizServices.GetAllBizServices
{
    public sealed record GetAllBizServicesQuery(
        ) : IRequest<Result<List<BizService>>>;
}
