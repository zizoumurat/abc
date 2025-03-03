using Ardalis.SmartEnum;

namespace porTIEVserver.Domain.Enums
{
    public sealed class CrmActionTypeEnum : SmartEnum<CrmActionTypeEnum>
    {
        public static readonly CrmActionTypeEnum PHONETALK  = new("Telefon Konuşması", 10);
        public static readonly CrmActionTypeEnum SENDMAIL   = new("E-posta gönderme" , 20);
        public static readonly CrmActionTypeEnum ONLINEMEET = new("Uzaktan Toplantı" , 30);
        public static readonly CrmActionTypeEnum FACETOFACE = new("Yüzyüze Toplantı" , 40);
		
        public CrmActionTypeEnum(string name, int value) : base(name, value)
        {
        }
    }
}
