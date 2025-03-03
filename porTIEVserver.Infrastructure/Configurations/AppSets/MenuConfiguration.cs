using System.Drawing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using porTIEVserver.Domain.Enums;

namespace porTIEVserver.Infrastructure.Configurations.AppSets
{
    internal sealed class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasKey(e => new { e.Ref });
            builder.HasIndex(e => e.Code);
            builder.HasQueryFilter(e => e.IsDeleted == false);

            builder.Property(e => e.Code  ).IsRequired().HasColumnType("nvarchar(16)");
            builder.Property(e => e.Name  ).HasColumnType("nvarchar(100)");
            builder.Property(e => e.Icon  ).HasColumnType("nvarchar(100)");
            builder.Property(e => e.AppUrl).HasColumnType("nvarchar(100)");
            builder.Property(e => e.ImgUrl).HasColumnType("nvarchar(100)");
        }
    }
}
