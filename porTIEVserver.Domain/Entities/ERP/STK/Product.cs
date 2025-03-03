using porTIEVserver.Domain.Abstractions;
using porTIEVserver.Domain.Enums;

namespace porTIEVserver.Domain.Entities.ERP.STK
{
    public sealed class Product : Entity
    {
        public ProductTypeEnum      ProductType     { get; set; } = ProductTypeEnum.MAMUL;
        public string               Code            { get; set; } = string.Empty;
        public string               Name            { get; set; } = string.Empty;
        public string               Name2           { get; set; } = string.Empty;
        public string               Name3           { get; set; } = string.Empty;
        public string               Name4           { get; set; } = string.Empty;
        public string               SpeCode         { get; set; } = string.Empty;
        public string               SpeCode2        { get; set; } = string.Empty;
        public string               SpeCode3        { get; set; } = string.Empty;
        public string               SpeCode4        { get; set; } = string.Empty;
        public string               SpeCode5        { get; set; } = string.Empty;
        public string               StkGroup        { get; set; } = string.Empty;
        public double               Debit           { get; set; } = 0.00;
        public double               Credit          { get; set; } = 0.00;
        public double               Balance         { get; set; } = 0.00;
        //public List<ProductStkUnit>    Units           { get; set; } = new List<ProductStkUnit>();

    }
}
