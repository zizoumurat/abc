using porTIEVserver.Domain.Abstractions;

namespace porTIEVserver.Domain.Entities.Admin.ToolSets
{
    public sealed class Bank : Entity
    {
        //public BankTypeEnum  BankType     { get; set; } = BankTypeEnum.EUROPE_EU;
        public string               Code                    { get; set; } = string.Empty;
        public string               Name                    { get; set; } = string.Empty;
        public string               Desc                    { get; set; } = string.Empty;
        public string               CountryCode             { get; set; } = "TR";

    }
}
