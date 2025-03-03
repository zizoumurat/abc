using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TS.Result;

namespace porTIEVserver.Application.Features.eCargo.CargoDetails.DeleteCargoDetail
{
    public sealed record DeleteCargoDetailCommand(
        int Ref
        ) : IRequest<Result<string>>;
}
