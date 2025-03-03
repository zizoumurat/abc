using porTIEVserver.Domain.Abstractions;
using porTIEVserver.Domain.Enums;

namespace porTIEVserver.Domain.Entities.ERP.FIN
{
    public sealed class Trading : Entity
    {
        public DateOnly                 FicheDate                   { get; set; }
        public TimeOnly                 FicheTime                   { get; set; }
        public string                   FicheNumber                 { get; set; } = string.Empty;
        public string                   DocumentNumber              { get; set; } = string.Empty;
        public string                   Description1                { get; set; } = string.Empty;
        public string                   Description2                { get; set; } = string.Empty;
        public string                   Description3                { get; set; } = string.Empty;
        public string                   Description4                { get; set; } = string.Empty;
        public string                   Description5                { get; set; } = string.Empty;
        /* Borç İşlem */
        public TradingTypeEnum          TradingType                 { get; set; } = TradingTypeEnum.B2B;
        public TraderTypeEnum           DebitTraderType             { get; set; } = TraderTypeEnum.CLNT;        // Kasa Banka Cari Taşıyıcı
        public string                   DebitTraderRef             { get; set; } = string.Empty;               // GUID (Kasa Banka Cari Taşıyıcı)
        public CurrencyTypeEnum         DebitCurrType               { get; set; } = CurrencyTypeEnum.TL;
        public decimal                  DebitCurrRate               { get; set; } = 0; // Kur 
        public decimal                  DebitAmount                 { get; set; } = 0;
        public string                   DebitDescription            { get; set; } = string.Empty;
        /* Alacak işlem */
        public Guid?                    ContraRef                    { get; set; }
        public TraderTypeEnum           CreditTraderType            { get; set; } = TraderTypeEnum.CLNT;        // Kasa Banka Cari Taşıyıcı
        public string                   CreditTraderRef            { get; set; } = string.Empty;                              // GUID (Kasa Banka Cari Taşıyıcı)
        public CurrencyTypeEnum         CreditCurrType              { get; set; } = CurrencyTypeEnum.TL;
        public decimal                  CreditCurrRate              { get; set; } = 0; // Kur 
        public decimal                  CreditAmount                { get; set; } = 0;
        public string                   CreditDescription           { get; set; } = string.Empty;

    }
}
