using System.Collections.Generic;

namespace BaseR.Lists
{
    public class SiNo
    {
        public int ID { get; set; }
        public bool Logico { get; set; }
        public bool? LogicoNull { get; set; }
        public string Descripcion { get; set; }

        public static List<SiNo> Lista()
        {
            var datos = new List<SiNo>();
            datos.Add(new SiNo {ID = 1, Logico = true, Descripcion = "SI"});
            datos.Add(new SiNo {ID = 0, Logico = false, Descripcion = "NO"});
            return datos;
        }

        public static List<SiNo> ListaTodos()
        {
            var datos = new List<SiNo>();
            datos.Add(new SiNo {ID = -1, LogicoNull = null, Descripcion = "Todos"});
            datos.Add(new SiNo {ID = 1, LogicoNull = true, Descripcion = "SI"});
            datos.Add(new SiNo {ID = 0, LogicoNull = false, Descripcion = "NO"});
            return datos;
        }

        public static List<SiNo> Lista_Kardex()
        {
            var datos = new List<SiNo>();
            datos.Add(new SiNo {ID = 1, Logico = true, Descripcion = "SALDO FINAL"});
            datos.Add(new SiNo {ID = 0, Logico = false, Descripcion = "SIN SALD"});
            return datos;
        }

        public static List<SiNo> ListaTodos_Kardex()
        {
            var datos = new List<SiNo>();
            datos.Add(new SiNo {ID = -1, LogicoNull = null, Descripcion = "Todos"});
            datos.Add(new SiNo {ID = 1, LogicoNull = true, Descripcion = "SI"});
            datos.Add(new SiNo {ID = 0, LogicoNull = false, Descripcion = "NO"});
            return datos;
        }

        public static List<SiNo> ListaParcialTotal()
        {
            var datos = new List<SiNo>();
            datos.Add(new SiNo {ID = 1, Logico = true, Descripcion = "PARCIAL"});
            datos.Add(new SiNo {ID = 0, Logico = false, Descripcion = "TOTAL"});
            return datos;
        }
    }
}