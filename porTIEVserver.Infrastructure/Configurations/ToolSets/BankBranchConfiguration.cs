using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using porTIEVserver.Domain.Entities.Admin.ToolSets;

namespace porTIEVserver.Infrastructure.Configurations.ToolSets
{
    internal sealed class BankBranchConfiguration : IEntityTypeConfiguration<BankBranch>
    {
        public void Configure(EntityTypeBuilder<BankBranch> builder)
        {
            builder.HasKey(e => new { e.Ref });
            builder.HasIndex(e => e.Code);

            builder.HasQueryFilter(e => e.IsDeleted == false);

            builder.Property(e => e.Code        ).HasColumnType("nvarchar(016)").IsRequired();
            builder.Property(e => e.Name        ).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(e => e.BankRef     ).HasColumnType("nvarchar(050)");
            builder.Property(e => e.InchargeRef ).HasColumnType("nvarchar(050)");
            builder.Property(e => e.FullAddress ).HasColumnType("nvarchar(250)");
            builder.Property(e => e.CityCode    ).HasColumnType("nvarchar(050)");
            builder.Property(e => e.CountryCode ).HasColumnType("nvarchar(050)");
            builder.Property(e => e.Phone       ).HasColumnType("nvarchar(050)");
            builder.Property(e => e.Mobile      ).HasColumnType("nvarchar(050)");
            builder.Property(e => e.Email       ).HasColumnType("nvarchar(050)");
        }
    }
}
