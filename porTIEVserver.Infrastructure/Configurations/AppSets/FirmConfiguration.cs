using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using porTIEVserver.Domain.Enums;

namespace porTIEVserver.Infrastructure.Configurations.AppSets
{
    internal sealed class FirmConfiguration : IEntityTypeConfiguration<Firm>
    {
        public void Configure(EntityTypeBuilder<Firm> builder)
        {
            builder.HasKey(e => new { e.Ref });
            builder.HasIndex(e => e.Code);
            builder.HasQueryFilter(e => e.IsDeleted == false);

            builder.Property(e => e.Code        ).HasColumnType("nvarchar(016)").IsRequired();
            builder.Property(e => e.Name        ).HasColumnType("nvarchar(100)");
            builder.Property(e => e.TaxNumber   ).HasColumnType("nvarchar(011)").IsRequired();
            builder.Property(e => e.Desc        ).HasColumnType("nvarchar(100)");
            builder.Property(e => e.FullAddress ).HasColumnType("nvarchar(250)");
            builder.Property(e => e.CityCode    ).HasColumnType("nvarchar(003)");
            builder.Property(e => e.CountryCode ).HasColumnType("nvarchar(003)");
            builder.Property(e => e.TaxOffice   ).HasColumnType("nvarchar(050)");
            builder.Property(e => e.TaxNumber   ).HasColumnType("nvarchar(011)");
            builder.Property(e => e.ImgUrl      ).HasColumnType("nvarchar(100)");
            builder.Property(e => e.DbServ      ).HasColumnType("nvarchar(050)");
            builder.Property(e => e.DbName      ).HasColumnType("nvarchar(050)");
            builder.Property(e => e.DbUser      ).HasColumnType("nvarchar(050)");
            builder.Property(e => e.DbPass      ).HasColumnType("nvarchar(050)");
            builder.Property(p => p.CurrencyType).HasConversion(type => type.Value,value => CurrencyTypeEnum.FromValue(value));
            builder.Property(p => p.FirmType    ).HasConversion(type => type.Value,value => FirmTypeEnum    .FromValue(value));

        }
    }
}
