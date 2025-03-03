using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Users.GetAllUsers
{
    public sealed record GetAllUsersQuery(
        ) : IRequest<Result<List<AppUser>>>;
}
