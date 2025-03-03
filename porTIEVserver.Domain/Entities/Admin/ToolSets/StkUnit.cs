using porTIEVserver.Domain.Abstractions;
using porTIEVserver.Domain.Enums;

namespace porTIEVserver.Domain.Entities.Admin.ToolSets
{
    public sealed class StkUnit : Entity
    {
        public StkUnitTypeEnum  UnitType    { get; set; } = StkUnitTypeEnum.MIKTAR;
        public string           Code        { get; set; } = string.Empty;
        public string           Name        { get; set; } = string.Empty;
        //public double           Carpan      { get; set; } = 0.00;
        //public double           Bolen       { get; set; } = 0.00;
    }
}
