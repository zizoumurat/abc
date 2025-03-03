using Ardalis.SmartEnum;

namespace porTIEVserver.Domain.Enums
{
    public sealed class ContactTypeEnum : SmartEnum<ContactTypeEnum>
    {
        public static readonly ContactTypeEnum ADAY = new("Aday Müşteri" , 1);
        public static readonly ContactTypeEnum TDRK = new("Tedarikçi"    , 2);
        public static readonly ContactTypeEnum NKLY = new("Nakliyeci"    , 3);
        public static readonly ContactTypeEnum LEAD = new("Fırsat"       , 4);
        public static readonly ContactTypeEnum ISCI = new("Personel"     , 5);
        public static readonly ContactTypeEnum DIGR = new("Diğer"        , 9);
        public ContactTypeEnum(string name, int value) : base(name, value)
        {
        }
    }
}
