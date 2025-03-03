using Ardalis.SmartEnum;

namespace porTIEVserver.Domain.Enums
{
    public sealed class StkUnitTypeEnum : SmartEnum<StkUnitTypeEnum>
    {
        public static readonly StkUnitTypeEnum MIKTAR  = new("MIKTAR" , 1);
        public static readonly StkUnitTypeEnum AGIRLIK = new("AGIRLIK", 2);
        public static readonly StkUnitTypeEnum HACIM   = new("HACIM"  , 3);
        public static readonly StkUnitTypeEnum ALAN    = new("ALAN"   , 4);

        public StkUnitTypeEnum(string name, int value) : base(name, value)
        {
        }
    }
}
