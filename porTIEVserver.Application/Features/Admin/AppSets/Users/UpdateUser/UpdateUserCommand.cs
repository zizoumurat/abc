using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Users.UpdateUser
{
    public sealed record UpdateUserCommand(

        Guid Id,
        string      FirstName,
        string      LastName,
        string      FullName,
        string      UserName,
        string      Email,
        string     Password,

        List<int>  FirmRefs,
        List<int>  RoleRefs,
        List<int>  RiteRefs,

        string      ImgUrl = "Atam.jpg",
        bool        IsAdmin = false,
        bool        IsDeleted = false

        ) : IRequest<Result<string>>;
}
