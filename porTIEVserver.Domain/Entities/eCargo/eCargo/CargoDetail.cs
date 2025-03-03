using porTIEVserver.Domain.Abstractions;
using porTIEVserver.Domain.Enums;

namespace porTIEVserver.Domain.Entities.eCargo.eCargo
{
    public sealed class CargoDetail : Entity
    {
        public string               CargoMainRef           { get; set; } = string.Empty;
        int                         CargoDetailNr           { get; set; }
        public CargoDetailTypeEnum  CargoDetailType         { get; set; } = CargoDetailTypeEnum.CARGO_QUANTY;    // ADET, KİLOGRAM
        public decimal              Quantity                { get; set; } = 1;
        public CurrencyTypeEnum     CurrencyType1           { get; set; } = CurrencyTypeEnum.TL;    // GUID (Kasa Banka Cari Taşıyıcı)
        public decimal              CurrencyRate1           { get; set; } = 0; // Kur 
        public decimal              Amount1                 { get; set; } = 0;
        public decimal              Total1                  { get; set; } = 0;
        public CurrencyTypeEnum     CurrencyType2           { get; set; } = CurrencyTypeEnum.TL;    // GUID (Kasa Banka Cari Taşıyıcı)
        public decimal              CurrencyRate2           { get; set; } = 0; // Kur 
        public decimal              Amount2                 { get; set; } = 0;
        public decimal              Total2                  { get; set; } = 0;
        public CurrencyTypeEnum     CurrencyType3           { get; set; } = CurrencyTypeEnum.TL;    // GUID (Kasa Banka Cari Taşıyıcı)
        public decimal              CurrencyRate3           { get; set; } = 0; // Kur 
        public decimal              Amount3                 { get; set; } = 0;
        public decimal              Total3                  { get; set; } = 0;

    }
}
