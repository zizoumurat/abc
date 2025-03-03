using porTIEVserver.Domain.Abstractions;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Entities.ERP.CRM;
using porTIEVserver.Domain.Enums;

namespace porTIEVserver.Domain.Entities.eCargo.eCargo
{
    public sealed class Office : Entity
    {
        //public OfficeTypeEnum   OfficeType      { get; set; } = OfficeTypeEnum.MRKZ;
        public string                   Code                    { get; set; } = string.Empty;
        public string                   Name                    { get; set; } = string.Empty;
        public string                   InchargeRef             { get; set; } = string.Empty;
        public string                   FullAddress             { get; set; } = string.Empty;
        public string                   CityRef                 { get; set; } = string.Empty;
        public string                   CountryRef              { get; set; } = string.Empty;
        public string                   Phone                   { get; set; } = string.Empty;
        public string                   Mobile                  { get; set; } = string.Empty;
        public string                   Email                   { get; set; } = string.Empty;

    }
}
