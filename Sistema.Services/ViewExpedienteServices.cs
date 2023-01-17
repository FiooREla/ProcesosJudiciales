using AutoMapper;
using Sistema.Services.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Services
{
    public class ViewExpedienteServices
    {
        private Sistema.Model.ContextoModelo CtxModelo;
        public ViewExpedienteServices()
        {
            CtxModelo = new Sistema.Model.ContextoModelo();
        }
        public List<viewExpediente> BuscarFechaExpediente(DateTime ddFechaInicio, DateTime ddFechaFin)
        {
            try
            {
                using (CtxModelo = new Sistema.Model.ContextoModelo())
                {

                    List<Sistema.Model.viewExpediente> lExpedienteFech = CtxModelo.viewExpediente.Where(x => x.FechaInicio >= ddFechaInicio && x.FechaInicio <= ddFechaFin && x.TipoExpediente == "EXPEDIENTEARBITRAL").ToList();
                    List<viewExpediente> listaEntidad = Mapper.Map<List<Sistema.Model.viewExpediente>, List<viewExpediente>>(lExpedienteFech);
                    return listaEntidad;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
