using Sistema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Services.Modelo
{
    public class Expediente
    {
        public int IdExpediente { get; set; }
        public int IdExpediente2 { get; set; }
        public string Codigo { get; set; }
        public string Codigo2 { get; set; }
        public int IdTipoProceso { get; set; }
        public int IdTipoProceso2 { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaInicio2 { get; set; }
        public int IdDemandante { get; set; }
        public int IdDemandante2 { get; set; }
        public int IdDemandado { get; set; }
        public int IdDemandado2 { get; set; }
        public int IdClaseProceso { get; set; }
        public int IdClaseProceso2 { get; set; }
        public string NDemandados { get; set; }
        public string Descripcion { get; set; }
        public string Descripcion2 { get; set; }
        public string Observacion { get; set; }
        public string Observacion2 { get; set; }
        public int IdAbogado { get; set; }
        public int IdAbogado2 { get; set; }
        public int IdExpedientePadre { get; set; }
        public int IdExpedientePadre2 { get; set; }
        public string IdNEWID { get; set; }
        public string IdNEWID2 { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public DateTime FechaMovimiento2 { get; set; }
        public int NroInstancia { get; set; }
        public int NroInstancia2 { get; set; }
        public decimal MontoSoles { get; set; }
        public decimal MontoSoles2 { get; set; }
        public decimal MontoDolares { get; set; }
        public decimal MontoDolares2 { get; set; }
        public string NDemandantes { get; set; }
        public string NDemandantes2 { get; set; }
        public int IdSupervisorInterno { get; set; }
        public int IdContrato { get; set; }
        public int IdContrato2 { get; set; }
        public int IdNotificacionTipoContenido { get; set; }
        public int IdNotificacionTipoContenido2 { get; set; }
        public int IdAbogadoPatrocinante { get; set; }
        public int IdAbogadoPatrocinante2 { get; set; }
        public Boolean Archivado { get; set; }
        public Boolean Archivado2 { get; set; }
        public string TipoNotificacion { get; set; }
        public string TipoNotificacion2 { get; set; }
        public string NroCasillaNotificacion { get; set; }
        public string NroCasillaNotificacion2 { get; set; }
        public string TipoContingencia { get; set; }
        public string TipoContingencia2 { get; set; }
        public DateTime FechaProximaAudiencia { get; set; }
        public DateTime FechaProximaAudiencia2 { get; set; }
        public DateTime HoraProximaAudiencia { get; set; }
        public DateTime HoraProximaAudiencia2 { get; set; }
        public string LugarProximaAudiencia { get; set; }
        public string LugarProximaAudiencia2 { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime FechaVencimiento2 { get; set; }
        public decimal MontoProbable { get; set; }
        public decimal MontoProbable2 { get; set; }
        public int IdEstadoActual { get; set; }
        public int IdEstadoActual2 { get; set; }
        public string TipoNotificacionMail { get; set; }
        public string TipoNotificacionMail2 { get; set; }
        public int NroDiasNotificacion { get; set; }
        public int NroDiasNotificacion2 { get; set; }
        public int NroDiasNotificacionRest { get; set; }
        public int NroDiasNotificacionRest2 { get; set; }
        public int IdSupervisorINternoRela { get; set; }
        public int IdSupervisorINternoRela2 { get; set; }
        public string TipoExpediente { get; set; }
        public string TipoExpediente2 { get; set; }
        public string TercerArbitro { get; set; }
        public string TercerArbitro2 { get; set; }
        public string DescripcionContrato { get; set; }
        public string DescripcionContrato2 { get; set; }
        public string DescripcionEstadoActual { get; set; }
        public string DescripcionEstadoActual2 { get; set; }
        public string DescripcionTipoArbitraje { get; set; }
        public string DescripcionTipoArbitraje2 { get; set; }
        public int IdTipoContenidadMateria { get; set; }
        public int IdTipoContenidadMateria2 { get; set; }
        public int DescripcionTipoContenidadMateria { get; set; }
        public int DescripcionTipoContenidadMateria2 { get; set; }
        public string CorreoParaNotificacion { get; set; }
        public string CorreoParaNotificacion2 { get; set; }
        public string TipoDocumento { get; set; }
        public string TipoDocumento2 { get; set; }
        public string Modalidad { get; set; }
        public string Modalidad2 { get; set; }
        public string ubicacion { get; set; }
        public string ubicacion2 { get; set; }
        public DateTime FechaInstalacionTrib { get; set; }
        public DateTime FechaInstalacionTrib2 { get; set; }
        public string TipoMonedaControversia { get; set; }
        public string TipoMonedaControversia2 { get; set; }
        public string MontoControversia { get; set; }
        public string MontoControversia2 { get; set; }
        public string TipoMonedaReconvencion { get; set; }
        public string TipoMonedaReconvencion2 { get; set; }
        public string MontoReconvencion { get; set; }
        public string MontoReconvencion2 { get; set; }
        public string TipoMonedaLaudado { get; set; }
        public string TipoMonedaLaudado2 { get; set; }
        public string MontoLaudado { get; set; }
        public string MontoLaudado2 { get; set; }
        public int IdSedeArbitral { get; set; }
        public int IdSedeArbitral2 { get; set; }
        public string LaudoFavor { get; set; }
        public string LaudoFavor2 { get; set; }
        public string JustificacionContingencia { get; set; }
        public string JustificacionContingencia2 { get; set; }
        public string SecretarioArbitral { get; set; }
        public string SecretarioArbitral2 { get; set; }
        public string UsuarioCrea { get; set; }
        public string UsuarioCrea2 { get; set; }
        public string UsuarioModifica { get; set; }
        public string UsuarioModifica2 { get; set; }
        public string FechaInstalacionTribText { get; set; }
        public string FechaInstalacionTribText2 { get; set; }
        public DateTime FechaEdicion { get; set; }
        public DateTime FechaEdicion2 { get; set; }
        public List<ActoProcesal> ActoProcesal { get; set; }
        public ClaseProceso ClaseProceso { get; set; }
        public List<Expediente> ListaExpediente { get; set; }
        public Expediente ExpedienteGeneral { get; set; }
        public TipoProceso TipoProceso { get; set; }
        public List<ExpedienteInstancia> ListaExpedienteInstancia { get; set; }
        public List<OrganoExpedientePersona> ListaOrganoExpedienteDemandante { get; set; }
        public List<OrganoExpedientePersona> ListaOrganoExpedienteDemandado { get; set; }
        public TipoContenido TipoContenido { get; set; }
        public List<ExpedienteAsesorLegal> ListaExpedienteAsesorLegal { get; set; }
        public PersonaEmpresa PersonaEmpresa { get; set; }


    }
}
