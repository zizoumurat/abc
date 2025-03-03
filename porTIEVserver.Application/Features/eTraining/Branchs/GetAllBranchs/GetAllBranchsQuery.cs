using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using porTIEVserver.Domain.Entities.eTraining;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Branchs.GetAllBranchs
{
    public sealed record GetAllBranchsQuery(
        ) : IRequest<Result<List<Branch>>>;
}
