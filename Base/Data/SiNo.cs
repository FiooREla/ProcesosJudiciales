using System;
using System.Collections.Generic;
using System.Data;

namespace Base.Data
{
    public class SiNo
    {
        public int ID { get; set; }
        public bool Logico { get; set; }
        public string Descripcion { get; set; }

        public static List<SiNo> Lista()
        {
            List<SiNo> datos = new List<SiNo>();
            datos.Add(new SiNo { ID = 1, Logico = true, Descripcion = "SI" });
            datos.Add(new SiNo { ID = 0, Logico = false, Descripcion = "NO" });
            return datos;
        }
    }
}