


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Model
{

    public class TipoUbicacion
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }

        public static List<TipoUbicacion> GLista()
        {
            List<TipoUbicacion> lista = new List<TipoUbicacion>();
            lista.Add(new TipoUbicacion() { ID = 1, Descripcion = "Nacional" });
            lista.Add(new TipoUbicacion() { ID = 2, Descripcion = "Internacional" });
            lista.Add(new TipoUbicacion() { ID = 3, Descripcion = "Otro" });
            return lista;
        }
    }
}
