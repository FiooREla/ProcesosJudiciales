using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Services.Modelo
{
    public class AutomapperConfig
    {

        public static MapperConfiguration ConfiguracionAutomapper() {


            MapperConfiguration configuracion = new MapperConfiguration(cfg => {

                cfg.CreateMap<ActoProcesal, Sistema.Model.ActoProcesal>();
                cfg.CreateMap<ActoProcesalContenido, Sistema.Model.ActoProcesalContenido>();
                cfg.CreateMap<Documento, Sistema.Model.Documento>();
                cfg.CreateMap<Expediente, Sistema.Model.Expediente>();



            });


            return configuracion;
        }


    }
}
