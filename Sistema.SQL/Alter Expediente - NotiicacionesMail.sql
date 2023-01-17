ALTER TABLE [Judicial].[Expediente]

ADD TipoNotificacionMail varchar(500) NULL,
NroDiasNotificacion int null,
NroDiasNotificacionRest int null;
	
go

select * from Judicial.Expediente