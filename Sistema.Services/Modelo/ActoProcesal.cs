using Sistema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Services.Modelo
{
    public class ActoProcesal
    {
        public string DescripcionInstancia { get; set; }
        public int IdActoPro { get; set; }
        public int IdExpediente { get; set; }
        public string Contenido { get; set; }
        public string Contenido1 { get; set; }
        public string IdNEWID { get; set; }
        public int IdExpedienteInstancia { get; set; }
        public string Codigo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaAvisoAlerta { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public int IdNotificacionTipoContenido { get; set; }
        public string EtapaProceso { get; set; }
        public Expediente Expediente { get; set; }
        public TipoContenido TipoContenido { get; set; }
        public List<ActoProcesalContenido> ActoProcesalContenido { get; set; }
        public int IdTipoContenido { get; set; }
    }
}
