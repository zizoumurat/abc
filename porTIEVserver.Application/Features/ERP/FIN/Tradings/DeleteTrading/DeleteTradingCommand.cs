using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.FIN.Tradings.DeleteTrading
{
    public sealed record DeleteTradingCommand(
        int Ref
        ) : IRequest<Result<string>>;
}
