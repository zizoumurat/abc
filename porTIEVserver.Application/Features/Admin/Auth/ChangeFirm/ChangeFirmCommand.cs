using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using porTIEVserver.Application.Features.Admin.Auth.Login;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.Auth.ChangeFirm
{
    public sealed record ChangeFirmCommand(
        string FirmRef
        ) : IRequest<Result<LoginCommandResponse>>;

}
