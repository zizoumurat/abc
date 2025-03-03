using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.SmartEnum;

namespace porTIEVserver.Domain.Enums
{
    public sealed class RightTypeEnum : SmartEnum<RightTypeEnum>
    {
        public static readonly RightTypeEnum CREATE = new("Yeni Ekle", 01);
        public static readonly RightTypeEnum UPDATE = new("Güncelle" , 02);
        public static readonly RightTypeEnum DELETE = new("Yok Et"   , 03);
        public static readonly RightTypeEnum MARKED = new("Çıkar"    , 04);
        public static readonly RightTypeEnum REMARK = new("Geri Al"  , 05);

        public RightTypeEnum(string name, int value) : base(name, value)
        {
        }
    }
}
