using MediatR;
using porTIEVserver.Domain.Entities.ERP.HR;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.HR.Personnels.GetAllPersonnels
{
    public sealed record GetAllPersonnelsQuery(        
        ) : IRequest<Result<List<Personnel>>>;
}
