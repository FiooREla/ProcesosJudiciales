using AutoMapper;
using Sistema.Services.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Services
{
    public class ActoProcesalService
    {
        private Sistema.Model.ContextoModelo CtxModelo;
        
        public ActoProcesal BuscarActoProcesalPorId(int codigoExpediente)
        {
            try
            {
                using (CtxModelo = new Sistema.Model.ContextoModelo())
                {
                    Sistema.Model.ActoProcesal oProcesal = CtxModelo.ActoProcesal.Where(x => x.IdExpediente == codigoExpediente).OrderByDescending(x => x.IdActoPro).FirstOrDefault();
                    ActoProcesal actoProcesalBuscado = Mapper.Map<Sistema.Model.ActoProcesal, ActoProcesal>(oProcesal);
                    return actoProcesalBuscado;
                }

            }
            catch (Exception)
            {
                ActoProcesal oProcesal = null;
                return oProcesal;
            }

        }
    }
}
