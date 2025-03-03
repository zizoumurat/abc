using Ardalis.SmartEnum;

namespace porTIEVserver.Domain.Enums
{
    public sealed class FirmTypeEnum : SmartEnum<FirmTypeEnum>
    {
        public static readonly FirmTypeEnum Person       = new("Gerçek Kişi", 1);
        public static readonly FirmTypeEnum Limited      = new("Limited"    , 2);
        public static readonly FirmTypeEnum Anonim       = new("Anonim"     , 3);
        public static readonly FirmTypeEnum Foundation   = new("Vakıf"      , 4);
        public static readonly FirmTypeEnum Cooperation  = new("Kooperatif" , 5);
        public static readonly FirmTypeEnum Holding      = new("Holding"    , 6);
        public FirmTypeEnum(string name, int value) : base(name, value)
        {
        }
    }
}
