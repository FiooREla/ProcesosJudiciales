using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects;
using System.Data.Objects.DataClasses;

namespace Sistema.Model
{    
    public partial class Expediente
    {

        public int NroDiasCalc
        {
            get
            {
               
                if(FechaProximaAudiencia==null)
                    return 0;
                else
                {
                    DateTime dDb = Convert.ToDateTime(FechaProximaAudiencia.Value.Date);
                    DateTime dNow = DateTime.Now.Date;
                    if (PersonaEmpresa != null)
                        TipoNotificacion = PersonaEmpresa.Email.ToString();
                    return (int) (dDb - dNow).TotalDays;

                }
                

            }
        }
    }

   
}
