using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Model;


namespace Sistema.Query
{
  public  static class QExpediente
    {

      public static Expediente GlExpediente(ContextoModelo ctxModelo,int ID )
      {
          return ctxModelo.Expediente.Where(x=>x.IdExpediente==ID).FirstOrDefault();
      }

      public static List<viewExpedienteInstancia>  GlExpedienteInstancias(ContextoModelo ctxModelo, int ID)
      {
          return ctxModelo.viewExpedienteInstancia.Where(x => x.IdExpediente == ID).ToList();
      }

    }
}
