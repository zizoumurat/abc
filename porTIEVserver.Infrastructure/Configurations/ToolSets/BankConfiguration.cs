using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using porTIEVserver.Domain.Entities.Admin.ToolSets;

namespace porTIEVserver.Infrastructure.Configurations.ToolSets
{
    internal sealed class BankConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.HasKey(e => new { e.Ref });
            builder.HasIndex(e => e.Code);

            builder.HasQueryFilter(e => e.IsDeleted == false);

            builder.Property(e => e.Code        ).HasColumnType("nvarchar(016)").IsRequired();
            builder.Property(e => e.Name        ).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(e => e.Desc        ).HasColumnType("nvarchar(100)");
            builder.Property(e => e.CountryCode ).HasColumnType("nvarchar(050)");

        }
    }
}
