using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Base.Data
{
    public class Mes
    {
        public int Numero { get; set; }
        public string Nombre { get; set; }

        public static List<Mes> Lista()
        {
            List<Mes> datos = new List<Mes>();
            datos.Add(new Mes { Numero = 1, Nombre = "Enero" });
            datos.Add(new Mes { Numero = 2, Nombre = "Febrero" });
            datos.Add(new Mes { Numero = 3, Nombre = "Marzo" });
            datos.Add(new Mes { Numero = 4, Nombre = "Abril" });
            datos.Add(new Mes { Numero = 5, Nombre = "Mayo" });
            datos.Add(new Mes { Numero = 6, Nombre = "Junio" });
            datos.Add(new Mes { Numero = 7, Nombre = "Julio" });
            datos.Add(new Mes { Numero = 8, Nombre = "Agosto" });
            datos.Add(new Mes { Numero = 9, Nombre = "Setiembre" });
            datos.Add(new Mes { Numero = 10, Nombre = "Octubre" });
            datos.Add(new Mes { Numero = 11, Nombre = "Noviembre" });
            datos.Add(new Mes { Numero = 12, Nombre = "Diciembre" });
            return datos;
        }

        public static Mes GMes(int numeroMes)
        {
            Mes mes = Mes.Lista().FirstOrDefault(x => x.Numero == numeroMes);
            return mes;
        }
    }
}