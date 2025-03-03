using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace porTIEVserver.Application.Globals
{
    public static class Messages
    {

        public static String MSG_SUCCESSFUL = "İşlem başarılı";

        public static String MSG_Found              = "BULUNDU";
        public static String MSG_NotFound           = "BULUNAMADI";
        public static String MSG_Exist              = "MEVCUT";
        public static String MSG_NotExist           = "KAYITLI DEGIL";
        public static String MSG_Active             = "AKTİF";
        public static String MSG_NotActive          = "AKTİF DEGIL";
        public static String MSG_Confirmed          = "ONAYLI";
        public static String MSG_NotConfirmed       = "ONAYLI DEĞİL";
        public static String MSG_Wrong_Password          = "Şifre HATALI";
        public static String MSG_MaxFailedAccessAttempts = " {MaxFailedAccessAttempts} kez yanlış şifre girildiği için kullanıcınız {DefaultLockoutTimeSpan} dakika süreyle bloke edilmiştir";
        public static String MSG_RequiredLengthUserName  = "Kullanıcı adı ya da mail bilgisi en az {RequiredLengthUserName} karakter olmalıdır";
        public static String MSG_RequiredLengthPassword  = "Şifre en az {RequiredLengthPassword} karakter olmalıdır";
        public static String MSG_NoAuthorised            = "Bu işlemi yapma yetkiniz yok";
        public static String MSG_NotSendConfirmMail      = "Onay mesajı gönderilemedi";


        public static String MSG_User      = "Kullanıcı";
        public static String MSG_Rite      = "Yetki";
        public static String MSG_Firm      = "Şirket";
        public static String MSG_Database  = "Veritabanı";
        public static String MSG_Role      = "Rol"; 
        public static String MSG_Menu      = "Menu";

        public static String MSG_Personnel = "Personel";
        public static String MSG_Presence  = "Yoklama";
        public static String MSG_Carrier   = "Taşıyıcı";
        public static String MSG_Office    = "Ofis";
        
        public static String MSG_CargoMain   = "Kargo";
        public static String MSG_CargoAction = MSG_CargoMain + " Hareket";
        public static String MSG_CargoDetail = MSG_CargoMain + " Detay";

        public static String MSG_Trading   = "İşlem";
        public static String MSG_BizService = "Hizmet";

        public static String MSG_Contact   = "Kişi";
        public static String MSG_CrmAction = "Faaliyet";

        public static String MSG_Product   = "Ürün";
        public static String MSG_StkUnit    = "Birim";
        public static String MSG_StkUnitSet = MSG_StkUnit+" Seti";
        public static String MSG_ProductStkUnit = MSG_Product+" "+ MSG_StkUnitSet;

        public static String MSG_Bank        = "Banka";
        public static String MSG_BankAccount = MSG_Bank + " Hesabı";
        public static String MSG_BankBranch  = MSG_Bank + " Şubesi";
        public static String MSG_Cashier   = "Kasa";
        public static String MSG_Customer  = "Müşteri";
        public static String MSG_Payment   = "Ödeme";
        public static String MSG_Collect   = "Tahsilat";
        public static String MSG_Course    = "Kurs";
        public static String MSG_Branch    = "Şube";
        public static String MSG_Classroom = "Sınıf";
        public static String MSG_Participant = "Kursiyer";
        public static String MSG_Partner   = "İş Ortağı";
        public static String MSG_Status    = "Durum";

        public static String MSG_City      = "Şehir";
        public static String MSG_Country   = "Ülke";

        public static String MSG_Code      = "Kod";
        public static String MSG_Name      = "Adı";

        public static String MSG_Email     = "Eposta";
        public static String MSG_TaxNumber = "VergiNo";

        public static String MSG_Create   = "Ekleme";
        public static String MSG_Update   = "Güncelleme";
        public static String MSG_Delete   = "Silme";
        public static String MSG_Confirm  = "Onaylama";
        public static String MSG_Send     = "Gönderim";

    }
}
