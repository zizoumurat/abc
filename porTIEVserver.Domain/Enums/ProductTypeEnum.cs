using Ardalis.SmartEnum;

namespace porTIEVserver.Domain.Enums
{
    public sealed class ProductTypeEnum : SmartEnum<ProductTypeEnum>
    {
        public static readonly ProductTypeEnum TICARI       = new("Ticari Mal"   , 01);
        public static readonly ProductTypeEnum SABITKIYMET  = new("Sabit Kıymet" , 04);
        public static readonly ProductTypeEnum HAMMADDE     = new("Hammadde"     , 10);
        public static readonly ProductTypeEnum YARIMAMUL    = new("Yarı Mamul"   , 11);
        public static readonly ProductTypeEnum MAMUL        = new("Mamul"        , 12);
        public static readonly ProductTypeEnum TUKETIM      = new("Tüketim Malı" , 13);

        public ProductTypeEnum(string name, int value) : base(name, value)
        {
        }
    }
}
