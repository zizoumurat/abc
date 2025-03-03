using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using porTIEVserver.Domain.Entities.eCargo.eCargo;
using TS.Result;

namespace porTIEVserver.Application.Features.eCargo.Offices.GetAllOffices
{
    public sealed record GetAllOfficesQuery(
        ) : IRequest<Result<List<Office>>>;
}
