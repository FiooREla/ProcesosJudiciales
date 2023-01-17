using Sistema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Services
{
    public class ModelosGeneralServices
    {
        private ContextoModelo CtxModelo;
        public ContextoModelo ObtenerTodosModelos()
        {
            try
            {
                using (CtxModelo = new ContextoModelo())
                {
                    return new ContextoModelo();
                }

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
