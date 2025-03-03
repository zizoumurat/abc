using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TS.Result;

namespace porTIEVserver.Application.Features.eCargo.Offices.DeleteOffice
{
    public sealed record DeleteOfficeCommand(
        int Ref
        ) : IRequest<Result<string>>;
}
