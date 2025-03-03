using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.Auth.Login
{
    public sealed record LoginCommand(
        string EmailOrUserName,
        string Password) : IRequest<Result<LoginCommandResponse>>;
}
