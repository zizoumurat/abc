using porTIEVserver.Domain.Abstractions;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Entities.ERP.CRM;
using porTIEVserver.Domain.Enums;

namespace porTIEVserver.Domain.Entities.ERP.FIN
{
    public sealed class Cashier : Entity
    {
        public CurrencyTypeEnum         CurrencyType            { get; set; } = CurrencyTypeEnum.TL;
        public string                   Code                    { get; set; } = string.Empty;
        public string                   Name                    { get; set; } = string.Empty;
        public decimal                  Debit                   { get; set; } = 0;
        public decimal                  Credit                  { get; set; } = 0;
        public decimal                  Balance                 { get; set; } = 0;

        public List<Trading>?           Tradings                { get; set; }

    }
}
