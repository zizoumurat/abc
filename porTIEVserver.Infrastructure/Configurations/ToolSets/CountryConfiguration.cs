using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using porTIEVserver.Domain.Entities.Admin.ToolSets;

namespace porTIEVserver.Infrastructure.Configurations.ToolSets
{
    internal sealed class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(e => new { e.Ref });
            builder.HasIndex(e => e.Code2);
            builder.HasIndex(e => e.Code3);
            builder.HasIndex(e => e.ShortNameTrk);
            builder.HasIndex(e => e.ShortNameEng);

            builder.HasQueryFilter(e => e.IsDeleted == false);

            builder.Property(e => e.Code2           ).HasColumnType("nvarchar(002)").IsRequired();
            builder.Property(e => e.Code3           ).HasColumnType("nvarchar(003)").IsRequired();
            builder.Property(e => e.ShortNameTrk    ).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(e => e.ShortNameEng    ).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(e => e.OfficialNameTrk ).HasColumnType("nvarchar(250)").IsRequired();
            builder.Property(e => e.OfficialNameEng ).HasColumnType("nvarchar(250)").IsRequired();
            builder.Property(e => e.PhoneAreaCode   ).HasColumnType("nvarchar(005)");
            builder.Property(e => e.CustomAreaCode  ).HasColumnType("nvarchar(005)");
            builder.Property(e => e.CurrencyCode    ).HasColumnType("nvarchar(003)");

        }
    }
}
