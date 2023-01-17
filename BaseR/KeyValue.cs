using System;

namespace BaseR
{
    public class ClsKeyValue
    {
        public string ID { get; set; }
        public string Descripcion { get; set; }
        public string Agrupacion { get; set; }
        public string Agrupacion2 { get; set; }
        public string Agrupacion3 { get; set; }
        public string Agrupacion4 { get; set; }
        public string HCE_Descripcion { get; set; }
        public string HCE_Descripcion2 { get; set; }
        public string HCE_Descripcion3 { get; set; }
        public string HCE_Descripcion4 { get; set; }
        public bool HCE_EsExterno { get; set; }

        public object HCE_RegistroDB { get; set; }

        public DateTime HCE_FECHA { get; set; }
    }
}