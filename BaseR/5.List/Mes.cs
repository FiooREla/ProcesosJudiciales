using System.Collections.Generic;
using System.Linq;

namespace BaseR.Lists
{
    public class Mes
    {
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public string Corto { get; set; }

        public static List<Mes> Lista()
        {
            var datos = new List<Mes>();
            datos.Add(new Mes {Numero = 1, Nombre = "Enero", Corto = "ENE"});
            datos.Add(new Mes {Numero = 2, Nombre = "Febrero", Corto = "FEB"});
            datos.Add(new Mes {Numero = 3, Nombre = "Marzo", Corto = "MAR"});
            datos.Add(new Mes {Numero = 4, Nombre = "Abril", Corto = "ABR"});
            datos.Add(new Mes {Numero = 5, Nombre = "Mayo", Corto = "MAY"});
            datos.Add(new Mes {Numero = 6, Nombre = "Junio", Corto = "JUN"});
            datos.Add(new Mes {Numero = 7, Nombre = "Julio", Corto = "JUL"});
            datos.Add(new Mes {Numero = 8, Nombre = "Agosto", Corto = "AGO"});
            datos.Add(new Mes {Numero = 9, Nombre = "Setiembre", Corto = "SET"});
            datos.Add(new Mes {Numero = 10, Nombre = "Octubre", Corto = "OCT"});
            datos.Add(new Mes {Numero = 11, Nombre = "Noviembre", Corto = "NOV"});
            datos.Add(new Mes {Numero = 12, Nombre = "Diciembre", Corto = "DIC"});
            return datos;
        }

        public static Mes GMes(int numeroMes)
        {
            var mes = Lista().FirstOrDefault(x => x.Numero == numeroMes);
            return mes;
        }

        public static string GCortoMes(int numeroMes)
        {
            var mes = Lista().FirstOrDefault(x => x.Numero == numeroMes);
            return mes.Corto;
        }
    }
}