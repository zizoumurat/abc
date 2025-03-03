using porTIEVserver.Domain.Abstractions;
using porTIEVserver.Domain.Enums;

namespace porTIEVserver.Domain.Entities.ERP.CRM
{
    public sealed class CrmAction : Entity 
    {
        public CrmActionTypeEnum        CrmActionType   { get; set; } = CrmActionTypeEnum.PHONETALK;
        public DateOnly                 FicheDate       { get; set; }
        public TimeOnly                 FicheTime       { get; set; }
        public string                   FicheNumber     { get; set; } = string.Empty;
        public string                   DocumentNumber  { get; set; } = string.Empty;
        public string                   Description1    { get; set; } = string.Empty;
        public string                   Description2    { get; set; } = string.Empty;
        public string                   Description3    { get; set; } = string.Empty;
        public string                   Description4    { get; set; } = string.Empty;
        public string                   Description5    { get; set; } = string.Empty;
        public string                   ContactRef     { get; set; } = string.Empty;  
    }
}
