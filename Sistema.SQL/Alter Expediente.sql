ALTER TABLE [Judicial].[Expediente]

ADD IdSupervisorInterno int null,
	IdContrato int null;

go

select * from Judicial.Expediente