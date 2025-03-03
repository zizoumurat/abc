using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using porTIEVserver.Domain.Entities.Admin.AppSets;

namespace porTIEVserver.Infrastructure.Configurations.AppSets
{
    internal sealed class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(p => p.FirstName   ).HasColumnType("nvarchar(50)");
            builder.Property(p => p.LastName    ).HasColumnType("nvarchar(50)");
            builder.Property(e => e.ImgUrl      ).HasColumnType("nvarchar(100)");

            builder.HasQueryFilter(x => x.IsDeleted == false);
        }
    }

}
