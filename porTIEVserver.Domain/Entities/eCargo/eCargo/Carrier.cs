using porTIEVserver.Domain.Abstractions;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Entities.ERP.CRM;
using porTIEVserver.Domain.Entities.ERP.FIN;
using porTIEVserver.Domain.Enums;

namespace porTIEVserver.Domain.Entities.eCargo.eCargo
{
    public sealed class Carrier : Entity
    {
        public CurrencyTypeEnum         CurrencyType            { get; set; } = CurrencyTypeEnum.TL;
        public string                   Code                    { get; set; } = string.Empty;
        public string                   Name                    { get; set; } = string.Empty;
        public string                   Desc                    { get; set; } = string.Empty;
        public string                   ImgUrl                  { get; set; } = string.Empty;
        public string                   InchargeRef            { get; set; } = string.Empty;
        public string                   FullAddress             { get; set; } = string.Empty;
        public string                   CityRef                { get; set; } = string.Empty;
        public string                   CountryRef             { get; set; } = string.Empty;
        public string                   Phone                   { get; set; } = string.Empty;
        public string                   Mobile                  { get; set; } = string.Empty;
        public string                   Email                   { get; set; } = string.Empty;
        public decimal                  Debit                   { get; set; } = 0;
        public decimal                  Credit                  { get; set; } = 0;
        public decimal                  Balance                 { get; set; } = 0;

        public List<Trading>?           Tradings                { get; set; }

    }
}
