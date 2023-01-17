using System.Collections.Generic;

namespace BaseR
{
    public class TipoReporte
    {
        public string ID { get; set; }
        public string Descripcion { get; set; }

        public static List<TipoReporte> Lista()
        {
            var items = new List<TipoReporte>();
            items.Add(new TipoReporte {ID = "G", Descripcion = "Grid"});
            items.Add(new TipoReporte {ID = "P", Descripcion = "PivotGrid"});
            return items;
        }
    }
}