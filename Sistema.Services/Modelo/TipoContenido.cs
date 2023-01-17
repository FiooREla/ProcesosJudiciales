using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Services.Modelo
{
    public class TipoContenido
    {
        public int IdTipoContenido { get; set; }
        public int IdTipoContenido2 { get; set; }
        public string Descripcion { get; set; }
        public string Descripcion2 { get; set; }
        public string Abreviado { get; set; }
        public string Abreviado2 { get; set; }
        public string Titulo { get; set; }
        public string Titulo2 { get; set; }
        public int NroDias { get; set; }
        public int NroDias2 { get; set; }
        public string TipoInterno { get; set; }
        public string TipoInterno2 { get; set; }
        public List<ActoProcesalContenido> ActoProcesalContenido { get; set; }
        public List<ActoProcesal> ActoProcesal { get; set; }
        public List<Expediente> Expediente { get; set; }



    }
}
