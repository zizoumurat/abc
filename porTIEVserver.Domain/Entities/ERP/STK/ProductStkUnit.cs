using porTIEVserver.Domain.Abstractions;

namespace porTIEVserver.Domain.Entities.ERP.STK
{
    public sealed class ProductStkUnit : Entity
    {
        public int                  LineNr                  { get; set; }
        public string               StkUnitRef             { get; set; } = string.Empty;
        public string               ProductRef             { get; set; } = string.Empty;
        public double               Carpan                  { get; set; } = 0.00;
        public double               Bolen                   { get; set; } = 0.00;

    }
}
