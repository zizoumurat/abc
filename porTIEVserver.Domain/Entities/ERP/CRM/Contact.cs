using porTIEVserver.Domain.Abstractions;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Enums;

namespace porTIEVserver.Domain.Entities.ERP.CRM
{
    public sealed class Contact : Entity
    {
        public ContactTypeEnum          ContactType             { get; set; } = ContactTypeEnum.ADAY;
        public string                   Code                    { get; set; } = string.Empty;
        public string                   FirstName               { get; set; } = string.Empty;
        public string                   LastName                { get; set; } = string.Empty;
        public string                   FullName                => string.Join(" ", FirstName, LastName);
        public string                   ImgUrl                  { get; set; } = string.Empty;
        public string                   InchargeRef            { get; set; } = string.Empty;
        public string                   FullAddress             { get; set; } = string.Empty;
        public string                   CityRef                { get; set; } = string.Empty;
        public string                   CountryRef             { get; set; } = string.Empty;
        public string                   Phone                   { get; set; } = string.Empty;
        public string                   Mobile                  { get; set; } = string.Empty;
        public string                   Email                   { get; set; } = string.Empty;

        //public List<CrmAction>? CrmActions      { get; set; }
    }
}
