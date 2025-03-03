using MediatR;
using porTIEVserver.Domain.Entities.eCargo.eCargo;
using porTIEVserver.Domain.Enums;
using TS.Result;


namespace porTIEVserver.Application.Features.eCargo.CargoActions.GetAllCargoActions
{
    public sealed record GetAllCargoActionsQuery(                
        string CargoMainRef
        ) : IRequest<Result<List<CargoAction>>>;
}
