using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using porTIEVserver.Domain.Entities.ERP.FIN;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.FIN.Tradings.GetAllTrading
{
    public sealed record GetAllTradingsQuery(
        ) : IRequest<Result<List<Trading>>>;
}
