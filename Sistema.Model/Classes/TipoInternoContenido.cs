using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Model
{
    public class TipoInternoContenido
    {
        public string TipoInterno { get; set; }
        public string TipoMostrar { get; set; }
        public string TipoPadre { get; set; }
       

        public static List<TipoInternoContenido> GLista()
        {
            List<TipoInternoContenido> lista = new List<TipoInternoContenido>();
            lista.Add(new TipoInternoContenido() { TipoInterno = "TIPOCONTENIDO", TipoMostrar = "Lista Tags", TipoPadre = null, });
            lista.Add(new TipoInternoContenido() { TipoInterno = "NOTIFICACION", TipoMostrar = "Notificaciones", TipoPadre = null});
            lista.Add(new TipoInternoContenido() { TipoInterno = "VARIABLES", TipoMostrar = "Variables de Sistema", TipoPadre = null });
            lista.Add(new TipoInternoContenido() { TipoInterno = "ESTADOSACTUALES", TipoMostrar = "Estados Actuales", TipoPadre = null });
            lista.Add(new TipoInternoContenido() { TipoInterno = "MATERIAEXARBITRAL", TipoMostrar = "Materia Expediente Arbitral", TipoPadre = null });
            lista.Add(new TipoInternoContenido() { TipoInterno = "TIPOACTOPROCESALARB", TipoMostrar = "Estado Actual - Acto Procesal", TipoPadre = null });
            return lista;
        }
    }

}
