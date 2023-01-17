﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Services.Modelo
{
    public class viewExpedienteReport
    {
        public int IdExpediente { get; set; }
        public int IdExpediente2 { get; set; }
        public string Codigo { get; set; }
        public string Codigo2 { get; set; }
        public int IdTipoProceso { get; set; }
        public int IdTipoProceso2 { get; set; }
        public string DescripcionTipoProceso { get; set; }
        public string DescripcionTipoProceso2 { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaInicio2 { get; set; }
        public int IdDemandante { get; set; }
        public int IdDemandante2 { get; set; }
        public string NombreDemandante { get; set; }
        public string NombreDemandante2 { get; set; }
        public string NroDocumentoDemandante { get; set; }
        public string NroDocumentoDemandante2 { get; set; }
        public int IdDemandado { get; set; }
        public int IdDemandado2 { get; set; }
        public string NombreDemandado { get; set; }
        public string NombreDemandado2 { get; set; }
        public string DocumentoDemandado { get; set; }
        public string DocumentoDemandado2 { get; set; }
        public int IdClaseProceso { get; set; }
        public int IdClaseProceso2 { get; set; }
        public string DescripcionClaseProceso { get; set; }
        public string DescripcionClaseProceso2 { get; set; }
        public string SiglaClaseProceso { get; set; }
        public string SiglaClaseProceso2 { get; set; }
        public string Descripcion { get; set; }
        public string Descripcion2 { get; set; }
        public string Observacion { get; set; }
        public string Observacion2 { get; set; }
        public int IdAbogado { get; set; }
        public int IdAbogado2 { get; set; }
        public string NombreAbogado { get; set; }
        public string NombreAbogado2 { get; set; }
        public string DocumentoAbogado { get; set; }
        public string DocumentoAbogado2 { get; set; }
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
        public int IdExpedienteInstancia { get; set; }
        public int IdExpedienteInstancia2 { get; set; }
        public int IdInstancia { get; set; }
        public int IdInstancia2 { get; set; }
        public string DescripcionInstancia { get; set; }
        public string DescripcionInstancia2 { get; set; }
        public int IdActoPro { get; set; }
        public int IdActoPro2 { get; set; }
        public string CodigoActoProcesal { get; set; }
        public string CodigoActoProcesal2 { get; set; }
        public string ContenidoActoProcesal { get; set; }
        public string ContenidoActoProcesal2 { get; set; }
        public DateTime FechaRegistroActoPro { get; set; }
        public DateTime FechaRegistroActoPro2 { get; set; }
        public DateTime FechaAvisoAlertaActoPro { get; set; }
        public DateTime FechaAvisoAlertaActoPro2 { get; set; }
        public string NDemandantes { get; set; }
        public string NDemandantes2 { get; set; }
        public string NDemandados { get; set; }
        public string NDemandados2 { get; set; }
        public string TipoExpediente { get; set; }
        public string TipoExpediente2 { get; set; }
        public string MateriaArbitral { get; set; }
        public string MateriaArbitral2 { get; set; }
        public string Modalidad { get; set; }
        public string Modalidad2 { get; set; }
        public string SedeArbitral { get; set; }
        public string SedeArbitral2 { get; set; }
        public string DescripcionTipoArbitraje { get; set; }
        public string DescripcionTipoArbitraje2 { get; set; }
        public string TipoMonedaControversia { get; set; }
        public string TipoMonedaControversia2 { get; set; }
        public string NombreAsesorLegalPatrocinador { get; set; }
        public string NombreAsesorLegalPatrocinador2 { get; set; }
        public string TipoDocumento { get; set; }
        public string TipoDocumento2 { get; set; }
        public string SupervisorInterno { get; set; }
        public string SupervisorInterno2 { get; set; }
        public string EstadoProceso { get; set; }
        public string EstadoProceso2 { get; set; }
        public string ubicacion { get; set; }
        public string ubicacion2 { get; set; }
        public string CorreoParaNotificacion { get; set; }
        public string CorreoParaNotificacion2 { get; set; }
        public string ContratoOrigen { get; set; }
        public string ContratoOrigen2 { get; set; }
        public string FechaInstalacionTribText { get; set; }
        public string FechaInstalacionTribText2 { get; set; }
        public string CentroArbitral { get; set; }
        public string CentroArbitral2 { get; set; }
        public string SecretarioArbitral { get; set; }
        public string SecretarioArbitral2 { get; set; }
        public string ArbitroUnicoPresidente { get; set; }
        public string ArbitroUnicoPresidente2 { get; set; }
        public string ArbitroParteEntidad { get; set; }
        public string ArbitroParteEntidad2 { get; set; }
        public string ArbitroParteDemandante { get; set; }
        public string ArbitroParteDemandante2 { get; set; }
        public string LaudoFavor { get; set; }
        public string LaudoFavor2 { get; set; }
        public string Contingencia { get; set; }
        public string Contingencia2 { get; set; }
        public string JustificacionContingencia { get; set; }
        public string JustificacionContingencia2 { get; set; }
        public decimal MontoControversia { get; set; }
        public decimal MontoControversia2 { get; set; }
        public string TipoMonedaReconvencion { get; set; }
        public string TipoMonedaReconvencion2 { get; set; }
        public string MontoReconvencion { get; set; }
        public string MontoReconvencion2 { get; set; }
        public string TipoMonedaLaudado { get; set; }
        public string TipoMonedaLaudado2 { get; set; }
        public string MontoLaudado { get; set; }
        public string MontoLaudado2 { get; set; }
        public DateTime FechaEdicion { get; set; }
        public DateTime FechaEdicion2 { get; set; }

    }
}
