using Sistema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Services.Modelo
{
    public class ActoProcesalContenido
    {
        public int IdActoProCont { get; set; }
        public int IdActoPro { get; set; }
        public int IdTipoContenido { get; set; }
        public int IdTipoContenido2 { get; set; }
        public TipoContenido TipoContenido { get; set; }
        public ActoProcesal actoProcesal { get; set; }


    }
}
