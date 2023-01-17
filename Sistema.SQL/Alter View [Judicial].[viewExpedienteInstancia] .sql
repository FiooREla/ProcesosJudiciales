USE [SIG-PJ]
GO


Alter VIEW [Judicial].[viewExpedienteInstancia]
AS
SELECT        Judicial.ExpedienteInstancia.IdExpedienteInstancia, Judicial.ExpedienteInstancia.IdExpediente, Judicial.ExpedienteInstancia.IdInstancia, Judicial.InstanciaJudicial.Descripcion AS DescripcionInstancia, 
                         Judicial.InstanciaJudicial.Sigla AS SiglaInstancia, Judicial.ExpedienteInstancia.FechaInicio, Judicial.ExpedienteInstancia.FechaFinal, Judicial.ExpedienteInstancia.Observacion, Judicial.ExpedienteInstancia.IdOrgano, 
                         Judicial.OrganoJudicial.Tipo AS TipoOrganoJ, Judicial.OrganoJudicial.Descripcion AS DescripcionOrganoJ, Judicial.SedeJudicial.IdSede, Judicial.SedeJudicial.Descripcion AS DescripcionSedeJudicial, 
                         Judicial.ExpedienteInstancia.Automisorio, Judicial.ExpedienteInstancia.TasacionInstancia, Judicial.ExpedienteInstancia.Apelacion, Judicial.ExpedienteInstancia.Comentarios, 
                         Judicial.PersonaEmpresa.Documento AS NroContrato
FROM            Judicial.ExpedienteInstancia INNER JOIN
                         Judicial.InstanciaJudicial ON Judicial.ExpedienteInstancia.IdInstancia = Judicial.InstanciaJudicial.IdInstancia INNER JOIN
                         Judicial.OrganoJudicial ON Judicial.ExpedienteInstancia.IdOrgano = Judicial.OrganoJudicial.IdOrgano INNER JOIN
                         Judicial.SedeJudicial ON Judicial.OrganoJudicial.IdSede = Judicial.SedeJudicial.IdSede LEFT OUTER JOIN
                         Judicial.PersonaEmpresa ON Judicial.ExpedienteInstancia.IdPersonaContrato = Judicial.PersonaEmpresa.IdPersonaEmpresa
GO
