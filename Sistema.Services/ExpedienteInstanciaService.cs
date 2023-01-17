using Sistema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Services
{
    public class ExpedienteInstanciaService
    {

        private ContextoModelo CtxModelo;
        public ExpedienteInstanciaService()
        {

        }

     
        public List<viewExpedienteInstancia> BuscarInstancias(int idExpediente ) {

            try
            {
                using (CtxModelo = new ContextoModelo())
                {
                    return CtxModelo.viewExpedienteInstancia.Where(x => x.IdExpediente == idExpediente).ToList();
                }
                
            }
            catch (Exception ex )
            {

                return null;
            }
        
        }
    }
}
