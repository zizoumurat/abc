using MediatR;
using porTIEVserver.Domain.Entities.eCargo.eCargo;
using TS.Result;

namespace porTIEVserver.Application.Features.eCargo.Carriers.GetAllCarriers
{
    public sealed record GetAllCarriersQuery(
        ) : IRequest<Result<List<Carrier>>>;
}
