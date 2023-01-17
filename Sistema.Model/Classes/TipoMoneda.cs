


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Model
{

    public class TipoMoneda
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }

        public static List<TipoMoneda> GLista()
        {
            List<TipoMoneda> lista = new List<TipoMoneda>();
            lista.Add(new TipoMoneda() { ID = 1, Descripcion = "SOLES" });
            lista.Add(new TipoMoneda() { ID = 2, Descripcion = "DOLARES" });
            return lista;
        }
    }
}
