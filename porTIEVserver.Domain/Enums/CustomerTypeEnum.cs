using Ardalis.SmartEnum;

namespace porTIEVserver.Domain.Enums
{
    public sealed class CustomerTypeEnum : SmartEnum<CustomerTypeEnum>
    {
        public static readonly CustomerTypeEnum SAHIS = new("Şahıs"    , 1);
        public static readonly CustomerTypeEnum FIRMA = new("Firma"    , 2);
        public static readonly CustomerTypeEnum KARGO = new("Kargo"    , 3);
        public static readonly CustomerTypeEnum ORTAK = new("Ortak"    , 4);
        public static readonly CustomerTypeEnum PRSNL = new("Personel" , 5);

        public CustomerTypeEnum(string name, int value) : base(name, value)
        {
        }
    }
}
