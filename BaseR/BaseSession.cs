using BaseR;
using System;
using System.Linq;

namespace BaseR
{
    public class BaseSession
    {
        public static string PC_Name { get; set; }
        public static bool PC_EsDeveloper { get; set; }
        public static bool PC_EsSTEVE = false;

        public static bool APP_ShowLogin { get; set; }
        public static string APP_Version { get; set; }

        public static string User_ID { get; set; }
        public static int User_IDEntidad { get; set; }
        public static bool User_EsLaboratorio { get; set; }
        public static bool User_EsConvenio { get; set; }
        public static bool User_EsMedico { get; set; }
        public static bool User_EsAnestesiologo { get; set; }
        public static bool User_EsEnfermera { get; set; }
        public static bool User_EsAdmin { get; set; }

        public static string BD_Server { get; set; }
        public static string BD_User { get; set; }
        public static string BD_Password { get; set; }

        public static object FBaseLista { get; set; }

        public static void FnInit_BaseSession(string _BD_Server, string _BD_User, string _BD_Password)
        {
            BaseSession.BD_Server = _BD_Server;
            BaseSession.BD_User = _BD_User;
            BaseSession.BD_Password = _BD_Password;
        }

        public static string SQLConnection => "Data Source=" + BD_Server + ";Initial Catalog=SIG-PJ;User ID=" + BD_User + ";Password=" + BD_Password + ";";
    }
}