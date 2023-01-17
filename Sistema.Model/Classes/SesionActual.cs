using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Model;


namespace Sistema.Model.Classes
{
    public class SesionActual
    {
        public static Usuario Usuario { get; set; }
        public static List<Derecho> ListDerechos { get; set; }

    }
}
