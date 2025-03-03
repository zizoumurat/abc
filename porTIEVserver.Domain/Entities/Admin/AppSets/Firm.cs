using porTIEVserver.Domain.Abstractions;
using porTIEVserver.Domain.Enums;

namespace porTIEVserver.Domain.Entities.Admin.AppSets
{
    public sealed class Firm : Entity
    {
        public FirmTypeEnum       FirmType           { get; set; } = FirmTypeEnum.Person;
        public string             Code               { get; set; } = string.Empty;
        public string             Name               { get; set; } = string.Empty;
        public string             Desc               { get; set; } = string.Empty;
        public string             FullAddress        { get; set; } = string.Empty;
        public string             CityCode           { get; set; } = string.Empty;
        public string             CountryCode        { get; set; } = string.Empty;
        public string             TaxOffice          { get; set; } = string.Empty;
        public string             TaxNumber          { get; set; } = string.Empty;
        public string             ImgUrl             { get; set; } = string.Empty;
        public CurrencyTypeEnum   CurrencyType       { get; set; } = CurrencyTypeEnum.TL;
        public string             DbServ             { get; set; } = string.Empty;
        public string             DbName             { get; set; } = string.Empty;
        public string             DbUser             { get; set; } = string.Empty; 
        public string             DbPass             { get; set; } = string.Empty;

    }
}
