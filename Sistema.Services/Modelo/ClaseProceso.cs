using Sistema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Services.Modelo
{
    public class ClaseProceso
    {
        public int IdClaseProceso { get; set; }
        public int IdClaseProceso2 { get; set; }
        public string Descripcion { get; set; }
        public string Sigla { get; set; }
        public int MyProperty { get; set; }
        public List<Expediente> Expediente { get; set; }

    }
}
