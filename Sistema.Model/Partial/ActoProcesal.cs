using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects;
using System.Data.Objects.DataClasses;

namespace Sistema.Model
{
    public partial class ActoProcesal
    {
        public string DescripcionInstancia
        {
            get
            {
                
                if (this.IdExpedienteInstancia < 1)
                {
                    return "";
                }
                else
                {

                    return "";
                    //ContextoModelo ctx = new ContextoModelo();
                    //return ctx.ExpedienteInstancia.Where(i => i.IdExpedienteInstancia == IdExpedienteInstancia).FirstOrDefault().InstanciaJudicial.Descripcion;

                }

            }
        }
    }


}
