using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using porTIEVserver.Domain.Entities.eTraining;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Statues.GetAllStatues
{
    public sealed record GetAllStatuesQuery(
        ) : IRequest<Result<List<Status>>>;
}
