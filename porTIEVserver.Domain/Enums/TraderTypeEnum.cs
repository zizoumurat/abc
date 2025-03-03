using Ardalis.SmartEnum;

namespace porTIEVserver.Domain.Enums
{
    public sealed class TraderTypeEnum : SmartEnum<TraderTypeEnum>
    {
        public static readonly TraderTypeEnum BANK = new("Banka"    , 1);
        public static readonly TraderTypeEnum CASH = new("Kasa"     , 2);
        public static readonly TraderTypeEnum CLNT = new("Müşteri"  , 3);
        public static readonly TraderTypeEnum CARR = new("Taşıyıcı" , 4);
        public static readonly TraderTypeEnum SRVR = new("Tedarikçi", 5);
        public TraderTypeEnum(string name, int value) : base(name, value)
        {
        }
    }
}
