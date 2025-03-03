using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.SmartEnum;

namespace porTIEVserver.Domain.Enums
{

    public sealed class ButtonTypeEnum : SmartEnum<ButtonTypeEnum>
    {
        public static readonly ButtonTypeEnum CREATE  = new("EKLE"  , 01);
        public static readonly ButtonTypeEnum SELECT  = new("GÖSTER", 02);
        public static readonly ButtonTypeEnum UPDATE  = new("DÜZELT", 04);
        public static readonly ButtonTypeEnum DELETE  = new("ÇIKAR" , 08);
        public static readonly ButtonTypeEnum EXCEPT  = new("DIŞLA" , 16);
        public static readonly ButtonTypeEnum MIGRATE = new("AKTAR" , 32);

        public ButtonTypeEnum(string name, int value) : base(name, value)
        {
        }
    }
}
