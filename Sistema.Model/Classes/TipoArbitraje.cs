using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Model
{

    public class TipoArbitraje
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }

        public static List<TipoArbitraje> GLista()
        {
            List<TipoArbitraje> lista = new List<TipoArbitraje>();
            lista.Add(new TipoArbitraje() { ID = 1, Descripcion = "Derecho" });
            lista.Add(new TipoArbitraje() { ID = 2, Descripcion = "Institucional" });
            lista.Add(new TipoArbitraje() { ID = 3, Descripcion = "Otro" });
            return lista;
        }
    }
}
