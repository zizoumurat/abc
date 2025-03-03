using Microsoft.EntityFrameworkCore.Metadata.Internal;
using porTIEVserver.Domain.Abstractions;

namespace porTIEVserver.Domain.Entities.Admin.AppSets
{
    public sealed class Role : Entity
    {
        public string          Code                    { get; set; } = string.Empty;
        public string          Name                    { get; set; } = string.Empty;
    }
}


