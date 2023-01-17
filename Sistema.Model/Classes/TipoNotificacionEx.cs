using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Model
{

    public class TipoNotificacionEx
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }

        public static List<TipoNotificacionEx> GLista()
        {
            List<TipoNotificacionEx> lista = new List<TipoNotificacionEx>();
            lista.Add(new TipoNotificacionEx() { ID = 1, Descripcion = "Físico" });
            lista.Add(new TipoNotificacionEx() { ID = 2, Descripcion = "Casilla Electrónica" });
            return lista;
        }
    }
}
