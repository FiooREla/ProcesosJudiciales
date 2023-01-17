
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Model
{

    public class TipoModalidad
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }

        public static List<TipoModalidad> GLista()
        {
            List<TipoModalidad> lista = new List<TipoModalidad>();
            lista.Add(new TipoModalidad() { ID = 1, Descripcion = "Ad Hod" });
            lista.Add(new TipoModalidad() { ID = 2, Descripcion = "Institucional" });
            lista.Add(new TipoModalidad() { ID = 3, Descripcion = "Otro" });
            return lista;
        }
    }
}
