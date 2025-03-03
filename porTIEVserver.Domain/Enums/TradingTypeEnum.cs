using Ardalis.SmartEnum;

namespace porTIEVserver.Domain.Enums
{
    public sealed class TradingTypeEnum : SmartEnum<TradingTypeEnum>
    {
        public static readonly TradingTypeEnum CRG = new("Kargo Taşıma"     , 01); // Kargo

        public static readonly TradingTypeEnum B2B = new("Bankadan Bankaya" , 11); // Banka Virman
        public static readonly TradingTypeEnum C2C = new("Cariden Cariye"   , 12); // Cari Virman
        public static readonly TradingTypeEnum K2K = new("Kasadan Kasaya"   , 13); // Kasa Virman

        public static readonly TradingTypeEnum C2K = new("Cariden Kasaya"   , 21); // Cariden Tahsilat
        public static readonly TradingTypeEnum K2C = new("Kasadan Cariye"   , 22); // Cariye Ödeme

        public static readonly TradingTypeEnum C2B = new("Cariden Bankaya"  , 31); // Cariden Gelen EFT/Havale
        public static readonly TradingTypeEnum B2C = new("Bankadan Cariye"  , 32); // Cariye Giden EFT/Havale

        public static readonly TradingTypeEnum K2B = new("Kasadan Bankaya"  , 41); // Bankaya Yatırılan Nakit
        public static readonly TradingTypeEnum B2K = new("Bankadan Kasaya"  , 42); // Bankadan Çekilen Nakit

        public TradingTypeEnum(string name, int value) : base(name, value)
        {
        }
    }
}