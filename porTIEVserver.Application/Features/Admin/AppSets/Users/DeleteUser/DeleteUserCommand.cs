using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Users.DeleteUser
{
    public sealed record DeleteUserCommand(
        Guid Id
        ) : IRequest<Result<string>>;
}
