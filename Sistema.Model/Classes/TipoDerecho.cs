using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Model
{

    public class TipoDerecho
    {
        public Boolean ID { get; set; }
        public string Descripcion { get; set; }

        public static List<TipoDerecho> GLista()
        {
            List<TipoDerecho> lista = new List<TipoDerecho>();
            lista.Add(new TipoDerecho() { ID = true, Descripcion = "Control Total" });
            lista.Add(new TipoDerecho() { ID = false, Descripcion = "Solo Lectura" });
            return lista;
        }
    }
}
