using System.Data;
using porTIEVserver.Application.Features.Admin.Auth.Login;
using porTIEVserver.Domain.Entities.Admin.AppSets;

namespace porTIEVserver.Application.Services
{
    public interface IJwtProvider
    {
        Task<LoginCommandResponse> CreateToken(AppUser user, 
            string firmRef, List<int> firms, 
            string roleRef, List<int> roles
            //,string menuRef, List<int> menus
            );
    }
}
