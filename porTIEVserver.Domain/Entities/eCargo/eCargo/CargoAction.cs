using porTIEVserver.Domain.Abstractions;
using porTIEVserver.Domain.Enums;

namespace porTIEVserver.Domain.Entities.eCargo.eCargo
{
    public sealed class CargoAction : Entity
    {
        public string               CargoMainRef            { get; set; } = string.Empty;
        int                         CargoActionNr           { get; set; }
        public CargoStatusEnum      CargoStatus             { get; set; } = CargoStatusEnum.TeslimAlindi;   // Durum
        public DateOnly             ActionDate              { get; set; }
        public TimeOnly             ActionTime              { get; set; }
        public string               Description             { get; set; } = string.Empty;


    }
}
