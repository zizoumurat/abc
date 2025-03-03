using porTIEVserver.Domain.Abstractions;

namespace porTIEVserver.Domain.Entities.Admin.AppSets
{
    public sealed class Menu : Entity
    {
        public string        Code                    { get; set; } = string.Empty;
        public string        Name                    { get; set; } = string.Empty;
        public string        Icon                    { get; set; } = string.Empty;
        public string        AppUrl                  { get; set; } = string.Empty;
        public string        ImgUrl                  { get; set; } = string.Empty;
        public bool          IsAdmin                 { get; set; } = false;

    }
}
