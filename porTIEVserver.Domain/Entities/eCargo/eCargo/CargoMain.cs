using porTIEVserver.Domain.Abstractions;
using porTIEVserver.Domain.Enums;

namespace porTIEVserver.Domain.Entities.eCargo.eCargo
{
    public sealed class CargoMain : Entity
    {
        public TradingTypeEnum                  TradingType                 { get; set; } = TradingTypeEnum.CRG;
        public DateOnly                         FicheDate                   { get; set; }
        public TimeOnly                         FicheTime                   { get; set; }
        public string                           FicheNumber                 { get; set; } = string.Empty;
        public string                           Description1                { get; set; } = string.Empty;
        public string                           Description2                { get; set; } = string.Empty;
        public string                           Description3                { get; set; } = string.Empty;
        public string                           Description4                { get; set; } = string.Empty;
        public string                           Description5                { get; set; } = string.Empty;
        /* İşlem */
        public CargoStatusEnum                  CargoStatus                 { get; set; } = CargoStatusEnum.TeslimAlindi;   // Durum
        public TransportTypeEnum                TransportType               { get; set; } = TransportTypeEnum.AIR;   // Taşıma Şekli
        public DateOnly                         EstimateArrivalDate         { get; set; }                           // Tahmini Varış Tarihi
        public string                           SenderOfficeRef            { get; set; } = string.Empty;           // GUID (Gönderen Ofis)
        public string                           SenderOfficeNote            { get; set; } = string.Empty;           // Gönderici Ofis Notu
        public string                           SenderRef                  { get; set; } = string.Empty;           // GUID (Gönderen Müşteri)
        public string                           SenderNote                  { get; set; } = string.Empty;           // Gönderici Notu
        public string                           PickerOfficeRef            { get; set; } = string.Empty;           // GUID (Alıcı Ofis)
        public string                           PickerRef                  { get; set; } = string.Empty;           // GUID (Alıcı Müşteri)
        public string                           PayerOfficeRef             { get; set; } = string.Empty;           // GUID (Tahsil Eden Ofis)
        public string                           PayerRef                   { get; set; } = string.Empty;           // GUID (Ödeyen Müşteri)
        public string                           PayerNote                   { get; set; } = string.Empty;           // Ödeme Notu
        public string                           CarrierRef                 { get; set; } = string.Empty;           // GUID (Taşıyıcı )
        public string                           CarrierNote                 { get; set; } = string.Empty;           // Taşıyıcı Notu

        //public List<CargoAction>?   CargoActions            { get; set; }
        //public List<CargoDetail>?   CargoDetails            { get; set; }
    }
}
