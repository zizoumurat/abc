using MediatR;
using porTIEVserver.Domain.Entities.eCargo.eCargo;
using porTIEVserver.Domain.Enums;
using TS.Result;


namespace porTIEVserver.Application.Features.eCargo.Cargos.GetAllCargos
{
    public sealed record GetAllCargoMainsQuery(
        ) : IRequest<Result<List<CargoMain>>>;
}
