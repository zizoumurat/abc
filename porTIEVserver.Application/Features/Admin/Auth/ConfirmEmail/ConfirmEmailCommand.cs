using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.Auth.ConfirmEmail
{
    public sealed record ConfirmEmailCommand(string Email) : IRequest<Result<string>>;

}
