using porTIEVserver.Domain.Abstractions;

namespace porTIEVserver.Domain.Entities.Admin.ToolSets
{
    public sealed class Country : Entity
    {
        //public CountryTypeEnum  CountryType     { get; set; } = CountryTypeEnum.EUROPE_EU;
        public string               Code2                   { get; set; } = string.Empty;
        public string               Code3                   { get; set; } = string.Empty;
        public string               ShortNameTrk            { get; set; } = string.Empty;
        public string               ShortNameEng            { get; set; } = string.Empty;
        public string               OfficialNameTrk         { get; set; } = string.Empty;
        public string               OfficialNameEng         { get; set; } = string.Empty;
        public string               PhoneAreaCode           { get; set; } = string.Empty;
        public string               CustomAreaCode          { get; set; } = string.Empty;
        public string               CurrencyCode            { get; set; } = string.Empty;

    }
}
