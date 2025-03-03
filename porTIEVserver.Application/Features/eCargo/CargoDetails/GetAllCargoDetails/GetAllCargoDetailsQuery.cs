using MediatR;
using porTIEVserver.Domain.Entities.eCargo.eCargo;
using porTIEVserver.Domain.Enums;
using TS.Result;


namespace porTIEVserver.Application.Features.eCargo.CargoDetails.GetAllCargoDetails
{
    public sealed record GetAllCargoDetailsQuery(                
        string CargoMainRef
        ) : IRequest<Result<List<CargoDetail>>>;
}
