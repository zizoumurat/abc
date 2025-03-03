using porTIEVserver.Domain.Abstractions;
using porTIEVserver.Domain.Entities.Admin;
using porTIEVserver.Domain.Entities.ERP.CRM;
using porTIEVserver.Domain.Enums;

namespace porTIEVserver.Domain.Entities.ERP.FIN
{
    public sealed class Customer : Entity
    {
        public CustomerTypeEnum         CustomerType            { get; set; } = CustomerTypeEnum.SAHIS;
        public FirmTypeEnum             FirmType                { get; set; } = FirmTypeEnum.Person;
        public CurrencyTypeEnum         CurrencyType            { get; set; } = CurrencyTypeEnum.TL;
        public string                   Code                    { get; set; } = string.Empty;
        public string                   FirstName               { get; set; } = string.Empty;
        public string                   LastName                { get; set; } = string.Empty;
        public string                   FullName                => string.Join(" ", FirstName, LastName);
        public string                   TaxOffice               { get; set; } = string.Empty;
        public string                   TaxNumber               { get; set; } = string.Empty;
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


