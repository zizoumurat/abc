using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using porTIEVserver.Domain.Abstractions;

namespace porTIEVserver.Domain.Entities.ERP.HR
{
    public sealed class Presence : Entity
    {
        public string       AppUserId   { get; set; } = string.Empty;
        public int          FirmRef     { get; set; }
        public string       ScanCode    { get; set; } = string.Empty;
        public DateTime     ScanTime    { get; set; } = DateTime.UtcNow;
        public DateTime     SendTime    { get; set; } = DateTime.UtcNow;
        public string       Latitude    { get; set; } = string.Empty;
        public string       Longitude   { get; set; } = string.Empty;
    }
}
