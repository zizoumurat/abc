using porTIEVserver.Domain.Abstractions;

namespace porTIEVserver.Domain.Entities.Admin.ToolSets
{

    public sealed class City : Entity
    {
        //public CityTypeEnum     CityType        { get; set; } = CityTypeEnum.Normal;
        public string               Code2                   { get; set; } = string.Empty;
        public string               Code3                   { get; set; } = string.Empty;
        public string               NameTrk                 { get; set; } = string.Empty;
        public string               NameEng                 { get; set; } = string.Empty;
        public string               PhoneAreaCode           { get; set; } = string.Empty;
        public string               CountryCode             { get; set; } = "TR";

    }
}
