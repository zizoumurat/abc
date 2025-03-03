using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Enums;

namespace porTIEVserver.Infrastructure.Configurations.ToolSets
{
    internal sealed class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(e => new { e.Ref });
            builder.HasIndex(e => e.Code3);
            builder.HasIndex(e => e.Code2);

            builder.HasQueryFilter(e => e.IsDeleted == false);

            builder.Property(e => e.Code3           ).HasColumnType("nvarchar(016)").IsRequired();
            builder.Property(e => e.Code2           ).HasColumnType("nvarchar(016)").IsRequired();
            builder.Property(e => e.NameTrk         ).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(e => e.NameEng         ).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(e => e.PhoneAreaCode   ).HasColumnType("nvarchar(003)");
            builder.Property(e => e.CountryCode     ).HasColumnType("nvarchar(003)");
        }
    }
}
