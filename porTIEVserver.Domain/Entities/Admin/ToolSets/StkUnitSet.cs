using porTIEVserver.Domain.Abstractions;

namespace porTIEVserver.Domain.Entities.Admin.ToolSets
{
    public sealed class StkUnitSet : Entity
    {
        public string           Code { get; set; } = string.Empty;
        public string           Name { get; set; } = string.Empty;
        public string           Desc { get; set; } = string.Empty;

        public List<StkUnit>    Units { get; set; } = new List<StkUnit>();
    }
}
