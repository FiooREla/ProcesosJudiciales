using System.Collections.Generic;

namespace BaseR.Lists
{
    public class Año
    {
        public int Numero { get; set; }

        public static List<Año> Lista()
        {
            var datos = new List<Año>();
            datos.Add(new Año { Numero = 2013 });
            datos.Add(new Año { Numero = 2014 });
            datos.Add(new Año { Numero = 2015 });
            datos.Add(new Año { Numero = 2016 });
            datos.Add(new Año { Numero = 2017 });
            datos.Add(new Año { Numero = 2018 });
            datos.Add(new Año { Numero = 2019 });
            datos.Add(new Año { Numero = 2020 });
            return datos;
        }
    }
}