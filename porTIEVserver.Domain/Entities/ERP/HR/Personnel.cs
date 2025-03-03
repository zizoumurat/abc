using porTIEVserver.Domain.Abstractions;
using porTIEVserver.Domain.Entities.Admin.ToolSets;

namespace porTIEVserver.Domain.Entities.ERP.HR
{

    public sealed class Personnel : Entity
    {
        public string                   Code                    { get; set; } = string.Empty;
        public string                   FirstName               { get; set; } = string.Empty;
        public string                   LastName                { get; set; } = string.Empty;
        public string                   FullName                => string.Join(" ", FirstName, LastName);
        public string                   ImgUrl                  { get; set; } = string.Empty;
        public string                   FullAddress             { get; set; } = string.Empty;
        public string                   CityRef                { get; set; } = string.Empty;
        public string                   CountryRef             { get; set; } = string.Empty;
        public string                   Phone                   { get; set; } = string.Empty;
        public string                   Mobile                  { get; set; } = string.Empty;
        public string                   Email                   { get; set; } = string.Empty;
        public decimal                  Debit                   { get; set; } = 0;
        public decimal                  Credit                  { get; set; } = 0;
        public decimal                  Balance                 { get; set; } = 0;

    }

}
