using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Model
{

    public class TipoCentroArbitral
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }

        public static List<TipoCentroArbitral> GLista()
        {
            List<TipoCentroArbitral> lista = new List<TipoCentroArbitral>();
            lista.Add(new TipoCentroArbitral() { ID = 1, Descripcion = "PUCP" });
            lista.Add(new TipoCentroArbitral() { ID = 2, Descripcion = "Cámara de Comercio" });
            lista.Add(new TipoCentroArbitral() { ID = 3, Descripcion = "Otro" });
            return lista;
        }
    }
}
