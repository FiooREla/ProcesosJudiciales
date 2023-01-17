using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Services.Modelo
{
    public class OrganoExpedientePersona
    {
        public int IdOrganoPersona { get; set; }
        public int IdOrganoPersona2 { get; set; }
        public int IdOrgano { get; set; }
        public int IdOrgano2 { get; set; }
        public int IdJuez { get; set; }
        public int IdJuez2 { get; set; }
        public int IdSecretario { get; set; }
        public int IdSecretario2 { get; set; }
        public int IdExpediente { get; set; }
        public int IdExpediente2 { get; set; }
        public int IdDemandante { get; set; }
        public int IdDemandante2 { get; set; }
        public int IdDemandado { get; set; }
        public int IdDemandado2 { get; set; }
        public int IdOrganoSecretario { get; set; }
        public int IdOrganoSecretario2 { get; set; }
        public int IdExpedienteDemandado { get; set; }
        public int IdExpedienteDemandado2 { get; set; }
        public PersonaEmpresa DemandanteExpediente { get; set; }
        public PersonaEmpresa DemandadoExpediente { get; set; }

    }
}
