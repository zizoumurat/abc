using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace porTIEVserver.Application.Globals
{
    public static class Parameters
    {
        /* ÖRNEKLER
        public const Int32 BUFFER_SIZE = 512; // Unmodifiable
        public static String FILE_NAME = "Output.txt"; // Modifiable
        public static readonly String CODE_PREFIX = "US-"; // Unmodifiable 
        */

        public static string DbServ = "mssql04.trwww.com";
        public static string DbName = "ideanos3_IdeaNostraMainDB";
        public static string DbUser = "IdeaAdminUser";
        public static string DbPass = "IdAdmn_Usr@2021!!";

        public static string AdminUser_UserName  = "Admin";
        public static string AdminUser_Password  = "1";
        public static string AdminUser_Email     = "admin@portiev.com.tr";
        public static string AdminUser_FirstName = "Portiev";
        public static string AdminUser_LastName  = "Administrator";
        public static string AdminUser_ImgUrl    = "Atam.jpg";

        public static string TestUser_UserName  = "Test";
        public static string TestUser_Password  = "1";
        public static string TestUser_Email     = "test@portiev.com.tr";
        public static string TestUser_FirstName = "Portiev";
        public static string TestUser_LastName  = "Tester";
        public static string TestUser_ImgUrl    = "Atam.jpg";

        public static int DefaultLockoutTimeSpan  = 5;
        public static int MaxFailedAccessAttempts = 3;
        public static int RequiredLengthUserName  = 3;
        public static int RequiredLengthPassword  = 0;

        public static bool CanRiteCodeChange = false;
        public static bool CanRiteNameChange = true;
        public static bool CanStkUnitCodeChange = false;
        public static bool CanStkUnitNameChange = true;
        public static bool CanStkUnitSetCodeChange = false;
        public static bool CanStkUnitSetNameChange = true;
        public static bool CanMenuCodeChange = false;
        public static bool CanMenuNameChange = true;
        public static bool CanRoleCodeChange = false;
        public static bool CanRoleNameChange = true;
        public static bool CanPersonnelCodeChange = false;
        public static bool CanPersonnelNameChange = true;
        //public static bool Can???CodeChange = false;
        //public static bool Can???NameChange = true;
        //public static bool Can???CodeChange = false;
        //public static bool Can???NameChange = true;
        //public static bool Can???CodeChange = false;
        //public static bool Can???NameChange = true;
        //public static bool Can???CodeChange = false;
        //public static bool Can???NameChange = true;
        //public static bool Can???CodeChange = false;
        //public static bool Can???NameChange = true;
        //public static bool Can???CodeChange = false;
        //public static bool Can???NameChange = true;
        //public static bool Can???CodeChange = false;
        //public static bool Can???NameChange = true;
        //public static bool Can???CodeChange = false;
        //public static bool Can???NameChange = true;

    }
}
