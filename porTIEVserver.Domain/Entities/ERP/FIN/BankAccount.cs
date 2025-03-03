using porTIEVserver.Domain.Abstractions;
using porTIEVserver.Domain.Enums;

namespace porTIEVserver.Domain.Entities.ERP.FIN
{
    public sealed class BankAccount : Entity
    {
        //public BankAccountTypeEnum   BankAccountType      { get; set; } = OfficeTypeEnum.MRKZ;
        public string               Code                        { get; set; } = string.Empty;
        public string               Name                        { get; set; } = string.Empty;
        public int BankRef                     { get; set; } = 0;
        public int BankBranchRef               { get; set; } = 0;
        public string               AccountNumber               { get; set; } = string.Empty;
        public string               Iban                        { get; set; } = string.Empty;
        public CurrencyTypeEnum     CurrencyType                { get; set; } = CurrencyTypeEnum.TL;
        public decimal              Debit                       { get; set; } = 0;
        public decimal              Credit                      { get; set; } = 0;
        public decimal              Balance                     { get; set; } = 0;

        //public List<Trading>?       Tradings                    { get; set; }
    }
}
