using porTIEVserver.Domain.Abstractions;

namespace porTIEVserver.Domain.Entities.Admin.ToolSets
{
    public sealed class BankBranch : Entity
    {
        //public BankBranchTypeEnum  BankBranchType     { get; set; } = BankBranchTypeEnum.EUROPE_EU;
        public string               Code                    { get; set; } = string.Empty;
        public string               Name                    { get; set; } = string.Empty;
        public int                  BankRef                 { get; set; }
        public int                  InchargeRef             { get; set; }
        public string               FullAddress             { get; set; } = string.Empty;
        public string               CityCode                { get; set; } = "34";
        public string               CountryCode             { get; set; } = "TR";
        public string               Phone                   { get; set; } = string.Empty;
        public string               Mobile                  { get; set; } = string.Empty;
        public string               Email                   { get; set; } = string.Empty;

    }
}
