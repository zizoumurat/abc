using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using porTIEVserver.Domain.Enums;

namespace porTIEVserver.Infrastructure.Configurations.AppSets
{
    internal sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(e => new { e.Ref });
            builder.HasIndex(e => e.Code);
            builder.HasQueryFilter(e => e.IsDeleted == false);

            builder.Property(e => e.Code).IsRequired().HasColumnType("nvarchar(16)");
            builder.Property(e => e.Name).HasColumnType("nvarchar(100)");
            
        }
    }
}
