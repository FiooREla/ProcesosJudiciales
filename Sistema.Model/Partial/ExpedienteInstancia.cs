using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects;
using System.Data.Objects.DataClasses;

namespace Sistema.Model
{    
    public partial class ExpedienteInstancia
    {
        private string instanciaTexto="";
        public string organoTexto="";

        public string InstanciaTexto
        {
            get
            {
                if (instanciaTexto != "") return instanciaTexto;

                if (InstanciaJudicial==null)
                    
                    return instanciaTexto= "";
                else
                {
                    
                    return instanciaTexto=InstanciaJudicial.Descripcion;
                }
                

            }
            set { instanciaTexto = value; }
        }

        public string OrganoTexto
        {
            get
            {
                if (organoTexto != "") return organoTexto;
                if (OrganoJudicial == null)
                    return organoTexto= "";
                else
                {

                    return  organoTexto =OrganoJudicial.Descripcion;
                }
               
            }
            set { organoTexto = value; }
        }
    }

   
}
