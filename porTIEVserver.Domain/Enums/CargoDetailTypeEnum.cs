using Ardalis.SmartEnum;

namespace porTIEVserver.Domain.Enums
{
    public sealed class CargoDetailTypeEnum : SmartEnum<CargoDetailTypeEnum>
    {
        public static readonly CargoDetailTypeEnum CARGO_QUANTY = new("Kargo (Adet)"  , 10);
        public static readonly CargoDetailTypeEnum CARGO_WEIGHT = new("Kargo (KG)"    , 20);
        public static readonly CargoDetailTypeEnum CARRIER_FIX  = new("Taşıyıcı"      , 30);
        public static readonly CargoDetailTypeEnum LOCAL_FEES   = new("Yerel Giderler", 40);
        public static readonly CargoDetailTypeEnum OTHER_FEES   = new("Diğer Giderler", 50);

        public CargoDetailTypeEnum(string name, int value) : base(name, value)
        {
        }
    }
}
