using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Statues.DeleteStatus
{
    public sealed record DeleteStatusCommand(
        int Ref
        ) : IRequest<Result<string>>;
}
