using Sistema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Services
{
    public class OrganoJudicialService
    {
        private ContextoModelo CtxModelo;
        public List<OrganoJudicial> ObtenerOrganoJudicial()
        {
            try
            {
                using (CtxModelo = new ContextoModelo())
                {
                    List<OrganoJudicial> organoJudicial = CtxModelo.OrganoJudicial.ToList();
                    return organoJudicial;
                }

            }
            catch (Exception)
            {
                return new List<OrganoJudicial>();
            }
        }
    }
}
