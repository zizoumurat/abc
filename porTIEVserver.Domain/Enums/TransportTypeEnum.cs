using Ardalis.SmartEnum;

namespace porTIEVserver.Domain.Enums
{
    public sealed class TransportTypeEnum : SmartEnum<TransportTypeEnum>
    {
        public static readonly TransportTypeEnum TIR = new("TIR" , 1);
        public static readonly TransportTypeEnum SHP = new("GEMI", 2);
        public static readonly TransportTypeEnum AIR = new("UCAK", 3);

        public TransportTypeEnum(string name, int value) : base(name, value)
        {
        }
    }
}
