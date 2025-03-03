using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using porTIEVserver.Domain.Entities.eTraining;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Partners.GetAllPartners
{
    public sealed record GetAllPartnersQuery(
        ) : IRequest<Result<List<Partner>>>;
}
