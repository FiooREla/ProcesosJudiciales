USE [SIG-PJ]
GO

/****** Object:  View [Judicial].[viewExpediente]    Script Date: 17/05/2019 13:21:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [Judicial].[viewExpediente]
AS
SELECT        TOP (100) PERCENT Judicial.Expediente.IdExpediente, Judicial.Expediente.Codigo, Judicial.Expediente.IdTipoProceso, Judicial.TipoProceso.Descripcion AS DescripcionTipoProceso, Judicial.Expediente.FechaInicio, 
                         Judicial.Expediente.IdDemandante, Judicial.PersonaEmpresa.Nombre AS NombreDemandante, Judicial.PersonaEmpresa.Documento AS NroDocumentoDemandante, Judicial.Expediente.IdDemandado, 
                         PersonaEmpresa_1.Nombre AS NombreDemandado, PersonaEmpresa_1.Documento AS DocumentoDemandado, Judicial.Expediente.IdClaseProceso, Judicial.ClaseProceso.Descripcion AS DescripcionClaseProceso, 
                         Judicial.ClaseProceso.Sigla AS SiglaClaseProceso, Judicial.Expediente.Descripcion, Judicial.Expediente.Observacion, Judicial.Expediente.IdAbogado, PersonaEmpresa_2.Nombre AS NombreAbogado, 
                         PersonaEmpresa_2.Documento AS DocumentoAbogado, Judicial.Expediente.IdExpedientePadre, Judicial.Expediente.IdNEWID, Judicial.Expediente.FechaMovimiento, Judicial.Expediente.NroInstancia, 
                         Judicial.Expediente.MontoSoles, Judicial.Expediente.MontoDolares, Judicial.Expediente.NDemandantes, Judicial.Expediente.NDemandados
						 ,case when Judicial.Expediente.Archivado=1 then 'SI' when Judicial.Expediente.Archivado=0 then 'NO' end as 'ArchivadoSIoNO'
						 ,Judicial.Expediente.Archivado 
FROM            Judicial.Expediente INNER JOIN
                         Judicial.TipoProceso ON Judicial.Expediente.IdTipoProceso = Judicial.TipoProceso.IdTipoProceso INNER JOIN
                         Judicial.PersonaEmpresa ON Judicial.Expediente.IdDemandante = Judicial.PersonaEmpresa.IdPersonaEmpresa INNER JOIN
                         Judicial.PersonaEmpresa AS PersonaEmpresa_1 ON Judicial.Expediente.IdDemandado = PersonaEmpresa_1.IdPersonaEmpresa INNER JOIN
                         Judicial.ClaseProceso ON Judicial.Expediente.IdClaseProceso = Judicial.ClaseProceso.IdClaseProceso LEFT OUTER JOIN
                         Judicial.PersonaEmpresa AS PersonaEmpresa_2 ON Judicial.Expediente.IdAbogado = PersonaEmpresa_2.IdPersonaEmpresa
ORDER BY Judicial.Expediente.FechaMovimiento DESC

GO


