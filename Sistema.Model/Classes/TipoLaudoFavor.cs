


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Model
{

    public class TipoLaudoFavor
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }

        public static List<TipoLaudoFavor> GLista()
        {
            List<TipoLaudoFavor> lista = new List<TipoLaudoFavor>();
            lista.Add(new TipoLaudoFavor() { ID = 1, Descripcion = "Demandado" });
            lista.Add(new TipoLaudoFavor() { ID = 2, Descripcion = "Demandante" });
            return lista;
        }
    }
}
