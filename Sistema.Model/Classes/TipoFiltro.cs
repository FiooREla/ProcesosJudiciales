using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Model
{

    public class TipoFiltro
    {
        public string IDTipo { get; set; }
        public string Descripcion { get; set; }

        public static List<TipoFiltro> GLista()
        {
            List<TipoFiltro> lista = new List<TipoFiltro>();
            lista.Add(new TipoFiltro() { IDTipo = "ODEMANDA", Descripcion = "Personas Naturales" });
            lista.Add(new TipoFiltro() { IDTipo = "ODEMANDA", Descripcion = "Personas Jurídicas" });

            lista.Add(new TipoFiltro() { IDTipo = "OASESORJURIDOCO", Descripcion = "Estudios de Abogados" });

            lista.Add(new TipoFiltro() { IDTipo = "OTRABAJADORJURIDOCO", Descripcion = "Jueces" });
            lista.Add(new TipoFiltro() { IDTipo = "OTRABAJADORJURIDOCO", Descripcion = "Secretarios" });
            lista.Add(new TipoFiltro() { IDTipo = "OTRABAJADORJURIDOCO", Descripcion = "Fiscales" });

            lista.Add(new TipoFiltro() { IDTipo = "ABOGADOS", Descripcion = "Abogados" });

            lista.Add(new TipoFiltro() { IDTipo = "SUPERVISORINTERNO", Descripcion = "Supervisor Interno" });

            lista.Add(new TipoFiltro() { IDTipo = "CONTRATOS", Descripcion = "Contratos" });




            return lista;
        }
    }
}
