using porTIEVserver.Domain.Abstractions;
using porTIEVserver.Domain.Entities.eCargo.eCargo;

namespace porTIEVserver.Domain.Entities.eBizService.eBizService
{
    public sealed class BizService : Entity
    {
        public string           Code                    { get; set; } = string.Empty;
        public string           Name                    { get; set; } = string.Empty;
        public string           Desc                    { get; set; } = string.Empty;
        public string           TraderServerRef        { get; set; } = string.Empty; // Tedarikçi
        public string           TraderClientRef        { get; set; } = string.Empty; // Müşteri
        public DateTime         StartDate               { get; set; }
        public DateTime         EndDate                 { get; set; }
        public bool             IsCompleted             { get; set; }

    }
}
