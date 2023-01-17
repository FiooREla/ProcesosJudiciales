using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Model
{
    public class TipoInternoPersona
    {
        public string TipoInterno { get; set; }
        public string TipoMostrar { get; set; }
        public string TipoPadre { get; set; }
        public string TipoHijo { get; set; }
        public bool MostrarHijos { get; set; }

        public static List<TipoInternoPersona> GLista()
        {
            List<TipoInternoPersona> lista = new List<TipoInternoPersona>();
            lista.Add(new TipoInternoPersona() { TipoInterno = "ODEMANDA", TipoMostrar = "Demandantes / Demandados", TipoPadre = null, TipoHijo = "INTERNO2", MostrarHijos = true });
            lista.Add(new TipoInternoPersona() { TipoInterno = "OASESORJURIDOCO", TipoMostrar = "Asesores Juridicos", TipoPadre = "INTERNO1", TipoHijo = null, MostrarHijos = false });
            lista.Add(new TipoInternoPersona() { TipoInterno = "OTRABAJADORJURIDOCO", TipoMostrar = "Trabajadores Judiciales", TipoPadre = "INTERNO1", TipoHijo = null, MostrarHijos = false }); // Es "Especialista Judicial"
            lista.Add(new TipoInternoPersona() { TipoInterno = "ABOGADOS", TipoMostrar = "Abogados", TipoPadre = "INTERNO1", TipoHijo = null, MostrarHijos = false });
            lista.Add(new TipoInternoPersona() { TipoInterno = "SUPERVISORINTERNO", TipoMostrar = "Supervisor Interno", TipoPadre = "INTERNO1", TipoHijo = null, MostrarHijos = false });
            lista.Add(new TipoInternoPersona() { TipoInterno = "CONTRATOS", TipoMostrar = "Contratos", TipoPadre = "INTERNO1", TipoHijo = null, MostrarHijos = false });
            return lista;
        }
    }

    public class TipoPersona
    {
        public string Descripcion { get; set; }

        public static List<TipoPersona> GLista()
        {
            List<TipoPersona> lista = new List<TipoPersona>();
            lista.Add(new TipoPersona() { Descripcion = "NATURAL" });
            lista.Add(new TipoPersona() { Descripcion = "JURIDICA" });
            return lista;
        }
    }
}
