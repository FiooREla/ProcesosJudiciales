using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.UI.Usuario
{
    public class clsData
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

        public static List<clsData> Lista()
        {
            List<clsData> lista = new List<clsData>();
            lista.Add(new clsData() { ID = 1, Nombre = "Nombre" });
            lista.Add(new clsData() { ID = 3, Nombre = "Nombre 2" });
            return lista;
        }
    }
}
