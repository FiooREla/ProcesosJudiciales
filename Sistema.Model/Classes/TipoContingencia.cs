using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Model
{

    public class TipoContingencia
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }

        public static List<TipoContingencia> GLista()
        {
            List<TipoContingencia> lista = new List<TipoContingencia>();
            lista.Add(new TipoContingencia() { ID = 1, Descripcion = "Probable" });
            lista.Add(new TipoContingencia() { ID = 2, Descripcion = "Posible" });
            lista.Add(new TipoContingencia() { ID = 3, Descripcion = "Remoto" });
            return lista;
        }
    }
}
