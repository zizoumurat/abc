using MediatR;
using porTIEVserver.Application.Features.Admin.Auth.Login;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.Auth.Test
{
    public sealed record TestCommand(

       ) : IRequest<Result<LoginCommandResponse>>;
}
