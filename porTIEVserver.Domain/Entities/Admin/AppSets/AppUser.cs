using Microsoft.AspNetCore.Identity;

namespace porTIEVserver.Domain.Entities.Admin.AppSets
{
    public sealed class AppUser : IdentityUser<Guid>
    {
        public int          Ref                     { get; set; } = 0;
        public string       FirstName               { get; set; } = string.Empty;
        public string       LastName                { get; set; } = string.Empty;
        public string       FullName => string.Join(" ", FirstName, LastName);
        public string       ImgUrl                  { get; set; } = string.Empty;
        public bool         IsAdmin                 { get; set; } = false;
        public bool         IsDeleted               { get; set; } = false;
        public string?      RefreshToken            { get; set; }
        public DateTime?    RefreshTokenExpires     { get; set; }
        public int          CreatedUser             { get; set; }
        public DateTime     CreatedDate             { get; set; } = DateTime.UtcNow;
        public int          LastUpdatedUser         { get; set; } = 0;
        public DateTime?    LastUpdatedDate         { get; set; }

    }
}
