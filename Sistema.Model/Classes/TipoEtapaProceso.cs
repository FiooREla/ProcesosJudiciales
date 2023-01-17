


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Model
{

    public class TipoEtapaProceso
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }

        public static List<TipoEtapaProceso> GLista()
        {
            List<TipoEtapaProceso> lista = new List<TipoEtapaProceso>();
            lista.Add(new TipoEtapaProceso() { ID = 1, Descripcion = "Postulatoria" });
            lista.Add(new TipoEtapaProceso() { ID = 2, Descripcion = "De Implementación" });
            lista.Add(new TipoEtapaProceso() { ID = 3, Descripcion = "Probatoria" });
            lista.Add(new TipoEtapaProceso() { ID = 3, Descripcion = "Decisoria" });
            lista.Add(new TipoEtapaProceso() { ID = 3, Descripcion = "Concluido" });
            lista.Add(new TipoEtapaProceso() { ID = 3, Descripcion = "Otro" });

            return lista;
        }
    }
}
