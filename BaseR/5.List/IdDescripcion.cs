using System.Collections.Generic;

namespace BaseR.Lists
{
    public class IdDescripcion
    {
        public string ID { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Img { get; set; }
        public string Parametros { get; set; }
        public bool Seleccion { get; set; }
        public List<IdDescripcion> Items { get; set; }
    }
}