using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Enums;

namespace porTIEVserver.Infrastructure.Configurations.ToolSets
{
    internal sealed class StkUnitConfiguration : IEntityTypeConfiguration<StkUnit>
    {
        public void Configure(EntityTypeBuilder<StkUnit> builder)
        {
            builder.HasKey(e => new { e.Ref });
            builder.HasIndex(e => e.Code);

            builder.HasQueryFilter(e => e.IsDeleted == false);

            builder.Property(e => e.Code        ).HasColumnType("nvarchar(016)").IsRequired();
            builder.Property(e => e.Name        ).HasColumnType("nvarchar(100)").IsRequired();

            builder.Property(p => p.UnitType).HasConversion(type => type.Value, value => StkUnitTypeEnum.FromValue(value));

        }
    }
}
