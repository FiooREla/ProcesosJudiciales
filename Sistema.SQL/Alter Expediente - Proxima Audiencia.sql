ALTER TABLE [Judicial].[Expediente]

ADD FechaProximaAudiencia datetime null,
	HoraProximaAudiencia datetime null,
	LugarProximaAudiencia Varchar(5000),
	FechaVencimiento datetime null ;
go

select * from Judicial.Expediente