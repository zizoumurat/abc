using Ardalis.SmartEnum;

namespace porTIEVserver.Domain.Enums
{
    public sealed class CargoStatusEnum : SmartEnum<CargoStatusEnum>
    {
        public static readonly CargoStatusEnum TeslimAlindi     = new("Kargo Teslim Alındı"      , 1);
        public static readonly CargoStatusEnum YolaCikti        = new("Kargo Yola Çıktı"         , 2);
        public static readonly CargoStatusEnum TeslimEdildi     = new("Kargo Teslim Edildi"      , 3);
        public static readonly CargoStatusEnum MüşteriTeslim    = new("Müşteriye Teslim Edildi"  , 4);		

        public CargoStatusEnum(string name, int value) : base(name, value)
        {
        }
    }
}
