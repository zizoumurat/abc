using Ardalis.SmartEnum;

namespace porTIEVserver.Domain.Enums
{
    public sealed class OfficeTypeEnum : SmartEnum<OfficeTypeEnum>
    {
        public static readonly OfficeTypeEnum MRKZ  = new("Merkez"    , 1);
        public static readonly OfficeTypeEnum SUBE  = new("Şube"      , 2);
        public static readonly OfficeTypeEnum FRNC  = new("Franchise" , 3);

        public OfficeTypeEnum(string name, int value) : base(name, value)
        {
        }
    }
}
