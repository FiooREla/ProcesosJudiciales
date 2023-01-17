using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Services.Modelo
{
    public class PersonaEmpresa
    {
        public int IdPersonaEmpresa { get; set; }
        public int IdPersonaEmpresa2 { get; set; }
        public string Nombre { get; set; }
        public string Nombre2 { get; set; }
        public string Documento { get; set; }
        public string Documento2 { get; set; }
        public string Direccion { get; set; }
        public string Direccion2 { get; set; }
        public int IdLocalidad { get; set; }
        public int IdLocalidad2 { get; set; }
        public string Telefono { get; set; }
        public string Telefono2 { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public int IdEmpresa { get; set; }
        public int IdEmpresa2 { get; set; }
        public string TipoInterno { get; set; }
        public string TipoInterno2 { get; set; }
        public string TipoFiltro { get; set; }
        public string TipoFiltro2 { get; set; }
        public string Descripcion { get; set; }
        public string Descripcion2 { get; set; }
        public DateTime FechaIncio { get; set; }
        public DateTime FechaIncio2 { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaFin2 { get; set; }
        public string RepresentanteLegal { get; set; }
        public string RepresentanteLegal2 { get; set; }
        public string RepresentanteLegalNombre { get; set; }
        public string RepresentanteLegalNombre2 { get; set; }
        public string RepresentanteLegalDNI { get; set; }
        public string RepresentanteLegalDNI2 { get; set; }

    }
}
