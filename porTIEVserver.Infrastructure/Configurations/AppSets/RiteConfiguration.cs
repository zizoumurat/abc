using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using porTIEVserver.Domain.Entities.Admin.AppSets;

namespace porTIEVserver.Infrastructure.Configurations.AppSets
{
    internal sealed class RiteConfiguration : IEntityTypeConfiguration<Rite>
    {
        public void Configure(EntityTypeBuilder<Rite> builder)
        {
            builder.HasKey(e => new { e.Ref });
            builder.HasIndex(e => new { e.AppUserRef, e.FirmRef, e.RoleRef, e.MenuRef, e.BttnRef });
            //builder.HasQueryFilter(filter => !filter.Firm!.IsDeleted);

            //builder.Property(e => e.BttnRef).IsRequired().HasColumnType("nvarchar(16)");

        }
    }
}
