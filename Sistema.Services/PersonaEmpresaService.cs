using Sistema.Services.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Services
{
    public class PersonaEmpresaService
    {
        private Sistema.Model.ContextoModelo CtxModelo;
        private Expediente expediente = new Expediente();
        public int NroDiasCalc
        {
            get
            {

                if (expediente.FechaProximaAudiencia == null)
                    return 0;
                else
                {
                    DateTime dDb = Convert.ToDateTime(expediente.FechaProximaAudiencia.Value.Date);
                    DateTime dNow = DateTime.Now.Date;
                    if (expediente.PersonaEmpresa != null)
                        expediente.TipoNotificacion = expediente.PersonaEmpresa.Email.ToString();
                    return (int)(dDb - dNow).TotalDays;

                }


            }
        }

    }
}
