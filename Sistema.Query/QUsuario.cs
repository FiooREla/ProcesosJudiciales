using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Model;


namespace Sistema.Query
{
    public static class QUsuario
    {

        public static Usuario  GUsuarioLogin(ContextoModelo ctxModelo, string usuario,string password )
      {
          return ctxModelo.Usuario.Where(x => x.Codigo == usuario && x.Clave==password).FirstOrDefault();
      }

        public static List<Derecho> GlDerechos(ContextoModelo ctxModelo, int idUsuario)
        {
            return ctxModelo.Derecho.Where(x => x.IdUsuario == idUsuario).ToList();
        }
    }
}
