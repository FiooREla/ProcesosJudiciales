using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Services.Modelo
{
    public class Localidad
    {
        public int IdLocalidad { get; set; }
        public int IdLocalidad2 { get; set; }
        public string Descripcion { get; set; }
        public string Descripcion2 { get; set; }
        public int IdLocalidadPadre { get; set; }
        public int IdLocalidadPadre2 { get; set; }

    }
}
